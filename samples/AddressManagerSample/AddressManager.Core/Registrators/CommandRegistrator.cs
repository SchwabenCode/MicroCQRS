using AddressManager.Commands;
using AddressManager.Database.Commands;
using AddressManager.Database.Commands.Notificators;
using AddressManager.Tracing.Console.Commands;
using Microsoft.Practices.Unity;
using SchwabenCode.MicroCQRS;

namespace AddressManager.Core.Registrators
{
    public static class CommandRegistrator
    {
        public static void Register( IUnityContainer unityContainer )
        {
            /* By definition a command can have multiple handlers.
             * In Unity you have to use named type registers and ResolveAll.
             * Otherwise multiple instances are not supported and only one default type will be used
            */

            unityContainer.RegisterType<ICommandHandler<AddPersonCommand, PersonAddedToDatabaseNotificator>, AddPersonDbCommandHandler>( "AddPersonDbCommandHandler" );
            unityContainer.RegisterType<ICommandHandler<AddPersonCommand>, AddPersonLoggingCommandHandler>( "AddPersonLoggingCommandHandler" );

        }
    }
}
