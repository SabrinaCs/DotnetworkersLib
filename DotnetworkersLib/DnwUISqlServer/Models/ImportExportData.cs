// ---------------------------------------------------------------
// DATI FILE ImportExportData.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwUISqlServer
// File....................: ImportExportData.cs
// Namespace...............: Dnw.UI.SqlServer.Models
// Classi..................: public ImportExportData
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 54
// Dimensione..............: 1,57 Kb
// Data Creazione..........: 07/05/2013 10:04:59
// Data ultima Modifica....: 07/05/2013 10:11:53
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;



namespace Dnw.UI.SqlServer.Models
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	public class ImportExportData
	{

		///<summary>
		/// Costruttore
		///</summary>
		public ImportExportData(string fileName, bool encrypt)
		{
			FileName = fileName;
			Encrypt = encrypt;
		}


		///<summary> 
		/// FileName
		///</summary>   
		public string FileName
		{
			get;
			private set;
		}


		///<summary> 
		/// Encryption Yes or no
		///</summary>   
		public bool Encrypt
		{
			get;
			private set;
		}

	}

	/// <summary>
	/// Delegate to define a method to implement Import or export
	/// </summary>
	/// <returns>THe Data needed to import or export data</returns>
	public delegate ImportExportData ImportExportDelegate(); 
}