// ---------------------------------------------------------------
// DATI FILE DnwSettingsManagerBase.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: DnwSettingsManagerBase.cs
// Namespace...............: Dnw.Base.Entities
// Classi..................: public abstract DnwSettingsManagerBase : INotifyPropertyChanged
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 143
// Dimensione..............: 3,53 Kb
// Data Creazione..........: 23/05/2013 10:43:55
// Data ultima Modifica....: 27/05/2013 10:19:04
// ---------------------------------------------------------------

using Dnw.Base.Collections;
using System.ComponentModel;

namespace Dnw.Base.Entities
{
	///<summary>
	/// Base settings manager
	///</summary>
	public abstract class DnwSettingsManagerBase : INotifyPropertyChanged
	{
		#region Fields

		/// <summary>
		/// ApplicationSettings
		/// N/A
		/// </summary>
		protected DnwSettingsCollection mAppSettings;

		/// <summary>
		/// UserSettingsCollection
		/// N/A
		/// </summary>
		protected DnwSettingsCollection mUsrSettings;

		#endregion Fields

		#region Public Methods

		/// <summary>
		/// Loads the settings.
		/// </summary>
		public void Load()
		{
			LoadAppSettings();
			LoadUsrSettings();
		}

		/// <summary>
		/// Saves the settings contained in this instance
		/// </summary>
		public void Save()
		{
			if (UserSettings != null)
			{
				SaveUsrSettings();
			}
			if (AppSettings != null)
			{
				SaveAppSettings();
			}
		}

		#endregion Public Methods

		#region Protected Methods

		/// <summary>
		/// Loads the application settings from the file.
		/// </summary>
		protected abstract void LoadAppSettings();

		/// <summary>
		/// Loads the user settings from the file.
		/// </summary>
		protected abstract void LoadUsrSettings();

		///<summary>
		/// Evento che viene generato alla modifica di una property
		///</summary>
		/// <param name="pPropertyName">nome della property</param>
		protected virtual void OnPropertyChanged(string pPropertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(pPropertyName));
		}

		#endregion Protected Methods

		#region Private Methods

		/// <summary>
		/// Saves the application settings.
		/// </summary>
		private void SaveAppSettings()
		{
			this.AppSettings.WriteXml(AppSettingsFileName);
		}

		/// <summary>
		/// Saves the user settings.
		/// </summary>
		private void SaveUsrSettings()
		{
			this.UserSettings.WriteXml(UsrSettingsFileName);
		}

		#endregion Private Methods

		//using System.CompnentModel; //se necessario
		/// <summary>
		/// Evento generato alla modifica di una property.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// ApplicationSettings
		/// N/A
		/// </summary>
		public DnwSettingsCollection AppSettings
		{
			get
			{
				return mAppSettings;
			}
		}

		/// <summary>
		/// Gets the name of the app settings file.
		/// </summary>
		public abstract string AppSettingsFileName { get; }

		/// <summary>
		/// UserSettingsCollection
		/// N/A
		/// </summary>
		public DnwSettingsCollection UserSettings
		{
			get
			{
				return mUsrSettings;
			}
		}

		/// <summary>
		/// Gets the name of the usr settings file.
		/// </summary>
		public abstract string UsrSettingsFileName { get; }
	}
}