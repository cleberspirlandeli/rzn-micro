using AutoMapper;
using Microsoft.Extensions.Options;
using RznMicro.Atlanta.Contract.Feature.User.Command;
using RznMicro.Atlanta.Contract.Feature.User.Message;
using RznMicro.Atlanta.Contract.Feature.User.Result;
using RznMicro.Atlanta.Core.AppSetting;
using RznMicro.Atlanta.Core.AWS.SQS;
using RznMicro.Atlanta.Core.RequestContext;
using RznMicro.Atlanta.Feature.User;
using RznMicro.Atlanta.Feature.User.Request;
using RznMicro.Atlanta.Feature.User.Result;

namespace RznMicro.Atlanta.Command.Feature.User;

public sealed class ImageUploadCommandHandler : ICommandHandler<ImageUploadCommand, ImageUploadCommandResult>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly IAwsSQSService _awsSqsService;
    private readonly AppSettings _appSettings;

    public ImageUploadCommandHandler(
        IUserService userService,
        IMapper mapper,
        IAwsSQSService awsSqsService,
        IOptions<AppSettings> appSettings)
    {
        _userService = userService;
        _mapper = mapper;
        _awsSqsService = awsSqsService;
        _appSettings = appSettings.Value;
    }

    public async Task<ImageUploadCommandResult> Handle(ImageUploadCommand request, CancellationToken cancellationToken)
    {
        var imageUploadRequest = new ImageUploadRequest(request.IdUser, request.Image, _appSettings.AWS.S3.BucketName);
        var result = await _userService.ImageUploadAsync(imageUploadRequest);

        var message = new ImageUploadMessage(result.IdUser, result.Url, result.ImageKey);
        await _awsSqsService.PublishAsync(_appSettings.AWS.SQS.ImageUploadUser.QueueUrl, message);

        return new ImageUploadCommandResult
        {
            Url = result.Url,
            ImageKey = result.ImageKey
        };
    }
}
