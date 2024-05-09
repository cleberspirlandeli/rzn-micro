using RznMicro.Atlanta.Feature.Address.Request;

namespace RznMicro.Atlanta.Feature.User.Request;

public class AddUserRequest
{
    public AddUserDtoRequest User { get; set; }
    public AddAddressDtoRequest Address { get; set; }
}
