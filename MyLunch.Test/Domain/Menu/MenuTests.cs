using MyLunch.Domain.Menu;
using NUnit.Framework;
using System;
using System.Linq;

namespace MyLunch.Test.Domain
{
    [TestFixture]
    public class MenuTests
    {
        [Test]
        public void CanCreateMenu()
        {
            var menu = new MyLunch.Domain.Menu.Menu(Guid.NewGuid());

            Assert.AreNotEqual(Guid.Empty, menu.Id);
            Assert.AreEqual(MenuState.UnderConstruction, menu.State);
            Assert.IsNull(menu.StartDate);
            Assert.IsNull(menu.EndDate);
            Assert.IsEmpty(menu.Groups);
            Assert.IsEmpty(menu.Items);
        }

        [Test]
        public void CanAddMenuGroup()
        {
            var menu = new MyLunch.Domain.Menu.Menu(Guid.NewGuid());
            var group = new MenuGroup(Guid.NewGuid(), "Broodjes");

            menu.AddMenuGroup(group);

            Assert.IsNotEmpty(menu.Groups);
            
            var first = menu.Groups.First();

            Assert.AreEqual(group.Id, first.Id);
            Assert.AreEqual(group.Name, first.Name);
        }

        [Test]
        public void CanAddMenuItems()
        {
            var menu = new MyLunch.Domain.Menu.Menu(Guid.NewGuid());
            var group = new MenuGroup(Guid.NewGuid(), "Broodjes");
            var item = new MenuItem(Guid.NewGuid(), group.Id, "Hoevekaas", "Hoevekaas, light mosterddressing of mayo, wortel, tomaat, krokante sla", 3.3);

            menu.AddMenuGroup(group);
            menu.AddMenuItem(item);

            Assert.IsNotEmpty(menu.Items);

            var first = menu.Items.First();

            Assert.AreEqual(item.Id, first.Id);
            Assert.AreEqual(group.Id, first.GroupId);
            Assert.AreEqual(item.ProductName, first.ProductName);
            Assert.AreEqual(item.ProductDescription, first.ProductDescription);
            Assert.AreEqual(item.Price, first.Price);
        }
    }
}
