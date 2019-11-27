using System.Linq;
using System.Threading.Tasks;
using Guards;
using Kledex.Commands;
using Kledex.Domain;
using Microsoft.Extensions.Logging;

namespace MyLunch.Application.Menu.Commands.Handlers
{
    public class RegisterRestaurantHandler : ICommandHandlerAsync<RegisterRestaurant>
    {
        private readonly ILogger<RegisterRestaurantHandler> _logger;

        public RegisterRestaurantHandler(IRepository<Domain.Menu.Restaurant> repository, ILogger<RegisterRestaurantHandler> logger)
        {
            Guard.ArgumentNotNull(() => logger);

            _logger = logger;
        }

        public async Task<CommandResponse> HandleAsync(RegisterRestaurant command)
        {
            // Register restaurant
            var restaurant = new Domain.Menu.Restaurant(command.RestaurantName, command.ContactEmailAddress);

            // Create first menu for restaurant
            var menu = new Domain.Menu.Menu(restaurant.Id);
            
            return await Task.FromResult(new CommandResponse
            {
                Events = restaurant.Events.Concat(menu.Events)
            });
        }
    }
}
