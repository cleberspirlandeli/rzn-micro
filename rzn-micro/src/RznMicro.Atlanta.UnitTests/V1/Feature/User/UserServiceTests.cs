using Moq.AutoMock;
using RznMicro.Atlanta.Feature.User;
using Xunit;

namespace RznMicro.Atlanta.UnitTests.V1.Feature.User;

[CollectionDefinition(nameof(UserCollection))]

public class UserServiceTests : IClassFixture<UserFixture>
{
    private readonly AutoMocker _mocker;
    private readonly UserFixture _userFixture;
    private readonly UserService _userService;

    public UserServiceTests(UserFixture userFixture)
    {
        _mocker = new AutoMocker();
        _userFixture = userFixture;
        _userService = _mocker.CreateInstance<UserService>();
    }


    [Fact(DisplayName = "Service - Add User Valid")]
    public async void Service_AddUserValid_Valid()
    {
        // Arrange
        var request = _userFixture.GenerateAddUserRequest();

        //_mocker.GetMock<IUserCommandStore>()
        //  .Setup(x => x.AddAsync(It.IsAny<MensagemSpbModel>()))
        //  .ReturnsAsync(result);

        // Action
        var result = await _userService.AddAsync(request);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Id);

        //_mocker.GetMock<IUserCommandStore>()
        //    .Verify(x => x.AddAsync(It.IsAny<UserModel>()), Times.Once);
    }
}
