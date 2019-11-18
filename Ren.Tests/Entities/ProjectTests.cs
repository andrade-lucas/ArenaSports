using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ren.Domain.Entities;
using Ren.Domain.Enums;
using Ren.Domain.ValueObjects;

namespace Ren.Tests.Entities
{
    [TestClass]
    public class ProjectTests
    {
        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnInvalidWhenHasNoOwner()
        {
            var project = new Project("Project", "My new project", DateTime.Now, null, EProjectStatus.Created);
            Assert.AreNotEqual(true, project.Valid);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnValidWhenChangeProjectStatus()
        {
            var owner = new User(Guid.NewGuid(), new Name("FirstName", "LastName"), EUserStatus.Active);
            var project = new Project("Project", "", DateTime.Now, owner, EProjectStatus.Created);
            project.ChangeStatus(EProjectStatus.Active);
            Assert.AreEqual(0, project.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnValidWhenProjectIsValid()
        {
            var owner = new User(Guid.NewGuid(), new Name("FirstName", "LastName"), EUserStatus.Active);
            var project = new Project("Project", "My new project", DateTime.Now, owner, EProjectStatus.Created);
            Assert.AreEqual(true, project.Valid);
        }
    }
}