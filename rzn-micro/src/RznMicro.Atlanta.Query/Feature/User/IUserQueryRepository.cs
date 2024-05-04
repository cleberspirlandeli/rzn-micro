using RznMicro.Atlanta.Contract.Feature.User.Result;

namespace RznMicro.Atlanta.Query.Feature.User;

public interface IUserQueryRepository
{
    Task<GetUserQueryResult> GetByIdAsync(Guid id);

    Task<IEnumerable<GetUserQueryResult>> GetAllAsync();
}
