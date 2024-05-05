using AutoMapper;
using RznMicro.Atlanta.Contract.Feature.User.Command;
using RznMicro.Atlanta.Contract.Feature.User.Message;
using RznMicro.Atlanta.Contract.Feature.User.Request;
using RznMicro.Atlanta.Contract.Feature.User.Result;
using RznMicro.Atlanta.Contract.Feature.User.Schema;
using RznMicro.Atlanta.Feature.Address.Result;
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
        CreateMap<AddUserResult, AddUserMessage>()
            .ForPath(
            dest => dest.User.User,
            src => src.MapFrom(s => new UserResult
            {
                Id = s.User.Id,
                FullName = s.User.FullName,
                DateBirth = s.User.DateBirth,
                Active = s.User.Active,
                Gender = s.User.Gender,
            }))
            .ForPath(
            dest => dest.User.Address,
            src => src.MapFrom(s => new AddressResult
            {
                Id = s.Address.Id,
                IdUser = s.Address.IdUser,
                Street = s.Address.Street,
                Number = s.Address.Number,
                ZipCode = s.Address.ZipCode,
                AdditionalInformation = s.Address.AdditionalInformation,
                TypeOfAddress = s.Address.TypeOfAddress,
            }));

        // Service
        CreateMap<UserCommandRequest, UserRequest>().ReverseMap();
        CreateMap<UserRequest, UserEntity>().ReverseMap();
        CreateMap<UserEntity, UserResult>().ReverseMap();
        CreateMap<UserEntity, UserResult>().ReverseMap();

        // TODO: Create AutoMapper for DynamoDB
        //CreateMap<List<UserSchema>, GetUserByFilterQueryResult>();
    }
}
