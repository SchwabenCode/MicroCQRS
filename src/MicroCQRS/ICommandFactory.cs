namespace SchwabenCode.MicroCQRS
{
    /// <summary>
    /// The command factory searches for all matching command handlers and runs them
    /// </summary>
    public interface ICommandFactory
    {
        /// <summary>
        /// Executes the command.
        /// </summary>
        void Execute<TCommand>( TCommand command ) where TCommand : class, ICommand;
    }
}
