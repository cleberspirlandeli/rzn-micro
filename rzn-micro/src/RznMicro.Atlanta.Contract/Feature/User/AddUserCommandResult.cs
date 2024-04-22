using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User;

public class AddUserCommandResult : ICommandResult
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Age { get; set; }
    public bool Active { get; set; }
}
