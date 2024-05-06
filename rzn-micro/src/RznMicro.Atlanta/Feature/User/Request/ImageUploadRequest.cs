using Microsoft.AspNetCore.Http;

namespace RznMicro.Atlanta.Feature.User.Request;

public record ImageUploadRequest
{
    public Guid IdUser { get; set; }
    public string BucketName { get; set; }
    public string ImageName { get; set; }
    public IFormFile File { get; set; }
}
