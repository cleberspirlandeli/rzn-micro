using RznMicro.Atlanta.Core.RequestContext;
using RznMicro.Atlanta.Feature.Address.Result;
using RznMicro.Atlanta.Feature.User.Result;

namespace RznMicro.Atlanta.Contract.Feature.User;

public class AddUserCommandResult : ICommandResult
{
    public UserResult User { get; set; }
    public AddressResult Address { get; set; }
}
