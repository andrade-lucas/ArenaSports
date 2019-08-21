using System;
using Ren.Domain.Enums;
using Ren.Shared.Commands;

namespace Ren.Domain.Commands.Inputs.Users
{
    public class EditUserCommand : ICommand
    {
        public Guid Id = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public EUserStatus Status { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
    }
}