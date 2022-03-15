using ITHelper.Application.Contracts.Persistence;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.Contracts.Persistence.NetworkPortInfo;
using ITHelper.Persistence.Repositories;
using ITHelper.Persistence.Repositories.AssetInventory;
using ITHelper.Persistence.Repositories.IssueTracker;
using ITHelper.Persistence.Repositories.NetworkPortInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Persistence.Services
{
    public static class PersistenceServicesRegistration 
    {
        public static IServiceCollection ConfigurePersistenceServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("Default"),
                    new MySqlServerVersion(new Version(8, 0, 26)));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //Asset Inventory Repository Services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IHardwareRepository, HardwareRepository>();
            services.AddScoped<IHardwareTypeRepository, HardwareTypeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVendorRepository, VendorRepository>();

            //Issue Tracker Repository Services
            services.AddScoped<IIssueUnitOfWork, IssueUnitOfWork>();
            services.AddScoped<IIssueRepository, IssueRepository>();
            services.AddScoped<ISystemContactRepository, SystemContactRepository>();
            services.AddScoped<IApplicationSystemRepository, ApplicationSystemRepository>();

            //Port Information Repository Services
            services.AddScoped<INetworkPortInformationRepository, NetworkPortInformationRepository>();

            return services;
        }
    }
}
