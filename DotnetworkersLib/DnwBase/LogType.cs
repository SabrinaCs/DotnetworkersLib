// ---------------------------------------------------------------
// DATI FILE LogType.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: LogType.cs
// Namespace...............: Dnw.Base
// Classi..................:
// Interfacce..............:
// Enumerazioni............: public LogType : int
// Linee di codice.........: 33
// Dimensione..............: 1,56 Kb
// Data Creazione..........: 18/04/2013 18:48:08
// Data ultima Modifica....: 23/04/2013 12:44:36
// ---------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dnw.Base
{
	/// <summary>
	/// Tipi di log attivabili
	/// </summary>
	public enum LogType : int
	{
		/// <summary>
		/// Nessun Log
		/// </summary>
		None = 0,
		/// <summary>
		/// Solo eccezioni
		/// </summary>
		ExceptionsOnly,
		/// <summary>
		/// Eccezioni e avvisi
		/// </summary>
		WarningsAndExceptions,
		/// <summary>
		/// Tutti i messaggi
		/// </summary>
		AllMessages,
	}
}
