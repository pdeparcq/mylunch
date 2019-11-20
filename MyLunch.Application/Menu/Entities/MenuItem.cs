using System;

namespace MyLunch.Application.Menu.Entities
{
    public class MenuItem
    {
        public Guid Id { get; set; }
        public Guid MenuGroupId { get; set; }
        public virtual MenuGroup MenuGroup { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double Price { get; set; }
    }
}
