using MyLunch.Domain.Menu;
using MyLunch.Domain.Shared;
using NUnit.Framework;

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
        }
    }
}
