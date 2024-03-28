using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SherplexTickets.Core.Contracts;
using SherplexTickets.Core.Services;
using SherplexTickets.Infrastructure.Common;
using SherplexTickets.Infrastructure.Data;
using SherplexTickets.Infrastructure.Data.Models.IdentityModels;

namespace SherplexTickets.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<SherplexTicketsDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<SherplexTicketsDbContext>();

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IMovieTheaterService, MovieTheaterService>();
            services.AddScoped<IMovieTheaterMovieLink, MovieTheaterMovieLinkService>();
            services.AddScoped<ITheaterManagerService, TheaterManagerService>();

            return services;
        }

    }
}
