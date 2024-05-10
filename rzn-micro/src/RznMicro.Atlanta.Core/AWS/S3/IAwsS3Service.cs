using RznMicro.Atlanta.Core.AWS.S3.Request;
using RznMicro.Atlanta.Core.AWS.S3.Result;

namespace RznMicro.Atlanta.Core.AWS.S3;

public interface IAwsS3Service
{
    Task<AwsS3Result> PutObjectAsync(AwsS3Request request);
    Task DeleteObjectAsync(AwsS3Request request);
}
