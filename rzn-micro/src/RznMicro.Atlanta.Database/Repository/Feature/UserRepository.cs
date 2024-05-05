using RznMicro.Atlanta.Database.Feature;
using RznMicro.Atlanta.Database.Repository.Base;
using RznMicro.Atlanta.Feature.User;
using RznMicro.Atlanta.Feature.User.Model;

namespace RznMicro.Atlanta.Database.Repository.Feature;

public class UserRepository : GenericRepository<UserEntity, DefaultDataBaseContext>, IUserRepository
{
    public UserRepository(DefaultDataBaseContext context) : base(context) { }

    /// <summary>
    /// Get all users with active equal the parameters
    /// </summary>
    /// <param name="active">bool</param>
    /// <returns>IQueryable<UserModel></returns>
    public IQueryable<UserEntity> GetByActive(bool active) => 
        _context.User.Where(x => x.Active == active);
}
