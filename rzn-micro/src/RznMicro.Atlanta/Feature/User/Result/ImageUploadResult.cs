namespace RznMicro.Atlanta.Feature.User.Result;

public record ImageUploadResult
{
    public Guid IdUser { get; set; }
    public string Url { get; set; }
    public string ImageKey { get; set; }
}
