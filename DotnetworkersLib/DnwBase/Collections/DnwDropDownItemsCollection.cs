// ---------------------------------------------------------------
// DATI FILE DnwDropDownItemsCollection.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: DnwDropDownItemsCollection.cs
// Namespace...............: Dnw.Base.Collections
// Classi..................: public DnwDropDownItemsCollection: List<DnwDropDownItem>
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 37
// Dimensione..............: 1,77 Kb
// Data Creazione..........: 24/05/2013 17:04:26
// Data ultima Modifica....: 24/05/2013 17:08:04
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Dnw.Base.Entities;



namespace Dnw.Base.Collections
{
	///<summary>
	/// Collection of dropdown Items
	///</summary>
	public class DnwDropDownItemsCollection: List<DnwDropDownItem>
	{


		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < this.Count; i++)
			{
				sb.AppendLine(this[i].ToString());
			}
			return (sb.ToString());
		}

	}
}