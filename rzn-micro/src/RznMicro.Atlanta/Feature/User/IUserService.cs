using RznMicro.Atlanta.Feature.User.Request;
using RznMicro.Atlanta.Feature.User.Result;

namespace RznMicro.Atlanta.Feature.User;

public interface IUserService
{
    Task<AddUserResult> AddAsync(AddUserRequest request);
    Task<UpdateUserResult> UpdateAsync(UpdateUserRequest request);
    Task<DeleteUserResult> DeleteAsync(DeleteUserRequest request);

    Task<ImageUploadResult> ImageUploadAsync(ImageUploadRequest request);
}
