using RznMicro.Atlanta.Enumerable;

namespace RznMicro.Atlanta.Contract.Feature.User;

public class AddressCommandRequest
{
    public string ZipCode { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }
    public string AdditionalInformation { get; set; }
    public TypeOfAddressEnum? TypeOfAddress { get; set; }
}
