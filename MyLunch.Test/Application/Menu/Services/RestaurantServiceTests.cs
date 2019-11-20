using AutoMapper;
using Kledex.Events;
using Kledex.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyLunch.Application.Menu.EventHandlers;
using MyLunch.Application.Menu.Mappings;
using MyLunch.Application.Menu.Services;
using MyLunch.Domain.Menu;
using MyLunch.Domain.Menu.Events;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MyLunch.Test.Application.Menu.Services
{
    [TestFixture]
    public class RestaurantServiceTests
    {
        [Test]
        public async Task CanGetRestaurantById()
        {
            var provider = CreateServiceProvider();
            ValidateMappers(provider.GetService<IMapper>());
            Guid restaurantId = await PublishEvents(provider.GetService<IEventPublisher>());

            var service = provider.GetService<RestaurantService>();
            var restaurant = await service.GetRestaurantById(restaurantId);

            Assert.IsNotNull(restaurant);
            restaurant.PrettyPrint(Console.Out);
        }

        private static async Task<Guid> PublishEvents(IEventPublisher publisher)
        {
            var restaurantId = Guid.NewGuid();
            await publisher.PublishAsync(new RestaurantRegistered
            {
                AggregateRootId = restaurantId,
                Name = "Taste it Gent",
                ContactEmail = new MyLunch.Domain.Shared.EmailAddress("info@taste-it-gent.be")
            });
            return restaurantId;
        }

        private static void ValidateMappers(IMapper mapper)
        {
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        private static IServiceProvider CreateServiceProvider()
        {
            //Register services
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyLunch.Application.Menu.Entities.MenuDbContext>(options => options.UseInMemoryDatabase(databaseName: "Test"));
            serviceCollection.AddKledex(typeof(RestaurantRegisteredEventHandler));
            serviceCollection.AddLogging(cfg => cfg.AddConsole());
            serviceCollection.AddTransient<RestaurantService>();

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddMaps(typeof(RestaurantProfile));
            });
            serviceCollection.AddSingleton(mappingConfig.CreateMapper());

            //Build provider
            var provider = serviceCollection.BuildServiceProvider();
            return provider;
        }
    }
}
