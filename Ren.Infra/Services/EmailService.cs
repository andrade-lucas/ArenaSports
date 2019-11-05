using Ren.Domain.Services;

namespace Ren.Infra.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string subject, string content, string[] attachments = null)
        {
            throw new System.NotImplementedException();
        }
    }
}