using System;

namespace SchwabenCode.MicroCQRS
{
    /// <summary>
    /// Exception that represents that the system tried to execute a command which was not registered
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
        public CommandNotFoundException( ICommand command ) : base( $@"Unknown command ""{command.GetType().FullName}""." )
        {
            Command = command;
        }
    }
}
