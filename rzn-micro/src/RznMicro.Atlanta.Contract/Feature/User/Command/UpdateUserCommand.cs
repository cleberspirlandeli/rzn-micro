using RznMicro.Atlanta.Contract.Feature.Address.Request;
using RznMicro.Atlanta.Contract.Feature.User.Request;
using RznMicro.Atlanta.Contract.Feature.User.Result;
using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User.Command;

public class UpdateUserCommand : ICommand<UpdateUserCommandResult>
{
    public UpdateUserCommandRequest User { get; set; }
    public UpdateAddressCommandRequest Address { get; set; }
}
