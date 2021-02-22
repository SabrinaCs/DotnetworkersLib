// ---------------------------------------------------------------
// DATI FILE EventLogger.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: EventLogger.cs
// Namespace...............: Dnw.Base
// Classi..................: public static EventLogger
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 107
// Dimensione..............: 3,51 Kb
// Data Creazione..........: 18/04/2013 18:48:08
// Data ultima Modifica....: 23/04/2013 12:44:37
// ---------------------------------------------------------------

using System;
using System.Reflection;

namespace Dnw.Base
{

	/// <summary>
	/// Classe statica con evento statico da collegare alla classe princiaple ed usare in tutte le altre
	/// per trasmettere tutto ciò che accade nel codice dell'applicazione.
	/// </summary>
	public static class EventLogger
	{

		#region Fields

		/// <summary>
		/// Type of logging
		/// </summary>
		private static LogType mLogType;

		/// <summary>
		/// Event to handle to receive the Logger Messages and manage them to a Log File
		/// or other repository.
		/// </summary>
		public static event SendMessageEventHandler LogNewEntry;

		/// <summary>
		/// Type of logging
		/// </summary>
		/// <value>
		/// The type of the log.
		/// </value>
		public static LogType LogType
		{
			get
			{
				return mLogType;
			}
			set
			{
				mLogType = value;
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Send a message to the log system
		/// </summary>
		/// <param name="messageToSend">Message to be sent</param>
		/// <param name="messageType">Type of message</param>
		public static void SendMsg(string messageToSend, MessageType messageType)
		{
			SendMessageEventArgs args = new SendMessageEventArgs(messageToSend, messageType);
			OnLogNewEntry(args);
		}

		/// <summary>
		/// Sends the data of an exception to the logging system
		/// </summary>
		/// <param name="exceptionToLog">The exception to log.</param>
		public static void SendMsg(Exception exceptionToLog)
		{

			PreserveStackTrace(exceptionToLog);

			SendMsg(exceptionToLog.XDwBuildExceptionMessage(), MessageType.Error);
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Raises the <see cref="E:LogNewEntry" /> event.
		/// </summary>
		/// <param name="e">The <see cref="SendMessageEventArgs" /> instance containing the event data.</param>
		private static void OnLogNewEntry(SendMessageEventArgs e)
		{
			if (LogNewEntry != null)
			{
				// Invokes the delegates. 
				LogNewEntry(null, e);
			}
		}

		/// <summary>
		/// Preserves the stack trace.
		/// </summary>
		/// <param name="exception">The exception.</param>
		private static void PreserveStackTrace(Exception exception)
		{
			MethodInfo preserveStackTrace = typeof(Exception).GetMethod("InternalPreserveStackTrace", BindingFlags.Instance | BindingFlags.NonPublic);
			preserveStackTrace.Invoke(exception, null);
		}

		#endregion


	
	}

}
