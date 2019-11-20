using Guards;
using Kledex.Events;
using MyLunch.Domain.Menu.Events;
using System.Linq;
using System.Threading.Tasks;

namespace MyLunch.Application.Menu.EventHandlers
{
    public class MenuGroupAddedEventHandler : IEventHandlerAsync<MenuGroupAdded>
    {
        private readonly MenuDbContext _db;

        public MenuGroupAddedEventHandler(MenuDbContext db)
        {
            Guard.ArgumentNotNull(() => db);

            _db = db;
        }

        public async Task HandleAsync(MenuGroupAdded e)
        {
            _db.MenuGroups.Add(new Entities.MenuGroup
            {
                Id = e.Id,
                Menu = _db.Menus.Single(m => m.Id == e.AggregateRootId),
                Name = e.Name
            });

            await _db.SaveChangesAsync();
        }
    }
}
