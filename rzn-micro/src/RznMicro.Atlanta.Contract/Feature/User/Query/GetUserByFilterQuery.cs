using RznMicro.Atlanta.Contract.Feature.User.Result;
using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User.Query;

public record GetUserByFilterQuery : IQuery<GetUserByFilterQueryResult>
{
    public Guid? IdUser { get; set; }
    public Guid? IdAddress { get; set; }

    public string FullName { get; set; } = string.Empty;
}
