﻿using System.Linq;
using System.Threading.Tasks;
using Guards;
using Kledex.Events;
using MyLunch.Application.Menu.Entities;
using MyLunch.Domain.Menu.Events;

namespace MyLunch.Application.Menu.EventHandlers
{
    public class MenuCreatedEventHandler : IEventHandlerAsync<MenuCreated>
    {
        private readonly MenuDbContext _db;

        public MenuCreatedEventHandler(MenuDbContext db)
        {
            Guard.ArgumentNotNull(() => db);

            _db = db;
        }

        public async Task HandleAsync(MenuCreated e)
        {
            _db.Menus.Add(new Entities.Menu
            {
                Id = e.AggregateRootId,
                Restaurant = _db.Restaurants.Single(r => r.Id == e.RestaurantId),
                State = Domain.Menu.MenuState.UnderConstruction
            });

            await _db.SaveChangesAsync();
        }
    }
}
