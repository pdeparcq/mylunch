using Kledex.Domain;
using MyLunch.Application.Menu.InputModels;
using System.Collections.Generic;

namespace MyLunch.Application.Menu.Commands
{
    public class ImportMenu : DomainCommand<Domain.Menu.Menu>
    {
        public List<MenuItemModel> MenuItems { get; set; }
    }
}
