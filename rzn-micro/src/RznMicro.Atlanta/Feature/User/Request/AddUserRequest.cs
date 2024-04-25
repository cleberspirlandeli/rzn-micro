using RznMicro.Atlanta.Feature.Address.Request;

namespace RznMicro.Atlanta.Feature.User.Request;

public class AddUserRequest
{
    public UserRequest User { get; set; }
    public AddressRequest Address { get; set; }
}
