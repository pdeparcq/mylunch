using Guards;
using Kledex.Queries;
using MyLunch.Application.Menu.Entities;
using System.Threading.Tasks;

namespace MyLunch.Application.Menu.Queries.Handlers
{
    public class GetRestaurantHandler : IQueryHandlerAsync<GetRestaurant, Entities.Restaurant>
    {
        private readonly MenuDbContext _db;

        public GetRestaurantHandler(MenuDbContext db)
        {
            Guard.ArgumentNotNull(() => db);

            _db = db;
        }
        public async Task<Entities.Restaurant> HandleAsync(GetRestaurant query)
        {
            return await _db.Restaurants.FindAsync(query.RestaurantId);
        }
    }
}
