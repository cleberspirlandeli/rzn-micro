using FluentValidation;

namespace RznMicro.Atlanta.Contract.Feature.User.Validation;

public class UserCommandValidator : AbstractValidator<AddUserCommand>
{
    public UserCommandValidator()
    {
        RuleFor(x => x.User.FullName)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(50)
            .WithMessage($"User Name is invalid");

        RuleFor(x => x.User.DateBirth)
            .NotNull()
            .LessThan(DateTime.Now)
            .GreaterThan(DateTime.Now.AddYears(-100))
            .WithMessage("User Age is invalid");
    }
}
