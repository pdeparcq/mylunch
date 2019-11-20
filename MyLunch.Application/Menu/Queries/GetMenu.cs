using Kledex.Queries;
using System;

namespace MyLunch.Application.Menu.Queries
{
    public class GetMenu : IQuery<Entities.Menu>
    {
        public Guid MenuId { get; set; }
    }
}
