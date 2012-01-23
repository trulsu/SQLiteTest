// 
//  ____  _     __  __      _        _ 
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from main on 2011-12-19 10:30:11Z.
// Please visit http://code.google.com/p/dblinq2007/ for more information.
//
using System;
using System.ComponentModel;
using System.Data;
#if MONO_STRICT
	using System.Data.Linq;
#else   // MONO_STRICT
	using DbLinq.Data.Linq;
	using DbLinq.Vendor;
#endif  // MONO_STRICT
	using System.Data.Linq.Mapping;
using System.Diagnostics;


public partial class Main : DataContext
{
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		#endregion
	
	
	public Main(string connectionString) : 
			base(connectionString)
	{
		this.OnCreated();
	}
	
	public Main(string connection, MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		this.OnCreated();
	}
	
	public Main(IDbConnection connection, MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		this.OnCreated();
	}
	
	public Table<SqLite> SqLite
	{
		get
		{
			return this.GetTable<SqLite>();
		}
	}
}

#region Start MONO_STRICT
#if MONO_STRICT

public partial class Main
{
	
	public Main(IDbConnection connection) : 
			base(connection)
	{
		this.OnCreated();
	}
}
#region End MONO_STRICT
	#endregion
#else     // MONO_STRICT

public partial class Main
{
	
	public Main(IDbConnection connection) : 
			base(connection, new DbLinq.Sqlite.SqliteVendor())
	{
		this.OnCreated();
	}
	
	public Main(IDbConnection connection, IVendor sqlDialect) : 
			base(connection, sqlDialect)
	{
		this.OnCreated();
	}
	
	public Main(IDbConnection connection, MappingSource mappingSource, IVendor sqlDialect) : 
			base(connection, mappingSource, sqlDialect)
	{
		this.OnCreated();
	}
}
#region End Not MONO_STRICT
	#endregion
#endif     // MONO_STRICT
#endregion

[Table(Name="main.SqLite")]
public partial class SqLite : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private string _id;
	
	private string _name;
	
	private float _value;
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(string value);
		
		partial void OnNameChanged();
		
		partial void OnNameChanging(string value);
		
		partial void OnValueChanged();
		
		partial void OnValueChanging(float value);
		#endregion
	
	
	public SqLite()
	{
		this.OnCreated();
	}
	
	[Column(Storage="_id", Name="Id", DbType="TEXT", IsPrimaryKey=true, AutoSync=AutoSync.Never)]
	[DebuggerNonUserCode()]
	public string ID
	{
		get
		{
			return this._id;
		}
		set
		{
			if (((_id == value) 
						== false))
			{
				this.OnIDChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("ID");
				this.OnIDChanged();
			}
		}
	}
	
	[Column(Storage="_name", Name="Name", DbType="TEXT", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string Name
	{
		get
		{
			return this._name;
		}
		set
		{
			if (((_name == value) 
						== false))
			{
				this.OnNameChanging(value);
				this.SendPropertyChanging();
				this._name = value;
				this.SendPropertyChanged("Name");
				this.OnNameChanged();
			}
		}
	}
	
	[Column(Storage="_value", Name="Value", DbType="FLOAT", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public float Value
	{
		get
		{
			return this._value;
		}
		set
		{
			if ((_value != value))
			{
				this.OnValueChanging(value);
				this.SendPropertyChanging();
				this._value = value;
				this.SendPropertyChanged("Value");
				this.OnValueChanged();
			}
		}
	}
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
}
