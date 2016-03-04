using System;
using AddressManager.Commands;
using AddressManager.Database.Commands.Notificators;
using AddressManager.Domain;

namespace AddressManager.Database.Commands
{

    public class AddPersonDbCommandHandler : DbCommandHandler<AddPersonCommand, PersonAddedToDatabaseNotificator, DbContext>
    {
        public AddPersonDbCommandHandler( DbContext dbContext )
            : base( dbContext )
        {
        }

        public override void Execute( AddPersonCommand command, PersonAddedToDatabaseNotificator notificator )
        {
            Person p = new Person
            {
                Id = Guid.NewGuid(),
                Firstname = command.Firstname,
                Lastname = command.Lastname
            };

            DbContext.Persons.Add( p );

            notificator?.OnAdded( p.Id );
        }


    }
}
