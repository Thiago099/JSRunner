using Microsoft.Extensions.DependencyInjection;

namespace JSRunner
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddJSRunner(this IServiceCollection services)
        {
            services.AddScoped<JS>();
            return services;
        }
    }
}