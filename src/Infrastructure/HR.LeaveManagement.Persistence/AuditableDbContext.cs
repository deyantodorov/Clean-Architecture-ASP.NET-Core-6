using System;
using System.Linq;
using System.Threading.Tasks;

using HR.LeaveManagement.Domain.Common;

using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence
{
    public abstract class AuditableDbContext : DbContext
    {
        public AuditableDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual async Task<int> SaveChangesAsync(string? username = "SYSTEM")
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseDomainEntity>()
                         .Where(x => x.State is EntityState.Added or EntityState.Modified))
            {
                entry.Entity.LastModifiedDate = DateTime.UtcNow;
                entry.Entity.LastModifiedBy = username;

                if (entry.State != EntityState.Added)
                {
                    continue;
                }

                entry.Entity.DateCreated = DateTime.UtcNow;
                entry.Entity.CreatedBy = username;
            }

            return await base.SaveChangesAsync();
        }
    }
}
