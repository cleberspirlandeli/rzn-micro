using Bogus;
using RznMicro.Atlanta.Feature.User.Model;
using RznMicro.Atlanta.Feature.User.Request;
using Xunit;

namespace RznMicro.Atlanta.UnitTests.V1.Feature.User;

[CollectionDefinition(nameof(UserCollection))]
public class UserCollection : ICollectionFixture<UserFixture> { }

public class UserFixture : IDisposable
{
    public UserModel GenerateUserModelModel()
    {
        return new Faker<UserModel>("pt_BR")
            .CustomInstantiator(f => new UserModel(
                f.Name.FirstName(),
                f.Date.Past(10),
                f.Random.Bool()
                ))
            .Generate();
    }

    public AddUserRequest GenerateAddUserRequest()
    {
        return new Faker<AddUserRequest>("pt_BR")
            .CustomInstantiator(f => new AddUserRequest())
            .Generate();
    }

    public AlterUserRequest GenerateAlterUserRequest()
    {
        return new Faker<AlterUserRequest>("pt_BR")
            .CustomInstantiator(f => new AlterUserRequest())
            .Generate();
    }

    public DeleteUserRequest GenerateDeleteUserRequest()
    {
        return new Faker<DeleteUserRequest>("pt_BR")
            .CustomInstantiator(f => new DeleteUserRequest())
            .Generate();
    }

    public void Dispose() { }
}
