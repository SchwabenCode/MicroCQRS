using System;
using System.Threading.Tasks;

namespace SchwabenCode.MicroCQRS
{
    /// <summary>
    /// Base engine for CQRS usage of queries and commands
    /// </summary>
    public abstract class MicroCQRSEngine : IMicroCQRSEngine
    {
        private readonly IQueryFactory _queryFactory;
        private readonly IAsyncCommandFactory _commandFactory;

        /// <summary>
        /// Creates an instance of <see cref="MicroCQRSEngine"/>
        /// </summary>
        /// <param name="queryFactory">Cannot be null</param>
        /// <param name="commandFactory">Cannot be null</param>
        protected MicroCQRSEngine(IQueryFactory queryFactory, IAsyncCommandFactory commandFactory)
        {
            if (queryFactory == null) throw new ArgumentNullException(nameof(queryFactory));
            if (commandFactory == null) throw new ArgumentNullException(nameof(commandFactory));

            _queryFactory = queryFactory;
            _commandFactory = commandFactory;
        }

        /// <summary>
        /// Resolves single query with the usage of the given queryfactory
        /// </summary>
        public TQuery Resolve<TQuery>() where TQuery : IQuery
        {
            return _queryFactory.Resolve<TQuery>();
        }

        /// <summary>
        /// Executes all commands of the given commandfactory
        /// </summary>
        public Task ExecuteAsync<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            return _commandFactory.ExecuteAsync(command);
        }
    }
}