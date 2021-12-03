using System.Collections.Generic;
using System.Threading.Tasks;

using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;

using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly HrLeaveManagementDbContext _dbcontext;

        public LeaveAllocationRepository(HrLeaveManagementDbContext dbContext)
            : base(dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations = await _dbcontext.LeaveAllocations
                .Include(x => x.LeaveType)
                .ToListAsync();

            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await _dbcontext.LeaveAllocations
                .Include(x => x.LeaveType)
                .FirstOrDefaultAsync(x => x.Id == id);

            return leaveAllocation;
        }

        public Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAllocation(List<LeaveAllocation> allocations)
        {
            throw new System.NotImplementedException();
        }
    }
}
