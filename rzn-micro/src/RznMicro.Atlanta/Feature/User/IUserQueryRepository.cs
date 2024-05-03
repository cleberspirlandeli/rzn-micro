using RznMicro.Atlanta.Feature.User.Result;

namespace RznMicro.Atlanta.Feature.User;

public interface IUserQueryRepository
{
    Task<AddUserResult> GetByIdAsync(Guid id);

    Task<IEnumerable<AddUserResult>> GetAllAsync();
}
