using Microsoft.Extensions.DependencyInjection;

namespace InspectionAPI.Services { 
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<AccountsService>();

            return services;
        }
    }
}
