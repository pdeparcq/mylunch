using Microsoft.Extensions.DependencyInjection;
using MyLunch.Application.Menu.Services;
using MyLunch.Domain.Menu;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MyLunch.Test.Application.Menu.Services
{
    [TestFixture]
    public class RestaurantServiceTests : IntegrationTest
    {
        [Test]
        public async Task CanGetRestaurantById()
        {
            var service = ServiceProvider.GetService<RestaurantService>();          
            var restaurant = await PublishEvents(new Restaurant("Taste It Gent", new MyLunch.Domain.Shared.EmailAddress("info@taste-it-gent.be")));
            var r = await service.GetRestaurantById(restaurant.Id);
            Assert.IsNotNull(r);
            restaurant.PrettyPrint(Console.Out);
        }
    }
}
