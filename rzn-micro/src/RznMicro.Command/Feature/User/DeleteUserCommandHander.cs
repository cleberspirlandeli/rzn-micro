using AutoMapper;
using Microsoft.Extensions.Options;
using RznMicro.Atlanta.Contract.Feature.User.Command;
using RznMicro.Atlanta.Contract.Feature.User.Message;
using RznMicro.Atlanta.Contract.Feature.User.Result;
using RznMicro.Atlanta.Contract.Feature.User.Validation;
using RznMicro.Atlanta.Core.AppSetting;
using RznMicro.Atlanta.Core.AWS.SQS;
using RznMicro.Atlanta.Core.RequestContext;
using RznMicro.Atlanta.Feature.User;
using RznMicro.Atlanta.Feature.User.Request;
using RznMicro.Atlanta.Feature.User.Result;

namespace RznMicro.Atlanta.Command.Feature.User;

public sealed class DeleteUserCommandHander : ICommandHandler<DeleteUserCommand, DeleteUserCommandResult>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly IAwsSQSService _awsSqsService;
    private readonly AppSettings _appSettings;

    public DeleteUserCommandHander(
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

    public async Task<DeleteUserCommandResult> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var validation = new DeleteUserCommandValidator().Validate(command);
        if (!validation.IsValid) return null;

        var request = _mapper.Map<DeleteUserCommand, DeleteUserRequest>(command);
        var result = await _userService.DeleteAsync(request);

        var message = _mapper.Map<DeleteUserResult, DeleteUserMessage>(result);
        await _awsSqsService.PublishAsync(_appSettings.AWS.SQS.DeleteUser.QueueUrl, message);

        return _mapper.Map<DeleteUserCommandResult>(result);
    }
}
