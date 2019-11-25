using Microsoft.Extensions.DependencyInjection;
using MyLunch.Application.Menu.Services;
using MyLunch.Domain.Menu;
using NUnit.Framework;
using System;
using System.Linq;
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
            await service.RegisterRestaurant(new MyLunch.Application.Menu.InputModels.RestaurantRegistrationModel
            {
                RestaurantName = "Taste it Gent",
                ContactEmailAddress = "info@taste-it-gent.be"
            });

            var restaurant = (await service.GetAllRestaurants()).First();
            var menu = restaurant.Menus.First();
            
            Assert.AreEqual(MenuState.UnderConstruction, menu.State);

            restaurant.PrettyPrint(Console.Out);
        }
    }
}
