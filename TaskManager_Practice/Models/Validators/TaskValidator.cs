using FluentValidation;

namespace TaskManager_Practice.Models.Validators
{
    public class TaskValidator: AbstractValidator<Task>
    {
        public TaskValidator()
        {
            RuleFor(t => t.Name).NotNull().NotEmpty().MaximumLength(20).WithMessage("Max length is 20")
                .MinimumLength(3).WithMessage("Minimum length is 3");
            RuleFor(t => t.StartTime).NotNull().NotEmpty().WithMessage("Incorrect date");
            RuleFor(t => t.EndTime).NotNull().NotEmpty().WithMessage("Incorrect date");
        }
    }
}