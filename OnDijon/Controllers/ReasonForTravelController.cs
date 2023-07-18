using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnDijon.DataAccess;
using OnDijon.Domain;
using OnDijon.Models.Responses.MeansOfLocomotion;
using OnDijon.Models.Responses.ReasonForTravel;

namespace OnDijon.Controllers;

[ApiController]
[Route("reasonsForTravel")]
public class ReasonForTravelController
{
    private readonly OnDijonDbContext _context;
    private readonly IMapper _mapper;

    public ReasonForTravelController(OnDijonDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ListReasonForTravelResponse>))]
    public async Task<IEnumerable<ListReasonForTravelResponse>> List()
    {

        var reasonsForTravel = await _context.Set<ReasonForTravel>().ToArrayAsync();

        return _mapper.Map<IEnumerable<ListReasonForTravelResponse>>(reasonsForTravel);
    }
}
