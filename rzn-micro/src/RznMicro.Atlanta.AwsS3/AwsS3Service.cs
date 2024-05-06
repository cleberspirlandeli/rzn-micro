using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using RznMicro.Atlanta.Core.AppSetting;
using RznMicro.Atlanta.Core.AWS.S3;
using RznMicro.Atlanta.Core.AWS.S3.Request;
using RznMicro.Atlanta.Core.AWS.S3.Result;

namespace RznMicro.Atlanta.AwsS3;

public class AwsS3Service : IAwsS3Service
{
    private const int MaximumSizeInKb = 5 * 1024 * 1024; // 5 MB in bytes
    private static readonly string[] AllowedFormats = { ".jpg", ".jpeg", ".png" };
    private readonly AppSettings _appSettings;
    private readonly AmazonS3Client _amazonS3Client;

    public AwsS3Service(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
        _amazonS3Client = new AmazonS3Client(_appSettings.AWS.Credentials.AccessKey, _appSettings.AWS.Credentials.SecretAccessKey, RegionEndpoint.USEast1);
    }

    public async Task<AwsS3Result> PutObjectAsync(AwsS3Request request)
    {
        if (!ValidateSizeOfImage(request.File))
            return null;

        if (!ValidateAllowedFormats(request.File))
            return null;

        var imageKey = GenerateKey(request.File);

        using (var stream = request.File.OpenReadStream())
        {
            var putObjectRequest = new PutObjectRequest
            {
                BucketName = request.BucketName,
                Key = imageKey,
                InputStream = stream,
                ContentType = request.File.ContentType
            };

            var response = await _amazonS3Client.PutObjectAsync(putObjectRequest);

            if (response.HttpStatusCode != System.Net.HttpStatusCode.OK)
                return null;
        }

        var result = new AwsS3Result
        {
            Url = GenerateUrl(request.BucketName, imageKey),
            ImageKey = imageKey,
        };

        return result;
    }

    private string GenerateUrl(string bucketName, string imageKey) =>
        $"https://s3.amazonaws.com/{bucketName}/{imageKey}";

    private string GenerateKey(IFormFile file)
    {
        var guid = Guid.NewGuid().ToString();
        string[] parts = guid.Split('-');

        string extension = Path.GetExtension(file.FileName).ToLower();
        var nameParts = file.FileName.Split(extension);

        return $"{nameParts[0]}-{parts[0]}{parts[1]}{extension}";
    }

    private bool ValidateSizeOfImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return false;

        if (file.Length > MaximumSizeInKb)
            return false;

        return true;
    }

    private bool ValidateAllowedFormats(IFormFile file)
    {
        if(!file.ContentType.StartsWith("image/"))
            return false;

        string extension = Path.GetExtension(file.FileName).ToLower();
        if(!AllowedFormats.Contains(extension))
            return false;

        return true;
    }
}