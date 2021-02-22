// ---------------------------------------------------------------
// DATI FILE IBusinessContext.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: IBusinessContext.cs
// Namespace...............: Dnw.Base
// Classi..................:
// Interfacce..............: public IBusinessContext
// Enumerazioni............:
// Linee di codice.........: 26
// Dimensione..............: 1,59 Kb
// Data Creazione..........: 18/04/2013 16:05:34
// Data ultima Modifica....: 23/04/2013 12:44:36
// ---------------------------------------------------------------


namespace Dnw.Base
{
	/// <summary>
	/// An interface defining the base informations that all kind of context need to implement
	/// </summary>
	public interface IBusinessContext
	{
		/// <summary>
		/// Gets the type of the context.
		/// </summary>
		/// <value>
		/// The type of the context.
		/// </value>
		string ContextType { get; }
		/// <summary>    
		/// Gets the name of the context.
		/// </summary>
		/// <value>
		/// The name of the context.
		/// </value>
		string ContextName { get; }
	}
}
