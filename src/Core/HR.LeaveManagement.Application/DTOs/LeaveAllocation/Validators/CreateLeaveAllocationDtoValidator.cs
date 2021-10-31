using FluentValidation;

using HR.LeaveManagement.Application.Persistance.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository leaveTypeRepository;

        public CreateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            this.leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveAllocationDtoValidator(this.leaveTypeRepository));
        }
    }
}
