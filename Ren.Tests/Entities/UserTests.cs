using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ren.Domain.Entities;
using Ren.Domain.Enums;
using Ren.Domain.ValueObjects;

namespace Ren.Tests.Entities
{
    [TestClass]
    public class UserTests
    {
        // Valid Properties.
        private readonly Name _validName;
        private readonly Document _validDocument;
        private readonly Email _validEmail;
        private readonly Password _validPassword;

        // Invalid Properties.
        private readonly Name _invalidName;
        private readonly Document _invalidDocument;
        private readonly Email _invalidEmail;
        private readonly Password _invalidPassword;

        public UserTests()
        {
            // Valid Properties.
            _validName = new Name("FirstName", "LastName");
            _validDocument = new Document("636.950.730-04"); // Document gerenated by https://www.4devs.com.br/gerador_de_cpf
            _validEmail = new Email("valid.email@rensoftware.com");
            _validPassword = new Password("vAl1dP4s$");

            // Invalid Properties.
            _invalidName = new Name("", "");
            _invalidDocument = new Document("12345678911");
            _invalidEmail = new Email("invalid.email");
            _invalidPassword = new Password("123");
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnInvalidWhenUserIsInvalid()
        {
            User user = new User(_invalidName, _invalidDocument, "", _invalidEmail, _invalidPassword, "");
            Assert.AreEqual(true, user.Invalid);
        }
        
        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnValidWhenUserIsValid()
        {
            User user = new User(_validName, _validDocument, "", _validEmail, _validPassword, "");
            Assert.AreEqual(0, user.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnValidWhenInstantiateAnUserById()
        {
            User user = new User(Guid.NewGuid(), _validName, EUserStatus.Active);
            Assert.AreEqual(0, user.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnUserNameWhenGetUserToString()
        {
            User user = new User(_validName, _validDocument, "", _validEmail, _validPassword, "");
            string a = user.ToString();
            Assert.AreEqual("FirstName LastName", user.ToString());
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnValidWhenChangeUserStatus()
        {
            User user = new User(_validName, _validDocument, "", _validEmail, _validPassword, "");
            user.ChangeStatus(EUserStatus.Inactive);
            Assert.AreEqual(user.Status, EUserStatus.Inactive);
        }
    }
}