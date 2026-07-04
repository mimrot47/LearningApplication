using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Appliation.Interfaces;
using MyApp.Domain;
using MyApp.Infrastrature.Percestency;
using MyApp.Infrastrature.Reposetries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Infrastrature
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastrature(this IServiceCollection services) {

            services.AddDbContext<MyAppDbcontext>(options =>
            {
                var connectionString = services.BuildServiceProvider().GetRequiredService<Microsoft.Extensions.Options.IOptions<ConnectionStringOptions>>().Value.DefaultConnection;
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IMyEmployeeReposetory,EmployeesReposetory>(); 
            return services;
        }
    }
}
