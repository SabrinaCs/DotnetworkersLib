// ---------------------------------------------------------------
// DATI FILE SendMessageEventArgs.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: SendMessageEventArgs.cs
// Namespace...............: Dnw.Base
// Classi..................: public SendMessageEventArgs : System.EventArgs
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 81
// Dimensione..............: 2,25 Kb
// Data Creazione..........: 18/04/2013 18:48:08
// Data ultima Modifica....: 23/04/2013 12:44:59
// ---------------------------------------------------------------



namespace Dnw.Base
{



	/// <summary>
	/// Event argument class used to give the data to the logging system
	/// </summary>
	public class SendMessageEventArgs : System.EventArgs
	{
		#region Fields


		/// <summary>
		/// The message
		/// </summary>
		private readonly string mMessageToLog;


		/// <summary>
		/// The message type
		/// </summary>
		private readonly MessageType mMessageType;

		#endregion

		#region Constructors


		/// <summary>
		/// Initializes a new instance of the <see cref="SendMessageEventArgs" /> class.
		/// </summary>
		/// <param name="messageToSend">The message to send.</param>
		/// <param name="messageType">Type of the message.</param>
		public SendMessageEventArgs(string messageToSend, MessageType messageType)
		{
			this.mMessageToLog = messageToSend;
			this.mMessageType = messageType;
		}

		#endregion

		#region Properties

		///<summary> 
		/// Message
		///</summary>
		public string MessageToLog
		{
			get
			{
				return (this.mMessageToLog);
			}
		}

		///<summary> 
		/// Message type
		///</summary>
		public MessageType MessageType
		{
			get
			{
				return (this.mMessageType);
			}
		}

		#endregion

	}


	/// <summary>
	/// Delegate to use the Send Message Arguments in an event
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The <see cref="SendMessageEventArgs" /> instance containing the event data.</param>
	public delegate void SendMessageEventHandler(object sender, SendMessageEventArgs e);
}