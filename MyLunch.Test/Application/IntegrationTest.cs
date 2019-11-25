using AutoMapper;
using Kledex.Domain;
using Kledex.Events;
using Kledex.Extensions;
using Kledex.Store.EF.InMemory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyLunch.Application;
using MyLunch.Application.Menu.EventHandlers;
using MyLunch.Application.Menu.Mappings;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyLunch.Test.Application
{
    public abstract class IntegrationTest
    {

        protected IServiceProvider ServiceProvider { get; private set; }

        [OneTimeSetUp]
        public void Init()
        {
            var config = new ConfigurationBuilder().AddInMemoryCollection(
                new Dictionary<string, string> {
                    [$"ConnectionStrings:KledexDomainStore"] = @"Server=(localdb)\\mssqllocaldb;Database=DomainStore;Trusted_Connection=True;"
                }).Build();

            //Register services
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IConfiguration>(config);
            serviceCollection.AddDbContext<MyLunch.Application.Menu.Entities.MenuDbContext>(options => options.UseInMemoryDatabase("Test"));
            serviceCollection.AddKledex(typeof(RestaurantRegisteredEventHandler)).AddInMemoryProvider();
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
    }
}
