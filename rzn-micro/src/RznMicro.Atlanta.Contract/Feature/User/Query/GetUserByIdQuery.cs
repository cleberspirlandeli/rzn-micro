using RznMicro.Atlanta.Contract.Feature.User.Result;
using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User.Query;

public record GetUserByIdQuery : IQuery<GetUserQueryResult>
{
    public Guid IdUser { get; set; }
}
