using FluentValidation;
using RznMicro.Atlanta.Contract.Feature.Address.Request;
using RznMicro.Atlanta.Contract.Feature.User.Command;
using RznMicro.Atlanta.Contract.Feature.User.Request;

namespace RznMicro.Atlanta.Contract.Feature.User.Validation;

public partial class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        // User
        RuleFor(x => x.User.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage($"Property {nameof(UpdateUserCommandRequest.Id)} is invalid");

        RuleFor(x => x.User.FullName)
            .NotNull()
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(50)
            .WithMessage($"Property {nameof(UpdateUserCommandRequest.FullName)} is invalid");

        RuleFor(x => x.User.DateBirth)
            .NotNull()
            .LessThan(DateTime.Now)
            .GreaterThan(DateTime.Now.AddYears(-100))
            .WithMessage($"Property {nameof(UpdateUserCommandRequest.DateBirth)} is invalid");

        // Address
        RuleFor(x => x.Address.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage($"Property {nameof(UpdateAddressCommandRequest.Id)} is invalid");

        RuleFor(x => x.Address.ZipCode)
            .NotNull()
            .NotEmpty()
            .WithMessage($"Property {nameof(UpdateAddressCommandRequest.ZipCode)} is invalid");

        RuleFor(x => x.Address.Street)
            .NotNull()
            .NotEmpty()
            .WithMessage($"Property {nameof(UpdateAddressCommandRequest.Street)} is invalid");

        RuleFor(x => x.Address.Number)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage($"Property {nameof(UpdateAddressCommandRequest.Number)} is invalid");
    }
}

