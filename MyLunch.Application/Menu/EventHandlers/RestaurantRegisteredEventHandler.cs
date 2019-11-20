using Guards;
using Kledex.Events;
using MyLunch.Domain.Menu.Events;
using System.Threading.Tasks;

namespace MyLunch.Application.Menu.EventHandlers
{
    public class RestaurantRegisteredEventHandler : IEventHandlerAsync<RestaurantRegistered>
    {
        private readonly MenuDbContext _db;

        public RestaurantRegisteredEventHandler(MenuDbContext db)
        {
            Guard.ArgumentNotNull(() => db);

            _db = db;
        }
        public async Task HandleAsync(RestaurantRegistered e)
        {
            _db.Restaurants.Add(new Entities.Restaurant
            {
                Id = e.AggregateRootId,
                Name = e.Name,
                ContactEmail = e.ContactEmail.Value
            });

            await _db.SaveChangesAsync();
        }
    }
}
