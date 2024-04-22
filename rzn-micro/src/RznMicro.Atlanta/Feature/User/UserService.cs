using RznMicro.Atlanta.Feature.User.Request;
using RznMicro.Atlanta.Feature.User.Result;

namespace RznMicro.Atlanta.Feature.User;

public class UserService : IUserService
{
    public async Task<AddUserResult> AddAsync(AddUserRequest request)
    {
        return new AddUserResult
        {
            Id = Guid.NewGuid()
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
}
