// ---------------------------------------------------------------
// DATI FILE SemaphoreCommands.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseWpf
// File....................: SemaphoreCommands.cs
// Namespace...............: Dnw.Base.Wpf.Commands
// Classi..................: public static SemaphoreCommands
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 30
// Dimensione..............: 1,48 Kb
// Data Creazione..........: 28/05/2013 10:41:10
// Data ultima Modifica....: 28/05/2013 10:47:28
// ---------------------------------------------------------------


using System.Windows.Input;



namespace Dnw.Base.Wpf.Commands
{
	///<summary>
	/// A class that supplies commands to start and stop things like services
	/// or timers or cycles in general
	///</summary>
	public static class SemaphoreCommands
	{
		/// <summary>
		/// Command to start something like the green light of a semaphore
		/// </summary>
		public static readonly RoutedCommand Start = new RoutedCommand();
		/// <summary>
		/// Command to pause something like the yellow lignt of a semaphore
		/// </summary>
		public static readonly RoutedCommand Pause = new RoutedCommand();
		/// <summary>
		/// Comman to stop something like the red light of a semaphore
		/// </summary>
		public static readonly RoutedCommand Stop = new RoutedCommand();


	}
}