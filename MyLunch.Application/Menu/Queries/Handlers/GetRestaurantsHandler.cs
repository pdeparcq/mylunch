using Guards;
using Kledex.Queries;
using MyLunch.Application.Menu.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLunch.Application.Menu.Queries.Handlers
{
    public class GetRestaurantsHandler : IQueryHandlerAsync<GetRestaurants, IEnumerable<Entities.Restaurant>>
    {
        private readonly MenuDbContext _db;

        public GetRestaurantsHandler(MenuDbContext db)
        {
            Guard.ArgumentNotNull(() => db);

            _db = db;
        }
        public async Task<IEnumerable<Entities.Restaurant>> HandleAsync(GetRestaurants query)
        {
            return await Task.FromResult(_db.Restaurants.ToList());
        }
    }
}
