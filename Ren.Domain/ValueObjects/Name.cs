using FluentValidator;
using FluentValidator.Validation;

namespace Ren.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 2, "FirstName", "Este campo de conter pelo menos 2 caracteres")
                .HasMaxLen(FirstName, 60, "FirstName", "Este campo deve conter no máximo 60 caracteres")
                .HasMinLen(LastName, 2, "FirstName", "Este campo de conter pelo menos 2 caracteres")
                .HasMaxLen(LastName, 60, "FirstName", "Este campo deve conter no máximo 60 caracteres")
            );
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}