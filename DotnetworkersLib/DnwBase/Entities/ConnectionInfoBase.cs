// ---------------------------------------------------------------
// DATI FILE ConnectionInfoBase.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: ConnectionInfoBase.cs
// Namespace...............: Dnw.Base.Entities
// Classi..................: public abstract ConnectionInfoBase : IEntity
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 199
// Dimensione..............: 4,67 Kb
// Data Creazione..........: 13/05/2013 15:45:36
// Data ultima Modifica....: 29/05/2013 09:36:59
// ---------------------------------------------------------------

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Dnw.Base.Entities
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	[DataContract(Name = "CNBASE")]
	public abstract class ConnectionInfoBase : IEntity
	{

		#region Constants

		/// <summary>
		/// ConnectionID
		/// N/A
		/// </summary>
		public const string FLD_ConnectionID = "ConnectionID";

		/// <summary>
		/// Connection Type
		/// N/A
		/// </summary>
		public const string FLD_ConnectionType = "ConnectionType";

		/// <summary>
		/// Description
		/// N/A
		/// </summary>
		public const string FLD_Description = "Description";

		/// <summary>
		/// IsValid
		/// N/A
		/// </summary>
		public const string FLD_IsValid = "IsValid";

		/// <summary>
		/// Position
		/// N/A
		/// </summary>
		public const string FLD_Position = "Position";

		#endregion

		#region Fields

		/// <summary>
		/// ConnectionID
		/// N/A
		/// </summary>
		private string mConnectionID;

		/// <summary>
		/// Connection Type
		/// N/A
		/// </summary>
		private string mConnectionType;

		/// <summary>
		/// Description
		/// N/A
		/// </summary>
		private string mDescription;

		/// <summary>
		/// Position
		/// N/A
		/// </summary>
		private int mPosition;

		#endregion

		#region Protected Methods

		/// <summary>
		/// Called when [property changed].
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion

		/// <summary>
		/// Gets the connection string should be implemented in the derived classes.
		/// </summary>
		/// <value>
		/// The connection string.
		/// </value>
		public abstract string ConnectionString { get; }

		/// <summary>
		/// Determines whether this instance is valid.
		/// </summary>
		/// <returns>
		///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
		/// </returns>
		public abstract bool IsValid { get; }

		/// <summary>
		/// ConnectionID
		/// N/A
		/// </summary>
		[DataMember(Name = "ID", EmitDefaultValue = false)]
		public string ConnectionID
		{
			get
			{
				return mConnectionID;
			}
			set
			{
				mConnectionID = value.Trim().ToUpper();
				OnPropertyChanged(FLD_ConnectionID);
				OnPropertyChanged(FLD_IsValid);
			}
		}

		/// <summary>
		/// Description
		/// N/A
		/// </summary>
		[DataMember(Name = "DD", EmitDefaultValue = false)]
		public string Description
		{
			get
			{
				return mDescription;
			}
			set
			{
				mDescription = value;
				OnPropertyChanged(FLD_Description);
			}
		}

		/// <summary>
		/// Position
		/// N/A
		/// </summary>
		[DataMember(Name = "POS", EmitDefaultValue = false)]
		public int Position
		{
			get
			{
				return mPosition;
			}
			set
			{
				mPosition = value;
				OnPropertyChanged(FLD_Position);
			}
		}

		/// <summary>
		/// Connection Type
		/// N/A
		/// </summary>
		[DataMember(Name = "CTY", EmitDefaultValue = false)]
		public string ConnectionType
		{
			get
			{
				return mConnectionType;
			}
			set
			{
				mConnectionType = value;
				OnPropertyChanged(FLD_ConnectionType);
			}
		}

		/// <summary>
		/// Occurs when a property value changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;


		/// <summary>
		/// Copies the content of this instance to another of the same kind
		/// it is made to implement a better CopyTo and clone on the derived
		/// classes
		/// </summary>
		/// <param name="newItem">The destination item.</param>
		public void CopyTo(ConnectionInfoBase newItem)
		{
			newItem.ConnectionID = this.ConnectionID;
			newItem.ConnectionType = this.ConnectionType;
			newItem.Description = this.Description;
			newItem.Position = this.Position;
		}
	}
}