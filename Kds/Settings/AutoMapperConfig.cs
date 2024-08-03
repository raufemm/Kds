using Kds.Api.AutoMapper;

namespace Kds.Api.Settings
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(ModelToEntityMapping));
        }
    }
}
