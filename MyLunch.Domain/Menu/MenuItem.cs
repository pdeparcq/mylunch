using Kledex.Domain;
using System;

namespace MyLunch.Domain.Menu
{
    public class MenuItem : Entity
    {
        public Guid ProductId { get; private set; }
        public double Price { get; private set; }
        public bool IsAvailable { get; private set; }   
    }
}
