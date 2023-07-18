using System;
using AutoMapper;
using OnDijon.Domain;
using OnDijon.Models.Requests.Shelter;
using OnDijon.Models.Requests.ShelterHistory;
using OnDijon.Models.Responses.Shelter;
using OnDijon.Models.Responses.ShelterHistory;

namespace OnDijon.Mapping;

public class ShelterProfile : Profile
{
	public ShelterProfile()
	{
        CreateMap<Shelter, ListShelterResponse>();
        CreateMap<Shelter, GetShelterByIdResponse>();

        CreateMap<ShelterHistory, GetShelterByIdHistoryResponse>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss")));

        CreateMap<CreateShelterHistoryRequest, ShelterHistory>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTimeOffset.UtcNow));

        CreateMap<ShelterHistory, CreateShelterHistoryResponse>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss")));

        CreateMap<CreateShelterReportRequest, ShelterReporting>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTimeOffset.UtcNow));
        
        CreateMap<ShelterReporting, CreateShelterReportResponse>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToLocalTime().ToString("dd/MM/yyyy HH:mm")));
            
        CreateMap<ShelterReporting, GetShelterByIdReportResponse>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToLocalTime().ToString("dd/MM/yyyy HH:mm")));
        
        CreateMap<CreateShelterBookRequest, ShelterReporting>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTimeOffset.UtcNow));

        CreateMap<CreateShelterBookRequest, ShelterBooking>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTimeOffset.UtcNow));
        
        CreateMap<ShelterBooking, CreateShelterBookResponse>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToLocalTime().ToString("dd/MM/yyyy HH:mm")))
            .ForMember(dest => dest.BeginDate, opt => opt.MapFrom(src => src.BeginDate.ToLocalTime().ToString("dd/MM/yyyy HH:mm")))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.ToLocalTime().ToString("dd/MM/yyyy HH:mm")));
    }
}

