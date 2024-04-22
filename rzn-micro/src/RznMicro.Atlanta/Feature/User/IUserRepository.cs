using RznMicro.Atlanta.Feature.User.Model;

namespace RznMicro.Atlanta.Feature.User;

public interface IUserRepository
{
    Task<bool> AddAsync(UserModel model);
}
