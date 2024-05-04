using Amazon.DynamoDBv2.DataModel;

namespace RznMicro.Atlanta.Contract.Feature.User.Result;

public record UserQueryResult
{
    [DynamoDBProperty("id")]
    public string Id { get; set; }

    [DynamoDBProperty("fullName")]
    public string FullName { get; set; }

    [DynamoDBProperty("dateBirth")]
    public string DateBirth { get; set; }

    [DynamoDBProperty("active")]
    public bool? Active { get; set; }

    [DynamoDBProperty("gender")]
    public int? Gender { get; set; }
}
