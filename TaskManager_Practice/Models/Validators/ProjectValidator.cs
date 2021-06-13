using FluentValidation;

namespace TaskManager_Practice.Models.Validators
{
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(p => p.Name).NotEmpty().MaximumLength(35).WithMessage("Max length is 35").MinimumLength(3)
                .WithMessage("Min length is 3");
            RuleFor(p => p.Deadline).NotEmpty().WithMessage("Incorrect date");
        }
    }
}