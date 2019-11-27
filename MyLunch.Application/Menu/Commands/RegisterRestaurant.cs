using Kledex.Domain;
using MyLunch.Domain.Menu;
using MyLunch.Domain.Shared;

namespace MyLunch.Application.Menu.Commands
{
    public class RegisterRestaurant : DomainCommand<Restaurant>
    {
        public string RestaurantName { get; set; }
        public EmailAddress ContactEmailAddress { get; set; }
    }
}
