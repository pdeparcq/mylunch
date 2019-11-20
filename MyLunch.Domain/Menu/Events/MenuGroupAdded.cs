using Kledex.Domain;

namespace MyLunch.Domain.Menu.Events
{
    public class MenuGroupAdded : DomainEvent
    {
        public string Name { get; set; }
    }
}
