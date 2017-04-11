using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SchwabenCode.MicroCQRS
{
    /// <summary>
    /// Default handler which uses <see cref="IServiceProvider"/> and <see cref="Microsoft.Extensions.DependencyInjection"/> to resolve services
    /// </summary>
    public class DefaultAsyncCommandHandlerFactory : IAsyncCommandFactory
    {
        private readonly IServiceProvider _register;

        /// <summary>
        /// Creates an instance of <see cref="DefaultAsyncCommandHandlerFactory"/> with the given <see cref="IServiceProvider"/>
        /// </summary>
        /// <param name="register"></param>
        public DefaultAsyncCommandHandlerFactory(IServiceProvider register)
        {
            if (register == null) throw new ArgumentNullException(nameof(register));

            _register = register;
        }

        /// <summary>
        /// Executes given command with all handlers defined in the Unity container
        /// </summary>
        public async Task ExecuteAsync<TCommand>(TCommand command)
            where TCommand : class, ICommand
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            IList<IAsyncCommandHandler<TCommand>> commands = _register.GetServices<IAsyncCommandHandler<TCommand>>().ToList();

            if (!commands.Any())
            {
                throw new CommandNotFoundException(command);
            }

            // Execute fire and forget commands
            foreach (IAsyncCommandHandler<TCommand> commandHandler in commands)
            {
                await commandHandler.ExecuteAsync(command);
            }
        }
    }
}
