// ---------------------------------------------------------------
// DATI FILE H:\Yeye\TheRecipesProject\Code\DnwLibraries\DnwBase\Xml\XmlHelper.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: XmlHelper.cs
// Path....................: H:\Yeye\TheRecipesProject\Code\DnwLibraries\DnwBase\Xml\
// Namespace...............: Dnw.Base.Xml
// Classi..................: public static XmlHelper
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 285
// Dimensione..............: 11,61 Kb
// Data Creazione..........: 13/05/2013 15:19:52 UTC
// Data ultima Modifica....: 21/09/2014 14:14:24 UTC
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Dnw.Base.Xml
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	public static class XmlHelper
	{
		private const string TXT_StandardNamespace = "http://www.dotnetwork.it";

		/// <summary>
		/// Deserializza un oggetto da un file in formato XML
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="inputPath">Path del file da cui deserializzare l'oggetto</param>
		/// <param name="extraTypes">Tipi dati extra per la serializzazione delle collezioni</param>
		/// <returns>
		/// Ritorna: Oggetto deserializzato
		/// </returns>
		public static T DeserializeFromFile<T>( 
			string inputPath, Type[] extraTypes = null)
		{
			T ret = default(T);
			try
			{
				using (XmlReader xr = XmlReader.Create(inputPath))
				{

					// Occorre un'istanza della classe XmlSerializer
					XmlSerializer serializer = null;
					if (extraTypes != null)
					{
						serializer = new XmlSerializer(typeof(T), extraTypes);
					}
					else
					{
						serializer = new XmlSerializer(typeof(T));
					}
					// e questo é tutto ciò che serve per leggere i dati dal formato XML
					ret = (T)serializer.Deserialize(xr);
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
		/// Deserializza una stringa XML in un oggetto
		/// V.1.0
		/// </summary>
		/// <param name="typeToDeserialize">Tipo dell'oggetto</param>
		/// <param name="extraTypes">Tipi dati extra per la serializzazione delle collezioni</param>
		/// <param name="xmlString">Stringa contenente l'oggetto</param>
		/// <returns>Ritorna: L'oggetto deserializzato</returns>
		public static object DeserializeFromString(Type typeToDeserialize, string xmlString, 
			Type[] extraTypes = null)
		{
			object ret = null;
			try
			{
				byte[] bites = new UTF8Encoding().GetBytes(xmlString);
				using (MemoryStream stream = new MemoryStream(bites))
				{

					XmlReader xr = XmlReader.Create(stream);

					XmlSerializer serializer = null;
					if (extraTypes != null)
					{
						serializer = new XmlSerializer(typeToDeserialize, extraTypes);
					}
					else
					{
						serializer = new XmlSerializer(typeToDeserialize);
					}
					ret = serializer.Deserialize(xr);
					xr.Close();
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
		/// Serializza un oggetto in formato XML
		/// </summary>
		/// <param name="outputPath">Path del file in cui serializzare l'oggetto</param>
		/// <param name="objToSerialize">Oggetto da serializzare</param>
		/// <param name="typeToSerialize">Tipo dell' Oggetto da serializzare</param>
		/// <param name="extraTypes">Tipi degli oggetti serializzabili contenuti nell'oggetto principale
		/// per permettere la serializzazione delle collezioni.</param>
		/// <param name="noNamespaces">se<c>true</c> non scrive i namespaces standard</param>
		/// <param name="elementsPrefix">The elements prefix.</param>
		/// <param name="namespaces">Eventuali namespaces gestiti in lista namespace + prefix se esiste</param>
		/// <param name="indent">Se <c>true</c> indenta gli elementi</param>
		/// <param name="indentation">Numero di caratteri per l'indentazione</param>
		/// <param name="newlineChars">Caratteri per l'accapo (spazio non va acapo???)</param>
		/// <param name="useBOM">http://en.wikipedia.org/wiki/Byte_order_mark</param>
		/// <param name="doctypeTypeName">Name of the doctype type.</param>
		/// <param name="doctypeSystem">Se non nullo scrive una riga !DOCTYPE con l'attributo SYSTEM ed il valore specificato in questa stringa
		/// i tre parametri doctype possono essere tutti non nulli, la riga inserita è una sola</param>
		/// <param name="doctypePublic">Se non nullo scrive una riga !DOCTYPE con l'attributo PUBLIC ed il valore specificato in questa stringa
		/// i tre parametri doctype possono essere tutti non nulli, la riga inserita è una sola</param>
		/// <param name="doctypeSubset">Se non nullo scrive una riga !DOCTYPE con l'attributo SUBSET ed il valore specificato in questa stringa
		/// i tre parametri doctype possono essere tutti non nulli, la riga inserita è una sola</param>
		public static void SerializeToFile(string outputPath, object objToSerialize, 
			Type typeToSerialize, Type[] extraTypes = null, bool noNamespaces = false,
			string elementsPrefix = null, List<KeyValuePair<string, string>> namespaces = null, 
			bool indent = true, int indentation = 4, string newlineChars = "\r\n", bool useBOM = true,
			string doctypeTypeName = null, string doctypeSystem = null, string doctypePublic = null, string doctypeSubset = null)
		{
			try
			{

				using (XmlWriter writer = XmlWriter.Create(outputPath, GetWriterSettings(indent, indentation, newlineChars, useBOM)))
				{

					//Predispongo i namespaces validi
					XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
					string prefix = elementsPrefix != null ? elementsPrefix : string.Empty;
					if (noNamespaces)
					{
						ns.Add(prefix, TXT_StandardNamespace);
					}
					else
					{
						if (namespaces != null)
						{
							foreach (KeyValuePair<string, string> nams in namespaces)
							{
								string prf = nams.Value == null ? string.Empty : nams.Value;
								ns.Add(prf, nams.Key);
							}

						}
					}
					if (doctypePublic != null || doctypeSubset != null || doctypeSystem != null)
					{
						writer.WriteDocType(doctypeTypeName, doctypePublic, doctypeSystem, doctypeSubset);
					}
					XmlSerializer serializer = new XmlSerializer(typeToSerialize, extraTypes);
					// e questo é tutto ciò che serve per persistere i dati
					serializer.Serialize(writer, objToSerialize, ns);
					writer.Close();
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}

		/// <summary>
		/// Metodo pubblico: Genera una stringa xml contenente un oggetto serializzato
		/// </summary>
		/// <param name="objToSerialize">Oggetto da serializzare</param>
		/// <param name="extraTypes">Tipi dati extra per la serializzazione delle collezioni</param>
		/// <param name="noNamespaces">se<c>true</c> non scrive i namespaces standard</param>
		/// <param name="elementsPrefix">Prefisso per i tag con il nostro namespace</param>
		/// <param name="namespaces">Eventuali namespaces gestiti in lista namespace + prefix se esiste</param>
		/// <param name="indent">Se <c>true</c> indenta gli elementi</param>
		/// <param name="indentation">Numero di caratteri per l'indentazione</param>
		/// <param name="newlineChars">Caratteri per l'accapo (spazio non va acapo???)</param>
		/// <param name="useBOM">http://en.wikipedia.org/wiki/Byte_order_mark</param>
		/// <param name="doctypeTypeName">Name of the doctype type.</param>
		/// <param name="doctypeSystem">Se non nullo scrive una riga !DOCTYPE con l'attributo SYSTEM ed il valore specificato in questa stringa
		/// i tre parametri doctype possono essere tutti non nulli, la riga inserita è una sola</param>
		/// <param name="doctypePublic">Se non nullo scrive una riga !DOCTYPE con l'attributo PUBLIC ed il valore specificato in questa stringa
		/// i tre parametri doctype possono essere tutti non nulli, la riga inserita è una sola</param>
		/// <param name="doctypeSubset">Se non nullo scrive una riga !DOCTYPE con l'attributo SUBSET ed il valore specificato in questa stringa
		/// i tre parametri doctype possono essere tutti non nulli, la riga inserita è una sola</param>
		/// <returns>
		/// Ritorna: Stringa XML contenente l'oggetto serializzato.
		/// </returns>
		public static string SerializeToString(object objToSerialize, Type[] extraTypes = null, 
			bool noNamespaces = false, string elementsPrefix = null, 
			List<KeyValuePair<string, string>> namespaces = null, bool indent = true, 
			int indentation = 4, string newlineChars = "\r\n", bool useBOM = true,
			string doctypeTypeName = null, string doctypeSystem=null, string doctypePublic=null, string doctypeSubset=null)
		{
			string ret = "";
			try
			{
				using (MemoryStream stream = new MemoryStream())
				{
					using (XmlWriter writer = XmlWriter.Create(stream, GetWriterSettings(indent, indentation, newlineChars, useBOM)))
					{


						XmlSerializer serializer = new XmlSerializer(objToSerialize.GetType(), extraTypes);

						//Predispongo i namespaces validi
						XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
						string prefix = elementsPrefix != null ? elementsPrefix : string.Empty;
						if (noNamespaces)
						{
							ns.Add(prefix, TXT_StandardNamespace);
						}
						else
						{
							if (namespaces != null)
							{
								foreach (KeyValuePair<string, string> nams in namespaces)
								{
									string prf = nams.Value == null ? string.Empty : nams.Value;
									ns.Add(prf, nams.Key);
								}

							}
						}

						if (doctypePublic != null || doctypeSubset != null || doctypeSystem != null)
						{
							writer.WriteDocType(doctypeTypeName, doctypePublic, doctypeSystem, doctypeSubset);
						}
						serializer.Serialize(writer, objToSerialize, ns);
						ret = Encoding.UTF8.GetString(stream.ToArray());
						writer.Close();
					}
					stream.Close();
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
		/// Genera i setting standard per un xml writer
		/// </summary>
		/// <param name="indent">if set to <c>true</c> [p indent].</param>
		/// <param name="indentation">The p indentation.</param>
		/// <param name="newlineChars">The p newline chars.</param>
		/// <param name="useBOM">http://en.wikipedia.org/wiki/Byte_order_mark</param>
		/// <returns></returns>
		private static XmlWriterSettings GetWriterSettings(bool indent, int indentation, string newlineChars, bool useBOM)
		{
			XmlWriterSettings xstt = new XmlWriterSettings();
			xstt.ConformanceLevel = ConformanceLevel.Document;
			xstt.Encoding = useBOM ? Encoding.UTF8 : new UTF8Encoding(false);
			xstt.Indent = indent;
			xstt.IndentChars = new string(' ', indentation);
			xstt.NewLineChars = newlineChars;
			xstt.NewLineHandling = NewLineHandling.None;
			xstt.NewLineOnAttributes = false;
			xstt.OmitXmlDeclaration = false;
			return xstt;
		}

	}
}