using System.Collections.Generic;
using System.Threading.Tasks;

using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application_
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);

        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();

        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus);
    }
}
