using System.Collections.Generic;
using System.Threading.Tasks;

using HR.LeaveManagement.Mvc.Models;
using HR.LeaveManagement.Mvc.Services.Base;

namespace HR.LeaveManagement.Mvc.Contracts
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVM>> GetLeaveTypes();

        Task<LeaveTypeVM> GetLeaveTypeDetails(int id);

        Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM createLeaveType);

        Task<Response<int>> UpdateLeaveType(int id, LeaveTypeVM leaveType);

        Task<Response<int>> DeleteLeaveType(int id);
    }
}
