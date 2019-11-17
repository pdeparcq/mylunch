using Guards;
using Kledex.Domain;
using System;
using System.Collections.Generic;

namespace MyLunch.Domain.Menu
{
    public class ProductGroup : Entity
    {
        public string Name { get; private set; }
        public List<MenuOption> Options { get; private set; }

        public ProductGroup(string name, List<MenuOption> options)
        {
            Guard.ArgumentNotNullOrEmpty(() => name);
            Guard.ArgumentNotNull(() => options);

            Name = name;
            Options = options;
        }
    }
}
