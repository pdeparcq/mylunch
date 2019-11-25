using MyLunch.Domain.Menu;
using System;
using System.Collections.Generic;

namespace MyLunch.Application.Menu.ViewModels
{
    public class RestaurantViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public List<RestaurantMenuViewModel> Menus { get; set; }
    }

    public class RestaurantMenuViewModel
    {
        public Guid Id { get; set; }
        public MenuState State { get; set; }
    }
}
