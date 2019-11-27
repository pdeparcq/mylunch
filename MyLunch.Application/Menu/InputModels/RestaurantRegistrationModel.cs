using System.ComponentModel.DataAnnotations;

namespace MyLunch.Application.Menu.InputModels
{
    public class RestaurantRegistrationModel
    {
        [Required(AllowEmptyStrings = false)]
        public string RestaurantName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ContactEmailAddress { get; set; }
    }
}
