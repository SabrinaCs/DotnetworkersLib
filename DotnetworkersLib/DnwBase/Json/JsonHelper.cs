// ---------------------------------------------------------------
// DATI FILE H:\Yeye\DnwCode\CommonLibraries\DnwLibraries\DnwBase\Json\JsonHelper.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: JsonHelper.cs
// Path....................: H:\Yeye\DnwCode\CommonLibraries\DnwLibraries\DnwBase\Json\
// Namespace...............: Dnw.Base.Json
// Classi..................: public static JsonHelper
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 95
// Dimensione..............: 2,83 Kb
// Data Creazione..........: 13/05/2013 13:45:36 UTC
// Data ultima Modifica....: 22/10/2014 16:29:16 UTC
// ---------------------------------------------------------------

using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;


namespace Dnw.Base.Json
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	public static class JsonHelper
	{

		/// <summary>
		/// Serializes the specified object on a string
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="formatting">The formatting.</param>
		/// <returns>
		/// String representing the serialization of the object
		/// </returns>
		public static string Serialize( object data, Formatting formatting = Formatting.None)
		{
			try
			{

				return JsonConvert.SerializeObject(
					data, formatting);
	

			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}

		/// <summary>
		/// Serializes the specified object to a file
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="fileName">Name of the file.</param>
		public static void Serialize(object data, string fileName)
		{
			try
			{

				File.WriteAllText(fileName, Serialize(data));

			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}


		/// <summary>
		/// Deserializes the specified object
		/// </summary>
		/// <typeparam name="T">Type of the object that has to be created</typeparam>
		/// <param name="fileNameOrData">The file name containing the json serialized data or the json data</param>
		/// <param name="isFile">if set to <c>true</c> [read a file]. else the parameter contains the serialized object</param>
		/// <returns></returns>
		public static T Deserialize<T>(string fileNameOrData, bool isFile = true) 
		{
			try
			{
				string data = null;
				if (isFile)
				{
					data = File.ReadAllText(fileNameOrData);
				}
				else
				{
					data = fileNameOrData;
				}

				return JsonConvert.DeserializeObject<T>(data);
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}
	}
}