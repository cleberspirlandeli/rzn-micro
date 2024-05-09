using RznMicro.Atlanta.Enumerable;

namespace RznMicro.Atlanta.Feature.User.Request;

public class AddUserDtoRequest
{
    public string FullName { get; set; }
    public DateTime DateBirth { get; set; }
    public bool? Active { get; set; }
    public GenderEnum Gender { get; set; }
}
