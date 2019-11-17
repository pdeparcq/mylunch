using Kledex.Domain;
using System;

namespace MyLunch.Domain.Menu.Events
{
    public class MenuItemAdded : DomainEvent
    {
        public Guid GroupId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
    }
}
