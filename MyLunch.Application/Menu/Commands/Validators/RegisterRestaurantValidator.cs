using FluentValidation;

namespace MyLunch.Application.Menu.Commands.Validators
{
    public class RegisterRestaurantValidator : AbstractValidator<RegisterRestaurant>
    {
        public RegisterRestaurantValidator()
        {
            RuleFor(c => c.RestaurantName).NotNull().NotEmpty();
        }
    }
}
