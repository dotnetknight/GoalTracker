using FluentValidation;
using GoalTracker.Web.Commands;

namespace GoalTracker.Web.Validators
{
    public class AddTaskCommandValidator : AbstractValidator<AddTaskCommand>
    {
        public AddTaskCommandValidator()
        {
            RuleFor(l => l.Priority)
                .NotEmpty()
                .WithMessage("Task priority is required!");

            RuleFor(l => l.TaskEndTime)
               .NotEmpty()
               .WithMessage("Task end time is required!");

            RuleFor(l => l.TaskStartTime)
               .NotEmpty()
               .WithMessage("Task start time is required!");

            RuleFor(l => l.Title)
               .NotEmpty()
               .WithMessage("Task titleis required!");
        }
    }
}