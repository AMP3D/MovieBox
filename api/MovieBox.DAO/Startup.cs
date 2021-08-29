using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieBox.DAO.Movies;
using MovieBox.DAO.Users;
using System;

namespace MovieBox.DAO
{
    public static class Startup
    {
        public static IServiceCollection AddMoviesDAOServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStrings = configuration.GetSection("ConnectionStrings");
            if (!connectionStrings.Exists())
            {
                throw new Exception("Settings key \"ConnectionStrings\" is missing at the root of the application settings file.");
            }

            services.Configure<ConnectionStrings>(connectionStrings);

            services.AddScoped<IMoviesDAO, MoviesDAO>();
            services.AddScoped<IUsersDAO, UsersDAO>();

            return services;
        }
    }
}