using Microsoft.Extensions.DependencyInjection;
using ProductFake.Application.Interfaces;
using ProductFake.Infrastructure.Resources.Services;

namespace ProductFake.Infrastructure.Resources
{
    public static class ServiceRegistration
    {
        public static void AddResourcesInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<ITranslator, Translator>();
        }
    }
}
