using FluentValidator;
using FluentValidator.Validation;
using Ren.Domain.Util;

namespace Ren.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName ?? "";
            LastName = lastName ?? "";

            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNull(FirstName, "FirstName", MessagesUtil.InvalidProperty.Replace("{0}", "Nome"))
                .HasMinLen(FirstName, 2, "FirstName", MessagesUtil.StringMinLength.Replace("{0}", "Nome").Replace("{1}", "2"))
                .HasMaxLen(FirstName, 60, "FirstName", MessagesUtil.StringMaxLength.Replace("{0}", "Nome").Replace("{1}", "60"))
                .IsNotNull(LastName, "LastName", MessagesUtil.InvalidProperty.Replace("{0}", "Sobrenome"))
                .HasMinLen(LastName, 2, "LastName", MessagesUtil.StringMinLength.Replace("{0}", "Sobrenome").Replace("{1}", "2"))
                .HasMaxLen(LastName, 60, "LasttName", MessagesUtil.StringMaxLength.Replace("{0}", "Sobrenome").Replace("{1}", "60"))
            );
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}