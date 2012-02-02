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
                Console.WriteLine(String.Format("  Id:{0}, Name:{1}, Value:{2}", entry.Id, entry.Name, entry.Value));
            }

            Guid firstId = new Guid("5641615f-b658-4572-a783-cf8c9217ba51");

            SqLite first = connection.SqLite.First(delegate(SqLite s) { return s.Id == firstId; });
            WriteSqLiteResult("First[Id]: ", first);

            SqLite firstOrDefault = connection.SqLite.FirstOrDefault(delegate(SqLite s) { return s.Id == firstId; });
            //SqLite firstOrDefault = connection.SqLite.FirstOrDefault(s => s.Id == firstId ); // This fails!
            WriteSqLiteResult("FirstOrDefault[Id]:", firstOrDefault);

            SqLite singleOrDefault = connection.SqLite.SingleOrDefault(t => t.Name == "Second");
            WriteSqLiteResult("SingleOrDefault[Name]: ", singleOrDefault);

            ExtraTest(connection.SqLite.ToList());

            SqLite firstOrDefaultOnName = connection.SqLite.FirstOrDefault(n => n.Name == "First");
            WriteSqLiteResult("FirstOrDefault[Name]: ", firstOrDefaultOnName);
        }

        private static void PersonTest(TestDBConnection connection)
        {
            Console.WriteLine("\n\n----- Table:Person -----\n");
            List<Person> result = connection.Person.ToList();
            Console.WriteLine("All entries:");
            foreach (Person entry in result) {
                WritePersonResult("  Person:", entry);
            }

            Person single = connection.Person.Single(t => t.Id == 1);
            WritePersonResult("Single: \t", single);

            Person firstOrDefault = connection.Person.FirstOrDefault(t => t.Id == 1);
            WritePersonResult("FirstOrDefault: ", firstOrDefault);

            Person singleOrDefault = connection.Person.SingleOrDefault(t => t.Name == "Pete");
            WritePersonResult("SingleOrDefault: ", singleOrDefault);

            Person firstOrDefaultOnName = connection.Person.FirstOrDefault(person => person.Name == "Bob"); // This crashes!
            WritePersonResult("FirstOrDefaultOnName: ", firstOrDefaultOnName);
        }

        private static void WritePersonResult(string header, Person person)
        {
            Console.Write(header);
            Console.WriteLine(person != null ? String.Format("Id:{0}, Name:{1}, Age:{2}", person.Id, person.Name, person.Age) : "----- None -----");
        }

        private static void WriteSqLiteResult(string header, SqLite result)
        {
            Console.Write(header);
            Console.WriteLine(result != null ? String.Format("Id:{0}, Name:{1}, Value:{2}", result.Id, result.Name, result.Value) : "----- None -----");
        }
    }
}
