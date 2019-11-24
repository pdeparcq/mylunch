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
        public async Task CanRegisterRestaurant()
        {
            var service = ServiceProvider.GetService<RestaurantService>();
            var restaurant = await service.RegisterRestaurant(new MyLunch.Application.Menu.InputModels.RestaurantRegistrationModel
            {
                RestaurantName = "Taste it Gent",
                ContactEmailAddress = "info@taste-it-gent.be"
            });
            restaurant = await service.GetRestaurantById(restaurant.Id);
            Assert.IsNotNull(restaurant);
            restaurant.PrettyPrint(Console.Out);
        }
    }
}
