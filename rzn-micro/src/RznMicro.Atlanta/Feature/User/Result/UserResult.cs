using RznMicro.Atlanta.Enumerable;

namespace RznMicro.Atlanta.Feature.User.Result;

public class UserResult
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public DateTime DateBirth { get; set; }
    public bool? Active { get; set; }
    public GenderEnum Gender { get; set; }
}
