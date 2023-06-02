using App.Domain.ValueObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.RequestValidators
{
    public class PasswordValidator : AbstractValidator<Password>
    {
        public PasswordValidator()
        {
            RuleFor(password => password.Key)
                .NotEmpty().WithMessage("Key is required.")
                .MaximumLength(300).WithMessage("Key is greater than 300 characters.");
            RuleFor(password => password.Validate()).Must(isTrue => isTrue == false).WithMessage("Password is not valid.");
        }
    }
}
