using MyApp.Appliation;
using MyApp.Domain;
using MyApp.Infrastrature;

namespace LearningApplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services,IConfiguration config)
        {
            services.AddAppliationDI();
            services.AddDomainDI(config);
            services.AddInfrastrature();
            return services;
        }
    }
}
