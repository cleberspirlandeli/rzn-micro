using MediatR;

namespace RznMicro.Atlanta.Core.RequestContext
{
    public interface IQuery<TQueryResult> : IRequest<TQueryResult> where TQueryResult : IQueryResult
    {
    }
}
