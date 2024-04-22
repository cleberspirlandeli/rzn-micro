using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User;

public class AddUserCommandResult : ICommandResult
{
    public Guid Id { get; set; }
}
