namespace RznMicro.Atlanta.Contract.Feature.User.Request;

public record GetAllByFilterQueryRequest
{
    public Guid? IdUser { get; set; }
    public Guid? IdAddress { get; set; }

    public string FullName { get; set; } = string.Empty;
}
