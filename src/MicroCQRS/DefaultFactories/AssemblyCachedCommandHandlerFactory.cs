﻿using Microsoft.Practices.Unity;

namespace SchwabenCode.MicroCQRS.DefaultFactories
{
    public class AssemblyCachedCommandHandlerFactory : ICommandFactory
    {
        private readonly IUnityContainer _container;

        public AssemblyCachedCommandHandlerFactory( IUnityContainer container )
        {
            _container = container;
        }

        /// <summary>
        /// Executes given command with all handlers defined in the Unity container
        /// </summary>
        public void Execute<TCommand, TCommandNotificator>( TCommand command, TCommandNotificator commandNotificator = null )
            where TCommand : class, ICommand
            where TCommandNotificator : class, ICommandNotificator
        {
            int executeCount = 0;


            // Execute fire and forget commands
            foreach( ICommandHandler<TCommand> commandHandler in _container.ResolveAll<ICommandHandler<TCommand>>() )
            {
                // Execute command
                commandHandler.Execute( command );
                executeCount++;
            }

            // Execute command with notificator
            foreach( ICommandHandler<TCommand, TCommandNotificator> commandHandler in _container.ResolveAll<ICommandHandler<TCommand, TCommandNotificator>>() )
            {
                // Execute command
                commandHandler.Execute( command, commandNotificator );
                executeCount++;
            }

            if( executeCount == 0 )
            {
                throw new CommandNotFoundException( command );
            }
        }
    }
}
