using SchwabenCode.MicroCQRS;

namespace AddressManager.Database
{
    public class DbQuery<TDbContext> : IQuery
        where TDbContext : DbContext
    {
        protected readonly TDbContext DbContext;

        protected DbQuery( TDbContext dbContext )
        {
            DbContext = dbContext;
        }
    }
}
