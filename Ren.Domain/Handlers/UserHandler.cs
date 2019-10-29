using FluentValidator;
using Ren.Domain.Commands.Inputs.Users;
using Ren.Domain.Commands.Results;
using Ren.Domain.Entities;
using Ren.Domain.Repositories;
using Ren.Domain.ValueObjects;
using Ren.Shared.Commands;
using Ren.Domain.Util;

namespace Ren.Domain.Handlers
{
    public class UserHandler : Notifiable, ICommandHandler<CreateUserCommand>, ICommandHandler<EditUserCommand>,
        ICommandHandler<AuthCommand>, ICommandHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _repository;

        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateUserCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var password = new Password(command.Password);

            var user = new User(name, document, command.Phone, email, password, command.Image);

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(password.Notifications);

            if (Invalid)
                return new CommandResult(MessagesUtil.InvalidInputs, false, Notifications);
            
            _repository.Create(user);
            return new CommandResult(MessagesUtil.CreatedSuccess, true, null);
        }

        public ICommandResult Handle(EditUserCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);

            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);

            if (Invalid)
                return new CommandResult(MessagesUtil.EditedError, false, Notifications);
            
            _repository.Edit(command);
            return new CommandResult(MessagesUtil.EditedSuccess, true, null);
        }

        public ICommandResult Handle(AuthCommand command)
        {
            var email = new Email(command.Email);
            var password = new Password(command.Password);

            AddNotifications(email.Notifications);
            AddNotifications(password.Notifications);

            if (Invalid)
                return new CommandResult(MessagesUtil.CreatedError, false, Notifications);

            var user = _repository.Login(new AuthCommand(email.Address, password.Value));
            if (user == null)
                return new CommandResult(MessagesUtil.NotFound.Replace("{0}", "Usuário"), false, null);

            return new CommandResult(MessagesUtil.SuccessAuth, true, user);
        }

        public ICommandResult Handle(DeleteUserCommand command)
        {
            if (command.ID == null)
                return new CommandResult(MessagesUtil.DeleteError, false, null);
            
            _repository.Delete(command.ID);
            return new CommandResult(MessagesUtil.DeletedSuccess, true, null);
        }
    }
}