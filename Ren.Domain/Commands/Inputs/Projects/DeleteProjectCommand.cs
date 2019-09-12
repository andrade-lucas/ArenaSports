using System;
using Ren.Shared.Commands;

namespace Ren.Domain.Commands.Inputs.Projects
{
    public class DeleteProjectCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}