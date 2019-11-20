using Microsoft.EntityFrameworkCore;
using MyLunch.Application.Menu;
using NUnit.Framework;
using System.Linq;

namespace MyLunch.Test.Application.Menu
{
    [TestFixture]
    public class MenuDbContextTests
    {
        [Test]
        public void CanCreateContext()
        {
            var options = new DbContextOptionsBuilder<MenuDbContext> ()
                           .UseInMemoryDatabase(databaseName: "Test")
                           .Options;

            using (var ctx = new MenuDbContext(options))
            {
                var menus = ctx.Menus.ToList();
            }
        }
    }
}
