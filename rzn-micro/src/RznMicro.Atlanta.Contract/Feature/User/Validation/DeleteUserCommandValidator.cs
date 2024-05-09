using FluentValidation;
using RznMicro.Atlanta.Contract.Feature.User.Command;

namespace RznMicro.Atlanta.Contract.Feature.User.Validation;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage($"Property {nameof(DeleteUserCommand.Id)} is invalid");
    }
}
