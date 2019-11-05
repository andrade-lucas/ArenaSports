using FluentValidator;
using FluentValidator.Validation;
using Ren.Domain.Util;

namespace Ren.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            Address = address;

            AddNotifications(new ValidationContract()
                .IsNotNull(Address, "Email", MessagesUtil.InvalidProperty.Replace("{0}", "E-mail"))
                .IsEmail(Address, "Email", MessagesUtil.InvalidProperty.Replace("{0}", "E-mail"))
            );
        }
    }
}