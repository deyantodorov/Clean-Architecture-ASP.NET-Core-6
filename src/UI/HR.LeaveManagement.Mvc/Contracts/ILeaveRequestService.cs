using System.Threading.Tasks;

using HR.LeaveManagement.Mvc.Models.LeaveRequest;
using HR.LeaveManagement.Mvc.Services.Base;

namespace HR.LeaveManagement.Mvc.Contracts
{
    public interface ILeaveRequestService
    {
        Task<AdminLeaveRequestViewVm> GetAdminLeaveRequestList();

        Task<EmployeeLeaveRequestViewVm> GetUserLeaveRequests();

        Task<Response<int>> CreateLeaveRequest(CreateLeaveRequestVm leaveRequest);

        Task<LeaveRequestVm> GetLeaveRequest(int id);

        Task DeleteLeaveRequest(int id);

        Task ApproveLeaveRequest(int id, bool approved);
    }
}
