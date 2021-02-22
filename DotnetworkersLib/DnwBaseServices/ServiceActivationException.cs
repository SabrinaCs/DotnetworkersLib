// ---------------------------------------------------------------
// DATI FILE ServiceActivationException.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseServices
// File....................: ServiceActivationException.cs
// Namespace...............: Dnw.Base.Services
// Classi..................: public ServiceActivationException : System.ApplicationException
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 31
// Dimensione..............: 1,24 Kb
// Data Creazione..........: 27/05/2013 14:51:10
// Data ultima Modifica....: 27/05/2013 14:53:53
// ---------------------------------------------------------------


namespace Dnw.Base.Services
{
	///<summary>
	/// Descrizione della classe: Eccezione personalizzata per $end$
	///</summary>
	///<remarks>
	///</remarks>
	public class ServiceActivationException : System.ApplicationException
	{
		#region Constructors

		/// <summary>
		/// Costruttore
		/// </summary>
		/// <param name="pMessage">Messaggio di errore</param>
		/// <remarks>
		/// V.1.0
		/// </remarks>
		public ServiceActivationException(string pMessage)
			: base(pMessage)
		{

		}

		#endregion

	}
}
