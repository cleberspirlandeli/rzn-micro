using AutoMapper;
using RznMicro.Atlanta.Feature.User.Model;
using RznMicro.Atlanta.Feature.User.Request;
using RznMicro.Atlanta.Feature.User.Result;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RznMicro.Atlanta.UnitTests")]
namespace RznMicro.Atlanta.Feature.User;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<AddUserResult> AddAsync(AddUserRequest request)
    {
        var model = _mapper.Map<UserModel>(request);

        await _userRepository.AddAsync(model);

        return new AddUserResult
        {
            Id = model.Id,
            Name = model.Name,
            Age = model.Age,
            Active = model.Active
        };
    }

    public async Task<AlterUserResult> AlterAsync(AlterUserRequest request)
    {
        return new AlterUserResult
        {
            Id = Guid.NewGuid()
        };
    }

    public async Task<DeleteUserResult> DeleteAsync(DeleteUserRequest request)
    {
        return new DeleteUserResult
        {
            Id = Guid.NewGuid()
        };
    }

    internal bool ExampleMethodInternal() => true;
}
