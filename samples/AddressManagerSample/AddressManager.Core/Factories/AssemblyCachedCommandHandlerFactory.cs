using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using SchwabenCode.MicroCQRS;

namespace AddressManager.Core.Factories
{
    public class AssemblyCachedCommandHandlerFactory : ICommandFactory
    {
        private readonly IUnityContainer _container;

        public AssemblyCachedCommandHandlerFactory( IUnityContainer container )
        {
            _container = container;
        }

        /// <summary>
        /// Executes given comamnd with all handlers defined in the Unity container
        /// </summary>
        public void Execute<TCommand>( TCommand command ) where TCommand : class, ICommand
        {
            // Initialize context
            IList<ICommandHandler<TCommand>> commandHandlers = _container.ResolveAll<ICommandHandler<TCommand>>().ToList();

            if( commandHandlers.Any() )
            {
                foreach( ICommandHandler<TCommand> commandHandler in commandHandlers )
                {
                    // Execute command
                    commandHandler.Execute( command );
                }
            }
            else
            {
                throw new ArgumentException( "Unknown command \"" + typeof( TCommand ).FullName + "\"" );
            }
        }
    }
}
