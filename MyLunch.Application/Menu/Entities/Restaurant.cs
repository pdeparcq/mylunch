using System;
using System.Collections.Generic;

namespace MyLunch.Application.Menu.Entities
{
    public class Restaurant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public virtual ICollection<Menu> Menus { get; private set; }
    }
}
