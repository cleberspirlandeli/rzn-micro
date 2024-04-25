using RznMicro.Atlanta.Common;
using RznMicro.Atlanta.Feature.User.Model;

namespace RznMicro.Atlanta.Feature.User;

public interface IUserRepository : IGenericRepository<UserEntity>
{
    /// <summary>
    /// Get all users with active equal the parameters
    /// </summary>
    /// <param name="active">bool</param>
    /// <returns>IQueryable<UserModel></returns>
    IQueryable<UserEntity> GetByActive(bool active);
}
