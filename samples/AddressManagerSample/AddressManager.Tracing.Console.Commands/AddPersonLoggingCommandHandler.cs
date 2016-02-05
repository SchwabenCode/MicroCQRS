using AddressManager.Commands;
using SchwabenCode.MicroCQRS;

namespace AddressManager.Tracing.Console.Commands
{

    public class AddPersonLoggingCommandHandler : ICommandHandler<AddPersonCommand>
    {
        public void Execute( AddPersonCommand command )
        {
            System.Console.WriteLine( $"Added to database: {command.Lastname}, {command.Firstname}" );
        }
    }
}
