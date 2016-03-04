using SchwabenCode.MicroCQRS;

namespace AddressManager.Database
{
    /// <summary>
    /// Executes commands
    /// </summary>
    public abstract class DbCommandHandler<TCommand, TDbContext> : ICommandHandler<TCommand>
        where TCommand : ICommand
        where TDbContext : DbContext
    {
        protected readonly TDbContext DbContext;

        protected DbCommandHandler( TDbContext dbContext )
        {
            DbContext = dbContext;
        }

        public abstract void Execute( TCommand command );

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }

    /// <summary>
    /// Executes commands with <see cref="TCommandNotificator"/>
    /// </summary>
    public abstract class DbCommandHandler<TCommand, TCommandNotificator, TDbContext> : ICommandHandler<TCommand, TCommandNotificator>
       where TCommand : ICommand
       where TCommandNotificator : ICommandNotificator
       where TDbContext : DbContext
    {
        protected readonly TDbContext DbContext;

        protected DbCommandHandler( TDbContext dbContext )
        {
            DbContext = dbContext;
        }

        public abstract void Execute( TCommand command, TCommandNotificator commandNotificator );

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}