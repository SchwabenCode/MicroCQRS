namespace SchwabenCode.MicroCQRS
{
    /// <summary>
    /// The query factory searches for the matching query. Only one result is allowed.
    /// </summary>
    public interface IQueryFactory
    {
        /// <summary>
        /// Resolves the Query and returns the matching item.
        /// </summary>
        TQuery Resolve<TQuery>() where TQuery : IQuery;
    }
}
