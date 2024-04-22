using RznMicro.Atlanta.Feature.User.Model;

namespace RznMicro.Atlanta.Feature.User;

public class UserRepository : IUserRepository
{
    public async Task<bool> AddAsync(UserModel model) => true;
}
