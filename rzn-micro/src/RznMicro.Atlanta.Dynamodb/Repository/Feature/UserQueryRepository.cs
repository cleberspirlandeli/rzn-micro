using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Microsoft.Extensions.Options;
using RznMicro.Atlanta.Contract.Feature.User.Result;
using RznMicro.Atlanta.Core.AppSetting;
using RznMicro.Atlanta.Query.Feature.User;
using System.Text.Json;

namespace RznMicro.Atlanta.DynamoDB.Repository.Feature;

public class UserQueryRepository : IUserQueryRepository
{
    private readonly AppSettings _appSettings;
    private readonly AmazonDynamoDBClient _amazonDynamoDBClient;
    private const string TableName = "users";

    public UserQueryRepository(
        IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
        _amazonDynamoDBClient = new AmazonDynamoDBClient(_appSettings.AWS.Credentials.AccessKey, _appSettings.AWS.Credentials.SecretAccessKey, RegionEndpoint.USEast1);
    }

    public async Task<GetUserQueryResult> GetByIdAsync(Guid id)
    {
        var request = new GetItemRequest
        {
            TableName = TableName,
            Key = new Dictionary<string, AttributeValue>
            {
                { "id", new AttributeValue { S = id.ToString().ToUpper() } }
            },
            
        };

        var response = await _amazonDynamoDBClient.GetItemAsync(request);
        if (response.Item.Count == 0)
            return null;

        var itemAsDocument = Document.FromAttributeMap(response.Item);
        var result = JsonSerializer.Deserialize<GetUserQueryResult>(itemAsDocument.ToJson());

        return result;
    }

    public async Task<IEnumerable<GetUserQueryResult>> GetAllAsync()
    {
        DynamoDBContext context = new DynamoDBContext(_amazonDynamoDBClient);

        var conditions = new List<ScanCondition>();
        //conditions.Add(new ScanCondition("FullName", ScanOperator.Contains, "reb"));
        //conditions.Add(new ScanCondition("Number", ScanOperator.Equal, 1500));

        var search = context.ScanAsync<GetUserQueryResult>(conditions);
        var results = await search.GetRemainingAsync();

        return results;
    }
}
