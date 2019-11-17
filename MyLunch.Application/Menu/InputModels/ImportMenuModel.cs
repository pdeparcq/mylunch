using System;
using System.Collections.Generic;

namespace MyLunch.Application.Menu.InputModels
{
    public class ImportMenuModel
    {
        public Guid MenuId { get; set; }
        public List<MenuItemModel> MenuItems { get; set; }
    }
}
