using System.Security.Cryptography;
using System.Text;
using FluentValidator;
using FluentValidator.Validation;

namespace Ren.Domain.ValueObjects
{
    public class Password : Notifiable
    {
        public string Value { get; private set; }

        public Password(string value)
        {
            Value = value.Trim();
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(Value, 6, "Password", "A senha deve conter pelo menos 6 caracteres")
                .HasMaxLen(Value, 20, "Password", "A senha deve conter no máximo 20 caracteres")
            );

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

        public void Change(string newValue)
        {
            Value = newValue;
            Validate();
        }

        private void Validate()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(Value, 6, "Password", "A senha deve conter pelo menos 6 caracteres")
                .HasMaxLen(Value, 20, "Password", "A senha deve conter no máximo 20 caracteres")
            );
            Encrypt();
        }
    }
}