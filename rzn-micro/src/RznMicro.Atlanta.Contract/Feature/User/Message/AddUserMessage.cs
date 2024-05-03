using RznMicro.Atlanta.Core.RequestContext;
using RznMicro.Atlanta.Feature.User.Result;

namespace RznMicro.Atlanta.Contract.Feature.User.Message;

public class AddUserMessage : IMessage
{
    public AddUserResult User { get; set; }
}
