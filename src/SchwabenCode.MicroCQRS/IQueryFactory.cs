
namespace SchwabenCode.MicroCQRS
{
    /// <summary>
    /// A <see cref="IQueryFactory"/> knows all registered queries
    /// </summary>
    public interface IQueryFactory
    {
        /// <summary>
        /// Resolves single query by given interface
        /// </summary>
        TQuery Resolve<TQuery>() where TQuery : IQuery;
    }
}