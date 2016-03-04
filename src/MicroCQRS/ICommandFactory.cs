using SchwabenCode.MicroCQRS.DefaultFactories;

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
        void Execute<TCommand, TCommandNotificator>( TCommand command, TCommandNotificator commandNotificator = null )
            where TCommand : class, ICommand
            where TCommandNotificator : class, ICommandNotificator;
    }
}
