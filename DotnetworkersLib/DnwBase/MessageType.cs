// ---------------------------------------------------------------
// DATI FILE MessageType.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: MessageType.cs
// Namespace...............: Dnw.Base
// Classi..................:
// Interfacce..............:
// Enumerazioni............: public MessageType : int
// Linee di codice.........: 29
// Dimensione..............: 1,46 Kb
// Data Creazione..........: 18/04/2013 18:48:08
// Data ultima Modifica....: 23/04/2013 12:44:35
// ---------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dnw.Base
{
	/// <summary>
	/// Tipo di messaggio spedito
	/// </summary>
	public enum MessageType : int
	{
		/// <summary>
		/// Informazione
		/// </summary>
		Info,
		/// <summary>
		/// Avviso
		/// </summary>
		Warning,
		/// <summary>
		/// Errore
		/// </summary>
		Error
	}
}
