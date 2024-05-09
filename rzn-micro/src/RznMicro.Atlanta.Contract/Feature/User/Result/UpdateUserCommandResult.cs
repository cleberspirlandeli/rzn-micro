using RznMicro.Atlanta.Core.RequestContext;
using RznMicro.Atlanta.Feature.Address.Result;
using RznMicro.Atlanta.Feature.User.Result;

namespace RznMicro.Atlanta.Contract.Feature.User.Result;

public class UpdateUserCommandResult : ICommandResult
{
    public string Source { get; private set; } = "AWS.RDS.MySQL";

    public UserResult User { get; set; }
    public AddressResult Address { get; set; }
}