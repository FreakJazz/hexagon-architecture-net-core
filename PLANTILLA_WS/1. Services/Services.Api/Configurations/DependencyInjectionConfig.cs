using CrossCutting;
using Microsoft.AspNetCore.Diagnostics;

namespace Services.Api.Configurations
{
    public static class DependenciaInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            IocRegister.RegisterServices(services);
        }
    }
}
