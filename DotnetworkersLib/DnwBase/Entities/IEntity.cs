// ---------------------------------------------------------------
// DATI FILE IEntity.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: IEntity.cs
// Namespace...............: Dnw.Base.Entities
// Classi..................:
// Interfacce..............: public IEntity :  INotifyPropertyChanged
// Enumerazioni............:
// Linee di codice.........: 22
// Dimensione..............: 1,59 Kb
// Data Creazione..........: 17/04/2013 14:34:09
// Data ultima Modifica....: 23/04/2013 12:44:37
// ---------------------------------------------------------------

using System;
using System.ComponentModel;

namespace Dnw.Base.Entities
{
	/// <summary>
	/// The common interface for entities.
	/// It's the base contract used for defining entities.
	/// </summary>
	public interface IEntity :  INotifyPropertyChanged
	{

		/// <summary>
		/// Validates the istance checking the value of a subset of the internal state variables. 
		/// </summary>
		/// <returns>A boolean value that indicates if the istance is valid.</returns>
		bool IsValid {get;}

	}
}
