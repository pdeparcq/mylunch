using Guards;
using Kledex.Domain;
using MyLunch.Domain.Menu.Events;
using MyLunch.Domain.Shared;

namespace MyLunch.Domain.Menu
{
    public class Restaurant : AggregateRoot
    {
        public string Name { get; private set; }
        public EmailAddress ContactEmail { get; private set; }

        public Restaurant(string name, EmailAddress email)
        {
            Guard.ArgumentNotNullOrEmpty(() => name);
            Guard.ArgumentNotNull(() => email);

            AddAndApplyEvent(new RestaurantRegistered
            {
                AggregateRootId = Id,
                Name = name,
                ContactEmail = email
            });
        }

        public void Apply(RestaurantRegistered e)
        {
            Id = e.AggregateRootId;
            Name = e.Name;
            ContactEmail = e.ContactEmail;
        }
    }
}
