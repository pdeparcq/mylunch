using Kledex.Domain;
using MyLunch.Domain.Shared;
using System;
using System.Collections.Generic;

namespace MyLunch.Domain.Menu
{
    public class Product : AggregateRoot
    {
        public Guid RestaurantId { get; private set; }
        public Guid GroupId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Ingredient> Ingredients { get; private set; }
        public List<Tag> Tags { get; private set; }
    }
}
