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
            this._validName = new Name("FirstName", "LastName");
            this._validDocument = new Document("636.950.730-04"); // Document gerenated by https://www.4devs.com.br/gerador_de_cpf
            this._validEmail = new Email("valid.email@rensoftware.com");
            this._validPassword = new Password("vAl1dP4s$");

            // Invalid Properties.
            this._validName = new Name("", "");
            this._validDocument = new Document("12345678911");
            this._validEmail = new Email("invalid.email");
            this._validPassword = new Password("123");
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenUserIsInvalid()
        {
            User user = new User(_invalidName, _invalidDocument, "", _invalidEmail, _invalidPassword, "");
            Assert.AreEqual(false, user.Invalid);
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenDocumentIsInvalid()
        {
            User user = new User(_validName, _invalidDocument, "", _validEmail, _validPassword, "");
            Assert.AreNotEqual(0, user.Notifications.Count);
        }
        
        [TestMethod]
        public void ShouldReturnValidWhenUserIsValid()
        {
            User user = new User(_validName, _validDocument, "", _validEmail, _validPassword, "");
            Assert.AreEqual(0, user.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnValidWhenInstantiateAnUserById()
        {
            User user = new User(Guid.NewGuid(), _validName, EUserStatus.Active);
            Assert.AreEqual(0, user.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnUserNameWhenGetUserToString()
        {
            User user = new User(_validName, _validDocument, "", _validEmail, _validPassword, "");
            string a = user.ToString();
            Assert.AreEqual("FirstName LastName", user.ToString());
        }

        [TestMethod]
        public void ShouldReturnValidWhenChangeUserStatus()
        {
            User user = new User(_validName, _validDocument, "", _validEmail, _validPassword, "");
            user.ChangeStatus(EUserStatus.Inactive);
            Assert.AreEqual(user.Status, EUserStatus.Inactive);
        }
    }
}