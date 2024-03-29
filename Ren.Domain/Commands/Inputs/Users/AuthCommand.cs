using Ren.Shared.Commands;

namespace Ren.Domain.Commands.Inputs.Users
{
    public class AuthCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public AuthCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}