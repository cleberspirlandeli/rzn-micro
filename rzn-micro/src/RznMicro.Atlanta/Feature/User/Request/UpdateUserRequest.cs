using RznMicro.Atlanta.Feature.Address.Request;

namespace RznMicro.Atlanta.Feature.User.Request;

public class UpdateUserRequest
{
    public UpdateUserDtoRequest User { get; set; }
    public UpdateAddressDtoRequest Address { get; set; }
}
