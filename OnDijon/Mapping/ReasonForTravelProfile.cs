using AutoMapper;
using OnDijon.Domain;
using OnDijon.Models.Responses.ReasonForTravel;

namespace OnDijon.Mapping;

public class ReasonForTravelProfile : Profile
{
    public ReasonForTravelProfile()
    {
        CreateMap<ReasonForTravel, ListReasonForTravelResponse>();
    }
}
