using FluentValidation;

namespace MyLunch.Application.Menu.Commands.Validators
{
    public class ImportMenuValidator : AbstractValidator<ImportMenu>
    {
        public ImportMenuValidator()
        {
            RuleFor(c => c.MenuItems).NotNull().NotEmpty();
        }
    }
}
