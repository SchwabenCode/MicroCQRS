using System;
using System.Collections.Generic;
using AddressManager.Domain;

namespace AddressManager.Database
{

    public class DbContext : IDisposable
    {
        private readonly List<Person> _demo = new List<Person>();

        public IList<Person> Persons => _demo;

        public void Dispose()
        {
            // DB Contexts are always to dispose!
        }
    }
}
