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

public sealed class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, UpdateUserCommandResult>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly IAwsSQSService _awsSqsService;
    private readonly AppSettings _appSettings;

    public UpdateUserCommandHandler(
        IUserService userService,
        IMapper mapper,
        IAwsSQSService awsSqsService,
        IOptions<AppSettings> appSettings
        )
    {
        _userService = userService;
        _mapper = mapper;
        _awsSqsService = awsSqsService;
        _appSettings = appSettings.Value;
    }

    public async Task<UpdateUserCommandResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var validation = new UpdateUserCommandValidator().Validate(command);
        if (!validation.IsValid) return null;

        var request = _mapper.Map<UpdateUserCommand, UpdateUserRequest>(command);
        var result = await _userService.UpdateAsync(request);

        var message = _mapper.Map<UpdateUserResult, UpdateUserMessage>(result);
        await _awsSqsService.PublishAsync(_appSettings.AWS.SQS.UpdateUser.QueueUrl, message);

        return _mapper.Map<UpdateUserCommandResult>(result);
    }
}
/*
idUser    c7d41a65-240f-436a-a997-36024ed391bc
idAddress 7abdafb5-df92-427b-8cbc-7326f19c3cba

POST
{
  "user": {
    "fullName": "Name Teste Update",
    "dateBirth": "2000-01-01",
    "active": true,
    "gender": 1
  },
  "address": {
    "zipCode": "10000001",
    "street": "Rua teste update",
    "number": 1010,
    "additionalInformation": "AdditionalInformation teste update",
    "typeOfAddress": 1
  }
}


UPDATE
{
  "user": {
    "fullName": "Name Teste Update 2",
    "dateBirth": "2000-02-02",
    "active": false,
    "gender": 1
  },
  "address": {
    "zipCode": "20000002",
    "street": "Rua teste update 2",
    "number": 20,
    "additionalInformation": "AdditionalInformation teste update 2",
    "typeOfAddress": 1
  }
}


{
    "user" : {
        "user": {
            "id": "1ddaca2c-de2c-4972-b99f-3b7928ae9615",
            "fullName": "Teste Update Lambda",
            "dateBirth": "2000-01-01",
            "active": true,
            "gender": 1,
            "fullNameSearch" : "TESTE UPDATE LAMBDA AWS",
           },
        "address": {
            "id": "1ddaca2c-de2c-4972-b99f-3b7928ae9615",
            "idUser": "1ddaca2c-de2c-4972-b99f-3b7928ae9615",
            "zipCode": "10000001",
            "street": "Rua update LAMBDA SQS",
            "number": 1010,
            "additionalInformation": "AdditionalInformation teste update lambda sqs",
            "typeOfAddress": 1
        }
    }
}

"{\"User\":{\"User\":{\"Id\":\"1ddaca2c-de2c-4972-b99f-3b7928ae9615\",\"FullName\":\"Name Teste All Endpoints\",\"DateBirth\":\"2000-01-01T00:00:00\",\"Active\":true,\"Gender\":0},\"Address\":{\"Id\":\"ae77da95-f638-4d92-a4fc-e9652f79808e\",\"IdUser\":\"3e438a26-8023-492e-8fa6-6a18c80a8b8d\",\"ZipCode\":\"10000001\",\"Street\":\"Rua All Endpoints\",\"Number\":10,\"AdditionalInformation\":\"AdditionalInformation All Endpoints\",\"TypeOfAddress\":1}}}",
*/