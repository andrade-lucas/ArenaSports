using Ren.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ren.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ShouldReturnInvalidWhenDocumentIsInvalid()
        {
            Document document = new Document("12345678911");
            Assert.AreEqual(true, document.Invalid);
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenDocumentIsNull()
        {
            Document document = new Document(null);
            Assert.AreNotEqual(true, document.IsValid);
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenDocumentLengthIsInvalid()
        {
            Document document = new Document("123");
            Assert.AreNotEqual(true, document.IsValid);
        }

        [TestMethod]
        public void ShouldReturnValidWhenDocumentIsValid()
        {
            Document document = new Document("30393227022"); // Document gerenated by https://www.4devs.com.br/gerador_de_cpf
            Assert.AreEqual(true, document.IsValid);
        }
    }
}