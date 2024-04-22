using MediatR;

namespace RznMicro.Atlanta.Core.RequestContext;

public interface ICommand<TCommandResult> : IRequest<TCommandResult> where TCommandResult : ICommandResult
{
}
