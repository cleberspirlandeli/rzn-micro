using AutoMapper;
using RznMicro.Atlanta.Feature.User.Model;
using RznMicro.Atlanta.Feature.User.Request;
using RznMicro.Atlanta.Feature.User.Result;

namespace RznMicro.Atlanta.Contract.Feature.User.AutoMapper;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<AddUserCommand, AddUserRequest>()
            .ForMember(x => x.User, map => 
                map.MapFrom(m => m.User))
            .ForMember(x => x.Address, map =>
                map.MapFrom(m => m.Address))
            .ReverseMap();
        
        CreateMap<AddUserResult, AddUserCommandResult>().ReverseMap();

        CreateMap<AddUserRequest, UserEntity>()
            .ForMember(x => x.FullName, map =>
                map.MapFrom(m => m.User.FullName))
            .ForMember(x => x.DateBirth, map =>
                map.MapFrom(m => m.User.DateBirth));

        CreateMap<AddUserRequest, AddUserResult>().ReverseMap();
    }
}
