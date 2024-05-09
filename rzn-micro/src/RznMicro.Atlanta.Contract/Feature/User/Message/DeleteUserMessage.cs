using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User.Message;

public class DeleteUserMessage : IMessage
{
    public Guid IdUser { get; set; }
    public Guid IdAddress { get; set; }
}
