using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Core;

public interface IPublisherQueue
{
    Task<string> PublishAsync<TMessage>(string queueUrl, TMessage message) where TMessage : IMessage;
}
