// ---------------------------------------------------------------
// DATI FILE SqlConnectionInfoControl.xaml.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwUISqlServer
// File....................: SqlConnectionInfoControl.xaml.cs
// Namespace...............: Dnw.UI.SqlServer.Controls
// Classi..................: public partial SqlConnectionInfoControl : UserControl
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 226
// Dimensione..............: 5,78 Kb
// Data Creazione..........: 13/05/2013 15:45:39
// Data ultima Modifica....: 16/05/2013 16:07:22
// ---------------------------------------------------------------


using Dnw.Base;
using Dnw.UI.SqlServer.Models;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Dnw.UI.SqlServer.Controls
{
	/// <summary>
	/// Interaction logic for SqlConnectionInfoControl.xaml
	/// </summary>
	public partial class SqlConnectionInfoControl : UserControl
	{

		#region Fields

		/// <summary>
		/// The export delegate to be supplied by the UI using
		/// this user control
		/// </summary>
		public ImportExportDelegate GetExportData;

		/// <summary>
		/// The import delegate to be supplied by the UI using
		/// this user control
		/// </summary>
		public ImportExportDelegate GetImportData;

		/// <summary>
		/// The data and command model that manages this
		/// user control
		/// </summary>
		private SqlConnectionInfoModel mControlModel;

		#endregion

		#region Public Methods

		/// <summary>
		/// Generates an empty collection
		/// </summary>
		public void Clear()
		{
			mControlModel.Clear();
		}

		/// <summary>
		/// Loads the connections data from the file
		/// </summary>
		public void Load(bool isEncrypted)
		{
			mControlModel.Load(isEncrypted);
		}

		/// <summary>
		/// Saves the data into the File specified
		/// </summary>
		public void Save(bool isEncrypted)
		{
			mControlModel.Save(isEncrypted);
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="SqlConnectionInfoControl"/> class.
		/// </summary>
		public SqlConnectionInfoControl()
		{
			InitializeComponent();
			mControlModel = new SqlConnectionInfoModel();
			this.DataContext = mControlModel;
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Exports the data in the model of this instance of the user control
		/// </summary>
		private void Export()
		{
			if (GetExportData != null)
			{
				ImportExportData data = GetExportData();
				mControlModel.Export(data);
			}
			else
			{
				MessageBox.Show(SqlConnectionInfoControlRx.warSCICNoExportDelegate, SqlConnectionInfoControlRx.warTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}

		///<summary>
		/// Imports data from a file into the model data of this instance of the user control
		///</summary>
		private void Import()
		{
			if (GetImportData != null)
			{
				ImportExportData data = GetImportData();
				mControlModel.Import(data);
			}
			else
			{
				MessageBox.Show(SqlConnectionInfoControlRx.warSCICNoImportDelegate, SqlConnectionInfoControlRx.warTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}

		/// <summary>
		/// Handles the click of the menu items
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
		private void mnuClick(object sender, RoutedEventArgs e)
		{
			try
			{

				MenuItem itm = sender as MenuItem;
				if (itm != null)
				{
					switch (itm.Name)
					{
						case "mnuClone":
							mControlModel.Clone();
							this.txtConnectionID.Focus();
							break;
						case "mnuDelete":
							mControlModel.Delete();
							break;
						case "mnuEdit":
							mControlModel.Edit();
							this.txtConnectionID.Focus();
							break;
						case "mnuExport":
							Export();
							break;
						case "mnuImport":
							Import();
							break;
						case "mnuNew":
							mControlModel.AddNew();
							this.txtConnectionID.Focus();
							break;
						case "mnuUndo":
							mControlModel.Undo();
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
		/// Handles the PasswordChanged event of the txtPassword control.
		/// Because the Password property cannot be automatically bound on XAML
		/// for security reasons, so we need to handle it manually
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
		private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.mControlModel.CurrentConnection != null)
				{
					this.mControlModel.CurrentConnection.Password = txtPassword.Password;
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				MessageBox.Show(ex.Message);
			}
		}

		#endregion

		/// <summary>
		/// Gets or sets the name of the file from which load or save the connection info data
		/// </summary>
		/// <value>
		/// The name of the file.
		/// </value>
		public string FileName
		{
			get
			{
				return mControlModel.FileName;
			}
			set
			{
				mControlModel.FileName = value;
			}
		}

		/// <summary>
		/// Determines wether the data in the control has been changed	
		/// </summary>
		public bool IsChanged
		{
			get
			{
				return mControlModel.IsChanged;
			}
		}

		private void btnTest_Click(object sender, RoutedEventArgs e)
		{
			mControlModel.TestConnection();

		}

	}
}
