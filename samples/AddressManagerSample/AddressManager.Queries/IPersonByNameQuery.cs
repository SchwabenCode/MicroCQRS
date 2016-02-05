using System.Collections.Generic;
using SchwabenCode.MicroCQRS;
using AddressManager.Domain;

namespace AddressManager.Queries
{
    public interface IPersonByNameQuery : IQuery
    {
        IEnumerable<Person> Execute( string name );
    }
}

