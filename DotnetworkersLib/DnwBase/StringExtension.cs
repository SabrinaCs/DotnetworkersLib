// ---------------------------------------------------------------
// DATI FILE StringExtension.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: StringExtension.cs
// Namespace...............: Dnw.Base
// Classi..................: public static StringExtension
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 71
// Dimensione..............: 2,16 Kb
// Data Creazione..........: 13/05/2013 15:45:35
// Data ultima Modifica....: 13/05/2013 17:48:04
// ---------------------------------------------------------------

using System;
using System.IO;



namespace Dnw.Base
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	public static class StringExtension
	{

		/// <summary>
		/// Returns true if the string is null or contains no characters except spaces
		/// </summary>
		/// <param name="stringValue">String to check</param>
		/// <returns></returns>
		public static bool XDwIsNullOrTrimEmpty(this String stringValue)
		{
			return (stringValue == null || stringValue.Trim().Length == 0);
		}

		/// <summary>
		/// Xs the dw left.
		/// </summary>
		/// <param name="stringValue">The string value.</param>
		/// <param name="length">The length.</param>
		/// <returns>
		/// the substring of length dimension starting from the first character of the original one.
		/// </returns>
		public static string XDwLeft(this String stringValue, int length)
		{
			string ret = stringValue;
			try
			{

				int nch = length;
				if (length > stringValue.Length)
				{
					nch = stringValue.Length;
				}
				ret = stringValue.Substring(0, nch);

			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);

			}

			return (ret);
		}

		/// <summary>
		/// Checks if exists a path and creates it
		/// </summary>
		/// <param name="stringValue">The string value.</param>
		public static void XDwCheckPath(this String stringValue)
		{
			if (!Directory.Exists(stringValue))
			{
				Directory.CreateDirectory(stringValue);
			}
		}



	}
}