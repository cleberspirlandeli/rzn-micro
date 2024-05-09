using RznMicro.Atlanta.Enumerable;

namespace RznMicro.Atlanta.Feature.Address.Request;

public class UpdateAddressDtoRequest
{
    public Guid Id { get; set; }
    public string ZipCode { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }
    public string AdditionalInformation { get; set; }
    public TypeOfAddressEnum? TypeOfAddress { get; set; }
}
