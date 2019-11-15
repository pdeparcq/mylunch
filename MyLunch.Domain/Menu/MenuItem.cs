using Kledex.Domain;
using System;
using System.Collections.Generic;

namespace MyLunch.Domain.Menu
{
    public class MenuItem : Entity
    {
        public Guid GroupId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public bool IsAvailable { get; private set; }
        public List<MenuOption> Options { get; private set; }
        public List<Tag> Tags { get; private set; }
    }
}
