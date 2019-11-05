using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ren.Domain.ValueObjects;

namespace Ren.Tests.ValueObjects
{
    [TestClass]
    public class PasswordTests
    {
        [TestMethod]
        public void ShouldReturnInvalidWhenPasswordIsNull()
        {
            Password pass = new Password(null);
            Assert.AreNotEqual(true, pass.Valid);
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenPasswordLengthIsLessThenSix()
        {
            Password pass = new Password("123");
            Assert.AreEqual(true, pass.Invalid);
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenPasswordLengthIsMoreThenTwenty()
        {
            Password pass = new Password("12345678912345678912345");
            Assert.AreNotEqual(0, pass.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnValidWhenPasswordIsValid()
        {
            Password pass = new Password("vAl1dP4s$");
            Assert.AreEqual(0, pass.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenChangePasswordHasInvalidOldPassword()
        {
            Password pass = new Password("vAl1dP4s$");
            pass.Change("ValidPass", "NewPass");
            Assert.AreNotEqual(true, pass.Valid);
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenChangePasswordHasInvalidNewPassword()
        {
            Password pass = new Password("vAl1dP4s$");
            pass.Change("vAl1dP4s$", "123");
            Assert.AreNotEqual(true, pass.Valid);
        }

        [TestMethod]
        public void ShouldReturnValidWhenChangePasswordIsValid()
        {
            Password pass = new Password("vAl1dP4s$");
            pass.Change(new Password("vAl1dP4s$").ToString(), "nEwV4l1DP@s$");
            Assert.AreEqual(true, pass.Valid);
        }

        [TestMethod]
        public void ShouldReturnValidWhenPasswordIsEncrypted()
        {
            string passValue = "vAl1dP4s$";
            Password pass = new Password(passValue);
            Assert.AreNotEqual(passValue, pass.Value);
        }
    }
}