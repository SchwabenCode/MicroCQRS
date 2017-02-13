using System.Threading.Tasks;

namespace SchwabenCode.MicroCQRS.Core
{
    /// <summary>
    /// IMicroCQRSEngine
    /// </summary>
    public interface IMicroCQRSEngine
    {
        /// <summary>
        /// Resolve given query interface
        /// </summary>
        TQuery Resolve<TQuery>() where TQuery : IQuery;

        /// <summary>
        /// Executes given command
        /// </summary>
        Task ExecuteAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}