using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace SchwabenCode.MicroCQRS.Core
{
    /// <summary>
    /// Default handler which uses <see cref="IServiceProvider"/> and <see cref="Microsoft.Extensions.DependencyInjection"/> to resolve services
    /// </summary>
    public class DefaultQueryHandlerFactory : IQueryFactory
    {
        private readonly IServiceProvider _register;

        /// <summary>
        /// Creates an instance of <see cref="DefaultQueryHandlerFactory"/>
        /// </summary>
        /// <param name="register"></param>
        public DefaultQueryHandlerFactory(IServiceProvider register)
        {
            if (register == null) throw new ArgumentNullException(nameof(register));

            _register = register;
        }

        /// <summary>
        /// Resolves single query by given interface
        /// </summary>
        /// <exception cref="MultipleQueryHandlersFoundException">if <see cref="IQuery"/> is registered multiple times</exception>
        public TQuery Resolve<TQuery>() where TQuery : IQuery
        {
            IList<TQuery> queries = _register.GetServices<TQuery>().ToList();
            if (queries.Count > 1)
            {
                throw new MultipleQueryHandlersFoundException(typeof(TQuery));
            }

            return queries.SingleOrDefault();
        }
    }
}