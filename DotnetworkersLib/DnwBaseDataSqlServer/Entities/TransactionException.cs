// ---------------------------------------------------------------
// DATI FILE TransactionException.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseDataSqlServer
// File....................: TransactionException.cs
// Namespace...............: Dnw.Base.Data.SqlServer.Entities
// Classi..................: public TransactionException : System.ApplicationException
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 26
// Dimensione..............: 494 Bytes
// Data Creazione..........: 18/04/2013 18:35:28
// Data ultima Modifica....: 23/04/2013 12:47:44
// ---------------------------------------------------------------


namespace Dnw.Base.Data.SqlServer.Entities
{
	///<summary>
	/// Descrizione della classe: Eccezione personalizzata per $end$
	///</summary>
	///<remarks>
	///</remarks>
	public class TransactionException : System.ApplicationException
	{
		#region Constructors

		/// <summary>
		/// Costruttore
		/// </summary>
		/// <param name="pMessage">Messaggio di errore</param>
		public TransactionException(string pMessage)
			: base(pMessage)
		{

		}

		#endregion

	}
}
