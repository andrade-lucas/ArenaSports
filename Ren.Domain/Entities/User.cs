namespace Ren.Domain.Entities
{
    public class User
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }
        public bool Status { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Image { get; private set; }
    }
}