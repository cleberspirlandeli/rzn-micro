using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Options;
using RznMicro.Atlanta.Core.AppSetting;
using RznMicro.Atlanta.Core.AWS.SQS;
using RznMicro.Atlanta.Core.RequestContext;
using System.Text.Json;

namespace RznMicro.Atlanta.AwsSQS;

public class AwsSQSService : IAwsSQSService
{
    private readonly BasicAWSCredentials _credentials;
    private readonly AmazonSQSClient _client;
    private readonly AppSettings _appSettings;

    public AwsSQSService(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
        _credentials = new BasicAWSCredentials(_appSettings.AWS.Credentials.AccessKey, _appSettings.AWS.Credentials.SecretAccessKey);
        _client = new AmazonSQSClient(_credentials, RegionEndpoint.USEast1);
    }

    public async Task<string> PublishAsync<TMessage>(string queueUrl, TMessage messageBody) where TMessage : IMessage
    {
        var request = new SendMessageRequest
        {
            QueueUrl = queueUrl,
            MessageBody = JsonSerializer.Serialize(messageBody),
        };

        var result = await _client.SendMessageAsync(request);

        return result.MessageId;
    }
}
