using AddressManager.Database.Queries;
using AddressManager.Queries;
using Microsoft.Practices.Unity;

namespace AddressManager.Core.Registrators
{
    public static class QueryRegistrator
    {
        public static void Register( IUnityContainer unityContainer )
        {
            /* By definition a query can only have one handler
                * ResolveAll with SingleOrDefault will be used. Type Register without names wont be found!
                Register multiple handlers for one query type results in an exception
            */

            unityContainer.RegisterType<IPersonByNameQuery, PersonByNameDbQuery>( "PersonByNameDbQuery" );
            unityContainer.RegisterType<IPersonListQuery, PersonListDbQuery>( "PersonListDbQuery" );
        }
    }
}
