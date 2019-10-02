using System;
using FluentValidator;
using Ren.Domain.Commands.Inputs.Projects;
using Ren.Domain.Commands.Results;
using Ren.Domain.Entities;
using Ren.Domain.Enums;
using Ren.Domain.Repositories;
using Ren.Domain.Util;
using Ren.Domain.ValueObjects;
using Ren.Shared.Commands;

namespace Ren.Domain.Handlers
{
    public class ProjectHandler : Notifiable, ICommandHandler<CreateProjectCommand>,
        ICommandHandler<EditProjectCommand>, ICommandHandler<DeleteProjectCommand>
    {
        private readonly IProjectRepository _repository;

        public ProjectHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateProjectCommand command)
        {
            var owner = _repository.GetOwner(command.OwnerId);
            var ownerName = new Name(owner.FirstName, owner.LastName);
            var user = new User(owner.OwnerId, ownerName, owner.Status);
            var project = new Project(command.Title, command.Description, DateTime.Now, DateTime.Now, user, EProjectStatus.Created);

            AddNotifications(ownerName.Notifications);
            AddNotifications(user.Notifications);
            AddNotifications(project.Notifications);

            if (Invalid)
                return new CommandResult(MessagesUtil.CreatedError, false, Notifications);
            if (user.Status == EUserStatus.Inactive)
                return new CommandResult(MessagesUtil.UserInactive, false);
            
            _repository.Create(project);
            return new CommandResult(MessagesUtil.CreatedSuccess, true);
        }

        public ICommandResult Handle(EditProjectCommand command)
        {
            var owner = _repository.GetOwner(command.OwnerId);
            var ownerName = new Name(owner.FirstName, owner.LastName);
            var user = new User(owner.OwnerId, ownerName, owner.Status);
            var project = new Project(command.Title, command.Description, DateTime.Now, user, command.Status);

            AddNotifications(ownerName.Notifications);
            AddNotifications(user.Notifications);
            AddNotifications(project.Notifications);

            if (Invalid)
                return new CommandResult(MessagesUtil.EditedError, false, Notifications);
            if (user.Status == EUserStatus.Inactive)
                return new CommandResult(MessagesUtil.UserInactive, false);

            _repository.Edit(command);
            return new CommandResult(MessagesUtil.EditedSuccess, true);
        }

        public ICommandResult Handle(DeleteProjectCommand command)
        {
            string id = command.Id.ToString();
            if (string.IsNullOrEmpty(id))
                return new CommandResult(MessagesUtil.InvalidIdentifier, false);
            
            try 
            {
                _repository.Delete(command);
                return new CommandResult(MessagesUtil.DeletedSuccess, true);
            }
            catch
            {
                return new CommandResult(MessagesUtil.DeleteError, false);
            }
        }
    }
}