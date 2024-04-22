namespace RznMicro.Atlanta.Feature.User.Request;

public class AddUserRequest
{
    public string Name { get; set; }
    public DateTime Age { get; set; }

    public AddUserRequest(string name, DateTime age)
    {
        Name = name;
        Age = age;
    }
}
