using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User.Result;

public sealed class GetUserByFilterQueryResult : IQueryResult
{
    public IEnumerable<GetUserQueryResult> Users { get; set; }
}
