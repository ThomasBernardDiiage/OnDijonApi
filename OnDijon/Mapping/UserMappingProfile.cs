using OnDijon.Domain;
using OnDijon.Models.Requests.Profil;
using OnDijon.Models.Requests.Address;
using OnDijon.Models.Requests.User;
using OnDijon.Models.Responses.Address;
using OnDijon.Models.Responses.User;

namespace OnDijon.Mapping;

public class UserMappingProfile : AutoMapper.Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, GetUserByIdResponse>();

        CreateMap<User, PartialUpdateByIdCommand>()
            .ReverseMap();
        CreateMap<User, PartialUpdateByIdResponse>();

        CreateMap<Address, ListAddressByUserResponse>();
        CreateMap<CreateAddressRequest, Address>();
        CreateMap<Address, CreateAddressResponse>();

        CreateMap<Address, PartialUpdateAddressByIdCommand>();
        CreateMap<PartialUpdateAddressByIdCommand, Address>();
        CreateMap<Address, PartialUpdateAddressByIdResponse>();
        CreateMap<Address, GetAddressByIdResponse>();
    }
}
