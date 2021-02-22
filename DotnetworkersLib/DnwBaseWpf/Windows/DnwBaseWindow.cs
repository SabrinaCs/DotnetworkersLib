// ---------------------------------------------------------------
// DATI FILE DnwBaseWindow.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseWpf
// File....................: DnwBaseWindow.cs
// Namespace...............: Dnw.Base.Wpf.Windows
// Classi..................: public partial DnwBaseWindow : Window
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 90
// Dimensione..............: 3,17 Kb
// Data Creazione..........: 13/06/2013 14:16:58
// Data ultima Modifica....: 14/06/2013 11:44:26
// ---------------------------------------------------------------


using Dnw.Base.Entities;
using System;
using System.Windows;

namespace Dnw.Base.Wpf.Windows
{
	/// <summary>
	/// Window base with functionalities added by Dnw
	/// </summary>
	public partial class DnwBaseWindow : Window
	{
		///<summary> 
		/// Name of the setting where to save the size of this window
		///</summary>   
		public string SizeSettingName
		{
			get;
			set;
		}


		///<summary> 
		/// Autosettings class where to save the size setting
		///</summary>   
		public DnwAutoSettingsManagerBase AutoSettings
		{
			get;
			set;
		}


		/// <summary>
		/// Raises the <see cref="E:System.Windows.FrameworkElement.Initialized" /> event. This method is invoked whenever <see cref="P:System.Windows.FrameworkElement.IsInitialized" /> is set to true internally.
		/// </summary>
		/// <param name="e">The <see cref="T:System.Windows.RoutedEventArgs" /> that contains the event data.</param>
		protected override void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e);
			if (AutoSettings != null && !SizeSettingName.XDwIsNullOrTrimEmpty())
			{
				string size = AutoSettings.GetSettingValue(SizeSettingName, null);
				if (size != null)
				{
					string[] elem = size.Split(';');
					if (elem.Length == 2)
					{
						double width = this.Width;
						double.TryParse(elem[0], out width);
						this.Width = width;
						double height = this.Height;
						double.TryParse(elem[1], out height);
						this.Height = height;
					}
				}
			}
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Window.Closing" /> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs" /> that contains the event data.</param>
		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			base.OnClosing(e);
			if (AutoSettings != null && !SizeSettingName.XDwIsNullOrTrimEmpty())
			{
				AutoSettings.AddOrReplace(SizeSettingName, string.Format("{0};{1}", this.Width, this.Height));
			}
		}


		/// <summary>
		/// Raises the <see cref="E:System.Windows.Window.Closed" /> event.
		/// Resets the properties with the size settings saving data to avoid
		/// References remain hanged so the object is not disposable
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
		protected override void OnClosed(EventArgs e)
		{
			AutoSettings = null;
			SizeSettingName = null;
			base.OnClosed(e);

		}

	}
}
