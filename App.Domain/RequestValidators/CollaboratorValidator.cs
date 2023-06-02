using App.Domain.Entities;
using FluentValidation;

namespace App.Domain.RequestValidators
{
    public class CollaboratorValidator : AbstractValidator<Collaborator>
    {
        public CollaboratorValidator()
        {
            RuleFor(c => c.Name)
                .SetValidator(new NameValidator());

            RuleFor(c => c.KeyPassword)
                .SetValidator(new PasswordValidator());

            RuleFor(c => c.Email)
                .SetValidator(new EmailValidator());

        }
    }
}
