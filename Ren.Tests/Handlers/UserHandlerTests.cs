using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ren.Domain.Commands.Inputs.Users;
using Ren.Domain.Enums;
using Ren.Domain.Handlers;
using Ren.Domain.Repositories;

namespace Ren.Tests.Handlers
{
    [TestClass]
    public class UserHandlerTests
    {
        private readonly IUserRepository _userRepository;

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldReturnInvalidWhenUserNameIsNull()
        {
            var command = new CreateUserCommand();
            command.FirstName = null;
            command.LastName = null;
            command.Document = "06828764374";
            command.Email = "teste@example.com";
            command.Password = "password";
            command.Phone = "";
            command.Image = "";
            var handler = new UserHandler(_userRepository);
            handler.Handle(command);
            Assert.AreEqual(true, handler.Invalid);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldReturnInvalidWhenCreateCommandIsInvalid()
        {
            var command = new CreateUserCommand();
            command.FirstName = null;
            command.LastName = null;
            command.Document = "";
            command.Email = "";
            command.Password = "";
            command.Phone = "";
            command.Image = "";
            var handler = new UserHandler(_userRepository);
            handler.Handle(command);
            Assert.AreNotEqual(true, handler.Valid);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShoudlReturnInvalidWhenEditCommandIsInvalid()
        {
            var command = new EditUserCommand();
            command.Id = Guid.NewGuid();
            command.FirstName = "";
            command.LastName = "";
            command.Status = EUserStatus.Active;
            command.Email = "email@example.com";
            command.Phone = "";
            command.Image = "";
            var handler = new UserHandler(_userRepository);
            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldReturnInvalidWhenDocumentIsInvalid()
        {
            Assert.Fail();
        }
    }
}