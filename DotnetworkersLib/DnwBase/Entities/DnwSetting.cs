// ---------------------------------------------------------------
// DATI FILE DnwSetting.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: DnwSetting.cs
// Namespace...............: Dnw.Base.Entities
// Classi..................: public DnwSetting : IEntity
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 320
// Dimensione..............: 6,57 Kb
// Data Creazione..........: 13/05/2013 17:02:08
// Data ultima Modifica....: 26/05/2013 11:03:35
// ---------------------------------------------------------------

using Dnw.Base.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace Dnw.Base.Entities
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	[XmlRoot(Namespace = "http://www.dotnetwork.it")]
	public class DnwSetting : IEntity
	{
		#region Constants

		/// <summary>
		/// Setting category for Grouping reasons
		/// N/A
		/// </summary>
		public const string FLD_Category = "Category";

		/// <summary>
		/// Description for this setting
		/// N/A
		/// </summary>
		public const string FLD_Description = "Description";

		/// <summary>
		/// List to host the keys and values to implement combo box elements
		/// N/A
		/// </summary>
		public const string FLD_DropdownValues = "DropdownValues";

		/// <summary>
		/// The Type of the editor used to set the value of this object
		/// N/A
		/// </summary>
		public const string FLD_EditorType = "EditorType";

		/// <summary>
		/// Unique identifier for this setting
		/// N/A
		/// </summary>
		public const string FLD_ID = "ID";

		/// <summary>
		/// Mask
		/// N/A
		/// </summary>
		public const string FLD_Mask = "Mask";

		/// <summary>
		/// Position
		/// N/A
		/// </summary>
		public const string FLD_Position = "Position";

		/// <summary>
		/// Value of this setting
		/// N/A
		/// </summary>
		public const string FLD_Value = "Value";

		#endregion

		#region Fields

		/// <summary>
		/// Setting category for Grouping reasons
		/// N/A
		/// </summary>
		private string mCategory;

		/// <summary>
		/// Description for this setting
		/// N/A
		/// </summary>
		private string mDescription;

		/// <summary>
		/// List to host the keys and values to implement combo box elements
		/// N/A
		/// </summary>
		private DnwDropDownItemsCollection mDropdownValues;

		/// <summary>
		/// The Type of the editor used to set the value of this object
		/// N/A
		/// </summary>
		private EditorType mEditorType;

		/// <summary>
		/// Unique identifier for this setting
		/// N/A
		/// </summary>
		private string mID;

		/// <summary>
		/// Mask
		/// N/A
		/// </summary>
		private string mMask;

		/// <summary>
		/// Position
		/// N/A
		/// </summary>
		private int mPosition;

		/// <summary>
		/// Value of this setting
		/// N/A
		/// </summary>
		private string mValue;

		#endregion

		#region Public Methods

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("[{0}] {1} {2} {3} ({4})",
				Category, ID, Description, Value,
				IsValid ? "Valid" : "Not Valid");
			sb.AppendLine();
			return (sb.ToString());
		}

		#endregion

		#region Protected Methods

		///<summary>
		/// Evento che viene generato alla modifica di una property
		///</summary>
		/// <param name="pPropertyName">nome della property</param>
		protected virtual void OnPropertyChanged(string pPropertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(pPropertyName));
		}

		#endregion

		/// <summary>
		/// Unique identifier for this setting
		/// N/A
		/// </summary>
		[XmlAttribute]
		public string ID
		{
			get
			{
				return mID;
			}
			set
			{
				mID = value;
				OnPropertyChanged(FLD_ID);
			}
		}

		/// <summary>
		/// Value of this setting
		/// </summary>
		[XmlElement]
		public string Value
		{
			get
			{
				return mValue;
			}
			set
			{
				mValue = value;
				OnPropertyChanged(FLD_Value);
			}
		}
	
		/// <summary>
		/// Setting category for Grouping reasons
		/// N/A
		/// </summary>
		[XmlIgnore]
		public string Category
		{
			get
			{
				return mCategory;
			}
			set
			{
				mCategory = value;
				OnPropertyChanged(FLD_Category);
			}
		}



		/// <summary>
		/// Description for this setting
		/// N/A
		/// </summary>
		[XmlIgnore]
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
		/// The Type of the editor used to set the value of this object
		/// N/A
		/// </summary>
		[XmlIgnore]
		public EditorType EditorType
		{
			get
			{
				return mEditorType;
			}
			set
			{
				mEditorType = value;
				OnPropertyChanged(FLD_EditorType);
			}
		}

		/// <summary>
		/// Position
		/// N/A
		/// </summary>
		[XmlIgnore]
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
		/// Mask
		/// N/A
		/// </summary>
		[XmlIgnore]
		public string Mask
		{
			get
			{
				return mMask;
			}
			set
			{
				mMask = value;
				OnPropertyChanged(FLD_Mask);
			}
		}

		/// <summary>
		/// List to host the keys and values to implement combo box elements
		/// N/A
		/// </summary>
		[XmlIgnore]
		public DnwDropDownItemsCollection DropdownValues
		{
			get
			{
				return mDropdownValues;
			}
			set
			{
				mDropdownValues = value;
				OnPropertyChanged(FLD_DropdownValues);
			}
		}

		/// <summary>
		/// Validates the istance checking the value of a subset of the internal state variables.
		/// </summary>
		/// <returns>A boolean value that indicates if the istance is valid.</returns>
		public bool IsValid
		{
			get
			{
				return (!this.ID.XDwIsNullOrTrimEmpty());
			}
		}

		//using System.CompnentModel; //se necessario
		/// <summary>
		/// Evento generato alla modifica di una property.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

	}
}