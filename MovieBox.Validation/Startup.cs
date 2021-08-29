using Microsoft.Extensions.DependencyInjection;

namespace MovieBox.Validation
{
    public static class Startup
    {
        public static IServiceCollection AddMoviesValidationServices(this IServiceCollection services)
        {
            return services;
        }
    }
}