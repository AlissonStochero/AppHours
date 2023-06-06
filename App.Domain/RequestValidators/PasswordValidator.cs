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
                .MinimumLength(6).WithMessage("password is less than 6 characters.")
                .MaximumLength(20).WithMessage("Key is greater than 20 characters.");
            RuleFor(password => password.Validate()).Must(isTrue => isTrue == true).WithMessage("Password is not valid.");
        }
    }
}
