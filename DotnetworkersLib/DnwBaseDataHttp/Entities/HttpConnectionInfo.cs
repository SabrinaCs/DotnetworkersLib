// ---------------------------------------------------------------
// DATI FILE HttpConnectionInfo.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseDataHttp
// File....................: HttpConnectionInfo.cs
// Namespace...............: Dnw.Base.Data.Http.Entities
// Classi..................: public HttpConnectionInfo : ConnectionInfoBase
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 201
// Dimensione..............: 4,71 Kb
// Data Creazione..........: 14/05/2013 13:00:57
// Data ultima Modifica....: 29/05/2013 09:38:32
// ---------------------------------------------------------------

using Dnw.Base.Entities;
using System.Runtime.Serialization;
using System.Text;

namespace Dnw.Base.Data.Http.Entities
{
	///<summary>
	/// Single HTTP connection
	///</summary>
	[DataContract(Name = "HTTPCONN")]
	public class HttpConnectionInfo : ConnectionInfoBase
	{
		#region Constants

		/// <summary>
		/// Connection Address
		/// </summary>
		public const string FLD_Address = "Address";

		/// <summary>
		/// Connection Port
		/// </summary>
		public const string FLD_Port = "Port";

		/// <summary>
		/// ConnectionString
		/// </summary>
		public const string FLD_ConnectionString = "ConnectionString";

		/// <summary>
		/// Connection Timeout in milliseconds (default is 100.000)
		/// </summary>
		public const string FLD_Timeout = "Timeout";

		private const string PROTOCOL_HEADER = "http://";

		#endregion

		#region Fields

		/// <summary>
		/// Connection Address
		/// </summary>
		private string mAddress;

		/// <summary>
		/// Connection Port
		/// </summary>
		private int mPort;

		/// <summary>
		/// Connection Timeout expressed in seconds
		/// </summary>
		private int mTimeout;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="HttpConnectionInfo"/> class.
		/// </summary>
		public HttpConnectionInfo()
		{
			mAddress = string.Empty;
			mTimeout = 100000;
			mPort = 0;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Connection Address
		/// </summary>
		[DataMember(Name = "ADD", EmitDefaultValue = false)]
		public string Address
		{
			get
			{
				return mAddress;
			}
			set
			{
				mAddress = value;
				OnPropertyChanged(FLD_Address);
				OnPropertyChanged(FLD_ConnectionString);
			}
		}

		/// <summary>
		/// Connection Port
		/// 0 for default port
		/// </summary>
		[DataMember(Name = "PT", EmitDefaultValue = false)]
		public int Port
		{
			get
			{
				return mPort;
			}
			set
			{
				mPort = value;
				OnPropertyChanged(FLD_Port);
				OnPropertyChanged(FLD_ConnectionString);
			}
		}

		/// <summary>
		/// Gets the connection string should be implemented in the derived classes.
		/// </summary>
		/// <value>The connection string.</value>
		public override string ConnectionString
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(PROTOCOL_HEADER);
				sb.Append(Address);

				if (Port >= 1 && Port <= 65535)
				{
					sb.AppendFormat(":{0}", Port);
				}
				return (sb.ToString());
			}
		}

		/// <summary>
		/// Connection Timeout in milliseconds (default is 100.000).
		/// Set the value to System.Threading.Timeout.Infinite for no timeout
		/// </summary>
		[DataMember(Name = "TO", EmitDefaultValue = false)]
		public int Timeout
		{
			get
			{
				return mTimeout;
			}
			set
			{
				mTimeout = value;
				OnPropertyChanged(FLD_Timeout);
				OnPropertyChanged(FLD_ConnectionString);
			}
		}

		/// <summary>
		/// Determines whether this instance is valid.
		/// </summary>
		/// <value></value>
		/// <returns>
		/// 	<c>true</c> if this instance is valid; otherwise, <c>false</c>.
		/// </returns>
		public override bool IsValid
		{
			get
			{
				return (
					(!Address.XDwIsNullOrTrimEmpty()) &&
					(Port == 0 || (Port >= 1 && Port <= 65535))
					);
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Clones this instance.
		/// </summary>
		/// <returns></returns>
		public HttpConnectionInfo Clone()
		{
			HttpConnectionInfo item = new HttpConnectionInfo();
			this.CopyTo(item);
			return (item);
		}

		/// <summary>
		/// Copies this instance to another of the same type.
		/// </summary>
		/// <param name="newItem">The new item.</param>
		public void CopyTo(HttpConnectionInfo newItem)
		{
			//From Connection base
			base.CopyTo(newItem);

			newItem.Timeout = this.Timeout;
			newItem.Address = this.Address;
			newItem.Port = this.Port;
		}

		#endregion




	}
}