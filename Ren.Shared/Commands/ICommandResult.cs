namespace Ren.Shared.Commands
{
    public interface ICommandResult
    {
        string Message { get; set; }
        bool Status { get; set; }
        object Data { get; set; }
    }
}