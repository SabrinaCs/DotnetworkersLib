// ---------------------------------------------------------------
// DATI FILE H:\Yeye\DnwCode\CommonLibraries\DnwLibraries\DnwBaseDataSqlServer\Collections\SqlConnectionInfosCollection.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseDataSqlServer
// File....................: SqlConnectionInfosCollection.cs
// Path....................: H:\Yeye\DnwCode\CommonLibraries\DnwLibraries\DnwBaseDataSqlServer\Collections\
// Namespace...............: Dnw.Base.Data.SqlServer.Collections
// Classi..................: public SqlConnectionInfosCollection : ObservableCollection<SqlConnectionInfo>
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 91
// Dimensione..............: 3,11 Kb
// Data Creazione..........: 13/05/2013 13:45:36 UTC
// Data ultima Modifica....: 22/10/2014 16:33:30 UTC
// ---------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Dnw.Base.Data.SqlServer.Entities;
using Dnw.Base.Json;



namespace Dnw.Base.Data.SqlServer.Collections
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	public class SqlConnectionInfosCollection : ObservableCollection<SqlConnectionInfo>
	{


		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="ID">The ID.</param>
		/// <returns></returns>
		public SqlConnectionInfo this[string ID]
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
			return (JsonHelper.Serialize( this));
		}

		/// <summary>
		/// Serializes this instance into the specified file.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		public void Serialize(string fileName)
		{
			JsonHelper.Serialize( this, fileName);
		}

		/// <summary>
		/// Deserializes the specified file or data.
		/// </summary>
		/// <param name="fileOrData">The file or data.</param>
		/// <param name="isFile">if set to <c>true</c> [is file].</param>
		/// <returns></returns>
		public static SqlConnectionInfosCollection Deserialize(string fileOrData, bool isFile = true)
		{
			return (JsonHelper.Deserialize<SqlConnectionInfosCollection>( fileOrData, isFile));
		}

		/// <summary>
		/// Clones this instance.
		/// </summary>
		/// <returns>A deep copy of this collection</returns>
		public SqlConnectionInfosCollection Clone()
		{
			SqlConnectionInfosCollection newData = new SqlConnectionInfosCollection();
			foreach (SqlConnectionInfo item in this)
			{
				newData.Add(item.Clone());
			}
			return (newData);
		}
	}
}