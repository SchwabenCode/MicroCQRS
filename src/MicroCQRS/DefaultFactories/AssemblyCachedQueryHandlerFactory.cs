using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;

namespace SchwabenCode.MicroCQRS.DefaultFactories
{
    public class AssemblyCachedQueryHandlerFactory : IQueryFactory
    {
        private readonly IUnityContainer _container;

        public AssemblyCachedQueryHandlerFactory( IUnityContainer container )
        {
            _container = container;
        }

        /// <summary>
        /// Resolves a query from the <see cref="IUnityContainer"/>
        /// </summary>
        public TQuery Resolve<TQuery>() where TQuery : IQuery
        {
            IList<TQuery> queries = _container.ResolveAll<TQuery>().ToList();
            if( queries.Count > 1 )
            {
                throw new MultipleQueryHandlersFoundException( typeof( TQuery ) );
            }

            return queries.SingleOrDefault();
        }
    }
}
