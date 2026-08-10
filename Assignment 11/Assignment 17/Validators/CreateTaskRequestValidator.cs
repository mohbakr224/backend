using Assignment_17.DTOS;
using FluentValidation;

namespace Assignment_17.Validators
{
    public class CreateTaskRequestValidator : AbstractValidator<TaskModelReqDTO>
    {
        public CreateTaskRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.ExpireDate)
                .GreaterThan(DateTime.Now)
                .WithMessage("Expire date must be in the future.");
        }
    }
}