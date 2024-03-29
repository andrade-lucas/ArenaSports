using Ren.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ren.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        [TestCategory("ValueObjects")]
        public void ShouldReturnInvalidWhenNameIsNull()
        {
            Name name = new Name(null, null);
            Assert.AreEqual(true, name.Invalid);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void ShouldReturnInvalidWhenFirstNameIsNull()
        {
            Name name = new Name(null, "LastName");
            Assert.AreNotEqual(true, name.Valid);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void ShouldReturnInvalidWhenLastNameIsNull()
        {
            Name name = new Name("FirstName", null);
            Assert.AreEqual(true, name.Invalid);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void ShouldReturnInvalidWhenNameLengthIsInvalid()
        {
            Name name = new Name("F", "L");
            Assert.AreNotEqual(true, name.Valid);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void ShouldReturnValidWhenNameIsValid()
        {
            Name name = new Name("FirstName", "LastName");
            Assert.AreEqual(true, name.Valid);
        }
    }
}