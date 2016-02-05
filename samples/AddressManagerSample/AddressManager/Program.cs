using System;
using System.Collections.Generic;
using System.Linq;
using AddressManager.Commands;
using AddressManager.Core;
using AddressManager.Domain;
using AddressManager.Queries;
using Microsoft.Practices.Unity;
using SchwabenCode.MicroCQRS;

namespace AddressManager
{
    public class Program
    {
        public static void Main( string[ ] args )
        {
            // Get Container for example directly
            IUnityContainer container = UnityBoostraper.Container;

            // Resolve the DbQuery Factory and Command Factory
            IQueryFactory queryFactory = container.Resolve<IQueryFactory>();
            ICommandFactory commandFactory = container.Resolve<ICommandFactory>();

            // Add Users to Database
            Console.WriteLine( "## Writing Users in Database:" );
            List<Person> personsToAdd = new[ ]  {
                new Person {Firstname = "Benjamin", Lastname = "Abt"},
                new Person {Firstname = "Taylor", Lastname = "Swift"},
                new Person {Firstname = "Emma", Lastname = "Watson"},
                new Person {Firstname = "Jennifer", Lastname = "Lawrence"},
            }.ToList();

            foreach( Person p in personsToAdd )
            {
                AddPersonCommand personCommand = new AddPersonCommand( p.Firstname, p.Lastname );
                commandFactory.Execute( personCommand );
            }


            // List all users in database
            Console.WriteLine( "## All users in Database:" );
            IEnumerable<Person> persons = queryFactory.Resolve<IPersonListQuery>().Execute();
            foreach( Person p in persons )
            {
                Console.WriteLine( $"LastName: {p.Lastname} - FirstName: {p.Firstname}" );
            }

            // Searching for Ben
            Console.WriteLine( "## Searching for Ben:" );
            IEnumerable<Person> personsByName1 = queryFactory.Resolve<IPersonByNameQuery>().Execute( "Ben" );
            foreach( Person p in personsByName1 )
            {
                Console.WriteLine( $"LastName: {p.Lastname} - FirstName: {p.Firstname}" );
            }

            // Searching for Emma
            Console.WriteLine( "## Searching for Emma:" );
            IEnumerable<Person> personsByName2 = queryFactory.Resolve<IPersonByNameQuery>().Execute( "Emma" );
            foreach( Person p in personsByName2 )
            {
                Console.WriteLine( $"LastName: {p.Lastname} - FirstName: {p.Firstname}" );
            }

            Console.WriteLine( "DEMO PROJECT DONE. Press key to exit." );
            Console.ReadKey();
        }
    }
}
