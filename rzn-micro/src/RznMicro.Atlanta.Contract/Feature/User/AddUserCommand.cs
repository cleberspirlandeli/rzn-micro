using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User;

public class AddUserCommand : ICommand<AddUserCommandResult>
{
    public string Name { get; set; }
    public DateTime Age { get; set; }
}
