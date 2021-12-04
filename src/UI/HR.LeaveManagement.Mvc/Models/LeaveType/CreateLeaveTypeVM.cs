using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.Mvc.Models.LeaveType
{
    public class CreateLeaveTypeVm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Default Number Of Days")]
        public int DefaultDays { get; set; }
    }
}

