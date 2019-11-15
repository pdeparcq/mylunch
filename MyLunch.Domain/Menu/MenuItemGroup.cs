using Kledex.Domain;
using System.Collections.Generic;

namespace MyLunch.Domain.Menu
{
    public class MenuItemGroup : Entity
    {
        public string Title { get; private set; }
        public int Order { get; private set; }
        public List<MenuOption> Options { get; private set; }
    }
}
