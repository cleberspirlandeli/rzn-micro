using AutoMapper;
using RznMicro.Atlanta.Feature.Address.Request;
using RznMicro.Atlanta.Feature.User.Model;
using RznMicro.Atlanta.Feature.User.Request;
using RznMicro.Atlanta.Feature.User.Result;

namespace RznMicro.Atlanta.Contract.Feature.User.AutoMapper;

public class UserMapper : Profile
{
    public UserMapper()
    {
        // Command Handler
        CreateMap<AddUserCommand, AddUserRequest>().ReverseMap();
        CreateMap<AddUserResult, AddUserCommandResult>().ReverseMap();

        // Service
        CreateMap<UserCommandRequest, UserRequest>().ReverseMap();
        CreateMap<UserRequest, UserEntity>().ReverseMap();
        CreateMap<UserEntity, UserResult>().ReverseMap();
    }
}
