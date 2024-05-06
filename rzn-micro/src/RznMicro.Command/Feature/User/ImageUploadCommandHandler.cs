using AutoMapper;
using Microsoft.Extensions.Options;
using RznMicro.Atlanta.Contract.Feature.User.Command;
using RznMicro.Atlanta.Contract.Feature.User.Result;
using RznMicro.Atlanta.Core.AppSetting;
using RznMicro.Atlanta.Core.AWS.S3;
using RznMicro.Atlanta.Core.RequestContext;
using RznMicro.Atlanta.Feature.User;
using RznMicro.Atlanta.Feature.User.Request;

namespace RznMicro.Atlanta.Command.Feature.User;

public sealed class ImageUploadCommandHandler : ICommandHandler<ImageUploadCommand, ImageUploadCommandResult>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly AppSettings _appSettings;

    public ImageUploadCommandHandler(
        IUserService userService,
        IMapper mapper,
        IOptions<AppSettings> appSettings
        )
    {
        _userService = userService;
        _mapper = mapper;
        _appSettings = appSettings.Value;
    }

    public async Task<ImageUploadCommandResult> Handle(ImageUploadCommand request, CancellationToken cancellationToken)
    {
        var result = await _userService.ImageUploadAsync(new ImageUploadRequest
        {
            BucketName = "rznapps.micro.users.dev",
            IdUser = Guid.NewGuid(),
            ImageName = "teste-upload.jpg",
            File = request.Image
        });

        return new ImageUploadCommandResult
        {
            Url = result.Url,
            ImageKey = result.ImageKey
        };
    }
}
