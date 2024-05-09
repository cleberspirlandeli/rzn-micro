using RznMicro.Atlanta.Core.RequestContext;
using RznMicro.Atlanta.Feature.User.Result;

namespace RznMicro.Atlanta.Contract.Feature.User.Message;

public class UpdateUserMessage : IMessage
{
    public UpdateUserResult User { get; set; }
}
