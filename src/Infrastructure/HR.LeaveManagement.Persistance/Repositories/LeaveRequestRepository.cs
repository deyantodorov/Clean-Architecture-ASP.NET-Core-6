using System.Collections.Generic;
using System.Threading.Tasks;

using HR.LeaveManagement.Application;
using HR.LeaveManagement.Domain;

using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistance.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly HrLeaveManagementDbContext _dbcontext;

        public LeaveRequestRepository(HrLeaveManagementDbContext dbContext)
            : base(dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus)
        {
            leaveRequest.Approved = approvalStatus;
            _dbcontext.Entry(leaveRequest).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await _dbcontext.LeaveRequests
                .Include(x => x.LeaveType)
                .ToListAsync();

            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _dbcontext.LeaveRequests
                .Include(x => x.LeaveType)
                .FirstOrDefaultAsync(x => x.Id == id);

            return leaveRequest;
        }
    }
}
