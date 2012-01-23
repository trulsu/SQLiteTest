﻿using System;
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
            using(var connection = new SqLiteDataContext()) {
                PersonTest(connection);
                SqLitesTest(connection);
            }
            Console.WriteLine("----- Press enter to continue -----");
            Console.ReadLine();
        }

        private static void ExtraTest(IEnumerable<SqLite> list)
        {
            Console.WriteLine("First or default on simple list:");
            Console.WriteLine(list.FirstOrDefault(t=>t.Name=="First").Name);
            Console.WriteLine();
        }

        private static void SqLitesTest(SqLiteDataContext connection)
        {
            List<SqLite> result = connection.SqLites.ToList();
            Console.WriteLine("All entries:");
            foreach (SqLite entry in result) {
                Console.WriteLine(String.Format("Id:{0}, Name:{1}, Value:{2}, Row Id:{3}", entry.Id, entry.Name, entry.Value, entry.RowId));
            }

            Console.WriteLine("Single entry:");
            SqLite single = connection.SqLites.Single(t => t.Id == new Guid("5641615F-B658-4572-A783-CF8C9217BA51"));
            Console.WriteLine(String.Format("Id:{0}, Name:{1}, Value:{2}", single.Id, single.Name, single.Value));

            Console.WriteLine("FirstOrDefault:");
            SqLite firstOrDefault = connection.SqLites.FirstOrDefault(t => t.Id == new Guid("5641615F-B658-4572-A783-CF8C9217BA51"));
            Console.WriteLine(String.Format("Id:{0}, Name:{1}, Value:{2}", firstOrDefault.Id, firstOrDefault.Name, firstOrDefault.Value));

            Console.WriteLine("SingleOrDefault:");
            SqLite singleOrDefault = connection.SqLites.SingleOrDefault(t => t.Name == "Second");
            Console.WriteLine(String.Format("Id:{0}, Name:{1}, Value:{2}", singleOrDefault.Id, singleOrDefault.Name, singleOrDefault.Value));

            ExtraTest(connection.SqLites.ToList());

            SqLite firstOrDefaultOnName = connection.SqLites.FirstOrDefault(n => n.Name == "First"); // This crashes!
            Console.WriteLine("FirstOrDefaultOnName:" + firstOrDefaultOnName.Name);
        }

        private static void PersonTest(SqLiteDataContext connection)
        {
            List<Person> result = connection.Persons.ToList();
            Console.WriteLine("All entries:");
            foreach (Person entry in result) {
                Console.WriteLine(String.Format("Id:{0}, Name:{1}, Value:{2}", entry.Id, entry.Name, entry.Age));
            }

            Console.WriteLine("Single entry:");
            Person single = connection.Persons.Single(t => t.Id == 1);
            Console.WriteLine(String.Format("Id:{0}, Name:{1}, Age:{2}", single.Id, single.Name, single.Age));

            Console.WriteLine("FirstOrDefault:");
            Person firstOrDefault = connection.Persons.FirstOrDefault(t => t.Id == 1);
            Console.WriteLine(String.Format("Id:{0}, Name:{1}, Age:{2}", firstOrDefault.Id, firstOrDefault.Name, firstOrDefault.Age));

            Console.WriteLine("SingleOrDefault:");
            Person singleOrDefault = connection.Persons.SingleOrDefault(t => t.Name == "Pete");
            Console.WriteLine(String.Format("Id:{0}, Name:{1}, Age:{2}", singleOrDefault.Id, singleOrDefault.Name, singleOrDefault.Age));

            Person firstOrDefaultOnName = connection.Persons.FirstOrDefault(person => person.Name == "Bob"); // This crashes!
            Console.WriteLine("FirstOrDefaultOnName:" + firstOrDefaultOnName.Name);
        }
    }
}