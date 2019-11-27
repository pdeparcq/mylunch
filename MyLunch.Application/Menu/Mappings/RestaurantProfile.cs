using AutoMapper;
using MyLunch.Application.Menu.ViewModels;

namespace MyLunch.Application.Menu.Mappings
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Entities.Restaurant, RestaurantViewModel>();
            CreateMap<Entities.Menu, RestaurantMenuViewModel>();
        }
    }
}
