using Microsoft.Extensions.DependencyInjection;
using MyLunch.Application.Menu.Services;

namespace MyLunch.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMyLunch(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddTransient<RestaurantService>();
        }
    }
}
