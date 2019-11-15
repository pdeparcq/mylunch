using Kledex.Domain;
using System;
using System.Collections.Generic;

namespace MyLunch.Domain.Menu
{
    public class Menu : AggregateRoot
    {
        public Guid RestaurantId { get; private set; }
        public DateTime StartDate { get; private set; }
        public List<MenuItemGroup> Groups { get; private set; }
        public List<MenuItem> Items { get; private set; }
    }
}
