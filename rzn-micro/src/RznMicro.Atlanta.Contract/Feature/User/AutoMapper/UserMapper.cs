using AutoMapper;
using RznMicro.Atlanta.Feature.User.Model;
using RznMicro.Atlanta.Feature.User.Request;
using RznMicro.Atlanta.Feature.User.Result;

namespace RznMicro.Atlanta.Contract.Feature.User.AutoMapper;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<AddUserCommand, AddUserRequest>();
        CreateMap<AddUserResult, AddUserCommandResult>();

        CreateMap<AddUserRequest, UserModel>()
            .ForMember(x => x.Name, map =>
        map.MapFrom(m => m.Name))
            .ForMember(x => x.Age, map =>
        map.MapFrom(m => m.Age));

        CreateMap<AddUserRequest, AddUserResult>().ReverseMap();
    }
}
