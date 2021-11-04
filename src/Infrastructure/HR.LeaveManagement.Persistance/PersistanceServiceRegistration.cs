using HR.LeaveManagement.Application_;
using HR.LeaveManagement.Persistance.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistanceService(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<HrLeaveManagementDbContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("HrLeaveManagementConnectionString"));
                });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

            return services;
        }
    }
}
