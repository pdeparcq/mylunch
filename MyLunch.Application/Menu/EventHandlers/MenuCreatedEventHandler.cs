using System.Linq;
using System.Threading.Tasks;
using Guards;
using Kledex.Events;
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
            await _db.Menus.AddAsync(new Entities.Menu
            {
                Id = e.Id,
                RestaurantId = e.RestaurantId,
                State = Domain.Menu.MenuState.UnderConstruction
            });
        }
    }
}
