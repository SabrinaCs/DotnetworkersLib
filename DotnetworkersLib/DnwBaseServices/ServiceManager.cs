// ---------------------------------------------------------------
// DATI FILE ServiceManager.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseServices
// File....................: ServiceManager.cs
// Namespace...............: Dnw.Base.Services
// Classi..................: public ServiceManager
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 84
// Dimensione..............: 2,05 Kb
// Data Creazione..........: 27/05/2013 14:51:13
// Data ultima Modifica....: 27/05/2013 17:30:04
// ---------------------------------------------------------------

using System.ServiceProcess;

namespace Dnw.Base.Services
{
	///<summary>
	/// Descrizione della classe: Classe x il controllo e la manipolazione di un servizio
	///</summary>
	///<remarks>
	/// 
	///</remarks>
	public class ServiceManager
	{

		ServiceController mController;

		/// <summary>
		/// Restarts this instance.
		/// </summary>
		public void Restart()
		{
			Stop();
			Start();
		}

		/// <summary>
		/// Costruttore
		/// </summary>
		/// <param name="service">nome del servizio</param>
		public ServiceManager(string service)
		{
			mController = new System.ServiceProcess.ServiceController(service, System.Net.Dns.GetHostName());

		}

		/// <summary>
		/// Starts this instance.
		/// </summary>
		public void Start()
		{
			if (!this.CanStop)
			{
				mController.Start();
			}
		}

		/// <summary>
		/// Stops this instance.
		/// </summary>
		public void Stop()
		{
			if (this.CanStop)
			{
				mController.Stop();
			}
		}

		/// <summary>
		/// Indica se il servizio si può fermare
		/// </summary>
		///<remarks>
		///</remarks>
		public bool CanStop
		{
			get
			{
				return this.mController.CanStop;
			}
		}

		/// <summary>
		/// Status del servizio
		/// </summary>
		public ServiceControllerStatus Status
		{
			get
			{
				return (this.mController.Status);
			}
		}

	}
}
