using RznMicro.Atlanta.Enumerable;

namespace RznMicro.Atlanta.Contract.Feature.User;

public class UserCommandRequest
{
    public string FullName { get; set; }
    public DateTime DateBirth { get; set; }
    public bool? Active { get; set; }
    public GenderEnum Gender { get; set; }
}