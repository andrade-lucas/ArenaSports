using Ren.Domain.Services;

namespace Ren.Tests.Mocks.Services
{
    public class EmailServiceMocky : IEmailService
    {
        public void Send(string to, string subject, string content, string[] attachments = null)
        {
            // It's a mock file.
        }
    }
}