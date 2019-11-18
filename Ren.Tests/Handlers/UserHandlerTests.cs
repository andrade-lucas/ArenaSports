using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ren.Domain.Commands.Inputs.Users;
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
        public void ShouldReturnInvalidWhenUserIsNull()
        {
            // var command = new CreateUserCommand();
            // command.FirstName = "";
            // command.LastName = "";
            // command.Document = "06828764374";
            // command.Email = "teste@example.com";
            // command.Password = "password";
            // command.Phone = "";
            // command.Image = "";
            // var handler = new UserHandler(_userRepository);
            // handler.Handle(command);
            // Assert.AreEqual(true, handler.Invalid);
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldReturnInvalidWhenCreateCommandIsInvalid()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShoudlReturnInvalidWhenEditCommandIsInvalid()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldReturnInvalidWhenDocumentIsInvalid()
        {
            Assert.Fail();
        }
    }
}