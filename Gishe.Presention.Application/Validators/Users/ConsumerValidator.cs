using FluentValidation;
using Gishe.presentation.Domain.Entities.Users;

namespace Gishe.Presentation.Application.Validators.Users;

public class ConsumerValidator : AbstractValidator<Consumer>
{
    public ConsumerValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.FamilyName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(150);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .MaximumLength(20);
    }
}
