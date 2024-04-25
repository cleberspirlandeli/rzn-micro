using FluentValidation;
using RznMicro.Atlanta.Feature.User.Model;

namespace RznMicro.Atlanta.Feature.User.Validation;

public class UserValidator : AbstractValidator<UserEntity>
{
    public UserValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(50)
            .WithMessage($"User Name is invalid");

        RuleFor(x => x.DateBirth)
            .NotNull()
            .LessThan(DateTime.Now)
            .GreaterThan(DateTime.Now.AddYears(-100))
            .WithMessage("User Age is invalid");
    }
}
