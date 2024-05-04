using Amazon.DynamoDBv2.DataModel;
using RznMicro.Atlanta.Contract.Feature.Address.Result;
using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User.Result;

[DynamoDBTable("users")]
public record GetUserQueryResult : IQueryResult
{
    [DynamoDBHashKey("id")]
    public string Id { get; set; }

    [DynamoDBProperty("idUser")]
    public string IdUser { get; set; }

    [DynamoDBProperty("fullName")]
    public string FullName { get; set; }

    [DynamoDBProperty("dateBirth")]
    public string DateBirth { get; set; }

    [DynamoDBProperty("active")]
    public bool? Active { get; set; }

    [DynamoDBProperty("gender")]
    public int? Gender { get; set; }

    [DynamoDBProperty("idAddress")]
    public string IdAddress { get; set; }

    [DynamoDBProperty("zipCode")]
    public string ZipCode { get; set; }

    [DynamoDBProperty("street")]
    public string Street { get; set; }

    [DynamoDBProperty("number")]
    public int? Number { get; set; }

    [DynamoDBProperty("additionalInformation")]
    public string AdditionalInformation { get; set; }

    [DynamoDBProperty("typeOfAddress")]
    public int? TypeOfAddress { get; set; }
}
