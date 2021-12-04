using System.ComponentModel.DataAnnotations;

using HR.LeaveManagement.Mvc.Models.LeaveType;

namespace HR.LeaveManagement.Mvc.Models.LeaveAllocation
{
    public class UpdateLeaveAllocationVm
    {
        public int Id { get; set; }

        [Display(Name = "Number Of Days")]
        [Range(1, 50, ErrorMessage = "Enter Valid Number")]

        public int NumberOfDays { get; set; }
        
        public LeaveTypeVm LeaveType { get; set; }
    }
}
