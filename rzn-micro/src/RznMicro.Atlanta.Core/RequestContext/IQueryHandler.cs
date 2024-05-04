using MediatR;

namespace RznMicro.Atlanta.Core.RequestContext;

public interface IQueryHandler<TQuery, TQueryResult> : IRequestHandler<TQuery, TQueryResult> where TQuery : IQuery<TQueryResult> where TQueryResult : IQueryResult, new()
{
}
