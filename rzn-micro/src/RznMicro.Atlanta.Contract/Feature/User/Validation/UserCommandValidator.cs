using FluentValidation;
using RznMicro.Atlanta.Contract.Feature.User.Command;
using RznMicro.Atlanta.Contract.Feature.User.Request;

namespace RznMicro.Atlanta.Contract.Feature.User.Validation;

public class UserCommandValidator : AbstractValidator<AddUserCommand>
{
    public UserCommandValidator()
    {
        // User
        RuleFor(x => x.User.FullName)
            .NotNull()
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(50)
            .WithMessage($"Property {nameof(UserCommandRequest.FullName)} is invalid");

        RuleFor(x => x.User.DateBirth)
            .NotNull()
            .LessThan(DateTime.Now)
            .GreaterThan(DateTime.Now.AddYears(-100))
            .WithMessage($"Property {nameof(UserCommandRequest.DateBirth)} is invalid");

        // Address
        RuleFor(x => x.Address.ZipCode)
            .NotNull()
            .NotEmpty()
            .WithMessage($"Property {nameof(AddressCommandRequest.ZipCode)} is invalid");

        RuleFor(x => x.Address.Street)
            .NotNull()
            .NotEmpty()
            .WithMessage($"Property {nameof(AddressCommandRequest.Street)} is invalid");

        RuleFor(x => x.Address.Number)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage($"Property {nameof(AddressCommandRequest.Number)} is invalid");
    }
}
