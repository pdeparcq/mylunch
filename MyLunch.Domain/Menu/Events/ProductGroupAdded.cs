using Kledex.Domain;
using System.Collections.Generic;

namespace MyLunch.Domain.Menu.Events
{
    public class ProductGroupAdded : DomainEvent
    {
        public string Name { get; set; }
        public List<MenuOption> Options { get; set; }
    }
}
