using System.Linq;
using Microsoft.Practices.Unity;
using SchwabenCode.MicroCQRS;

namespace AddressManager.Core.Factories
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
        /// <typeparam name="TQuery"></typeparam>
        /// <returns></returns>
        public TQuery Resolve<TQuery>() where TQuery : IQuery
        {
            // Searches for all named type registers but accepts only one register entry
            return _container.ResolveAll<TQuery>().SingleOrDefault();
        }
    }
}
