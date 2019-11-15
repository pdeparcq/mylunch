using Kledex.Domain;

namespace MyLunch.Domain.Menu
{
    public class Restaurant : AggregateRoot
    {
        public string Name { get; private set; }
        public string Currency { get; private set; }
    }
}
