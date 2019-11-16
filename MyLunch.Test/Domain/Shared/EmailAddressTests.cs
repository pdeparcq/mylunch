using MyLunch.Domain.Shared;
using NUnit.Framework;
using System;

namespace MyLunch.Test.Domain.Shared
{
    [TestFixture]
    public class EmailAddressTests
    {
        [Test]
        public void CanCreateValidEmailAddress()
        {
            var email = new EmailAddress("info@taste-it-gent.be");

            Assert.AreEqual("info@taste-it-gent.be", email.Value);
        }

        [Test]
        public void CanNotCreateInvalidEmailAddress()
        {
            Assert.Catch<ArgumentException>(() => new EmailAddress("blabla"));
        }
    }
}
