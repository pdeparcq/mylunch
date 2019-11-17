using Guards;
using Kledex.Domain;
using MyLunch.Domain.Menu.Events;
using MyLunch.Domain.Shared;
using System.Collections.Generic;
using System.Linq;

namespace MyLunch.Domain.Menu
{
    public class Restaurant : AggregateRoot
    {
        public string Name { get; private set; }
        public EmailAddress ContactEmail { get; private set; }
        public List<ProductGroup> ProductGroups { get; private set; }

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

        public void AddProductGroup(string name, List<MenuOption> options = null)
        {
            Guard.ArgumentCondition(() => name, n => !ProductGroups.Any(g => g.Name == n));

            AddAndApplyEvent(new ProductGroupAdded
            {
                AggregateRootId = Id,
                Name = name,
                Options = options ?? new List<MenuOption>()
            });
        }

        public void Apply(RestaurantRegistered e)
        {
            Id = e.AggregateRootId;
            Name = e.Name;
            ContactEmail = e.ContactEmail;
            ProductGroups = new List<ProductGroup>();
        }

        public void Apply(ProductGroupAdded e)
        {
            ProductGroups.Add(new ProductGroup(e.Name, e.Options));
        }
    }
}
