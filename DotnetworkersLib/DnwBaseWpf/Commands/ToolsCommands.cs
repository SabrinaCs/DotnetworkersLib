// ---------------------------------------------------------------
// DATI FILE ToolsCommands.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseWpf
// File....................: ToolsCommands.cs
// Namespace...............: Dnw.Base.Wpf.Commands
// Classi..................: public static ToolsCommands
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 29
// Dimensione..............: 1,51 Kb
// Data Creazione..........: 28/05/2013 10:37:01
// Data ultima Modifica....: 30/05/2013 17:50:52
// ---------------------------------------------------------------


using System.Windows.Input;



namespace Dnw.Base.Wpf.Commands
{

	/// <summary>
	/// Routed commands common to all applications to be set in the tools menu
	/// </summary>
	public static class ToolsCommands
	{
		/// <summary>
		/// Command to execute the configuration window of an application
		/// it is set here because all WPF applications need some kind of
		/// parameterized settings so it is useless to redefine this command
		/// every time it is needed
		/// </summary>
		public static readonly RoutedCommand OpenConfig = new RoutedCommand();

		/// <summary>
		/// Command to execute a monitor window like service profiler or http listener
		/// or any other application profiler or monitor window
		/// </summary>
		public static readonly RoutedCommand OpenMonitor = new RoutedCommand();
	}
}