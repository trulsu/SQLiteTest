using System;
using System.Data.Linq.Mapping;
using System.Data.SQLite;

namespace SqLiteTest
{
    /// <summary>
    /// Data connection for the SQLite database.
    /// The schema for creating this is in Schema.sqlite
    /// The database is saved as TestDB.db3
    /// </summary>
    public class SqLiteDataContext : System.Data.Linq.DataContext
    {
        private const string ConnectionString = @"DbLinqProvider=Sqlite;Data Source=TestDB.db3";
        private static readonly MappingSource m_MappingSource = new AttributeMappingSource();

        public SqLiteDataContext() : base(new SQLiteConnection(ConnectionString), m_MappingSource)
        {
        }

        public System.Data.Linq.Table<SqLite> SqLites
        {
            get { return GetTable<SqLite>(); }
        }

        public System.Data.Linq.Table<Person> Persons
        {
            get { return GetTable<Person>(); }
        }
    }

    /// <summary>
    /// A sample marked-up dataclass.
    /// </summary>
    [TableAttribute(Name="SqLite")]
    public class SqLite
    {
        [ColumnAttribute(Name="Id", DbType="TEXT", IsPrimaryKey=true)]
        public Guid Id { get; set; }

        [ColumnAttribute(Name = "Name", DbType = "VARCHAR(MAX)", CanBeNull = false)]
        public string Name { get; set; }

        [ColumnAttribute(Name = "RowId", DbType = "INT", CanBeNull = false)]
        public string RowId { get; set; }

        [ColumnAttribute(Name="Value", DbType = "FLOAT", CanBeNull = false)]
        public double Value { get; set; }
    }

    [TableAttribute(Name="Person")]
    public class Person
    {
        [ColumnAttribute(Name = "Id", DbType = "INT", IsPrimaryKey = true)]
        public int Id { get; set; }

        [ColumnAttribute(Name = "Name", DbType = "VARCHAR(MAX)", CanBeNull = false)]
        public string Name { get; set; }

        [ColumnAttribute(Name = "Age", DbType = "INT", CanBeNull = false)]
        public int Age { get; set; }
    }

}
