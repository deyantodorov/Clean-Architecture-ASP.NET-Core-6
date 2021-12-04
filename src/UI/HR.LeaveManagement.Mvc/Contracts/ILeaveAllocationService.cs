using System.Threading.Tasks;

using HR.LeaveManagement.Mvc.Services.Base;

namespace HR.LeaveManagement.Mvc.Contracts
{
    public interface ILeaveAllocationService
    {
        Task<Response<int>> CreateLeaveAllocations(int leaveTypeId);
    }
}
