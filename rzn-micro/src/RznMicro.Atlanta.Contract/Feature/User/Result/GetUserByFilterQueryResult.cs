using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User.Result;

public class GetUserByFilterQueryResult : IQueryResult
{
    public int Total { get; private set; }
    public IEnumerable<GetUserQueryResult> Users { get; set; }

    public GetUserByFilterQueryResult(IEnumerable<GetUserQueryResult> users)
    {
        Users = users;
        Total = users.Count();
    }

    public GetUserByFilterQueryResult() { }
}
