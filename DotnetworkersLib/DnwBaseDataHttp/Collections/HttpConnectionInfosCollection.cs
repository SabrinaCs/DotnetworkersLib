// ---------------------------------------------------------------
// DATI FILE H:\Yeye\DnwCode\CommonLibraries\DnwLibraries\DnwBaseDataHttp\Collections\HttpConnectionInfosCollection.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseDataHttp
// File....................: HttpConnectionInfosCollection.cs
// Path....................: H:\Yeye\DnwCode\CommonLibraries\DnwLibraries\DnwBaseDataHttp\Collections\
// Namespace...............: Dnw.Base.Data.Http.Collections
// Classi..................: public HttpConnectionInfosCollection : ObservableCollection<HttpConnectionInfo>
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 88
// Dimensione..............: 3,09 Kb
// Data Creazione..........: 14/05/2013 15:10:52 UTC
// Data ultima Modifica....: 22/10/2014 16:32:03 UTC
// ---------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Dnw.Base.Data.Http.Entities;
using Dnw.Base.Json;

namespace Dnw.Base.Data.Http.Collections
{
	///<summary>
	/// Collection of HTTP connections
	///</summary>
	public class HttpConnectionInfosCollection : ObservableCollection<HttpConnectionInfo>
	{
		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="ID">The ID.</param>
		/// <returns></returns>
		public HttpConnectionInfo this[string ID]
		{
			get
			{
				return (this.FirstOrDefault(c => c.ConnectionID == ID));
			}
		}

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < this.Count; i++)
			{
				sb.AppendLine(this[i].ToString());
			}
			return (sb.ToString());
		}


		/// <summary>
		/// Serializes this instance.
		/// </summary>
		/// <returns></returns>
		public string Serialize()
		{
			return (JsonHelper.Serialize(this));
		}

		/// <summary>
		/// Serializes this instance into the specified file.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		public void Serialize(string fileName)
		{
			JsonHelper.Serialize(this, fileName);
		}

		/// <summary>
		/// Deserializes the specified file or data.
		/// </summary>
		/// <param name="fileOrData">The file or data.</param>
		/// <param name="isFile">if set to <c>true</c> [is file].</param>
		/// <returns></returns>
		public static HttpConnectionInfosCollection Deserialize(string fileOrData, bool isFile = true)
		{
			return (JsonHelper.Deserialize<HttpConnectionInfosCollection>(fileOrData, isFile));
		}

		/// <summary>
		/// Clones this instance.
		/// </summary>
		/// <returns>A deep copy of this collection</returns>
		public HttpConnectionInfosCollection Clone()
		{
			HttpConnectionInfosCollection newData = new HttpConnectionInfosCollection();
			foreach (HttpConnectionInfo item in this)
			{
				newData.Add(item.Clone());
			}
			return (newData);
		}

	}
}