using RznMicro.Atlanta.Enumerable;

namespace RznMicro.Atlanta.Contract.Feature.Address.Request;

public class AddAddressCommandRequest
{
    public string ZipCode { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }
    public string AdditionalInformation { get; set; }
    public TypeOfAddressEnum? TypeOfAddress { get; set; }
}
