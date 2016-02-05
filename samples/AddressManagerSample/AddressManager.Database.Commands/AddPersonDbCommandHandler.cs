using AddressManager.Commands;
using AddressManager.Domain;

namespace AddressManager.Database.Commands
{

    public class AddPersonDbCommandHandler : DbCommandHandler<AddPersonCommand, DbContext>
    {
        public AddPersonDbCommandHandler( DbContext dbContext )
            : base( dbContext )
        {
        }

        public override void Execute( AddPersonCommand command )
        {
            Person p = new Person
            {
                Firstname = command.Firstname,
                Lastname = command.Lastname
            };

            DbContext.Persons.Add( p );
        }


    }
}
