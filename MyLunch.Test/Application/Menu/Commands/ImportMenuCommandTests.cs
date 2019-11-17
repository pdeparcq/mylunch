using Kledex.Domain;
using Microsoft.Extensions.Logging;
using Moq;
using MyLunch.Application.Menu.Commands;
using MyLunch.Application.Menu.Commands.Handlers;
using MyLunch.Application.Menu.Commands.Validators;
using MyLunch.Domain.Menu.Events;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLunch.Test.Application.Menu.Commands
{
    [TestFixture]
    public class ImportMenuCommandTests
    {
        [Test]
        public void CanValidateImportMenuCommand()
        {
            var validator = new ImportMenuValidator();

            var result = validator.Validate(CreateCommand(Guid.NewGuid()));

            Assert.IsTrue(result.IsValid);

            result = validator.Validate(new ImportMenu
            {
                AggregateRootId = Guid.NewGuid(),
                MenuItems = new List<MyLunch.Application.Menu.InputModels.MenuItemModel>()
            });

            Assert.IsFalse(result.IsValid);
        }

        [Test]
        public async Task CanHandleImportMenuCommand()
        {
            var menuRepositoryMock = new Mock<IRepository<MyLunch.Domain.Menu.Menu>>();
            var loggerMock = new Mock<ILogger<ImportMenuHandler>>();
            var menu = new MyLunch.Domain.Menu.Menu(Guid.NewGuid());

            menuRepositoryMock.Setup(x => x.GetByIdAsync(menu.Id)).Returns(Task.FromResult(menu));

            var handler = new ImportMenuHandler(menuRepositoryMock.Object, loggerMock.Object);

            var result = await handler.HandleAsync(CreateCommand(menu.Id));

            Assert.NotNull(result);
            Assert.AreEqual(2, result.Events.OfType<MenuGroupAdded>().Count());
            Assert.AreEqual(4, result.Events.OfType<MenuItemAdded>().Count());
        }

        private static ImportMenu CreateCommand(Guid menuId)
        {
            return new ImportMenu
            {
                AggregateRootId = menuId,
                MenuItems = new List<MyLunch.Application.Menu.InputModels.MenuItemModel>()
                {
                    new MyLunch.Application.Menu.InputModels.MenuItemModel
                    {
                        GroupName = "Broodjes",
                        ProductName = "Hoevekaas",
                        ProductDescription = "Hoevekaas, light mosterddressing of mayo, wortel, tomaat, krokante sla",
                        Price = 3.3
                    },
                    new MyLunch.Application.Menu.InputModels.MenuItemModel
                    {
                        GroupName = "Broodjes",
                        ProductName = "Ambachtelijke Ham",
                        ProductDescription = "Ambachtelijke ham, augurk, light mosterddressing of mayo, tomaat, krokante sla",
                        Price = 3.3
                    },
                    new MyLunch.Application.Menu.InputModels.MenuItemModel
                    {
                        GroupName = "Dranken",
                        ProductName = "Coca-Cola",
                        Price = 1.5
                    },
                    new MyLunch.Application.Menu.InputModels.MenuItemModel
                    {
                        GroupName = "Dranken",
                        ProductName = "Ice-Tea Zero",
                        Price = 1.5
                    }
                }
            };
        }
    }
}
