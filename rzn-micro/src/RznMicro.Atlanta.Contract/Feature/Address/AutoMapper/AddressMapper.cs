using AutoMapper;
using RznMicro.Atlanta.Contract.Feature.User.Request;
using RznMicro.Atlanta.Feature.Address.Model;
using RznMicro.Atlanta.Feature.Address.Request;
using RznMicro.Atlanta.Feature.Address.Result;

namespace RznMicro.Atlanta.Contract.Feature.Address.AutoMapper;

public sealed class AddressMapper : Profile
{
    public AddressMapper()
    {
        // Command Handler
        CreateMap<AddressCommandRequest, AddressRequest>().ReverseMap();

        // Service
        CreateMap<AddressRequest, AddressEntity>().ReverseMap();
        CreateMap<AddressEntity, AddressResult>().ReverseMap();
    }
}
