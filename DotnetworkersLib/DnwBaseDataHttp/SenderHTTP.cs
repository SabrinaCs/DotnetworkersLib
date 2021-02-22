// ---------------------------------------------------------------
// DATI FILE SenderHTTP.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseDataHttp
// File....................: SenderHTTP.cs
// Namespace...............: Dnw.Base.Data.Http
// Classi..................: public static SenderHTTP
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 230
// Dimensione..............: 6,85 Kb
// Data Creazione..........: 14/05/2013 17:10:52
// Data ultima Modifica....: 11/06/2013 12:37:59
// ---------------------------------------------------------------

using Dnw.Base.Data.Http.Entities;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace Dnw.Base.Data.Http
{
	///<summary>
	/// Sends data through
	///</summary>
	public static class SenderHTTP
	{
		#region Public Methods

		/// <summary>
		/// Makes an HTTP GET call and return the result string recived from addressee
		/// </summary>
		/// <param name="connectionData">Data for connection</param>
		/// <param name="parametrizerDataToSend">Data to send (key, value)</param>
		/// <param name="ignoreWebErrors">if set to <c>true</c> [ignore web errors].</param>
		/// <returns>
		/// The answer received from addressee
		/// </returns>
		public static string HTTPGet(HttpConnectionInfo connectionData, 
			NameValueCollection parametrizerDataToSend, bool ignoreWebErrors = false)
		{
			string result = string.Empty;
			HttpWebRequest txRequest = null;
			try
			{
				StringBuilder sbParams = new StringBuilder(connectionData.ConnectionString);
				if ((parametrizerDataToSend != null) && (parametrizerDataToSend.Count > 0))
				{
					string paramSeparator = "?";
					for (int i = 0; i < parametrizerDataToSend.Count; i++)
					{
						sbParams.Append(paramSeparator);
						sbParams.Append(parametrizerDataToSend.GetKey(i));
						sbParams.Append("=");
						sbParams.Append(HttpUtility.UrlEncode(parametrizerDataToSend.Get(i)));
						paramSeparator = "&";
					}
				}

				txRequest = (HttpWebRequest)WebRequest.Create(sbParams.ToString());
				txRequest.Method = "GET";
				txRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
				txRequest.Timeout = connectionData.Timeout;
				txRequest.Date = DateTime.Now.ToUniversalTime();

				result = GetResponse(txRequest);
			}
			catch (WebException wEx)
			{
				if (ignoreWebErrors)
				{
					result = string.Format("WEBERROR:{0}", wEx.Message);
				}
				else
				{
					EventLogger.SendMsg(wEx);
					throw;
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
			finally
			{
				if (txRequest != null)
				{
					try
					{
						txRequest.Abort();
					}
					catch { }

					txRequest = null;
				}
			}

			return (result);
		}

		/// <summary>
		/// Sends data with POST method.
		/// The content type is multipart/form-data
		/// </summary>
		/// <param name="connectionData">Data for connection</param>
		/// <param name="parametrizerDataToSend">Data to send (key, value)</param>
		/// <param name="waitResponse">if set to <c>true</c> [wait response].</param>
		/// <param name="ignoreWebErrors">if set to <c>true</c> [ignore web errors].</param>
		/// <returns>
		/// The response if wait for it or string.empty
		/// </returns>
		public static string HTTPPost(HttpConnectionInfo connectionData,
			NameValueCollection parametrizerDataToSend, 
			bool waitResponse = true, bool ignoreWebErrors = false)
		{
			string result = string.Empty;
			HttpWebRequest txRequest = null;

			try
			{
				if (parametrizerDataToSend != null)
				{
					string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");

					ServicePointManager.Expect100Continue = false;

					txRequest = (HttpWebRequest)WebRequest.Create(connectionData.ConnectionString);
					txRequest.ContentType = "multipart/form-data; boundary=" + boundary;
					txRequest.Method = "POST";
					txRequest.KeepAlive = waitResponse;
					txRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
					txRequest.Timeout = connectionData.Timeout;
					txRequest.Date = DateTime.Now.ToUniversalTime();

					using (Stream memStream = new MemoryStream())
					{
						byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

						string formdataTemplate = "\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";

						foreach (string key in parametrizerDataToSend.Keys)
						{
							string formitem = string.Format(formdataTemplate, key, parametrizerDataToSend[key]);
							byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
							memStream.Write(formitembytes, 0, formitembytes.Length);
						}
						memStream.Write(boundarybytes, 0, boundarybytes.Length);

						string footer = "\r\n--" + boundary + "--\r\n";
						byte[] footerbytes = System.Text.Encoding.UTF8.GetBytes(footer);
						memStream.Write(footerbytes, 0, footerbytes.Length);

						txRequest.ContentLength = memStream.Length;

						using (Stream requestStream = txRequest.GetRequestStream())
						{
							memStream.Position = 0;
							byte[] tempBuffer = new byte[memStream.Length];
							memStream.Read(tempBuffer, 0, tempBuffer.Length);
							requestStream.Write(tempBuffer, 0, tempBuffer.Length);
							requestStream.Flush();
							requestStream.Close();
						}
						memStream.Close();
					}

					if (waitResponse)
					{
						result = GetResponse(txRequest);
					}
				}
			}
			catch (WebException wEx)
			{
				if (ignoreWebErrors)
				{
					result = string.Format("WEBERROR:{0}", wEx.Message);
				}
				else
				{
					EventLogger.SendMsg(wEx);
					throw;
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
			finally
			{
				if (txRequest != null)
				{
					try
					{
						txRequest.Abort();
					}
					catch { }

					txRequest = null;
				}
			}

			return (result);
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Gets the response.
		/// </summary>
		/// <param name="txRequest">The tx request.</param>
		/// <returns></returns>
		private static string GetResponse(HttpWebRequest txRequest)
		{
			string result = string.Empty;

			using (WebResponse response = txRequest.GetResponse())
			{
				using (Stream responseStream = response.GetResponseStream())
				{
					using (StreamReader responseStreamReader = new StreamReader(responseStream))
					{
						result = responseStreamReader.ReadToEnd();
						responseStreamReader.Close();
					}
					responseStream.Close();
				}
				response.Close();
			}

			return result;
		}

		#endregion

	}
}