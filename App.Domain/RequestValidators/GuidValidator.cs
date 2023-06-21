using FluentValidation;

namespace App.Domain.RequestValidators
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator()
        {
            RuleFor(guid => guid)
                .NotEmpty().WithMessage("GUID is not empty.")
                .Must(BeValidGuid)
                .WithMessage("GUID is not valid.");
        }

        private bool BeValidGuid(Guid guid)
        {
            return guid != Guid.Empty;
        }
    }
}
