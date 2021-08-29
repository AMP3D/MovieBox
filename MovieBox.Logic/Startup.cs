using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieBox.DAO;
using MovieBox.Validation;

namespace MovieBox.Logic
{
    public static class Startup
    {
        public static IServiceCollection AddMovieLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMoviesValidationServices();
            services.AddMoviesDAOServices(configuration);

            return services;
        }
    }
}