// ---------------------------------------------------------------
// DATI FILE D:\DNW\DnwLibraries\DnwBaseDataHttp\HTTPDataReceivedEventArgs.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseDataHttp
// File....................: HTTPDataReceivedEventArgs.cs
// Namespace...............: Dnw.Base.Data.Http
// Classi..................: public HTTPDataReceivedEventArgs : EventArgs
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 137
// Dimensione..............: 4,05 Kb
// Data Creazione..........: 14/05/2013 13:58:43
// Data ultima Modifica....: 21/05/2013 11:48:32
// ---------------------------------------------------------------

using System;
using System.Collections.Specialized;
using System.Net;

namespace Dnw.Base.Data.Http
{
	/// <summary>
	/// Delegate to call on incoming data.
	/// After the creation of <see cref="ListenerHTTP"/> class remember to assign this event handler (listener.RequestReceived=new RequestReceivedDelegate(NameOfTheFuncionToCall);)
	/// The result if the function (string) will be transitted to the sender (if SendResponseToRequest is enabled)
	/// </summary>
	public delegate string RequestReceivedDelegate(HTTPDataReceivedEventArgs httpDataReceived);

	///<summary>
	/// Data recived from HTTP Listener
	///</summary>
	public class HTTPDataReceivedEventArgs : EventArgs
	{

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="HTTPDataReceivedEventArgs"/> class.
		/// </summary>
		/// <param name="requestedURL">The requested URL.</param>
		/// <param name="txDate">The tx date.</param>
		/// <param name="senderEndPoint">The sender end point.</param>
		/// <param name="destinationEndPoint">The destination end point.</param>
		/// <param name="dataReceived">The data received.</param>
		/// <param name="httpMethod">The HTTP method.</param>
		/// <param name="contentType">Type of the content.</param>
		/// <param name="contentLength">Length of the content.</param>
		/// <param name="fieldsCollection">The fields collection.</param>
		public HTTPDataReceivedEventArgs(string requestedURL, DateTime? txDate, IPEndPoint senderEndPoint, IPEndPoint destinationEndPoint, string dataReceived, string httpMethod, string contentType, long contentLength, NameValueCollection fieldsCollection)
		{
			RequestedURL = requestedURL;
			SenderEndPoint = senderEndPoint;
			DestinationEndPoint = destinationEndPoint;
			DataReceived = dataReceived;
			HttpMethod = httpMethod;
			ContentType = contentType;
			ContentLength = contentLength;
			FieldsCollection = fieldsCollection;
			TxDate = txDate;
		}

		#endregion

		#region Properties

		///<summary> 
		/// Lenght of recived data
		///</summary>
		public long ContentLength
		{
			get;
			private set;
		}

		///<summary> 
		/// ContentType
		///</summary>
		public string ContentType
		{
			get;
			private set;
		}

		///<summary> 
		/// Data Received (only GET transmission type, otherwise null)
		///</summary>
		public string DataReceived
		{
			get;
			private set;
		}

		///<summary> 
		/// Destination URL
		///</summary>   
		public IPEndPoint DestinationEndPoint
		{
			get;
			private set;
		}

		///<summary> 
		/// Collection dei campi (null se non multipart)
		///</summary>   
		public NameValueCollection FieldsCollection
		{
			get;
			private set;
		}

		/// <summary>
		/// The HTTP method of transission
		/// </summary>
		/// <value>The HTTP method.</value>
		public string HttpMethod
		{
			get;
			private set;
		}

		/// <summary>
		/// The request URL
		/// </summary>
		public string RequestedURL
		{
			get;
			private set;
		}

		///<summary> 
		/// URL of the sender
		///</summary>   
		public IPEndPoint SenderEndPoint
		{
			get;
			private set;
		}

		/// <summary>
		/// Date and time of transmission
		/// </summary>
		public DateTime? TxDate
		{
			get;
			private set;
		}

		#endregion

	}
}