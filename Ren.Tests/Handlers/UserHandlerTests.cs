using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ren.Domain.Commands.Inputs.Users;
using Ren.Domain.Enums;
using Ren.Domain.Handlers;
using Ren.Domain.Repositories;
using Ren.Tests.Mocks.Repositories;

namespace Ren.Tests.Handlers
{
    [TestClass]
    public class UserHandlerTests
    {
        private readonly IUserRepository _userRepository;

        public UserHandlerTests()
        {
            _userRepository = new UserRepository();
        }

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
            var command = new CreateUserCommand();
            command.FirstName = "FirstName";
            command.LastName = "LastName";
            command.Document = "1234";
            command.Email = "valid.email@example.com";
            command.Password = "password";
            command.Phone = "99999999999";
            command.Image = "";
            var handler = new UserHandler(_userRepository);
            handler.Handle(command);
            Assert.AreNotEqual(true, handler.Valid);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldReturnValidWhenCreateCommandIsValid()
        {
            var command = new CreateUserCommand();
            command.FirstName = "FirstName";
            command.LastName = "LastName";
            command.Document = "87384428092";
            command.Email = "valid.email@example.com";
            command.Password = "password";
            command.Phone = "99999999999";
            command.Image = "";
            var handler = new UserHandler(_userRepository);
            handler.Handle(command);
            Assert.AreEqual(true, handler.Valid);
        }
    }
}