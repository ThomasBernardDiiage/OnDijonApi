using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnDijon.DataAccess;
using OnDijon.Domain;
using OnDijon.Models.Responses.MeansOfLocomotion;

namespace OnDijon.Controllers;

[ApiController]
[Route("meansOfLocomotion")]
public class MeanOfLocomotionController
{
    private readonly OnDijonDbContext _context;
    private readonly IMapper _mapper;

    public MeanOfLocomotionController(OnDijonDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ListMeanOfLocomotionResponse>))]
    public async Task<IEnumerable<ListMeanOfLocomotionResponse>> List()
    {

        var meansOfLocomotion = await _context.Set<MeanOfLocomotion>().ToArrayAsync();

        return _mapper.Map<IEnumerable<ListMeanOfLocomotionResponse>>(meansOfLocomotion);
    }

}
