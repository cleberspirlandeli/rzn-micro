using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User.Result;

public class ImageUploadCommandResult : ICommandResult
{
    public string Url { get; set; }
    public string ImageKey { get; set; }
}
