// ---------------------------------------------------------------
// DATI FILE ServiceHelper.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseServices
// File....................: ServiceHelper.cs
// Namespace...............: Dnw.Base.Services
// Classi..................: public static ServiceHelper
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 86
// Dimensione..............: 2,6 Kb
// Data Creazione..........: 27/05/2013 14:51:12
// Data ultima Modifica....: 27/05/2013 18:11:42
// ---------------------------------------------------------------

using System;
using System.ServiceProcess;

namespace Dnw.Base.Services
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	public static class ServiceHelper
	{

		/// <summary>
		/// Controlla lo stato d di un servizio
		/// </summary>
		/// <param name="pServiceName">Name of the p service.</param>
		/// <returns></returns>
		public static ServiceControllerStatus CheckServiceState(string pServiceName)
		{
			try
			{
				ServiceControllerStatus ret = ServiceControllerStatus.Stopped;
				try
				{
					ServiceManager serviceManager = new ServiceManager(pServiceName);
					ret = serviceManager.Status;
				}
				catch
				{
					//Ignora le eccezioni
				}

				return (ret);
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}

		/// <summary>
		/// Fai fermare o partire il servizio
		/// </summary>
		/// <param name="pStartState">Start state of the p.</param>
		/// <param name="pServiceName">Name of the p service.</param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		public static ServiceControllerStatus SwitchService(
			ServiceControllerStatus pStartState, string pServiceName)
		{
			try
			{
				ServiceManager serviceManager = new ServiceManager(pServiceName);
				string msg = string.Empty;
				if (pStartState == ServiceControllerStatus.Running)
				{
					if (serviceManager.CanStop)
					{
						serviceManager.Stop();
						msg = string.Format(ServiceHelperRx.warSHLPServiceStopRequested, pServiceName);
					}
				}
				else
				{
					if (!serviceManager.CanStop)
					{
						serviceManager.Start();
						msg = string.Format(ServiceHelperRx.warSHLPServiceStartRequested, pServiceName);

					}
				}
				EventLogger.SendMsg(msg, MessageType.Info);
				return (serviceManager.Status);
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}

	}
}
