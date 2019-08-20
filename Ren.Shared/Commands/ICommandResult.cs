namespace Ren.Shared.Commands
{
    public interface ICommandResult
    {
        string message { get; set; }
        bool status { get; set; }
        object data { get; set; }
    }
}