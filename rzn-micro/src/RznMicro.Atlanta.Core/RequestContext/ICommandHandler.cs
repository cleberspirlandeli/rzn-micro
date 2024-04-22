using MediatR;
namespace RznMicro.Atlanta.Core.RequestContext;

public interface ICommandHandler<TCommand, TCommandResult> : IRequestHandler<TCommand, TCommandResult> where TCommand : ICommand<TCommandResult> where TCommandResult : ICommandResult, new()
{
}