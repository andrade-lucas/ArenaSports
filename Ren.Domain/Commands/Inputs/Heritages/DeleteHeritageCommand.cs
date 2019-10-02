using System;
using Ren.Shared.Commands;

namespace Ren.Domain.Commands.Inputs.Heritages
{
    public class DeleteHeritageCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}