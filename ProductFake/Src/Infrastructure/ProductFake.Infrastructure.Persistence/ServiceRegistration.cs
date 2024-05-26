using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductFake.Application.Interfaces;
using ProductFake.Application.Interfaces.Repositories;
using ProductFake.Infrastructure.Persistence.Contexts;
using ProductFake.Infrastructure.Persistence.Repositories;
using System.Linq;
using System.Reflection;

namespace ProductFake.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(
               configuration.GetConnectionString("DefaultConnection"),
               b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.RegisterRepositories();

        }
        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            var interfaceType = typeof(IGenericRepository<>);
            var interfaces = Assembly.GetAssembly(interfaceType).GetTypes()
                .Where(p => p.GetInterface(interfaceType.Name.ToString()) != null);

            foreach (var item in interfaces)
            {
                var implimentation = Assembly.GetAssembly(typeof(GenericRepository<>)).GetTypes()
                    .FirstOrDefault(p => p.GetInterface(item.Name.ToString()) != null);
                services.AddTransient(item, implimentation);

            }

        }
    }
}
