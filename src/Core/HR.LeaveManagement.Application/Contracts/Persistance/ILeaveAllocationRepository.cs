using System.Collections.Generic;
using System.Threading.Tasks;

using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application_
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);

        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
    }
}
