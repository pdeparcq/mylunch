using Microsoft.EntityFrameworkCore;
using MyLunch.Application.Menu.Entities;
using MyLunch.Application.Menu.EventHandlers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyLunch.Test.Application.Menu.EventHandlers
{
    [TestFixture]
    public class MenuHandlerTests
    {
        [Test]
        public async Task CanHandleMenuEvents()
        {
            var options = new DbContextOptionsBuilder<MenuDbContext>()
                           .UseInMemoryDatabase(databaseName: "Test")
                           .Options;

            using (var ctx = new MenuDbContext(options))
            {
                var restaurantId = Guid.NewGuid();
                var menuId = Guid.NewGuid();
                var menuGroupId = Guid.NewGuid();

                await new RestaurantRegisteredEventHandler(ctx).HandleAsync(new MyLunch.Domain.Menu.Events.RestaurantRegistered
                {
                    AggregateRootId = restaurantId,
                    Name = "Taste it Gent",
                    ContactEmail = new MyLunch.Domain.Shared.EmailAddress("info@taste-it-gent.be")
                });
                await new MenuCreatedEventHandler(ctx).HandleAsync(new MyLunch.Domain.Menu.Events.MenuCreated
                {
                    AggregateRootId = menuId,
                    RestaurantId = restaurantId
                });
                await new MenuGroupAddedEventHandler(ctx).HandleAsync(new MyLunch.Domain.Menu.Events.MenuGroupAdded
                {
                    AggregateRootId = menuId,
                    Id = menuGroupId,
                    Name = "Broodjes"
                });
                await new MenuItemAddedEventHandler(ctx).HandleAsync(new MyLunch.Domain.Menu.Events.MenuItemAdded
                {
                    AggregateRootId = menuId,
                    Id = Guid.NewGuid(),
                    GroupId = menuGroupId,
                    ProductName = "Hoevekaas",
                    ProductDescription = "Hoevekaas, light mosterddressing of mayo, wortel, tomaat, krokante sla",
                    Price = 3.3
                });
                await new MenuItemAddedEventHandler(ctx).HandleAsync(new MyLunch.Domain.Menu.Events.MenuItemAdded
                {
                    AggregateRootId = menuId,
                    Id = Guid.NewGuid(),
                    GroupId = menuGroupId,
                    ProductName = "Krab",
                    ProductDescription = "Huisbereide krabsalade met bieslook, tomaat, krokante sla",
                    Price = 3.6
                });

                (await ctx.Menus.FirstAsync()).PrettyPrint(Console.Out);
            }
        }
    }
}
