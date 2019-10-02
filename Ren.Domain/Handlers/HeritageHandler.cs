using FluentValidator;
using Ren.Domain.Commands.Inputs.Heritage;
using Ren.Domain.Repositories;
using Ren.Shared.Commands;

namespace Ren.Domain.Handlers
{
    public class HeritageHandler : Notifiable, ICommandHandler<CreateHeritageCommand>
    {
        private readonly IHeritageRepository _repository;

        public HeritageHandler(IHeritageRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateHeritageCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}