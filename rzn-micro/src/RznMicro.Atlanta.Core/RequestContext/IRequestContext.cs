namespace RznMicro.Atlanta.Core.RequestContext;

public interface IRequestContext
{
    Task<TCommandResult> ProcessAsync<TCommandResult>(ICommand<TCommandResult> commandRequest) where TCommandResult : ICommandResult, new();
    Task<TQueryResult> QueryAsync<TQueryResult>(IQuery<TQueryResult> queryRequest) where TQueryResult : IQueryResult, new();

    //Task PublishEvent<T>(T ev) where T : Event;
}
