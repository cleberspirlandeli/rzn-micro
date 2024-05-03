using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Microsoft.Extensions.Options;
using RznMicro.Atlanta.Core.AppSetting;
using RznMicro.Atlanta.Feature.User;
using RznMicro.Atlanta.Feature.User.Result;
using System.Text.Json;

namespace RznMicro.Atlanta.DynamoDB.Repository.Feature;

public class UserQueryRepository : IUserQueryRepository
{
    private readonly AppSettings _appSettings;
    private readonly AmazonDynamoDBClient _amazonDynamoDBClient;

    public UserQueryRepository(
        IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
        _amazonDynamoDBClient = new AmazonDynamoDBClient(_appSettings.AWS.Credentials.AccessKey, _appSettings.AWS.Credentials.SecretAccessKey, RegionEndpoint.USEast1);
    }

    public async Task<AddUserResult> GetByIdAsync(Guid id)
    {
        var ids = id.ToString();
        var request = new GetItemRequest
        {
            TableName = "users",
            Key = new Dictionary<string, AttributeValue>
            {
                { "id", new AttributeValue { S = id.ToString().ToUpper() } }
            }
        };

        var response = await _amazonDynamoDBClient.GetItemAsync(request);
        if (response.Item.Count == 0)
            return null;

        var itemAsDocument = Document.FromAttributeMap(response.Item);
        return JsonSerializer.Deserialize<AddUserResult>(itemAsDocument.ToJson());
    }

    public async Task<IEnumerable<AddUserResult>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
