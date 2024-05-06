using Microsoft.AspNetCore.Http;

namespace RznMicro.Atlanta.Core.AWS.S3.Request;

public record AwsS3Request
{
    public string BucketName { get; set; }
    public string ImageName { get; set; }
    public IFormFile File { get; set; }
}
