using FluentValidation;
using RznMicro.Atlanta.Feature.User.Model;

namespace RznMicro.Atlanta.Feature.User.Validation;

public class UserValidator : AbstractValidator<UserModel>
{
    public UserValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(50)
            .WithMessage($"User Name is invalid");

        RuleFor(x => x.Age)
            .NotNull()
            .LessThan(DateTime.Now)
            .GreaterThan(DateTime.Now.AddYears(-100))
            .WithMessage("User Age is invalid");
    }
}
