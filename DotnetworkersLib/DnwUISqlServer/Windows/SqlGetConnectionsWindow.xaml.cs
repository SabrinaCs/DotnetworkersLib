// ---------------------------------------------------------------
// DATI FILE SqlGetConnectionsWindow.xaml.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwUISqlServer
// File....................: SqlGetConnectionsWindow.xaml.cs
// Namespace...............: Dnw.UI.SqlServer.Windows
// Classi..................: public partial SqlGetConnectionsWindow : Window, INotifyPropertyChanged
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 227
// Dimensione..............: 6,53 Kb
// Data Creazione..........: 15/05/2013 11:59:06
// Data ultima Modifica....: 15/05/2013 15:28:03
// ---------------------------------------------------------------


using Dnw.Base;
using Dnw.UI.SqlServer.Models;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Dnw.UI.SqlServer.Windows
{
	/// <summary>
	/// Interaction logic for SqlGetConnectionsWIndow.xaml
	/// </summary>
	public partial class SqlGetConnectionsWindow : Window, INotifyPropertyChanged
	{
		#region Constants
		/// <summary>
		/// Extension for the cryptographed files
		/// </summary>
		private const string EXT_Dnwx = ".dnwx";

		/// <summary>
		/// Indicates wether the control has the correct data to work
		/// N/A
		/// </summary>
		public const string FLD_HasData = "HasData";

		/// <summary>
		/// Filters for the Open and Save file dialogs
		/// </summary>
		private const string TXT_Filters = "Json files (*.json)|*.json|Dnw Hidden (*.dnwx)|*.dnwx|All files (*.*)|*.*";

		#endregion



		/// <summary>
		/// Initializes a new instance of the <see cref="SqlGetConnectionsWindow"/> class.
		/// </summary>
		/// <param name="icon">The icon.</param>
		/// <param name="fileName">Name of the file.</param>
		public SqlGetConnectionsWindow(ImageSource icon, string fileName)
		{
			InitializeComponent();
			this.DataContext = this;
			this.Icon = icon;
			this.FileName = fileName;
		}


		/// <summary>
		/// Name of the file where to save the data
		/// </summary>
		///<remarks>
		///</remarks>
		public string FileName
		{
			get
			{
				return this.ctlConnections.FileName;
			}
			set
			{
				this.ctlConnections.FileName = value;
				bool isencrypted = Path.GetExtension(this.ctlConnections.FileName).ToLower() == EXT_Dnwx;
				if (File.Exists(value))
				{
					this.ctlConnections.Load(isencrypted);
				}
				else
				{
					
					this.ctlConnections.Clear();
				}
			}
		}

		//using System.CompnentModel; //se necessario
		/// <summary>
		/// Evento generato alla modifica di una property.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		///<summary>
		/// Evento che viene generato alla modifica di una property
		///</summary>
		/// <param name="pPropertyName">nome della property</param>
		protected virtual void OnPropertyChanged(string pPropertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(pPropertyName));
		}

		/// <summary>
		/// Event handler for the window save and exit buttons
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
		private void btnClick(object sender, RoutedEventArgs e)
		{
			try
			{

				Button btn = sender as Button;
				if (btn != null)
				{
					switch (btn.Name)
					{
						case "btnExit":
							this.Close();
							break;
						case "btnSave":
							Save();
							break;
					}
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				MessageBox.Show(ex.Message);
			}
		}


		/// <summary>
		/// Gets the export data.
		/// </summary>
		/// <returns></returns>
		private ImportExportData GetExportData()
		{
			ImportExportData ieData = null;
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = SqlGetConnectionsWindowRx.txtSGCWExportTitle;
			sfd.DefaultExt = EXT_Dnwx;
			sfd.Filter = TXT_Filters;
			sfd.FilterIndex = 2;
			sfd.CheckFileExists = false;
			sfd.CheckPathExists = true;
			bool? ret = sfd.ShowDialog();
			if (ret.HasValue && ret.Value)
			{
				bool isEncrypted = Path.GetExtension(sfd.FileName).ToLower() == EXT_Dnwx;
				ieData = new ImportExportData(sfd.FileName, isEncrypted);
			}

			return (ieData);
		}

		/// <summary>
		/// Gets the import data.
		/// </summary>
		/// <returns></returns>
		private ImportExportData GetImportData()
		{
			ImportExportData ieData = null;
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = SqlGetConnectionsWindowRx.txtSGCWImportTitle;
			ofd.DefaultExt = EXT_Dnwx;
			ofd.Multiselect = false;
			ofd.Filter = TXT_Filters;
			ofd.FilterIndex = 2;
			ofd.CheckFileExists = false;
			ofd.CheckPathExists = true;
			bool? ret = ofd.ShowDialog();
			if (ret.HasValue && ret.Value)
			{
				bool isEncrypted = Path.GetExtension(ofd.FileName).ToLower() == EXT_Dnwx;
				ieData = new ImportExportData(ofd.FileName, isEncrypted);
			}

			return (ieData);
		}

		/// <summary>
		/// Saves The content of the model to the given file.
		/// </summary>
		private void Save()
		{
			bool isEncrypted = Path.GetExtension(ctlConnections.FileName).ToLower() == EXT_Dnwx;
			ctlConnections.Save(isEncrypted);
		}

		/// <summary>
		/// Handles the Closing event of the Window control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (ctlConnections.IsChanged)
			{
				if (MessageBox.Show(SqlGetConnectionsWindowRx.warSGCWDiscardChanges,
					SqlGetConnectionsWindowRx.warGEN, MessageBoxButton.YesNo,
					MessageBoxImage.Warning) != MessageBoxResult.Yes)
				{
					e.Cancel = true;
				}
			}
		}

		/// <summary>
		/// Handles the Loaded event of the Window control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			if (this.FileName.XDwIsNullOrTrimEmpty())
			{
				MessageBox.Show(SqlGetConnectionsWindowRx.warSGCWNoFileName);
				this.Close();
			}
		}
	}
}