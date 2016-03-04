using System;
using SchwabenCode.MicroCQRS;

namespace AddressManager.Database.Commands.Notificators
{
    public class PersonAddedToDatabaseNotificator : ICommandNotificator
    {
        public event EventHandler<Guid> Added;

        public void OnAdded( Guid personId )
        {
            Added?.Invoke( this, personId );
        }
    }
}
