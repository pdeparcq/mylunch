using MyLunch.Domain.Menu;
using MyLunch.Domain.Shared;
using NUnit.Framework;
using System;

namespace MyLunch.Test.Domain.Menu
{
    [TestFixture]
    public class RestaurantTests
    {
        [Test]
        public void CanRegisterRestaurant()
        {
            var restaurant = new Restaurant("Taste-it Gent", new EmailAddress("info@taste-it-gent.be"));

            Assert.AreEqual("Taste-it Gent", restaurant.Name);
            Assert.AreEqual(new EmailAddress("info@taste-it-gent.be"), restaurant.ContactEmail);
            Assert.AreNotEqual(Guid.Empty, restaurant.Id);
        }

        [Test]
        public void CanAddProductGroups()
        {
            var restaurant = new Restaurant("Taste-it Gent", new EmailAddress("info@taste-it-gent.be"));

            restaurant.AddProductGroup("Broodjes");
            restaurant.AddProductGroup("Salades");
            restaurant.AddProductGroup("Dranken");

            Assert.AreEqual(3, restaurant.ProductGroups.Count);
        }
    }
}
