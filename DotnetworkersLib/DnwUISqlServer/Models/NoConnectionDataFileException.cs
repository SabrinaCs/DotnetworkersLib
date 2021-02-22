// ---------------------------------------------------------------
// DATI FILE (AGGIORNA PREMENDO Ctrl + 7)
// ---------------------------------------------------------------
// Progetto................: Miscellaneous Files
// File....................: InvalidEntityException.cs
// Namespace...............: rootnamespace
// Classe..................: safeitemname
// Path....................: D:\4udata\00_OnlySourceControl\Templates\ItemTemplates\CSharp\General\1033\ExceptionClass
// Ultima modifica di......: scosolo
// Linee di codice.........: 37
// Dimensione..............: 601 Bytes
// Data Creazione..........: 25/05/2006 14.26
// Data ultima Modifica....: 09/09/2010 12.59
// ---------------------------------------------------------------

namespace Dnw.UI.SqlServer.Models
{
	///<summary>
	/// Descrizione della classe: Eccezione personalizzata per $end$
	///</summary>
	///<remarks>
	///</remarks>
	public class NoConnectionDataFileException : System.ApplicationException
	{
		#region Constructors

		/// <summary>
		/// Costruttore
		/// </summary>
		/// <param name="pMessage">Messaggio di errore</param>
		public NoConnectionDataFileException(string pMessage)
			: base(pMessage)
		{

		}

		#endregion

	}
}
