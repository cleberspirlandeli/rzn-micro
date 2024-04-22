namespace RznMicro.Atlanta.Core.RequestContext;

public interface IRequestContext
{
    Task<TCommandResult> ProcessAsync<TCommandResult>(ICommand<TCommandResult> commandRequest) where TCommandResult : ICommandResult, new();

    //Task PublishEvent<T>(T ev) where T : Event;
    //Task<ValidationResult> SendComand<T>(T comando) where T : Command;
}
