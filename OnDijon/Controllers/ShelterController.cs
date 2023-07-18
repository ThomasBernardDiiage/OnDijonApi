using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OnDijon.DataAccess;
using OnDijon.Domain;
using OnDijon.Models.Requests.Shelter;
using OnDijon.Models.Requests.ShelterHistory;
using OnDijon.Models.Responses.Shelter;
using OnDijon.Models.Responses.ShelterHistory;
using XAct;

namespace OnDijon.Controllers;

[ApiController]
[Route("shelters")]
public class ShelterController : ControllerBase
{
    private readonly OnDijonDbContext _context;
    private readonly IMapper _mapper;
    private readonly IHubContext<ShelterBookingHub> _shelterBookingHub;

    public ShelterController(OnDijonDbContext context, IMapper mapper, IHubContext<ShelterBookingHub> shelterBookingHub)
    {
        _context = context;
        _mapper = mapper;
        _shelterBookingHub = shelterBookingHub;
    }


    #region GET shelters
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ListShelterResponse>))]
    public async Task<IEnumerable<ListShelterResponse>> List()
    {
        var shelters = await _context.Set<Shelter>().ToArrayAsync();

        var shelterOccupations = await _context.Set<ShelterHistory>()
            .GroupBy(h => h.ShelterId)
            .Select(g => new
            {
                ShelterId = g.Key,
                Occupation = g.Count(h => h.IsEntry) - g.Count(h => !h.IsEntry)
            })
            .ToArrayAsync();

        var result = _mapper.Map<IEnumerable<ListShelterResponse>>(shelters);

        foreach (var shelter in result)
        {
            var occupation = shelterOccupations.FirstOrDefault(o => o.ShelterId == shelter.Id);
            shelter.Occupation = occupation?.Occupation ?? 0;
        }

        return result;
    }
    #endregion

    #region GET shelters/{id}

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetShelterByIdResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetShelterByIdResponse>> GetById([FromRoute] int id, [FromQuery] string? includes = null)
    {
        var shelter = await _context.Set<Shelter>()
            .FirstOrDefaultAsync(s => s.Id == id);

        if (shelter is null)
            return NotFound();
        
        var result = _mapper.Map<Shelter, GetShelterByIdResponse>(shelter);
        
        var history = await _context.Set<ShelterHistory>()
            .Where(s => s.ShelterId == shelter.Id).OrderByDescending(x => x.Date).ToArrayAsync();
        
        if (!string.IsNullOrWhiteSpace(includes)) 
        { // Vérifiez et séparez plusieurs "includes" par des virgules
          foreach (var include in includes.Split(',')) // Ajoutez une condition pour chaque référentiel possible
          {
              if (include.Trim().ToLower() == "history") // Ajoutez ici d'autres conditions pour d'autres référentiels
              {
                  result.History = _mapper.Map<IEnumerable<GetShelterByIdHistoryResponse>>(history); // Must be improve this part
              }

              if (include.Trim().ToLower() == "reports")
              {
                  var reports = await _context.Set<ShelterReporting>()
                      .Where(r => r.ShelterId == shelter.Id).ToArrayAsync();
                  
                  result.Reports = _mapper.Map<IEnumerable<GetShelterByIdReportResponse>>(reports);
              }
          }
        }

        result.Occupation = history.Count(h => h.IsEntry) - history.Count(h => !h.IsEntry);

        return result;
    }

    #endregion

    #region PATCH shelters/{id}

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Consumes("application/json")]
    public async Task<ActionResult> UpdateQuantity([FromRoute] int id, UpdateQuantityRequest updateQuantityRequest )
    {
        var shelter = await _context.Set<Shelter>()
            .FirstOrDefaultAsync(s => s.Id == id);

        if (shelter is null)
            return NotFound();
      

        return Ok();
    }

    #endregion

    #region POST shelters/{id}/booking

    [HttpPost("{id}/booking")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateShelterBookResponse))]
    public async Task<ActionResult<CreateShelterBookResponse>> CreateBook([FromRoute] int id, [FromBody] CreateShelterBookRequest request)
    {
        TryValidateModel(request);
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var shelter = await _context.Set<Shelter>().FirstOrDefaultAsync(s => s.Id == id);

        if (shelter is null)
            return NotFound();
        
        var newBooking = _mapper.Map<ShelterBooking>(request);
        newBooking.ShelterId = shelter.Id;
        
        // 1) Check if shelter have enough places

        var currentBookingCount = await _context.Set<ShelterBooking>()
            .Where(b => b.ShelterId == id && 
                        b.BeginDate < request.EndDate && 
                        b.EndDate > request.BeginDate)
            .CountAsync();
        
        var available = currentBookingCount + 1 <= shelter.Capacity;
        
        if (!available)
            return BadRequest("Shelter doesn't have enough capacity for the requested booking.");

        
        await _context.Set<ShelterBooking>().AddAsync(newBooking);
        await _context.SaveChangesAsync();


        var response = _mapper.Map<CreateShelterBookResponse>(newBooking);
        

        await _shelterBookingHub.Clients.All.SendAsync(shelter.Id.ToString(), JsonConvert.SerializeObject(response));


        return Created("", response);
    }

    #endregion
    
    #region POST shelters/{id}/history
    [HttpPost("{id}/history")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateShelterHistoryResponse))]
    public async Task<ActionResult<CreateShelterHistoryResponse>> CreateHistory([FromRoute] int id, [FromBody] CreateShelterHistoryRequest request)
    {
        TryValidateModel(request);
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var shelter = await _context.Set<Shelter>().FirstOrDefaultAsync(s => s.Id == id);

        if (shelter is null)
            return NotFound("Shelter not found");

        if (request.Spot < 1 || request.Spot > shelter.Capacity)
            return NotFound("Wrong spot");
        
        // Get last history for this shelter's emplacement
        var shelterHistory = await _context.Set<ShelterHistory>()
            .OrderByDescending(s => s.Date)
            .FirstOrDefaultAsync(s => s.ShelterId == shelter.Id && s.Spot == request.Spot);


        if (request.IsEntry ?? false)
        {
            // If last history is entry return forbid
            if (shelterHistory?.IsEntry ?? false)
                return NotFound("Spot not available");
        }
        else
        {
            if (!shelterHistory?.IsEntry ?? true)
                return NotFound("Spot already free");
        }

        var history = _mapper.Map<ShelterHistory>(request);
        history.ShelterId = id;
        

        await _context.AddAsync(history);

        await _context.SaveChangesAsync();

        var mapped = _mapper.Map<CreateShelterHistoryResponse>(history);

        return Created( history.Id.ToString(), mapped) ;
    }
    #endregion

    #region POST shelters/{id}/report

    [HttpPost("{id}/report")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateShelterReportResponse))]
    public async Task<ActionResult<CreateShelterReportResponse>> CreateReport([FromRoute] int id, [FromBody] CreateShelterReportRequest request)
    {
        TryValidateModel(request);
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var shelter = await _context.Set<Shelter>().FirstOrDefaultAsync(s => s.Id == id);

        if (shelter is null)
            return NotFound();

        var reports = _mapper.Map<ShelterReporting>(request);

        reports.ShelterId = id;

        await _context.AddAsync(reports);

        await _context.SaveChangesAsync();

        var mapped = _mapper.Map<CreateShelterReportResponse>(reports);

        return Created( reports.Id.ToString(), mapped) ;
    }

    #endregion



    
}

