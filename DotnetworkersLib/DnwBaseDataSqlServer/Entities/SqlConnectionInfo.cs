// ---------------------------------------------------------------
// DATI FILE SqlConnectionInfo.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseDataSqlServer
// File....................: SqlConnectionInfo.cs
// Namespace...............: Dnw.Base.Data.SqlServer.Entities
// Classi..................: public SqlConnectionInfo : ConnectionInfoBase
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 341
// Dimensione..............: 7,85 Kb
// Data Creazione..........: 13/05/2013 15:45:36
// Data ultima Modifica....: 29/05/2013 09:38:07
// ---------------------------------------------------------------


using Dnw.Base.Entities;
using System.Runtime.Serialization;

namespace Dnw.Base.Data.SqlServer.Entities
{
	///<summary>
	/// Dati di connessione a SQL Server
	///</summary>
	[DataContract(Name = "SCNI")]
	public class SqlConnectionInfo : ConnectionInfoBase
	{

		#region Constants

		/// <summary>
		/// Timeout of the commands for the Queries
		/// N/A
		/// </summary>
		public const string FLD_CommandsTimeout = "CommandsTimeout";

		/// <summary>
		/// Connection Timeout expressed in seconds
		/// N/A
		/// </summary>
		public const string FLD_ConnectionTimeout = "ConnectionTimeout";


		/// <summary>
		/// ConnectionString
		/// N/A
		/// </summary>
		public const string FLD_ConnectionString = "ConnectionString";

		/// <summary>
		/// Database to connect to
		/// N/A
		/// </summary>
		public const string FLD_Database = "Database";

		/// <summary>
		/// Password to the SQL connection
		/// N/A
		/// </summary>
		public const string FLD_Password = "Password";

		/// <summary>
		/// Name of the database server
		/// </summary>
		public const string FLD_Server = "Server";

		/// <summary>
		/// Use Trusted Connection
		/// </summary>
		public const string FLD_Trusted = "Trusted";

		/// <summary>
		/// User Name for a SQL Connection
		/// N/A
		/// </summary>
		public const string FLD_Username = "Username";

		#endregion

		#region Fields

		/// <summary>
		/// Timeout of the commands for the Queries
		/// N/A
		/// </summary>
		private int mCommandsTimeout = -1;

		/// <summary>
		/// Connection Timeout expressed in seconds
		/// N/A
		/// </summary>
		private int mConnectionTimeout = -1;

		/// <summary>
		/// Database to connect to
		/// N/A
		/// </summary>
		private string mDatabase;

		/// <summary>
		/// Password to the SQL connection
		/// N/A
		/// </summary>
		private string mPassword;

		/// <summary>
		/// Name of the database server
		/// </summary>
		private string mServer;

		/// <summary>
		/// Use Trusted Connection
		/// N/A
		/// </summary>
		private bool mTrusted;

		/// <summary>
		/// User Name for a SQL Connection
		/// N/A
		/// </summary>
		private string mUsername;

		#endregion


		/// <summary>
		/// Gets the connection string.
		/// </summary>
		/// <value>
		/// The connection string.
		/// </value>
		public override string ConnectionString
		{
			get
			{
				string ret = string.Empty;
				if (Trusted)
				{
					if (ConnectionTimeout > -1)
					{
						ret = string.Format(SqlConstants.FMP_SQL_ConnectionTrustedTimeouted, Server, Database, ConnectionTimeout);
					}
					else
					{
						ret = string.Format(SqlConstants.FMP_SQL_ConnectionTrusted, Server, Database);
					}
				}
				else
				{
					if (ConnectionTimeout > -1)
					{
						ret = string.Format(SqlConstants.FMP_SQL_ConnectionTimeouted, Server, Database, Username, Password, ConnectionTimeout);
					}
					else
					{
						ret = string.Format(SqlConstants.FMP_SQL_Connection, Server, Database, Username, Password);
					}
				}
				return (ret);
			}
		}

