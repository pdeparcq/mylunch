using Guards;
using Kledex.Domain;
using System;
using System.Collections.Generic;

namespace MyLunch.Domain.Menu
{
    public class MenuGroup : Entity
    {
        public string Name { get; private set; }
        public double DefaultItemPrice { get; private set; }
        public List<MenuOption> Options { get; private set; }

        public MenuGroup(Guid id, string name, double defaultItemPrice) : base(id)
        {
            Guard.ArgumentNotNullOrEmpty(() => name);
            Guard.ArgumentIsGreaterThan(() => defaultItemPrice, 0);

            Name = name;
            DefaultItemPrice = defaultItemPrice;
            Options = new List<MenuOption>();
        }
    }
}
