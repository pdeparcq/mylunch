using AutoMapper;
using Guards;
using Kledex;
using Microsoft.Extensions.Logging;
using MyLunch.Application.Menu.Commands;
using MyLunch.Application.Menu.InputModels;
using MyLunch.Application.Menu.Queries;
using MyLunch.Application.Menu.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyLunch.Application.Menu.Services
{
    public class RestaurantService
    {
        private readonly IDispatcher _dispatcher;
        private readonly ILogger<RestaurantService> _logger;
        private readonly IMapper _mapper;

        public RestaurantService(IDispatcher dispatcher, ILogger<RestaurantService> logger, IMapper mapper)
        {
            Guard.ArgumentNotNull(() => dispatcher);
            Guard.ArgumentNotNull(() => logger);
            Guard.ArgumentNotNull(() => mapper);

            _dispatcher = dispatcher;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task RegisterRestaurant(RestaurantRegistrationModel model)
        {
            try
            {
                await _dispatcher.SendAsync(new RegisterRestaurant
                {
                    RestaurantName = model.RestaurantName,
                    ContactEmailAddress = new Domain.Shared.EmailAddress(model.ContactEmailAddress)
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<RestaurantViewModel>> GetAllRestaurants()
        {
            try
            {
                return _mapper.Map<IEnumerable<Entities.Restaurant>, IEnumerable<RestaurantViewModel>>(await _dispatcher.GetResultAsync(new GetRestaurants()));
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }

        public async Task<RestaurantViewModel> GetRestaurantById(Guid id)
        {
            try
            {
                return _mapper.Map<Entities.Restaurant, RestaurantViewModel>(await _dispatcher.GetResultAsync(new GetRestaurant
                {
                    RestaurantId = id
                }));
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }
    }
}
