using System;
using System.Linq;
using System.Collections.Generic;
using AddressManager.Domain;
using AddressManager.Queries;

namespace AddressManager.Database.Queries
{
    public class PersonByNameDbQuery : DbQuery<DbContext>, IPersonByNameQuery
    {
        public PersonByNameDbQuery( DbContext dbContext )
            : base( dbContext )
        {
        }

        /// <summary>
        /// Returns all Persons which contains given <paramref name="name"/>
        /// You can return DTOs here.
        /// </summary>
        public IEnumerable<Person> Execute( string name )
        {
            return ( from person in DbContext.Persons
                     where person.Firstname.IndexOf( name, StringComparison.OrdinalIgnoreCase ) > -1 ||
                           person.Lastname.IndexOf( name, StringComparison.OrdinalIgnoreCase ) > -1
                     orderby person.Lastname ascending
                     select person );
        }
    }
}
