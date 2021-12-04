using System.Collections.Generic;
using System.Threading.Tasks;

using HR.LeaveManagement.Mvc.Models.LeaveType;
using HR.LeaveManagement.Mvc.Services.Base;

namespace HR.LeaveManagement.Mvc.Contracts
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVm>> GetLeaveTypes();

        Task<LeaveTypeVm> GetLeaveTypeDetails(int id);

        Task<Response<int>> CreateLeaveType(CreateLeaveTypeVm createLeaveType);

        Task<Response<int>> UpdateLeaveType(int id, LeaveTypeVm leaveType);

        Task<Response<int>> DeleteLeaveType(int id);
    }
}
