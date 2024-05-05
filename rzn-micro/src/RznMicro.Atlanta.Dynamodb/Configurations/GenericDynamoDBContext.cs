using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.Extensions.Options;
using RznMicro.Atlanta.Core.AppSetting;

namespace RznMicro.Atlanta.DynamoDB.Configurations;

public class GenericDynamoDBContext
{
    private readonly AppSettings _appSettings;
    protected readonly AmazonDynamoDBClient _amazonDynamoDBClient;
    protected readonly DynamoDBContext _dynamoDBContext;

    public GenericDynamoDBContext(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
        _amazonDynamoDBClient = new AmazonDynamoDBClient(_appSettings.AWS.Credentials.AccessKey, _appSettings.AWS.Credentials.SecretAccessKey, RegionEndpoint.USEast1);
        _dynamoDBContext = new DynamoDBContext(_amazonDynamoDBClient);
    }
}
