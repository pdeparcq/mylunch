using System;
using System.Linq;
using System.Threading.Tasks;
using Guards;
using Kledex.Commands;
using Kledex.Domain;
using Microsoft.Extensions.Logging;
using MyLunch.Application.Menu.Exceptions;

namespace MyLunch.Application.Menu.Commands.Handlers
{
    public class ImportMenuHandler : ICommandHandlerAsync<ImportMenu>
    {
        private readonly IRepository<Domain.Menu.Menu> _repository;
        private readonly ILogger<ImportMenuHandler> _logger;

        public ImportMenuHandler(IRepository<Domain.Menu.Menu> repository, ILogger<ImportMenuHandler> logger)
        {
            Guard.ArgumentNotNull(() => repository);
            Guard.ArgumentNotNull(() => logger);

            _repository = repository;
            _logger = logger;
        }

        public async Task<CommandResponse> HandleAsync(ImportMenu command)
        {
            var menu = await _repository.GetByIdAsync(command.AggregateRootId);

            if (menu == null)
                throw new MenuNotFoundException();

            foreach(var item in command.MenuItems)
            {
                try
                {
                    var group = menu.Groups.FirstOrDefault(g => g.Name == item.GroupName);

                    if (group == null)
                    {
                        group = new Domain.Menu.MenuGroup(Guid.NewGuid(), item.GroupName);

                        menu.AddMenuGroup(group);
                    }

                    menu.AddMenuItem(new Domain.Menu.MenuItem(Guid.NewGuid(), group.Id, item.ProductName, item.ProductDescription, item.Price));
                }
                catch(Exception e)
                {
                    _logger.LogError(e, "Failed to import menu item");
                }
            }

            return new CommandResponse
            {
                Events = menu.Events
            };
        }
    }
}
