using RznMicro.Atlanta.Feature.Address.Result;

namespace RznMicro.Atlanta.Feature.User.Result;

public class AddUserResult
{
    public UserResult User { get; set; }
    public AddressResult Address { get; set; }
}
