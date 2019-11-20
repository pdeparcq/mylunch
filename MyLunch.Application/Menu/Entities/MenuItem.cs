using System;

namespace MyLunch.Application.Menu.Entities
{
    public class MenuItem
    {
        public Guid Id { get; set; }
        public Guid MenuGroupId { get; set; }
        public virtual MenuGroup MenuGroup { get; set; }
        public string ProductName { get; private set; }
        public string ProductDescription { get; private set; }
        public double Price { get; private set; }
    }
}
