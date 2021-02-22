// ---------------------------------------------------------------
// DATI FILE ChildObjectsCollection.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseWpf
// File....................: ChildObjectsCollection.cs
// Namespace...............: Dnw.Base.Wpf.Collections
// Classi..................: public ChildObjectsCollection<T> : List<ChildObject<T>> where T:class
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 37
// Dimensione..............: 1,49 Kb
// Data Creazione..........: 14/06/2013 14:08:19
// Data ultima Modifica....: 14/06/2013 14:25:50
// ---------------------------------------------------------------

using Dnw.Base.Wpf.Entities;
using System.Collections.Generic;
using System.Linq;



namespace Dnw.Base.Wpf.Collections
{
	/// <summary>
	/// Collection of child objects to implement check to avoid opening more than one
	/// window or tab in the UI
	/// </summary>
	public class ChildObjectsCollection<T> : List<ChildObject<T>> where T:class
	{


		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="objectName">Name of the object.</param>
		/// <returns>
		/// The child window or null if not found
		/// </returns>
		public ChildObject<T> this[string objectName]
		{
			get
			{
				return (this.FirstOrDefault(item => item.Name == objectName));
			}
		}




	}
}