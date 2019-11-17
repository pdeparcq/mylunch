using Guards;
using Kledex.Domain;
using MyLunch.Domain.Menu.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLunch.Domain.Menu
{
    public enum MenuState
    {
        UnderConstruction,
        Scheduled,
        Active,
        Ended
    }

    public class Menu : AggregateRoot
    {
        public Guid RestaurantId { get; private set; }
        public MenuState State { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public List<MenuGroup> Groups { get; private set; }
        public List<MenuItem> Items { get; private set; }

        public Menu(Guid restaurantId)
        {
            Guard.ArgumentCondition(() => restaurantId, id => id != Guid.Empty);

            AddAndApplyEvent(new MenuCreated
            {
                AggregateRootId = Id,
                RestaurantId = restaurantId
            });
        }

        public void AddMenuGroup(MenuGroup group)
        {
            if (State != MenuState.UnderConstruction)
                throw new ApplicationException("Invalid state for adding menu group");

            if (Groups.Any(g => g.Name == group.Name))
                throw new ArgumentException("Group with same name already exists", nameof(group));

            AddAndApplyEvent(new MenuGroupAdded
            {
                AggregateRootId = Id,
                Id = group.Id,
                Name = group.Name
            });
        }

        public void AddMenuItem(MenuItem item)
        {
            if (State != MenuState.UnderConstruction)
                throw new ApplicationException("Invalid state for adding menu item");

            if (!Groups.Any(g => g.Id == item.GroupId))
                throw new ArgumentException("Group not found for menu item", nameof(item));

            if (Items.Any(i => i.ProductName == item.ProductName))
                throw new ArgumentException("Menu item with same product name already exists", nameof(item));

            AddAndApplyEvent(new MenuItemAdded
            {
                AggregateRootId = Id,
                Id = item.Id,
                GroupId = item.GroupId,
                ProductName = item.ProductName,
                ProductDescription = item.ProductDescription,
                Price = item.Price
            });
        }

        public void Apply(MenuCreated e)
        {
            Id = e.AggregateRootId;
            State = MenuState.UnderConstruction;
            Groups = new List<MenuGroup>();
            Items = new List<MenuItem>();
        }

        public void Apply(MenuGroupAdded e)
        {
            Groups.Add(new MenuGroup(e.Id, e.Name));
        }

        public void Apply(MenuItemAdded e)
        {
            var group = Groups.First(g => g.Id == e.GroupId);

            Items.Add(new MenuItem(e.Id, e.GroupId, e.ProductName, e.ProductDescription, e.Price));
        }
    }
}
