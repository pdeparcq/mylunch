using Kledex.Domain;
using MyLunch.Domain.Shared;
using System;

namespace MyLunch.Domain.Menu.Events
{
    public class RestaurantRegistered : DomainEvent
    {
        public string Name { get; set; }
        public EmailAddress ContactEmail { get; set; }
    }
}
