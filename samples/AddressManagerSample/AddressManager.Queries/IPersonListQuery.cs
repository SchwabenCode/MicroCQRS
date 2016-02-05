using System.Collections.Generic;
using AddressManager.Domain;
using SchwabenCode.MicroCQRS;

namespace AddressManager.Queries
{
    public interface IPersonListQuery : IQuery
    {
        IEnumerable<Person> Execute(  );
    }
}

