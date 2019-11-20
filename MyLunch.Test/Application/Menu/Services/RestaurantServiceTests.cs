using AutoMapper;
using Kledex.Events;
using Kledex.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyLunch.Application.Menu.EventHandlers;
using MyLunch.Application.Menu.Mappings;
using MyLunch.Application.Menu.Services;
using MyLunch.Domain.Menu.Events;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyLunch.Test.Application.Menu.Services
{
    [TestFixture]
    public class RestaurantServiceTests
    {
        [Test]
        public async Task CanGetRestaurantById()
        {

            //Register services
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyLunch.Application.Menu.Entities.MenuDbContext>(options => options.UseInMemoryDatabase(databaseName: "Test"));
            serviceCollection.AddKledex(typeof(RestaurantRegisteredEventHandler));
            serviceCollection.AddAutoMapper(typeof(RestaurantProfile).Assembly);
            serviceCollection.AddLogging(cfg => cfg.AddConsole());
            serviceCollection.AddTransient<RestaurantService>();

            //Build provider
            var provider = serviceCollection.BuildServiceProvider();

            //Validate mappers
            var mapper = provider.GetService<IMapper>();
            mapper.ConfigurationProvider.AssertConfigurationIsValid();

            //Publish events
            var publisher = provider.GetService<IEventPublisher>();
            var restaurantId = Guid.NewGuid();
            await publisher.PublishAsync(new RestaurantRegistered
            {
                AggregateRootId = restaurantId,
                Name = "Taste it Gent",
                ContactEmail = new MyLunch.Domain.Shared.EmailAddress("info@taste-it-gent.be")
            });

            var service = provider.GetService<RestaurantService>();

            var restaurant = await service.GetRestaurantById(restaurantId);

            Assert.IsNotNull(restaurant);

            restaurant.PrettyPrint(Console.Out);
        }
    }
}
