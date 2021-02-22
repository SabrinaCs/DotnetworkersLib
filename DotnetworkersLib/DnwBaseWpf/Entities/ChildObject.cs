// ---------------------------------------------------------------
// DATI FILE ChildObject.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseWpf
// File....................: ChildObject.cs
// Namespace...............: Dnw.Base.Wpf.Entities
// Classi..................: public ChildObject<T> where T : class
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 74
// Dimensione..............: 1,62 Kb
// Data Creazione..........: 14/06/2013 14:01:39
// Data ultima Modifica....: 14/06/2013 15:53:16
// ---------------------------------------------------------------



namespace Dnw.Base.Wpf.Entities
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	public class ChildObject<T> where T : class
	{

		#region Fields

		/// <summary>
		/// Name of the window
		/// </summary>
		private string mName;

		/// <summary>
		/// Window
		/// </summary>
		private T mWindow;

		#endregion

		#region Public Methods

		///<summary>
		/// Costruttore
		///</summary>
		public ChildObject(string name, T win)
		{
			mName = name;
			mWindow = win;
		}

		#endregion

		/// <summary>
		/// Name of the window
		/// </summary>
		///<remarks>
		///</remarks>
		public string Name
		{
			get
			{
				return mName;
			}
			set
			{
				mName = value;
			}
		}

		/// <summary>
		/// Window
		/// </summary>
		///<remarks>
		///</remarks>
		public T Child
		{
			get
			{
				return mWindow;
			}
			set
			{
				mWindow = value;
			}
		}

	}
}