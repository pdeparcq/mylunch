using Guards;
using Kledex.Domain;
using MyLunch.Domain.Shared;
using System;
using System.Collections.Generic;

namespace MyLunch.Domain.Menu
{
    public class MenuItem : Entity
    {
        public Guid GroupId { get; private set; }
        public string ProductName { get; private set; }
        public string ProductDescription { get; private set; }
        public double Price { get; private set; }
        public bool IsAvailable { get; private set; }
        public List<MenuOption> Options { get; private set; }
        public List<Ingredient> Ingredients { get; private set; }
        public List<Tag> Tags { get; private set; }

        public MenuItem(Guid id, Guid groupId, string productName, string productDescription, double price) : base(id)
        {
            Guard.ArgumentCondition(() => groupId, id => id != Guid.Empty);
            Guard.ArgumentNotNullOrEmpty(() => productName);
            Guard.ArgumentNotNullOrEmpty(() => productDescription);
            Guard.ArgumentIsGreaterThan(() => price, 0);

            GroupId = groupId;
            ProductName = productName;
            ProductDescription = productDescription;
            Price = price;
        }
    }
}
