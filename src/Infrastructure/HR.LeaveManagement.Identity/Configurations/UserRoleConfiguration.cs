using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
            new IdentityUserRole<string>
            {
                // admin@localhost.com
                RoleId = "3d889a94-b98f-4920-a666-29bb3949bec6",
                UserId = "fb9c1b70-4f42-41e8-ba21-75b6069be846"
            },
            new IdentityUserRole<string>
            {
                // user@localhost.com
                RoleId = "726d32ec-9934-4d0f-a67c-6a925226dfdc",
                UserId = "7e8f9c00-f190-4dad-8dd8-2568857e1279"
            });
        }
    }
}
