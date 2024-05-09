using RznMicro.Atlanta.Feature.User.Model;
using RznMicro.Atlanta.Feature.User.Request;

namespace RznMicro.Atlanta.UnitTests.V1.Feature.User;

[CollectionDefinition(nameof(UserCollection))]
public class UserCollection : ICollectionFixture<UserFixture> { }

public class UserFixture : IDisposable
{
    public UserEntity GenerateUserModelModel()
    {
        return new Faker<UserEntity>("pt_BR")
            .CustomInstantiator(f => new UserEntity(
                f.Name.FirstName(),
                f.Date.Past(10),
                f.Random.Bool()
                ))
            .Generate();
    }

    public AddUserRequest GenerateAddUserRequest()
    {
        return new Faker<AddUserRequest>("pt_BR")
            .CustomInstantiator(f => new AddUserRequest
            {
                User = new AddUserDtoRequest
                {
                    FullName = f.Name.FirstName(),
                    DateBirth = f.Date.Past(10)
                }
            })
            .Generate();
    }

    public UpdateUserRequest GenerateUpdateUserRequest()
    {
        return new Faker<UpdateUserRequest>("pt_BR")
            .CustomInstantiator(f => new UpdateUserRequest())
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
