using RznMicro.Atlanta.Contract.Feature.User.Request;
using RznMicro.Atlanta.Contract.Feature.User.Result;
using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User.Command;

public class AddUserCommand : ICommand<AddUserCommandResult>
{
    public UserCommandRequest User { get; set; }
    public AddressCommandRequest Address { get; set; }
}
