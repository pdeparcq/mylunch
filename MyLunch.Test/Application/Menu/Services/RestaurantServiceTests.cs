using AutoMapper;
using Kledex.Domain;
using Kledex.Events;
using Kledex.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyLunch.Application;
using MyLunch.Application.Menu.EventHandlers;
using MyLunch.Application.Menu.Mappings;
using MyLunch.Application.Menu.Services;
using MyLunch.Domain.Menu;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MyLunch.Test.Application.Menu.Services
{
    [TestFixture]
    public class RestaurantServiceTests
    {
        protected IServiceProvider ServiceProvider { get; private set; }

        [OneTimeSetUp]
        public void Init()
        {
            //Register services
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyLunch.Application.Menu.Entities.MenuDbContext>(options => options.UseInMemoryDatabase(databaseName: "Test"));
            serviceCollection.AddKledex(typeof(RestaurantRegisteredEventHandler));
            serviceCollection.AddLogging(cfg => cfg.AddConsole());
            serviceCollection.AddMyLunch();

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddMaps(typeof(RestaurantProfile));
            });
            var mapper = mappingConfig.CreateMapper();
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
            serviceCollection.AddSingleton(mapper);

            //Build provider
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        [Test]
        public async Task CanGetRestaurantById()
        {
            var service = ServiceProvider.GetService<RestaurantService>();          
            var restaurant = await PublishEvents(new Restaurant("Taste It Gent", new MyLunch.Domain.Shared.EmailAddress("info@taste-it-gent.be")));
            var r = await service.GetRestaurantById(restaurant.Id);
            Assert.IsNotNull(r);
            restaurant.PrettyPrint(Console.Out);
        }

        private async Task<T> PublishEvents<T>(T aggregate) where T:AggregateRoot
        {
            var eventPublisher = ServiceProvider.GetService<IEventPublisher>();
            var eventFactory = ServiceProvider.GetService<IEventFactory>();
            foreach (var e in aggregate.Events)
            {
                var concreteEvent = eventFactory.CreateConcreteEvent(e);
                await eventPublisher.PublishAsync(concreteEvent);
            }
            return aggregate;
        }
    }
}
