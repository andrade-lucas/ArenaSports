using FluentValidator;
using FluentValidator.Validation;
using Ren.Domain.Util;

namespace Ren.Domain.ValueObjects
{
    public class Document : Notifiable
    {
        public string Number { get; private set; }

        public Document(string number)
        {
            if (number != null)
                Number = number.Trim().Replace(".", "").Replace("-", "");

            AddNotifications(new ValidationContract()
                .Requires()
                .IsTrue(IsCpf(), "Document", MessagesUtil.InvalidProperty.Replace("{0}", "DocumentTrue"))
                .IsNotNull(Number, "Document", MessagesUtil.InvalidProperty.Replace("{0}", "DocumentNull"))
            );
        }

        private bool IsCpf()
        {
            if (Number != null)
            {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                int soma;
                int resto;
                Number = Number.Trim();
                Number = Number.Replace(".", "").Replace("-", "");
                if (Number.Length != 11)
                    return false;
                tempCpf = Number.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                return Number.EndsWith(digito);
            }
            return false;
        }
    }
}