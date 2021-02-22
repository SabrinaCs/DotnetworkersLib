// ---------------------------------------------------------------
// DATI FILE SettingsManagerControl.xaml.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwUISettings
// File....................: SettingsManagerControl.xaml.cs
// Namespace...............: Dnw.UI.Settings.Controls
// Classi..................: public partial SettingsManagerControl : UserControl, INotifyPropertyChanged
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 219
// Dimensione..............: 5,64 Kb
// Data Creazione..........: 23/05/2013 11:29:21
// Data ultima Modifica....: 10/06/2013 17:38:46
// ---------------------------------------------------------------

using Dnw.Base;
using Dnw.Base.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Dnw.UI.Settings.Controls
{
	/// <summary>
	/// Interaction logic for SettingsManagerControl.xaml
	/// </summary>
	public partial class SettingsManagerControl : UserControl, INotifyPropertyChanged
	{
		#region Constants

		/// <summary>
		/// App Tab is visible
		/// N/A
		/// </summary>
		public const string FLD_AppTabIsVisible = "AppTabIsVisible";

		/// <summary>
		/// User Tab Is Visible
		/// N/A
		/// </summary>
		public const string FLD_UsrTabIsVisible = "UsrTabIsVisible";

		#endregion

		#region Readonly

		/// <summary>
		/// The Cancelled event registration
		/// </summary>
		public static readonly RoutedEvent CancelledEvent = EventManager.RegisterRoutedEvent(
			"Cancelled", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SettingsManagerControl));

		/// <summary>
		/// Defines a new routed event that is raised when the content of the user control 
		/// has been saved
		/// </summary>
		public static readonly RoutedEvent SavedEvent = EventManager.RegisterRoutedEvent(
			"Saved", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SettingsManagerControl));

		#endregion

		#region Fields

		/// <summary>
		/// App Tab is visible
		/// N/A
		/// </summary>
		private bool mAppTabIsVisible;

		/// <summary>
		/// User Tab Is Visible
		/// N/A
		/// </summary>
		private bool mUsrTabIsVisible;

		#endregion

		#region Public Methods

		/// <summary>
		/// Inits the specified app settings file name.
		/// </summary>
		/// <param name="appSettings">The app settings.</param>
		/// <param name="usrSettings">The usr settings.</param>
		public void Init(DnwSettingsCollection appSettings = null, DnwSettingsCollection usrSettings = null)
		{
			AppTabIsVisible = appSettings != null;
			UsrTabIsVisible = usrSettings != null;
			if (AppTabIsVisible)
			{
				PageApplicationSettings.Init(appSettings);
			}
			if (UsrTabIsVisible)
			{
				PageUserSettings.Init(usrSettings);
			}
			if (!AppTabIsVisible && !UsrTabIsVisible)
			{
				MessageBox.Show("You don't have any settings file to modify Check your code!");
				RaiseCancelledEvent();
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SettingsManagerControl"/> class.
		/// </summary>
		public SettingsManagerControl()
		{
			InitializeComponent();
			DataContext = this;
		}

		#endregion

		#region Protected Methods

		///<summary>
		/// Evento che viene generato alla modifica di una property
		///</summary>
		/// <param name="pPropertyName">nome della property</param>
		protected virtual void OnPropertyChanged(string pPropertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(pPropertyName));
		}

		#endregion

		#region Private Methods

		private void CancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			RaiseCancelledEvent();
		}

		/// <summary>
		/// Raises the cancelled event.
		/// </summary>
		private void RaiseCancelledEvent()
		{
			RoutedEventArgs args = new RoutedEventArgs(SettingsManagerControl.CancelledEvent);
			RaiseEvent(args);
		}

		/// <summary>
		///The function to call to raise the saved event event
		/// </summary>
		private void RaiseSavedEvent()
		{
			RoutedEventArgs args = new RoutedEventArgs(SettingsManagerControl.SavedEvent);
			RaiseEvent(args);
		}

		private void SaveButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			RaiseSavedEvent();
		}

		#endregion

		/// <summary>
		/// App Tab is visible
		/// N/A
		/// </summary>
		public bool AppTabIsVisible
		{
			get
			{
				return mAppTabIsVisible;
			}
			set
			{
				mAppTabIsVisible = value;
				OnPropertyChanged(FLD_AppTabIsVisible);
			}
		}

		/// <summary>
		/// User Tab Is Visible
		/// N/A
		/// </summary>
		public bool UsrTabIsVisible
		{
			get
			{
				return mUsrTabIsVisible;
			}
			set
			{
				mUsrTabIsVisible = value;
				OnPropertyChanged(FLD_UsrTabIsVisible);
			}
		}

		//using System.CompnentModel; //se necessario
		/// <summary>
		/// Evento generato alla modifica di una property.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// The Routed event add and remove handlers definition
		/// </summary>
		public event RoutedEventHandler Saved
		{
			add
			{
				AddHandler(SavedEvent, value);
			}
			remove
			{
				RemoveHandler(SavedEvent, value);
			}
		}

		/// <summary>
		/// The routed event add and remove handlers definition
		/// </summary>
		public event RoutedEventHandler Cancelled
		{
			add
			{
				AddHandler(CancelledEvent, value);
			}
			remove
			{
				RemoveHandler(CancelledEvent, value);
			}
		}

	}
}
