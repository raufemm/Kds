using Kds.CrossCutting;

namespace Kds.Api.Settings
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            InjectorBootstrapper.RegisterServices(services);
        }
    }
}
