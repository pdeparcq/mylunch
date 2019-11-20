using System;
using System.Collections.Generic;

namespace MyLunch.Application.Menu.Entities
{
    public class MenuGroup
    {
        public Guid Id { get; set; }
        public Guid MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MenuItem> Items { get; set; }
    }
}
