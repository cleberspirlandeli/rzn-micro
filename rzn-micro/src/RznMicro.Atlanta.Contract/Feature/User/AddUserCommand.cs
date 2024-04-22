using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User;

public class AddUserCommand : ICommand<AddUserCommandResult>
{
    public int TesteInputCommand { get; set; }
}
