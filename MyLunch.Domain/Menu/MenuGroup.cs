using Guards;
using Kledex.Domain;
using System;
using System.Collections.Generic;

namespace MyLunch.Domain.Menu
{
    public class MenuGroup : Entity
    {
        public string Name { get; private set; }
        public List<MenuOption> Options { get; private set; }

        public MenuGroup(Guid id, string name) : base(id)
        {
            Guard.ArgumentNotNullOrEmpty(() => name);

            Name = name;
            Options = new List<MenuOption>();
        }
    }
}
