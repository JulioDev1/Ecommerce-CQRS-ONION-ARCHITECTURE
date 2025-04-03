using Microsoft.Extensions.DependencyInjection;

namespace DigitalProducts.Application
{
    public static class ConfigureService
    {
        public static void AddInjectionApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        }
    }
}
