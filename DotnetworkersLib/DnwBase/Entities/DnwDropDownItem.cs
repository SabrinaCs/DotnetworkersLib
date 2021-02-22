// ---------------------------------------------------------------
// DATI FILE DnwDropDownItem.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: DnwDropDownItem.cs
// Namespace...............: Dnw.Base.Entities
// Classi..................: public DnwDropDownItem:INotifyPropertyChanged
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 113
// Dimensione..............: 2,67 Kb
// Data Creazione..........: 24/05/2013 17:03:00
// Data ultima Modifica....: 26/05/2013 11:03:34
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.ComponentModel;



namespace Dnw.Base.Entities
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	public class DnwDropDownItem:INotifyPropertyChanged
	{


		/// <summary>
		/// Description
		/// N/A
		/// </summary>
		public const string FLD_Description = "Description";

		/// <summary>
		/// Description
		/// N/A
		/// </summary>
		private string mDescription;

		/// <summary>
		/// Description
		/// N/A
		/// </summary>
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
		/// Value
		/// N/A
		/// </summary>
		public const string FLD_Value = "Value";

		/// <summary>
		/// Value
		/// N/A
		/// </summary>
		private string mValue;

		/// <summary>
		/// Value
		/// N/A
		/// </summary>
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

	


		//using System.CompnentModel; //se necessario
		/// <summary>
		/// Evento generato alla modifica di una property.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		///<summary>
		/// Evento che viene generato alla modifica di una property
		///</summary>
		/// <param name="pPropertyName">nome della property</param>
		protected virtual void OnPropertyChanged(string pPropertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(pPropertyName));
		}



		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return string.Format("{0} {1}", Value, Description);

		}

	}
}