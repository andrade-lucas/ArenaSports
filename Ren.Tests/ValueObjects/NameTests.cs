using Ren.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ren.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void ShouldReturnValid()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void ShouldReturnInvalid()
        {
            Assert.AreEqual(false, true);
        }
        // [TestMethod]
        // public void ShouldReturnInvalidWhenNameIsNull()
        // {
        //     Name name = new Name(null, null);
        //     Assert.AreEqual(true, name.Invalid);
        // }

        // [TestMethod]
        // public void ShouldReturnInvalidWhenFirstNameIsNull()
        // {
        //     Name name = new Name(null, "LastName");
        //     Assert.AreNotEqual(true, name.IsValid);
        // }

        // [TestMethod]
        // public void ShouldReturnInvalidWhenLastNameIsNull()
        // {
        //     Name name = new Name("FirstName", null);
        //     Assert.AreEqual(false, name.Invalid);
        // }

        // [TestMethod]
        // public void ShouldReturnInvalidWhenNameLengthIsInvalid()
        // {
        //     Name name = new Name("F", "L");
        //     Assert.AreNotEqual(true, name.IsValid);
        // }

        // [TestMethod]
        // public void ShouldReturnValidWhenNameIsValid()
        // {
        //     Name name = new Name("FirstName", "LastName");
        //     Assert.AreEqual(true, name.IsValid);
        // }
    }
}