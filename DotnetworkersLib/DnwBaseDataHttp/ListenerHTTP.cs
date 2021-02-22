// ---------------------------------------------------------------
// DATI FILE ListenerHTTP.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseDataHttp
// File....................: ListenerHTTP.cs
// Namespace...............: Dnw.Base.Data.Http
// Classi..................: public ListenerHTTP
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 216
// Dimensione..............: 5,14 Kb
// Data Creazione..........: 14/05/2013 17:10:51
// Data ultima Modifica....: 29/05/2013 16:16:15
// ---------------------------------------------------------------

using System;
using System.Net;
using System.Threading;
using Dnw.Base.Data.Http.Entities;

namespace Dnw.Base.Data.Http
{
	///<summary>
	/// Listen data and call a method (<see cref="RequestReceivedDelegate"/>) on recive data
	///</summary>
	public class ListenerHTTP
	{

		#region Fields

		private HttpListener mListener;

		/// <summary>
		/// Listener thread
		/// </summary>
		private Thread mListenerThread;

		/// <summary>
		/// Delegate to function to call on incoming data
		/// </summary>
		public RequestReceivedDelegate RequestReceived;

		#endregion

		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ListenerHTTP"/> class.
		/// </summary>
		/// <param name="connectionToListen">The connection to listen.</param>
		/// <param name="priority">The priority of the listening thread</param>
		/// <param name="isBackgroundThread">if set to <c>true</c> [is background thread].</param>
		/// <param name="sendResponseToRequest">if set to <c>true</c> [send response to request].</param>
		/// <param name="autoStart">if set to <c>true</c> [auto start].</param>
		public ListenerHTTP(HttpConnectionInfo connectionToListen, ThreadPriority priority, bool isBackgroundThread = true, bool sendResponseToRequest = true, bool autoStart = true)
		{
			try
			{
				IsListening = false;
				ConnectionToListen = connectionToListen;
				SendResponseToRequest = sendResponseToRequest;

				if (autoStart)
				{
					Start(priority, isBackgroundThread: isBackgroundThread);
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}

		#endregion

		#region Properties

		///<summary> 
		/// Connection to listen
		///</summary>   
		public HttpConnectionInfo ConnectionToListen
		{
			get;
			private set;
		}

		///<summary> 
		/// Indicates if the listner is listening
		///</summary>   
		public bool IsListening
		{
			get;
			private set;
		}

		///<summary> 
		/// If true the value returned from RequestReceived delegate is sended to sender
		///</summary>   
		public bool SendResponseToRequest
		{
			get;
			set;
		}

		#endregion

		#region Public Methods


		/// <summary>
		/// Starts the listen.
		/// </summary>
		/// <param name="priority">The priority.</param>
		/// <param name="isBackgroundThread">if set to <c>true</c> [is background thread].</param>
		public void Start(ThreadPriority priority, bool isBackgroundThread = true)
		{
			try
			{
				DestroyListener();

				IsListening = true;

				mListener = new HttpListener();
				string cn = ConnectionToListen.ConnectionString;
				if (!cn.EndsWith("/"))
				{
					cn = cn + "/";
				}
				mListener.Prefixes.Add(cn);
				mListener.Start();

				mListenerThread = new Thread(OnDataReceived)
				{
					Priority = priority,
					IsBackground = isBackgroundThread
				};
				mListenerThread.Start();
			}
			catch (Exception ex)
			{
				DestroyListener();

				EventLogger.SendMsg(ex);
				throw;
			}
		}

		private void DestroyListener()
		{
			try
			{
				IsListening = false;
				if (mListener != null)
				{
					mListener.Close();
					mListener = null;
				}
			}
			catch { }
		}

		/// <summary>
		/// Stops the listen.
		/// </summary>
		public void Stop()
		{
			try
			{
				DestroyListener();
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}

		#endregion

		#region Private Methods

		private void ListenerCallback(IAsyncResult result)
		{

			try
			{
				HttpListener listener = (HttpListener)result.AsyncState;
				if ((listener != null) && (listener.IsListening))
				{
					HttpListenerContext context = listener.EndGetContext(result);

					DecodeFromContext wrk = new DecodeFromContext(context, SendResponseToRequest, this.RequestReceived);
					Thread th = new Thread(wrk.ProcessRequest);
					th.Start();
					th.Join();
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}

		/// <summary>
		/// Called when [data received].
		/// </summary>
		private void OnDataReceived()
		{
			try
			{
				while ((mListener != null) && (mListener.IsListening))
				{
					IAsyncResult context = mListener.BeginGetContext(new AsyncCallback(ListenerCallback), mListener);
					context.AsyncWaitHandle.WaitOne();
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}

		#endregion

	}

}