using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ren.Domain.Entities;
using Ren.Domain.Enums;

namespace Ren.Tests.Entities
{
    [TestClass]
    public class HeritageTests
    {
        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnInvalidWhenDescriptionIsEmpty()
        {
            var heritage = new Heritage("", DateTime.Now, EHeritageStatus.Aviable, "");
            Assert.AreEqual(true, heritage.Invalid);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnInvalidWhenPassingGuidWithEmptyDescription()
        {
            var heritage = new Heritage(Guid.NewGuid(), "", DateTime.Now, EHeritageStatus.Aviable, "");
            Assert.AreNotEqual(true, heritage.Valid);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnValidWhenHeritageIsValid()
        {
            var heritage = new Heritage("Heritage", DateTime.Now, EHeritageStatus.Aviable, "");
            Assert.AreEqual(true, heritage.Valid);
        }
    }
}