using Guards;
using Kledex.Events;
using MyLunch.Application.Menu.Entities;
using MyLunch.Domain.Menu.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLunch.Application.Menu.EventHandlers
{
    public class MenuItemAddedEventHandler : IEventHandlerAsync<MenuItemAdded>
    {
        private readonly MenuDbContext _db;

        public MenuItemAddedEventHandler(MenuDbContext db)
        {
            Guard.ArgumentNotNull(() => db);

            _db = db;
        }

        public async Task HandleAsync(MenuItemAdded e)
        {
            _db.MenuItems.Add(new Entities.MenuItem
            {
                Id = e.Id,
                MenuGroup = _db.MenuGroups.Single(g => g.Id == e.GroupId),
                ProductName = e.ProductName,
                ProductDescription = e.ProductDescription,
                Price = e.Price
            });

            await _db.SaveChangesAsync();
        }
    }
}
