using Microsoft.AspNetCore.Http;

namespace RznMicro.Atlanta.Core.AWS.S3.Request;

public record AwsS3Request
{
    public IFormFile File { get; set; }
    public string BucketName { get; set; }
    public string Key { get; set; }
}
