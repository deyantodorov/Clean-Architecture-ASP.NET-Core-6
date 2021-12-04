using System.Collections.Generic;

using HR.LeaveManagement.Mvc.Models.LeaveAllocation;

namespace HR.LeaveManagement.Mvc.Models.LeaveRequest
{
    public class EmployeeLeaveRequestViewVm
    {
        public List<LeaveAllocationVm> LeaveAllocations { get; set; }

        public List<LeaveRequestVm> LeaveRequests { get; set; }
    }
}
