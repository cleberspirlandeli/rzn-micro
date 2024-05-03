using Amazon;
using Amazon.DynamoDBv2;
using Microsoft.Extensions.Options;
using RznMicro.Atlanta.Core.AppSetting;

namespace RznMicro.Atlanta.DynamoDB.Configurations;

public class DynamoDBContext
{
    private readonly AppSettings _appSettings;
    private readonly AmazonDynamoDBClient _amazonDynamoDBClient;

    public DynamoDBContext(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
        _amazonDynamoDBClient = new AmazonDynamoDBClient(_appSettings.AWS.Credentials.AccessKey, _appSettings.AWS.Credentials.SecretAccessKey, RegionEndpoint.USEast1);
    }
}
