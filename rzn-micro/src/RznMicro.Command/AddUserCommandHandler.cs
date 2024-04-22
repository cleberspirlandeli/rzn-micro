using RznMicro.Atlanta.Contract.Feature.User;
using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Command;

public class AddUserCommandHandler : ICommandHandler<AddUserCommand, AddUserCommandResult>
{
    public async Task<AddUserCommandResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var x = 10;
        var y = request.TesteInputCommand + x;

        return new AddUserCommandResult
        {
            Id = Guid.NewGuid()
        };
    }
}
