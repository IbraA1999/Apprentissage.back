using FoodTruck.Infra;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace FoodTruck.Bll
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            services.InfrastructureExtensions(configuration);

            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
