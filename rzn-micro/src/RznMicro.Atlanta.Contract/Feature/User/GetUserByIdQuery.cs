using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User;

public class GetUserByIdQuery : ICommand<AddUserCommandResult>
{
    public Guid IdUser { get; set; }
}
