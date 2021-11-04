using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.DefaultDays)
                .GreaterThan(0).WithMessage("{PropertyName} must be at least {ComparisonValue}.")
                .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisonValue}.");
        }
    }
}
