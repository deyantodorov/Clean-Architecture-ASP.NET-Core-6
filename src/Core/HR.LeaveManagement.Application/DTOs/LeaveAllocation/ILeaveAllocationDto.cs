namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation
{
    public interface ILeaveAllocationDto
    {
        int NumberOfDays { get; set; }

        int LeaveTypeId { get; set; }

        int Period { get; set; }
    }
}
