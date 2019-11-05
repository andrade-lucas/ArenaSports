using System.Security.Cryptography;
using System.Text;
using FluentValidator;
using FluentValidator.Validation;
using Ren.Domain.Util;

namespace Ren.Domain.ValueObjects
{
    public class Password : Notifiable
    {
        public string Value { get; private set; }

        public Password(string value)
        {
            Value = !string.IsNullOrEmpty(value) ? Value = value.Trim() : "";

            Validate();
        }

        public void Encrypt()
        {
            byte[] temp;

            SHA1 sha = new SHA1CryptoServiceProvider();
            temp = sha.ComputeHash(Encoding.UTF8.GetBytes(Value));

            //storing hashed vale into byte data type
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < temp.Length; i++)
                sb.Append(temp[i].ToString("x2"));

            Value = sb.ToString();
        }

        public void Change(string oldPassword, string newPassword)
        {
            if (this.Value != oldPassword)
                AddNotification("Password", MessagesUtil.InvalidProperty.Replace("{0}", "Senha Antiga"));
            
            this.Value = !string.IsNullOrEmpty(newPassword) ? newPassword : "";
            Validate();
        }

        public override string ToString() => this.Value;

        private void Validate()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNull(Value, "Password", MessagesUtil.InvalidProperty.Replace("{0}", "Senha"))
                .HasMinLen(Value, 6, "Password", MessagesUtil.StringMinLength.Replace("{0}", "Senha").Replace("{1}", "6"))
                .HasMaxLen(Value, 20, "Password", MessagesUtil.StringMaxLength.Replace("{0}", "Senha").Replace("{1}", "20"))
            );
            Encrypt();
        }
    }
}