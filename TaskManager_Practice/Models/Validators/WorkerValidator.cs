using FluentValidation;

namespace TaskManager_Practice.Models.Validators
{
    public class WorkerValidator:AbstractValidator<Worker>
    {
        public WorkerValidator()
        {
            RuleFor(w => w.Name).NotEmpty().NotNull().MaximumLength(20).MinimumLength(3);
            RuleFor(w => w.Surname).NotEmpty().NotNull().MaximumLength(20).MinimumLength(3);
            RuleFor(w => w.Position).NotEmpty().NotNull().MaximumLength(20).MinimumLength(3);
            RuleFor(w => w.PhoneNumber).NotEmpty().NotNull().MaximumLength(15).MinimumLength(10);
        }
    }
}