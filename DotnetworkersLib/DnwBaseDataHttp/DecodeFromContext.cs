// ---------------------------------------------------------------
// DATI FILE DecodeFromContext.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseDataHttp
// File....................: DecodeFromContext.cs
// Namespace...............: Dnw.Base.Data.Http
// Classi..................: internal DecodeFromContext
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 337
// Dimensione..............: 9,62 Kb
// Data Creazione..........: 14/05/2013 17:10:51
// Data ultima Modifica....: 29/05/2013 13:43:32
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace Dnw.Base.Data.Http
{
	/// <summary>
	/// Decodes the data listened and make the callback to the function passed to the listener
	/// </summary>
	internal class DecodeFromContext
	{

		#region Fields

		///<summary> 
		/// Content Type
		///</summary>   
		private string mContentType;

		/// <summary>
		/// the context of the connection/transmission
		/// </summary>
		private HttpListenerContext mContext;

		///<summary> 
		/// Content of fields
		///</summary>   
		private NameValueCollection mFieldsCollection;

		///<summary> 
		/// If true the value returned from RequestReceived is transitted back to the sender
		///</summary>   
		private bool mBuildResponse;

		///<summary> 
		/// Full data read (only GET transmission type)
		///</summary>   
		private string mReadData;

		/// <summary>
		/// Delegate to implement in the caller class to do whatever needed
		/// when data are received
		/// </summary>
		private RequestReceivedDelegate mRequestReceived;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="DecodeFromContext"/> class.
		/// </summary>
		/// <param name="context">The HTTP context data received.</param>
		/// <param name="buildResponse">if set to <c>true</c> [sends an answer to sender].</param>
		/// <param name="requestReceived">Delegate for call the caller class method with recieved data.</param>
		public DecodeFromContext(HttpListenerContext context, bool buildResponse, RequestReceivedDelegate requestReceived)
		{
			try
			{
				mContext = context;
				mBuildResponse = buildResponse;
				mFieldsCollection = new NameValueCollection();
				mRequestReceived = requestReceived;
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Processes the request.
		/// </summary>
		public void ProcessRequest()
		{
			try
			{
				if (mRequestReceived != null)
				{
					HttpListenerRequest request = mContext.Request;

					DateTime? txDate = null;
					string d = request.Headers["date"];
					if (!d.XDwIsNullOrTrimEmpty())
					{
						DateTime d1 = DateTime.Now;
						if (DateTime.TryParse(d, out d1))
						{
							txDate = d1;
						}
					}

					mContentType = request.ContentType;
					long contentLength = request.ContentLength64;
					string httpMethod = request.HttpMethod.ToUpper();
					string requestedURL = request.Url.ToString();

					bool isManagedMethod = false;

					if (httpMethod == "GET")
					{
						isManagedMethod = true;
						ParseGET(request);
					}
					else if (httpMethod == "POST")
					{
						isManagedMethod = true;
						ParsePOST(request);
					}

					if (isManagedMethod)
					{
						// I'm receiving, so the sender is the remote IP and the receiver is the local IP
						HTTPDataReceivedEventArgs args = new HTTPDataReceivedEventArgs(requestedURL,
							txDate, request.RemoteEndPoint, request.LocalEndPoint,
							mReadData, httpMethod, mContentType, contentLength, mFieldsCollection);
						string responseForRequest = mRequestReceived(args);

						if (mBuildResponse)
						{
							try
							{
								if (responseForRequest == null)
								{
									responseForRequest = string.Empty;
								}

								byte[] b = Encoding.UTF8.GetBytes(responseForRequest);
								mContext.Response.ContentLength64 = b.Length;
								mContext.Response.OutputStream.Write(b, 0, b.Length);
								mContext.Response.OutputStream.Close();
							}
							catch (Exception responseEx)
							{
								EventLogger.SendMsg(responseEx);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}

		#endregion

		#region Private Methods

		private Dictionary<string, string> ParseContentLine(string line)
		{
			Dictionary<string, string> output = new Dictionary<string, string>();

			try
			{
				string[] contentLinePieces = line.Split(";".ToCharArray());
				for (int i = 1; i < contentLinePieces.Length; i++)
				{
					string[] pieceParts = contentLinePieces[i].Split("=".ToCharArray());
					if (pieceParts.Length > 1)
					{
						string name = HttpUtility.UrlDecode(pieceParts[0].TrimStart(" ".ToCharArray()));
						string value = HttpUtility.UrlDecode(pieceParts[1].TrimStart(" \"".ToCharArray()).TrimEnd(" \"".ToCharArray()));

						output.Add(name, value);
					}
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}

			return output;
		}

		private void ParseGET(HttpListenerRequest request)
		{
			mReadData = request.Url.ToString();

			foreach (string qsKey in request.QueryString.AllKeys)
			{
				mFieldsCollection.Add(qsKey, HttpUtility.UrlDecode(request.QueryString[qsKey]));
			}
		}

		private void ParsePOST(HttpListenerRequest request)
		{
			mReadData = null;

			using (MemoryStream body = new MemoryStream())
			{
				int bytes = 0;
				byte[] temp = new byte[4096];
				while ((bytes = request.InputStream.Read(temp, 0, temp.Length)) > 0)
				{
					body.Write(temp, 0, bytes);
				}
				// Go back to the beginning of the memory stream
				body.Seek(0, SeekOrigin.Begin);

				Encoding encoding = request.ContentEncoding;
				using (StreamReader reader = new StreamReader(body, encoding))
				{
					//Checks that the message is a valid POST message  the POST messages start always
					//With the  multipart/form-data string.
					if (mContentType.IndexOf("multipart/form-data", StringComparison.InvariantCultureIgnoreCase) > -1)
					{
						//Parse the content type value to get what is in the message
						Dictionary<string, string> items = ParseContentLine(mContentType);

						//Get the boundary ID of the message
						string boundary = string.Empty;
						if (items.ContainsKey("boundary"))
						{
							boundary = items["boundary"];
						}

						bool endOfLines = false;

						string row = string.Empty;

						//start reading the content of the message 
						while (row == string.Empty)
						{
							//Until you have reached the end of the boundary header 
							//Read the content
							row = reader.ReadLine();
							if (row.IndexOf(boundary) > -1)
							{
								endOfLines = row.EndsWith("--");
								row = string.Empty;
							}
						}

						//Go on reading the data (the first row is already read)
						while (!endOfLines)
						{
							//If the row in the buffer is the header of a data section
							if (row.ToLower().Contains("content-disposition: form-data;"))
							{
								//Get all the data parts in the row
								Dictionary<string, string> p = ParseContentLine(row);
								//If this is a Data section, you have to find a name key in the collection
								//the value for the name element of the collection is the parameter name
								if (p.ContainsKey("name"))
								{
									//Get the name element of the collection
									string fieldKey = p["name"];

									//Prepare a stringbuilder for the value of the parameter
									StringBuilder fieldValue = new StringBuilder();

									//Read a line
									row = reader.ReadLine();
									//If empty no data
									if (row.XDwIsNullOrTrimEmpty())
									{
										//start reading the data lines
										bool stop = false;
										while (!stop)
										{
											//If I have not reached the end of the stream
											if (!reader.EndOfStream)
											{
												//Read a line
												row = reader.ReadLine();
												//If it is the boundary code which marks the end of each data field
												//Stop reading
												if (row.IndexOf(boundary) > -1)
												{
													endOfLines = row.EndsWith("--"); // se è boundary + -- sono alla fine
													stop = true;
												}
												else
												{
													//Attach the row data to the streambuilder
													//The newline is automatically added by appendline
													row = row.Replace("\r\n", "");
													fieldValue.AppendLine(row);

												}
											}
											else
											{
												endOfLines = true;
												stop = true;
											}
										}
									}
									//Add the field to the name value collection
									mFieldsCollection.Add(fieldKey, fieldValue.ToString());
								}
							}
							if (!endOfLines)
							{
								//If there are more datapart rows read them and cycle
								if (reader.EndOfStream)
								{
									endOfLines = true;
								}
								else
								{
									row = reader.ReadLine();
								}
							}

							if (!endOfLines)
							{
								endOfLines = (reader.EndOfStream);
							}
						}
					}

					reader.Close();
				}
				body.Close();
			}
		}

		#endregion

	}
}