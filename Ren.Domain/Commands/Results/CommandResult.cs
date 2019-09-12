using Ren.Shared.Commands;

namespace Ren.Domain.Commands.Results
{
    public class CommandResult : ICommandResult
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public object Data { get; set; }

        public CommandResult(string message, bool status, object data = null)
        {
            this.Message = message;
            this.Status = status;
            this.Data = data;
        }
    }
}