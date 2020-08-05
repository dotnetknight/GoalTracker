using FluentValidation;
using FluentValidation.Validators;
using GoalTracker.Web.Commands;

namespace GoalTracker.Web.Validators
{
    public class UserRegistrationCommandValidator : AbstractValidator<UserRegistrationCommand>
    {
        [System.Obsolete]
        public UserRegistrationCommandValidator()
        {
            RuleFor(reg => reg.FirstName)
                .NotEmpty()
                .WithMessage("First Name is required");

            RuleFor(reg => reg.LastName)
                .NotEmpty()
                .WithMessage("Last Name is required");

            RuleFor(reg => reg.Email)
                .EmailAddress(EmailValidationMode.Net4xRegex)
                .WithMessage("Email is required")
                .WithMessage("Email is not in correct format");

            RuleFor(reg => reg.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}