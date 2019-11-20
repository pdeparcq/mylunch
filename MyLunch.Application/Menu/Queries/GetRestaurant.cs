using Kledex.Queries;
using System;

namespace MyLunch.Application.Menu.Queries
{
    public class GetRestaurant : IQuery<Entities.Restaurant>
    {
        public Guid RestaurantId { get; set; }
    }
}
