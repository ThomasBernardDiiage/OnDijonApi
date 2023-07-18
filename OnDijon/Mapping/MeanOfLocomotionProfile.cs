using AutoMapper;
using OnDijon.Domain;
using OnDijon.Models.Responses.MeansOfLocomotion;

namespace OnDijon.Mapping;

public class MeanOfLocomotionProfile : Profile
{
    public MeanOfLocomotionProfile()
    {
        CreateMap<MeanOfLocomotion, ListMeanOfLocomotionResponse>();
    }
}
