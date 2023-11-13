using BankAccountProject.Services.Interfaces;
using BankAccountProject.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace BankAccountProject.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles));            
            services.AddScoped<IBankAccountService, BankAccountService>();
            return services;
        }
    }
}
