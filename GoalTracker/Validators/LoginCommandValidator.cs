using FluentValidation;
using FluentValidation.Validators;
using GoalTracker.Web.Commands;

namespace GoalTracker.Web.Validators
{
    public class LoginCommandValidator : AbstractValidator<UserLoginCommand>
    {
        [System.Obsolete]
        public LoginCommandValidator()
        {
            RuleFor(l => l.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress(EmailValidationMode.Net4xRegex)
                .WithMessage("Email is not in correct format");

            RuleFor(l => l.Password)
                .NotEmpty()
                .WithMessage("Password is required!");
        }
    }
}