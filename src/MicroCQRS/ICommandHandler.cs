using SchwabenCode.MicroCQRS.DefaultFactories;

namespace SchwabenCode.MicroCQRS
{
    /// <summary>
    /// Contract for command handlers. Implements the logic to run.
    /// </summary>
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Execute( TCommand command );
    }


    /// <summary>
    /// Contract for command handlers with command executed notificator. Implements the logic to run.
    /// </summary>
    public interface ICommandHandler<in TCommand, in TCommandNotificator>
        where TCommand : ICommand
        where TCommandNotificator : ICommandNotificator

    {
        void Execute( TCommand command, TCommandNotificator resultNotificator );
    }
}
