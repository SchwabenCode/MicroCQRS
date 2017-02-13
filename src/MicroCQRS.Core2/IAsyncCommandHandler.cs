using System.Threading.Tasks;

namespace SchwabenCode.MicroCQRS.Core
{
    /// <summary>
    /// IAsyncCommandHandler
    /// </summary>
    public interface IAsyncCommandHandler<in TCommand> where TCommand : ICommand
    {
        /// <summary>
        /// Executes given command
        /// </summary>
        Task ExecuteAsync(TCommand command);
    }
}