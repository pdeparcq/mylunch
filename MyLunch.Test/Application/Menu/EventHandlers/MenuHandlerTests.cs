using Microsoft.EntityFrameworkCore;
using MyLunch.Application.Menu;
using MyLunch.Application.Menu.EventHandlers;
using NUnit.Framework;
using System;
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
                await new MenuCreatedEventHandler(ctx).HandleAsync(
                    new MyLunch.Domain.Menu.Events.MenuCreated
                    {
                        AggregateRootId = Guid.NewGuid(),
                        RestaurantId = Guid.NewGuid()
                    });

                Assert.IsNotEmpty(ctx.Menus);
            }
        }
    }
}
