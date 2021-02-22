// ---------------------------------------------------------------
// DATI FILE SqlConnectionFileEditorControl.xaml.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwUISqlServer
// File....................: SqlConnectionFileEditorControl.xaml.cs
// Namespace...............: Dnw.UI.SqlServer.Controls
// Classi..................: public partial SqlConnectionFileEditorControl : UserControl
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 157
// Dimensione..............: 4,43 Kb
// Data Creazione..........: 15/05/2013 11:51:37
// Data ultima Modifica....: 20/05/2013 15:41:18
// ---------------------------------------------------------------


using Dnw.Base;
using Dnw.UI.SqlServer.Windows;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Dnw.UI.SqlServer.Controls
{
	/// <summary>
	/// Interaction logic for SqlConnectionFileEditorControl.xaml
	/// </summary>
	public partial class SqlConnectionFileEditorControl : UserControl
	{
		private const string FLD_FileName = "FileName";
		/// <summary>
		/// Extension for the cryptographed files
		/// </summary>
		private const string EXT_Dnwx = ".dnwx";

		/// <summary>
		/// Filters for the Open and Save file dialogs
		/// </summary>
		private const string TXT_Filters = "Json files (*.json)|*.json|Dnw Hidden (*.dnwx)|*.dnwx|All files (*.*)|*.*";


		/// <summary>
		/// Initializes a new instance of the <see cref="SqlConnectionFileEditorControl"/> class.
		/// </summary>
		public SqlConnectionFileEditorControl()
		{
			InitializeComponent();
			mIcon = BitmapFrame.Create(new Uri("pack://application:,,,/Dnw.UI.SqlServer;component/dnwico.ico", UriKind.RelativeOrAbsolute));
		}

		private void btnEdit_Click(object sender, RoutedEventArgs e)
		{
			bool ret = true;
			if (this.FileName.XDwIsNullOrTrimEmpty())
			{
				ret = GetFileName();
			}
			if (ret)
			{
				SqlGetConnectionsWindow win = new SqlGetConnectionsWindow(Icon, this.FileName);
				win.ShowDialog();
			}
			else
			{
				MessageBox.Show(SqlConnectionFileEditorControlRx.txtSCFECNoFileName);
			}
		}



		/// <summary>
		/// Handles the Click event of the btnSearch control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
		private void btnSearch_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				GetFileName();
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				MessageBox.Show(ex.Message,
                    SqlConnectionFileEditorControlRx.excError,
					MessageBoxButton.OK, MessageBoxImage.Error);
			}

		}

		private bool GetFileName()
		{
			bool gotten = false;
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = SqlConnectionFileEditorControlRx.txtSCFEOfdTitle;
			ofd.Multiselect = false;
			ofd.DefaultExt = EXT_Dnwx;
			ofd.Filter = TXT_Filters;
			ofd.FilterIndex = 2;
			ofd.CheckFileExists = false;
			ofd.CheckPathExists = true;
			bool? ret = ofd.ShowDialog();
			if (ret.HasValue && ret.Value)
			{
				this.FileName = ofd.FileName;
				if (!this.FileName.XDwIsNullOrTrimEmpty())
				{
					gotten = true;
				}
			}
			return (gotten);
		}


		/// <summary>
		/// The Icon for the window
		/// </summary>
		private ImageSource mIcon;

		/// <summary>
		/// The Icon for the window
		/// </summary>
		///<remarks>
		///</remarks>
		public ImageSource Icon
		{
			get
			{
				return mIcon;
			}
			set
			{
				mIcon = value;
			}
		}

		/// <summary>
		/// The Text property of the textbox control
		/// </summary>
		///<remarks>
		///</remarks>
		public string FileName
		{
			get
			{
				return (string)this.GetValue(FileNameProperty);
			}
			set
			{
				this.SetValue(FileNameProperty, value);
			}
		}


		/// <summary>
		/// Dependency property that exposes the file name to the external use
		/// To allow Binding to the Textbox Through the control.
		/// </summary>
		public static readonly DependencyProperty FileNameProperty = DependencyProperty.Register(
			FLD_FileName, typeof(string), typeof(SqlConnectionFileEditorControl),
				new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



	}
}
