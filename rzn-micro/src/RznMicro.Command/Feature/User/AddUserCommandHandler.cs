using AutoMapper;
using Microsoft.Extensions.Options;
using RznMicro.Atlanta.Contract.Feature.User;
using RznMicro.Atlanta.Contract.Feature.User.Message;
using RznMicro.Atlanta.Contract.Feature.User.Validation;
using RznMicro.Atlanta.Core;
using RznMicro.Atlanta.Core.AppSetting;
using RznMicro.Atlanta.Core.RequestContext;
using RznMicro.Atlanta.Feature.User;
using RznMicro.Atlanta.Feature.User.Request;
using RznMicro.Atlanta.Feature.User.Result;

namespace RznMicro.Atlanta.Command.Feature.User;

public sealed class AddUserCommandHandler : ICommandHandler<AddUserCommand, AddUserCommandResult>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly IPublisherQueue _publisherQueue;
    private readonly AppSettings _appSettings;


    public AddUserCommandHandler(
        IUserService userService,
        IMapper mapper,
        IPublisherQueue publisherQueue,
        IOptions<AppSettings> appSettings
        )
    {
        _userService = userService;
        _mapper = mapper;
        _publisherQueue = publisherQueue;
        _appSettings = appSettings.Value;
    }

    public async Task<AddUserCommandResult> Handle(AddUserCommand command, CancellationToken cancellationToken)
    {
        var validation = new UserCommandValidator().Validate(command);
        if (!validation.IsValid) return null;

        var request = _mapper.Map<AddUserCommand, AddUserRequest>(command);
        var result = await _userService.AddAsync(request);

        var message = _mapper.Map<AddUserResult, AddUserMessage>(result);
        await _publisherQueue.PublishAsync(_appSettings.AWS.SQS.User.QueueUrl, message);

        return _mapper.Map<AddUserCommandResult>(result);
    }
}
