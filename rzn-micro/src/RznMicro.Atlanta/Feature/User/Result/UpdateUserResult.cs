using RznMicro.Atlanta.Feature.Address.Result;

namespace RznMicro.Atlanta.Feature.User.Result;

public class UpdateUserResult
{
    public UserResult User { get; set; }
    public AddressResult Address { get; set; }
}
