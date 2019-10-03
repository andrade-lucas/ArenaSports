using System;
using Ren.Domain.Enums;
using Ren.Shared.Commands;

namespace Ren.Domain.Commands.Inputs.Projects
{
    public class EditProjectCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedAt => DateTime.Now;
        public Guid OwnerId { get; set; }
        public EProjectStatus Status { get; set; }
    }
}