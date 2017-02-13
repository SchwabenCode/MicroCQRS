using System;

namespace SchwabenCode.MicroCQRS.Core
{
    /// <summary>
    /// Exception of not found command
    /// </summary>
    public sealed class CommandNotFoundException : Exception
    {
        /// <summary>
        /// Unknown command type
        /// </summary>
        public ICommand Command { get; }

        /// <summary>
        /// Creates an instance of <see cref="CommandNotFoundException"/>
        /// </summary>
        public CommandNotFoundException(ICommand command) : base($@"Unknown command ""{command.GetType().FullName}"".")
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            Command = command;
        }
    }
}