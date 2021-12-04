using System.Collections.Generic;
using System.Threading.Tasks;

using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);

        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();

        Task<bool> AllocationExists(string userId, int leaveTypeId, int period);

        Task AddAllocations(IEnumerable<LeaveAllocation> allocations);
    }
}
