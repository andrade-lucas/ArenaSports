using System;
using Ren.Shared.Commands;

namespace Ren.Domain.Commands.Inputs.Users
{
    public class DeleteUserCommand : ICommand
    {
        public Guid ID { get; set; }
    }
}