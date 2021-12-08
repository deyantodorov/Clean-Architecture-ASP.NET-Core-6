using System.Collections.Generic;
using System.Linq;
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

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await _dbcontext.LeaveAllocations
                .Include(x => x.LeaveType)
                .FirstAsync(x => x.Id == id);

            return leaveAllocation;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocation = await _dbcontext.LeaveAllocations
                .Include(x => x.LeaveType)
                .ToListAsync();

            return leaveAllocation;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
        {
            var leaveAllocations = await _dbcontext.LeaveAllocations
                .Include(x => x.LeaveType)
                .Where(x => x.EmployeeId == userId)
                .ToListAsync();

            return leaveAllocations;
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            return await _dbcontext.LeaveAllocations.AnyAsync(x => x.EmployeeId == userId && x.LeaveTypeId == leaveTypeId && x.Period == period);
        }

        public async Task AddAllocations(IEnumerable<LeaveAllocation> allocations)
        {
            await _dbcontext.AddRangeAsync(allocations);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<LeaveAllocation?> GetUserAllocations(string userId, int leaveTypeId)
        {
            return await _dbcontext
                .LeaveAllocations
                .FirstOrDefaultAsync(x => x.EmployeeId == userId && x.LeaveTypeId == leaveTypeId);
        }
    }
}
