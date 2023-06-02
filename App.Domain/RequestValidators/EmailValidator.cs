using App.Domain.ValueObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.RequestValidators
{
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(email => email.Address)
                .NotEmpty().WithMessage("Email address is required.")
                .MaximumLength(100).WithMessage("Email address is greater than 100 characters.")
                .EmailAddress().WithMessage("Invalid email address.");
        }
    }
}
