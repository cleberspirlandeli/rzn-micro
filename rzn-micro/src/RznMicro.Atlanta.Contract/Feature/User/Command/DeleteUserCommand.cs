using RznMicro.Atlanta.Contract.Feature.User.Result;
using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User.Command;

public class DeleteUserCommand : ICommand<DeleteUserCommandResult>
{
    public Guid Id { get; private set; }

    public void SetId(Guid id) => Id = id;
}
