using RznMicro.Atlanta.Enumerable;

namespace RznMicro.Atlanta.Contract.Feature.Address.Result;

public record AddressQueryResult
{
    public string Id { get; set; }
    public string  IdUser { get; set; }
    public string ZipCode { get; set; }
    public string Street { get; set; }
    public int? Number { get; set; }
    public string AdditionalInformation { get; set; }
    public TypeOfAddressEnum? TypeOfAddress { get; set; }
}
