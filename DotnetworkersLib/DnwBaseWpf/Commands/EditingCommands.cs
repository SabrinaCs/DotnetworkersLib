// ---------------------------------------------------------------
// DATI FILE EditingCommands.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseWpf
// File....................: EditingCommands.cs
// Namespace...............: Dnw.Base.Wpf.Commands
// Classi..................: public static EditingCommands
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 26
// Dimensione..............: 1,21 Kb
// Data Creazione..........: 04/06/2013 12:03:31
// Data ultima Modifica....: 06/06/2013 10:57:57
// ---------------------------------------------------------------


using System.Windows.Input;



namespace Dnw.Base.Wpf.Commands
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	public static class EditingCommands
	{

		/// <summary>
		/// Command to set a User control or a window in edit mode
		/// </summary>
		public static readonly RoutedCommand Edit = new RoutedCommand();

		/// <summary>
		/// Command to clone an object on the editing windows
		/// </summary>
		public static readonly RoutedCommand Clone = new RoutedCommand();

	}
}