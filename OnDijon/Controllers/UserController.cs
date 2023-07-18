using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnDijon.DataAccess;
using OnDijon.Domain;
using OnDijon.Models.Requests.Address;
using OnDijon.Models.Requests.Profil;
using OnDijon.Models.Requests.User;
using OnDijon.Models.Responses.Address;
using OnDijon.Models.Responses.User;

namespace OnDijon.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly OnDijonDbContext _context;
    private readonly IMapper _mapper;

    public UserController(OnDijonDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    #region users

    #region GET users/{id}

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUserByIdResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetUserByIdResponse>> GetById(int id)
    {
        var user = await _context.Set<User>()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (user is null)
            return NotFound();

        return _mapper.Map<GetUserByIdResponse>(user);
    }

    #endregion

    #region PATCH users/{id}

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PartialUpdateByIdResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PartialUpdateByIdResponse>> PartialUpdateById([FromRoute] int id, [FromBody] JsonPatchDocument<PartialUpdateByIdCommand> request)
    {
        var user = await _context.Set<User>()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (user is null)
            return NotFound();

        var updateCommand = _mapper.Map<PartialUpdateByIdCommand>(user);

        request.ApplyTo(updateCommand);

        TryValidateModel(updateCommand);
        if (!ModelState.IsValid) return BadRequest(ModelState);

        _mapper.Map(updateCommand, user);

        _context.Update(user);
        await _context.SaveChangesAsync();

        return _mapper.Map<PartialUpdateByIdResponse>(user);
    }

    #endregion

    #endregion

    #region address

    #region GET users/{id}/address

    [HttpGet("{id}/address")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ListAddressByUserResponse>))]
    public async Task<IEnumerable<ListAddressByUserResponse>> ListAddress([FromRoute] int id)
    {
        var address = await _context.Set<Address>().Where(a => a.UserId == id).ToArrayAsync();

        return _mapper.Map<IEnumerable<ListAddressByUserResponse>>(address);
    }
    #endregion

    #region GET users/{id}/address

    [HttpGet("{id}/address/{addressId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAddressByIdResponse))]
    public async Task<ActionResult<GetAddressByIdResponse>> GetAddressById([FromRoute] int id, [FromRoute] int addressId)
    {
        var address = await _context.Set<Address>()
            .FirstOrDefaultAsync(a => a.Id == addressId);

        if (address is null)
            return NotFound();

        return Ok(_mapper.Map<GetAddressByIdResponse>(address));
    }
    #endregion

    #region POST users/{id}/address 
    [HttpPost("{id}/address")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateAddressResponse))]
    public async Task<ActionResult<CreateAddressResponse>> CreateAddress([FromRoute] int id, [FromBody] CreateAddressRequest request)
    {
        var address = _mapper.Map<Address>(request);
        address.UserId = id;

        await _context.AddAsync(address);
        await _context.SaveChangesAsync();

        return Created(address.Id.ToString(), _mapper.Map<CreateAddressResponse>(address));
    }
    #endregion

    #region DELETE users/{id}/address/{id}
    [HttpDelete("{id}/address/{addressId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreateAddress([FromRoute] int id, [FromRoute] int addressId)
    {
        var address = await _context.Set<Address>().FirstOrDefaultAsync(a => a.Id == addressId);

        if (address is null)
            return NotFound();

        _context.Remove<Address>(address);
        await _context.SaveChangesAsync();

        return Ok();
    }
    #endregion

    #region PATCH users/{id}/address/{id}

    [HttpPatch("{id}/address/{addressId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PartialUpdateAddressByIdResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PartialUpdateAddressByIdResponse>> PartialUpdateAddressById([FromRoute] int addressId, [FromBody] JsonPatchDocument<PartialUpdateAddressByIdCommand> request)
    {
        //var user = await _context.Set<User>().FirstOrDefaultAsync(e => e.Id == id);

        var address = await _context.Set<Address>().FirstOrDefaultAsync(a => a.Id == addressId);

        if (address is null)
            return NotFound();

        var updateCommand = _mapper.Map<PartialUpdateAddressByIdCommand>(address);

        request.ApplyTo(updateCommand);

        TryValidateModel(updateCommand);
        if (!ModelState.IsValid) return BadRequest(ModelState);

        _mapper.Map(updateCommand, address);

        _context.Update(address);
        await _context.SaveChangesAsync();

        return _mapper.Map<PartialUpdateAddressByIdResponse>(address);
    }

    #endregion

    #endregion
}
