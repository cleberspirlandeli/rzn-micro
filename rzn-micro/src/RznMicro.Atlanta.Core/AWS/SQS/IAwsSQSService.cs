using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Core.AWS.SQS;

public interface IAwsSQSService
{
    Task<string> PublishAsync<TMessage>(string queueUrl, TMessage message) where TMessage : IMessage;
}
