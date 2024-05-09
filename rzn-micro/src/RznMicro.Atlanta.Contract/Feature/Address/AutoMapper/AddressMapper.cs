using AutoMapper;
using RznMicro.Atlanta.Contract.Feature.Address.Request;
using RznMicro.Atlanta.Feature.Address.Model;
using RznMicro.Atlanta.Feature.Address.Request;
using RznMicro.Atlanta.Feature.Address.Result;

namespace RznMicro.Atlanta.Contract.Feature.Address.AutoMapper;

public sealed class AddressMapper : Profile
{
    public AddressMapper()
    {
        #region Command Handler
        // ADD
        CreateMap<AddAddressCommandRequest, AddAddressDtoRequest>().ReverseMap();

        // UPDATE
        CreateMap<UpdateAddressCommandRequest, UpdateAddressDtoRequest>().ReverseMap();
        #endregion

        #region Service
        // ADD
        CreateMap<AddAddressDtoRequest, AddressEntity>().ReverseMap();

        // UPDATE
        CreateMap<UpdateAddressDtoRequest, AddressEntity>().ReverseMap();

        CreateMap<AddressEntity, AddressResult>().ReverseMap();
        #endregion

    }
}
