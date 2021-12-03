using HR.LeaveManagement.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Persistence.Configurations
{
    public class LeaveTypesConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Vacation"
                },
                new LeaveType
                {
                    Id = 2,
                    DefaultDays = 12,
                    Name = "Party"
                }
            );
        }
    }
}
