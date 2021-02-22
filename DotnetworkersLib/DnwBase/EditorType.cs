// ---------------------------------------------------------------
// DATI FILE EditorType.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: EditorType.cs
// Namespace...............: Dnw.Base
// Classi..................:
// Interfacce..............:
// Enumerazioni............: public EditorType
// Linee di codice.........: 61
// Dimensione..............: 1,76 Kb
// Data Creazione..........: 14/05/2013 10:57:44
// Data ultima Modifica....: 24/05/2013 17:09:28
// ---------------------------------------------------------------





namespace Dnw.Base
{
	///<summary>
	/// Editor types for auto generated controls lists
	///</summary>
	public enum EditorType
	{
		/// <summary>
		/// A simple textbox
		/// </summary>
		TextBox,
		/// <summary>
		/// A masked editor for integers
		/// </summary>
		NumericInteger,
		/// <summary>
		/// A masked editor for double
		/// </summary>
		NumericDouble,
		/// <summary>
		/// A checkbox editor
		/// </summary>
		CheckBox,
		/// <summary>
		/// A file name picker
		/// </summary>
		FileName,
		/// <summary>
		/// A directory name Picker
		/// </summary>
		DirectoryName,
		/// <summary>
		/// A date picker
		/// </summary>
		Date,
		/// <summary>
		/// A short time picker hh:mm
		/// </summary>
		TimeShort,
		/// <summary>
		/// A long time picker hh:mm:ss
		/// </summary>
		TimeLong,
		/// <summary>
		/// Editor for acquire the file name and content of a
		/// Sql Connections collection
		/// </summary>
		SqlConnectionsFile,
		/// <summary>
		/// Editor to design a dropdown list of value, description pairs
		/// </summary>
		DropDown


	}
}