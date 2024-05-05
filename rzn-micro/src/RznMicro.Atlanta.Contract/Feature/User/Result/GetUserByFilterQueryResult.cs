using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User.Result;

public class GetUserByFilterQueryResult : IQueryResult
{
    public IEnumerable<GetUserQueryResult> Users { get; set; }

    public GetUserByFilterQueryResult(IEnumerable<GetUserQueryResult> users)
    {
        Users = users;
    }

    public GetUserByFilterQueryResult() { }
}
