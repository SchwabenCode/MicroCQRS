using System;
using AddressManager.Core.Factories;
using AddressManager.Core.Registrators;
using AddressManager.Database;
using Microsoft.Practices.Unity;
using SchwabenCode.MicroCQRS;

namespace AddressManager.Core
{
    public class UnityBoostraper
    {
        private static readonly Lazy<UnityBoostraper> _instance = new Lazy<UnityBoostraper>( () => new UnityBoostraper() );

        readonly IUnityContainer _container;

        UnityBoostraper()
        {
            _container = new UnityContainer();


            // For this example use a fixed DbContext!
            DbContext dbContext = new DbContext();
            _container.RegisterInstance( dbContext );


            // Register Factories
            _container.RegisterType<IQueryFactory, AssemblyCachedQueryHandlerFactory>();
            _container.RegisterType<ICommandFactory, AssemblyCachedCommandHandlerFactory>();

            // Register Commands and QUeries
            CommandRegistrator.Register( _container );
            QueryRegistrator.Register( _container );
        }


        public static IUnityContainer Container => _instance.Value._container;
    }
}
