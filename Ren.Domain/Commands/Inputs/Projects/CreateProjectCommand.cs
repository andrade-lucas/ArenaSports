using System;
using Ren.Shared.Commands;

namespace Ren.Domain.Commands.Inputs.Projects
{
    public class CreateProjectCommand : ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid OwnerId { get; set; }
    }
}