using AutoMapper;
using RznMicro.Atlanta.Contract.Feature.User;
using RznMicro.Atlanta.Contract.Feature.User.Validation;
using RznMicro.Atlanta.Core.RequestContext;
using RznMicro.Atlanta.Feature.User;
using RznMicro.Atlanta.Feature.User.Request;

namespace RznMicro.Atlanta.Command;

public class AddUserCommandHandler : ICommandHandler<AddUserCommand, AddUserCommandResult>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public AddUserCommandHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<AddUserCommandResult> Handle(AddUserCommand command, CancellationToken cancellationToken)
    {
        var validation = new UserCommandValidator().Validate(command);
        if (!validation.IsValid) return null;

        var request = _mapper.Map<AddUserRequest>(command); 
        var result = await _userService.AddAsync(request);

        return _mapper.Map<AddUserCommandResult>(result);
    }
}
