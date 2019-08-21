using Ren.Shared.Commands;

namespace Ren.Domain.Commands.Inputs.Users
{
    public class CreateUserCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
    }
}