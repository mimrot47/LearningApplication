using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain
{
    public static class DependencyInjection
    {
       public static IServiceCollection AddDomainDI(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<ConnectionStringOptions>(config.GetSection(ConnectionStringOptions.SectionsName));
            return services;
        }
}
}
