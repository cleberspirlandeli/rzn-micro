using Amazon.DynamoDBv2.DataModel;

namespace RznMicro.Atlanta.Contract.Feature.Address.Result;

public record AddressQueryResult
{
    [DynamoDBProperty("id")]
    public string Id { get; set; }

    [DynamoDBProperty("idUser")]
    public string  IdUser { get; set; }

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
