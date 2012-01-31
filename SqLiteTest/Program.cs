using System;
using System.Collections.Generic;
using System.Linq;

namespace SqLiteTest
{
    class Program
    {
        /// <summary>
        /// Retrieves all entries in the database using LINQ.
        /// The database has been created using the Schema.sqlite script
        /// and the command line tool sqlite3.
        /// </summary>
        static void Main()
        {
            using (var connection = new TestDBConnection()) {
                PersonTest(connection);
            }
            using (var connection = new TestDBConnection()) {
                SqLitesTest(connection);
            }
            Console.WriteLine("----- Press enter to continue -----");
            Console.ReadLine();
        }

        private static void ExtraTest(IEnumerable<SqLite> list)
        {
            Console.Write("First or default on simple list:");
            Console.WriteLine(list.FirstOrDefault(t=>t.Name=="First").Name);
        }

        private static void SqLitesTest(TestDBConnection connection)
        {
            Console.WriteLine("\n\n----- Table:SqLite -----\n");
            List<SqLite> result = connection.SqLite.ToList();
            Console.WriteLine("All entries:");
            foreach (SqLite entry in result) {
                Console.WriteLine(String.Format("Id:{0}, Name:{1}, Value:{2}", entry.Id, entry.Name, entry.Value));
            }

            Guid firstId = new Guid("5641615F-B658-4572-A783-CF8C9217BA51");

            Console.Write("First[Id]: ");
            SqLite first = connection.SqLite.First(delegate(SqLite s) { return s.Id == firstId; });
            Console.WriteLine(String.Format("Id:{0}, Name:{1}, Value:{2}", first.Id, first.Name, first.Value));

            Console.Write("*** FirstOrDefault[Id]:\t");
            SqLite firstOrDefault = connection.SqLite.FirstOrDefault(delegate(SqLite s) { return s.Id == firstId; });
            //SqLite firstOrDefault = connection.SqLite.FirstOrDefault(s => s.Id == firstId ); // This fails!
            if(firstOrDefault != null) {
                Console.WriteLine(String.Format("Id:{0}, Name:{1}, Value:{2}", firstOrDefault.Id, firstOrDefault.Name, firstOrDefault.Value));
            } else {
                Console.WriteLine("--- None ---");
            }

            Console.Write("SingleOrDefault[Name]:\t");
            SqLite singleOrDefault = connection.SqLite.SingleOrDefault(t => t.Name == "Second");
            if (singleOrDefault != null) {
                Console.WriteLine(String.Format("Id:{0}, Name:{1}, Value:{2}", singleOrDefault.Id, singleOrDefault.Name, singleOrDefault.Value));
            } else {
                Console.WriteLine("--- None ---");
            }

            ExtraTest(connection.SqLite.ToList());

            Console.Write("FirstOrDefault[Name]:\t");
            SqLite firstOrDefaultOnName = connection.SqLite.FirstOrDefault(n => n.Name == "First");
            if (firstOrDefaultOnName != null) {
                Console.WriteLine(String.Format("Id:{0}, Name:{1}, Value:{2}", firstOrDefaultOnName.Id, firstOrDefaultOnName.Name, firstOrDefaultOnName.Value));
            } else {
                Console.WriteLine("--- None ---");
            }
        }

        private static void PersonTest(TestDBConnection connection)
        {
            Console.WriteLine("\n\n----- Table:Person -----\n");
            List<Person> result = connection.Person.ToList();
            Console.WriteLine("All entries:");
            foreach (Person entry in result) {
                Console.WriteLine(String.Format("Id:{0}, Name:{1}, Value:{2}", entry.Id, entry.Name, entry.Age));
            }

            Console.Write("Single:\t");
            Person single = connection.Person.Single(t => t.Id == 1);
            Console.WriteLine(String.Format("Id:{0}, Name:{1}, Age:{2}", single.Id, single.Name, single.Age));

            Console.Write("FirstOrDefault:\t");
            Person firstOrDefault = connection.Person.FirstOrDefault(t => t.Id == 1);
            Console.WriteLine(String.Format("Id:{0}, Name:{1}, Age:{2}", firstOrDefault.Id, firstOrDefault.Name, firstOrDefault.Age));

            Console.Write("SingleOrDefault:\t");
            Person singleOrDefault = connection.Person.SingleOrDefault(t => t.Name == "Pete");
            Console.WriteLine(String.Format("Id:{0}, Name:{1}, Age:{2}", singleOrDefault.Id, singleOrDefault.Name, singleOrDefault.Age));

            Person firstOrDefaultOnName = connection.Person.FirstOrDefault(person => person.Name == "Bob"); // This crashes!
            Console.WriteLine("FirstOrDefaultOnName:\t" + firstOrDefaultOnName.Name);
        }
    }
}
