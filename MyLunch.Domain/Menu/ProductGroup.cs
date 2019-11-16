using Kledex.Domain;
using System;
using System.Collections.Generic;

namespace MyLunch.Domain.Menu
{
    public class ProductGroup : AggregateRoot
    {
        public Guid RestaurantId { get; private set; }
        public string Title { get; private set; }
        public int MenuOrder { get; private set; }
        public List<MenuOption> Options { get; private set; }
    }
}
