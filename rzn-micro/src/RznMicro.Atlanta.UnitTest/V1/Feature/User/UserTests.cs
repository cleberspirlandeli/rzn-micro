namespace RznMicro.Atlanta.UnitTests.V1.Feature.User;

[CollectionDefinition(nameof(UserCollection))]

public class UserTests : IClassFixture<UserFixture>
{
    private readonly UserFixture _userFixture;

    public UserTests(UserFixture userFixture)
    {
        _userFixture = userFixture;
    }

    [Trait("Exemplo", "Payload Exemplo")]
    [Fact(DisplayName = "Testar sem erros")]
    public void TesteUser_Valid()
    {
        // Arrange & Action
        var user = _userFixture.GenerateUserModelModel();
        var id = Guid.NewGuid();

        // Assert
        user.SetId(id);

        //Assert.False(result.Any());
        Assert.NotNull(user);
        Assert.NotNull(user.Id);
        Assert.NotNull(user.Name);
        Assert.NotNull(user.Age);
        Assert.NotNull(user.Active);
        Assert.Equal(id, user.Id);
    }
}
