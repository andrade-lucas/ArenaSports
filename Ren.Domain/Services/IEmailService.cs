namespace Ren.Domain.Services
{
    public interface IEmailService
    {
        void Send(string to, string subject, string content, string[] attachments = null);
    }
}