using AutoMapper;
using RznMicro.Atlanta.Feature.User;
using RznMicro.Atlanta.Feature.User.Model;
using RznMicro.Atlanta.Feature.User.Request;

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
        var model = _userFixture.GenerateUserModelModel();
        var request = _userFixture.GenerateAddUserRequest();

        _mocker.GetMock<IMapper>()
            .Setup(x => x.Map<UserEntity>(It.IsAny<AddUserRequest>()))
            .Returns(model);

        // Action
        var result = await _userService.AddAsync(request);

        // Assert
        Assert.NotNull(result);

        _mocker.GetMock<IMapper>()
            .Verify(x => x.Map<UserEntity>(It.IsAny<AddUserRequest>()), Times.Once);

        _mocker.GetMock<IUserRepository>()
            .Verify(x => x.AddAsync(It.IsAny<UserEntity>()), Times.Once);
    }    
    
    [Fact(DisplayName = "Service - Example Method Internal Valid")]
    public void Service_ExampleMethodInternal_Valid()
    {
        // Arrange & Action
        var result = _userService.ExampleMethodInternal();

        // Assert
        Assert.True(result);
    }
}
