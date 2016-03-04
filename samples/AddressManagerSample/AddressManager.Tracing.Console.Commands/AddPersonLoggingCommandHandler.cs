using AddressManager.Commands;
using SchwabenCode.MicroCQRS;

namespace AddressManager.Tracing.Console.Commands
{

    public class AddPersonLoggingCommandHandler : ICommandHandler<AddPersonCommand>
    {
        public void Execute( AddPersonCommand command )
        {
            System.Console.WriteLine( $"[TRACE COMMAND] AddPersonCommand: {command.Lastname}, {command.Firstname}" );
        }
    }
}
