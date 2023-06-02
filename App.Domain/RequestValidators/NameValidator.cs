using App.Domain.ValueObjects;
using FluentValidation;

namespace App.Domain.RequestValidators
{
    public class NameValidator : AbstractValidator<Name>
    {
        public NameValidator()
        {
            RuleFor(name => name.ToString())
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name is greater than 100 characters.");
        }
    }
}
