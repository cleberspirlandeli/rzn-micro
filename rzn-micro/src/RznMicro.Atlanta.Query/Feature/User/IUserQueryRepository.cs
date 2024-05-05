using RznMicro.Atlanta.Contract.Feature.User.Request;
using RznMicro.Atlanta.Contract.Feature.User.Schema;

namespace RznMicro.Atlanta.Query.Feature.User;

public interface IUserQueryRepository
{
    Task<UserSchema> GetByIdAsync(Guid id);

    Task<List<UserSchema>> GetAllByFilterAsync(GetAllByFilterQueryRequest request);
}
