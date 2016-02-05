using SchwabenCode.MicroCQRS;

namespace AddressManager.Database
{
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
}