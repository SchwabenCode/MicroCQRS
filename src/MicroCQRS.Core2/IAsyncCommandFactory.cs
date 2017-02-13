using System.Threading.Tasks;

namespace SchwabenCode.MicroCQRS.Core
{
    /// <summary>
    /// A <see cref="IAsyncCommandFactory"/> knows all registered commands
    /// </summary>
    public interface IAsyncCommandFactory
    {
        /// <summary>
        /// Executes all registered commands of <see cref="ICommand"/>
        /// </summary>
        Task ExecuteAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}