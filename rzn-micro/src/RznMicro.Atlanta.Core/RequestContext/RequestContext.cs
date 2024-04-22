using MediatR;

namespace RznMicro.Atlanta.Core.RequestContext;

public class RequestContext : IRequestContext
{
    private readonly IMediator _mediator;

    public RequestContext(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<TCommandResult> ProcessAsync<TCommandResult>(ICommand<TCommandResult> commandRequest) where TCommandResult : ICommandResult, new()
    {
        return await _mediator.Send(commandRequest);
    }

    //public async Task PublishEvent<T>(T ev) where T : Event
    //{
    //    await _mediator.Publish(ev);
    //}

    //public async Task<bool> SendComand<T>(T comand) where T : Command
    //{
    //    return await _mediator.Send(comand);
    //}
}
