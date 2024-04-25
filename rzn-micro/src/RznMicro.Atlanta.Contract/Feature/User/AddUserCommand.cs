using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User;

public class AddUserCommand : ICommand<AddUserCommandResult>
{
    public UserCommandRequest User { get; set; }
    public AddressCommandRequest Address { get; set; }
}