		/// <summary>
		/// Name of the database server
		/// </summary>
		[DataMember(Name = "SRV", EmitDefaultValue = false)]
		public string Server
		{
			get
			{
				return mServer;
			}
			set
			{
				mServer = value;
				OnPropertyChanged(FLD_Server);
				OnPropertyChanged(FLD_IsValid);
				OnPropertyChanged(FLD_ConnectionString);
			}
		}

		/// <summary>
		/// Use Trusted Connection
		/// N/A
		/// </summary>
		[DataMember(Name = "TRS", EmitDefaultValue = false)]
		public bool Trusted
		{
			get
			{
				return mTrusted;
			}
			set
			{
				mTrusted = value;
				OnPropertyChanged(FLD_Trusted);
				OnPropertyChanged(FLD_ConnectionString);
			}
		}

		/// <summary>
		/// Connection Timeout expressed in seconds
		/// N/A
		/// </summary>
		[DataMember(Name = "CNT", EmitDefaultValue = false)]
		public int ConnectionTimeout
		{
			get
			{
				return mConnectionTimeout;
			}
			set
			{
				mConnectionTimeout = value;
				OnPropertyChanged(FLD_ConnectionTimeout);
				OnPropertyChanged(FLD_ConnectionString);
			}
		}

		/// <summary>
		/// Timeout of the commands for the Queries
		/// N/A
		/// </summary>
		[DataMember(Name = "CMT", EmitDefaultValue = false)]
		public int CommandsTimeout
		{
			get
			{
				return mCommandsTimeout;
			}
			set
			{
				mCommandsTimeout = value;
				OnPropertyChanged(FLD_CommandsTimeout);
			}
		}

		/// <summary>
		/// Database to connect to
		/// N/A
		/// </summary>
		[DataMember(Name = "DB", EmitDefaultValue = false)]
		public string Database
		{
			get
			{
				return mDatabase;
			}
			set
			{
				mDatabase = value;
				OnPropertyChanged(FLD_Database);
				OnPropertyChanged(FLD_IsValid);
				OnPropertyChanged(FLD_ConnectionString);
			}
		}

		/// <summary>
		/// User Name for a SQL Connection
		/// N/A
		/// </summary>
		[DataMember(Name = "USR", EmitDefaultValue = false)]
		public string Username
		{
			get
			{
				return mUsername;
			}
			set
			{
				mUsername = value;
				OnPropertyChanged(FLD_Username);
				OnPropertyChanged(FLD_ConnectionString);
			}
		}

		/// <summary>
		/// Password to the SQL connection
		/// N/A
		/// </summary>
		[DataMember(Name = "PWD", EmitDefaultValue = false)]
		public string Password
		{
			get
			{
				return mPassword;
			}
			set
			{
				mPassword = value;
				OnPropertyChanged(FLD_Password);
				OnPropertyChanged(FLD_ConnectionString);
			}
		}

		/// <summary>
		/// Determines whether this instance is valid.
		/// </summary>
		/// <returns>
		///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
		///   </returns>
		public override bool IsValid
		{
			get
			{
				return (!this.ConnectionID.XDwIsNullOrTrimEmpty() &&
					!this.Server.XDwIsNullOrTrimEmpty() &&
					!this.Database.XDwIsNullOrTrimEmpty());
			}
		}


		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return (string.Format("{0} {1} {2} {3}", ConnectionID, ConnectionType, Description, ConnectionString));
		}

		/// <summary>
		/// Copies this instance to another of the same type
		/// </summary>
		/// <param name="newItem">The new item where to copy this class content</param>
		public void CopyTo(SqlConnectionInfo newItem)
		{
			//From Connection base
			base.CopyTo(newItem);
			//Specific properties
			newItem.CommandsTimeout = this.CommandsTimeout;
			newItem.ConnectionTimeout = this.ConnectionTimeout;
			newItem.Database = this.Database;
			newItem.Password = this.Password;
			newItem.Server = this.Server;
			newItem.Trusted = this.Trusted;
			newItem.Username = this.Username;
		}

		/// <summary>
		/// Clones this instance.
		/// </summary>
		/// <returns></returns>
		public SqlConnectionInfo Clone()
		{
			SqlConnectionInfo item = new SqlConnectionInfo();
			this.CopyTo(item);
			return (item);
		}

	}

}