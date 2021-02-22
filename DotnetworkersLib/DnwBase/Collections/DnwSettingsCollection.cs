// ---------------------------------------------------------------
// DATI FILE DnwSettingsCollection.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: DnwSettingsCollection.cs
// Namespace...............: Dnw.Base.Collections
// Classi..................: public DnwSettingsCollection : ObservableCollection<DnwSetting>
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 155
// Dimensione..............: 5,07 Kb
// Data Creazione..........: 13/05/2013 17:10:13
// Data ultima Modifica....: 13/06/2013 12:49:19
// ---------------------------------------------------------------


using Dnw.Base.Entities;
using Dnw.Base.Xml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;



namespace Dnw.Base.Collections
{
	///<summary>
	/// Collection of setting data
	///</summary>
	[XmlRoot(Namespace = "http://www.dotnetwork.it", ElementName = "DnwSettingsCollection")]
	public class DnwSettingsCollection : ObservableCollection<DnwSetting>
	{


		/// <summary>
		/// Gets an element of the collection with the specified ID
		/// </summary>
		/// <param name="itemID">The item ID.</param>
		/// <returns></returns>
		public DnwSetting this[string itemID]
		{
			get
			{
				return this.FirstOrDefault(item => item.ID == itemID);
			}
		}

		/// <summary>
		/// Check if the item with the specified item ID exists in the collection.
		/// </summary>
		/// <param name="itemID">The item ID.</param>
		/// <returns>true if the item exists false elsewhere</returns>
		public bool Exists(string itemID)
		{
			return (this.Any(item => item.ID == itemID));
		}

		/// <summary>
		/// Serializes the DnwSettingCollection class on an XML File
		/// </summary>
		/// <param name="xmlPath">The path of the xml file produced</param>
		/// <param name="indentOutput">if set to <c>true</c> [indent output].</param>
		/// <param name="newlineCharsOutput">The newline chars for the output XML</param>
		public void WriteXml(string xmlPath, bool indentOutput = true, string newlineCharsOutput = "\r\n")
		{
			try
			{
				XmlHelper.SerializeToFile(xmlPath, this, typeof(DnwSettingsCollection),
					new Type[] { typeof(DnwSetting) }, noNamespaces: false,
					indent: indentOutput, newlineChars: newlineCharsOutput);
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}

		///<summary>
		/// Serializes the DnwSettingCollection class on an XML string
		/// </summary>
		/// <param name="indentOutput">if set to <c>true</c> [indent output].</param>
		/// <param name="newlineCharsOutput">The newline chars for the output XML</param>
		public string WriteXml(bool indentOutput = true, string newlineCharsOutput = "\r\n")
		{
			try
			{
				return (XmlHelper.SerializeToString(this, new Type[] { typeof(DnwSetting) },
					noNamespaces: false, indent: indentOutput, newlineChars: newlineCharsOutput));
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}


		/// <summary>
		/// Deserializes an XML file or an XML string to a DnwSettingCollection
		/// </summary>
		/// <param name="xmlData">The XML data or file name</param>
		/// <param name="isXmlData">if set to <c>true</c> the content is data else it is a file name</param>
		/// <returns></returns>
		public static DnwSettingsCollection ReadXml(string xmlData, bool isXmlData)
		{
			DnwSettingsCollection ret = null;
			try
			{
				if (!isXmlData)
				{
					if (File.Exists(xmlData))
					{
						ret = (DnwSettingsCollection)XmlHelper.DeserializeFromFile<DnwSettingsCollection>(xmlData, new Type[] { typeof(DnwSetting) });
					}
					else
					{
						ret = new DnwSettingsCollection();
					}
				}
				else
				{
					ret = (DnwSettingsCollection)XmlHelper.DeserializeFromString(typeof(DnwSettingsCollection), xmlData, new Type[] { typeof(DnwSetting) });
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
			return (ret);
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
		/// Gets the list ordered by category and description
		/// </summary>
		/// <returns></returns>
		public IEnumerable<DnwSetting> GetOrderedList()
		{
			return (this.OrderBy(x => x.Category).ThenBy(x => x.Position));
		}

		/// <summary>
		/// Gets the rows necessary to build a grid with categories headers
		/// </summary>
		/// <returns> The number of categories plus the count of the collection</returns>
		public int GridRowsCount()
		{
			int cats = this.Select(item => item.Category).Distinct().Count();
			return (Count + cats);
		}
	}
}