using FoodTruck.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodTruck.Infra
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection InfrastructureExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FoodTruckContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
