using MyLunch.Domain.Menu;
using System;
using System.Collections.Generic;

namespace MyLunch.Application.Menu.Entities
{
    public class Menu
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public MenuState State { get; set; }
        public virtual ICollection<MenuItem> Items { get; set; }
    }
}
