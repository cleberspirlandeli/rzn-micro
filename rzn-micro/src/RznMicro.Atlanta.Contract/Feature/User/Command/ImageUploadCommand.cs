using Microsoft.AspNetCore.Http;
using RznMicro.Atlanta.Contract.Feature.User.Result;
using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User.Command;

public class ImageUploadCommand : ICommand<ImageUploadCommandResult>
{
    public Guid IdUser { get; set; }
    public IFormFile Image { get; set; }
}
