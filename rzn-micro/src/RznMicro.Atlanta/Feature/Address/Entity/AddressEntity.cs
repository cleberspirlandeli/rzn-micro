using RznMicro.Atlanta.Common;
using RznMicro.Atlanta.Enumerable;
using RznMicro.Atlanta.Feature.User.Model;

namespace RznMicro.Atlanta.Feature.Address.Model;

public class AddressEntity : Entity
{
    public Guid IdUser { get; set; }

    public string ZipCode { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }
    public string AdditionalInformation { get; set; }
    public TypeOfAddressEnum? TypeOfAddress { get; set; }

    // EF Relations
    public AddressEntity() { }
    public virtual UserEntity User { get; set; }
}
