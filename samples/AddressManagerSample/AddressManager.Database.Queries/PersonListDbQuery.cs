using System.Collections.Generic;
using AddressManager.Domain;
using AddressManager.Queries;

namespace AddressManager.Database.Queries
{
    public class PersonListDbQuery : DbQuery<DbContext>, IPersonListQuery
    {
        public PersonListDbQuery( DbContext dbContext )
            : base( dbContext )
        {
        }
        /// <summary>
        /// Returns all Persons
        /// You can return DTOs here.
        /// </summary>
        public IEnumerable<Person> Execute(  )
        {
            return DbContext.Persons;
        }
    }
}
