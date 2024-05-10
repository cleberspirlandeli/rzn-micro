using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Microsoft.Extensions.Options;
using RznMicro.Atlanta.Contract.Feature.User.Request;
using RznMicro.Atlanta.Contract.Feature.User.Schema;
using RznMicro.Atlanta.Core.AppSetting;
using RznMicro.Atlanta.DynamoDB.Configurations;
using RznMicro.Atlanta.Query.Feature.User;

namespace RznMicro.Atlanta.DynamoDB.Repository.Feature;

public class UserQueryRepository : GenericDynamoDBContext, IUserQueryRepository
{
    private const string TableName = "users";

    public UserQueryRepository(IOptions<AppSettings> appSettings) :base(appSettings) { } 

    public async Task<UserSchema> GetByIdAsync(Guid id)
    {
        var result = await _dynamoDBContext.LoadAsync<UserSchema>(id.ToString());
        return result;
    }

    public async Task<List<UserSchema>> GetAllByFilterAsync(GetAllByFilterQueryRequest request)
    {
        var conditions = GenerateFilter(request);
        var search = _dynamoDBContext.ScanAsync<UserSchema>(conditions);
        var results = await search.GetRemainingAsync();

        return results;
    }

    private List<ScanCondition> GenerateFilter(GetAllByFilterQueryRequest request)
    {
        var conditions = new List<ScanCondition>();

        if (request.IdUser is not null)
            conditions.Add(new ScanCondition(nameof(UserSchema.IdUser), ScanOperator.Equal, request.IdUser?.ToString()));

        if (request.IdAddress is not null)
            conditions.Add(new ScanCondition(nameof(UserSchema.IdAddress), ScanOperator.Equal, request.IdAddress?.ToString()));

        if (!string.IsNullOrEmpty(request.FullName))
            conditions.Add(new ScanCondition(nameof(UserSchema.FullNameSearch), ScanOperator.Contains, request.FullName.ToUpper()));

        return conditions;
    }
}
