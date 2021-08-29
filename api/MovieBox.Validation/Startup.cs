using Microsoft.Extensions.DependencyInjection;
using MovieBox.Validation.Movies;

namespace MovieBox.Validation
{
    public static class Startup
    {
        public static IServiceCollection AddMoviesValidationServices(this IServiceCollection services)
        {
            services.AddTransient<IMoviesValidator, MoviesValidator>();

            return services;
        }
    }
}