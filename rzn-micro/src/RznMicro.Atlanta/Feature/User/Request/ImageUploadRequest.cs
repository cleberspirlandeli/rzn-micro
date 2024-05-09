using Microsoft.AspNetCore.Http;

namespace RznMicro.Atlanta.Feature.User.Request;

public record ImageUploadRequest
{
    public Guid IdUser { get; set; }
    public IFormFile File { get; set; }
    public string BucketName { get; set; }

    public ImageUploadRequest(Guid idUser, IFormFile file, string bucketName)
    {
        IdUser = idUser;
        File = file;
        BucketName = bucketName;
    }
}
