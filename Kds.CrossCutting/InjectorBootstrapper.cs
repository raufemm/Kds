using Kds.Domain.Interfaces.Repositories;
using Kds.Domain.Interfaces.Services;
using Kds.Domain.Services;
using Kds.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Kds.CrossCutting
{
    public static class InjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
