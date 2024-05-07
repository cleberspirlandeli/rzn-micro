using RznMicro.Atlanta.Contract.Feature.Address.Result;
using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User.Result;

public record GetUserQueryResult : IQueryResult
{
    public string Source { get; private set; } = "AWS.RDS.DynamoDB";

    public UserQueryResult User { get; set; }
    public AddressQueryResult Address { get; set; }
}
