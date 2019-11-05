using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ren.Domain.ValueObjects;

namespace Ren.Tests.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public void ShouldReturnInvalidWhenEmailIsNull()
        {
            Email email = new Email(null);
            Assert.AreNotEqual(true, email.Notifications.Count == 0);
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenEmailIsInvalid()
        {
            Email email = new Email("invalid.email");
            Assert.AreEqual(true, email.Invalid);
        }

        [TestMethod]
        public void ShouldReturnValidWhenEmailIsValid()
        {
            Email email = new Email("valid.email@rensoftware.com");
            Assert.AreEqual(0, email.Notifications.Count);
        }
    }
}