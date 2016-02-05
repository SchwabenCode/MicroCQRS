namespace SchwabenCode.MicroCQRS
{
    /// <summary>
    /// Contract for command handlers. Implements the logic to run.
    /// </summary>
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Execute( TCommand command );
    }
}
