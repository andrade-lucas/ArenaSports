using System;
using FluentValidator;
using Ren.Domain.Commands.Inputs.Heritages;
using Ren.Domain.Commands.Results;
using Ren.Domain.Entities;
using Ren.Domain.Repositories;
using Ren.Domain.Util;
using Ren.Shared.Commands;

namespace Ren.Domain.Handlers
{
    public class HeritageHandler : Notifiable, ICommandHandler<CreateHeritageCommand>,
        ICommandHandler<EditHeritageCommand>, ICommandHandler<DeleteHeritageCommand>
    {
        private readonly IHeritageRepository _repository;

        public HeritageHandler(IHeritageRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateHeritageCommand command)
        {
            var heritage = new Heritage(command.Description, command.PurchaseDate, command.Status, command.BarCode);

            AddNotifications(heritage);
            if (Invalid)
                return new CommandResult(MessagesUtil.CreatedError, false, Notifications);
            
            _repository.Create(heritage);
            return new CommandResult(MessagesUtil.CreatedSuccess, true);
        }

        public ICommandResult Handle(EditHeritageCommand command)
        {
            var heritage = new Heritage(command.Id, command.Description, command.PurchaseDate, command.Status, command.BarCode);

            throw new System.NotImplementedException();
        }

        public ICommandResult Handle(DeleteHeritageCommand command)
        {
            string id = command.Id.ToString();
            if (string.IsNullOrEmpty(id))
                AddNotification("Identifier", MessagesUtil.InvalidIdentifier);

            if (Invalid)
                return new CommandResult(MessagesUtil.DeleteError, true);

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