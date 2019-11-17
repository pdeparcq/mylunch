using Kledex.Domain;
using System;

namespace MyLunch.Domain.Menu.Events
{
    public class MenuCreated : DomainEvent
    {
        public Guid RestaurantId { get; set; }
    }
}
