using System;

namespace AddressManager.Domain
{
    public class Person
    {
        public Guid Id { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
