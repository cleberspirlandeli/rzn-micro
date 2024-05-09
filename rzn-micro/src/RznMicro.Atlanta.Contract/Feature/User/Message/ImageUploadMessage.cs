using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User.Message;

public class ImageUploadMessage : IMessage
{
    public Guid IdUser { get; set; }
    public string Url { get; set; }
    public string ImageKey { get; set; }

    public ImageUploadMessage(Guid idUser, string url, string imageKey)
    {
        IdUser = idUser;
        Url = url;
        ImageKey = imageKey;
    }
}
