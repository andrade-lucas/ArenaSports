using Ren.Shared.Commands;

namespace Ren.Domain.Commands.Results
{
    public class CommandResult : ICommandResult
    {
        public string message { get; set; }
        public bool status { get; set; }
        public object data { get; set; }

        public CommandResult(string message, bool status, object data)
        {
            this.message = message;
            this.status = status;
            this.data = data;
        }
    }
}