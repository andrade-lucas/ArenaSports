using Ren.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ren.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        [TestCategory("ValueObjects")]
        public void ShouldReturnInvalidWhenDocumentIsInvalid()
        {
            Document document = new Document("12345678911");
            Assert.AreEqual(true, document.Invalid);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void ShouldReturnInvalidWhenDocumentIsNull()
        {
            Document document = new Document(null);
            Assert.AreEqual(false, document.Valid);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void ShouldReturnInvalidWhenDocumentLengthIsInvalid()
        {
            Document document = new Document("123");
            Assert.AreNotEqual(true, document.Valid);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void ShouldReturnValidWhenDocumentIsValid()
        {
            Document document = new Document("30393227022");
            Assert.AreEqual(true, document.Valid);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void ShouldReturnInvalidWhenDocumentNumberIs()
        {
            Document document = new Document("00000000000");
            Assert.AreNotEqual(true, document.Valid);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void ShouldReturnInvalidWhenDocumentNumberIsZero()
        {
            Document document = new Document("00000000000");
            Assert.AreNotEqual(true, document.Valid);
        }
    }
}