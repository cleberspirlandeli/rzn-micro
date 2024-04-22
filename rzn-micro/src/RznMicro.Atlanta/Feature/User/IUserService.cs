using RznMicro.Atlanta.Feature.User.Request;
using RznMicro.Atlanta.Feature.User.Result;

namespace RznMicro.Atlanta.Feature.User;

public interface IUserService
{
    Task<AddUserResult> AddAsync(AddUserRequest request);
    Task<AlterUserResult> AlterAsync(AlterUserRequest request);
    Task<DeleteUserResult> DeleteAsync(DeleteUserRequest request);
}
