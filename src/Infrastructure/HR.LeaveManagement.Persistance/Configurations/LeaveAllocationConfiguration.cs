using HR.LeaveManagement.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Persistance.Configurations
{
    public class LeaveAllocationConfiguration : IEntityTypeConfiguration<LeaveAllocation>
    {
        public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
        {
            //builder.HasData(
            //    new LeaveAllocation
            //    {
            //    },
            //    new LeaveAllocation
            //    {
            //    }
            // );
        }
    }
}
