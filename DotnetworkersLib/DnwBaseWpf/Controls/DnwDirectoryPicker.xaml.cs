// ---------------------------------------------------------------
// DATI FILE DnwDirectoryPicker.xaml.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseWpf
// File....................: DnwDirectoryPicker.xaml.cs
// Namespace...............: Dnw.Base.Wpf.Controls
// Classi..................: public partial DnwDirectoryPicker : UserControl
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 152
// Dimensione..............: 3,9 Kb
// Data Creazione..........: 17/05/2013 07:48:02
// Data ultima Modifica....: 20/05/2013 16:40:31
// ---------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Controls;

namespace Dnw.Base.Wpf.Controls
{
	/// <summary>
	/// Interaction logic for DnwDirectoryPicker.xaml
	/// </summary>
	public partial class DnwDirectoryPicker : UserControl
	{
		/// <summary>
		/// File window title
		/// N/A
		/// </summary>
		public const string FLD_DirectoryName = "DirectoryName";


		/// <summary>
		/// File window title
		/// N/A
		/// </summary>
		private string mDescription;

		/// <summary>
		/// Filters for the search
		/// N/A
		/// </summary>
		private Environment.SpecialFolder mRootFolder;

		/// <summary>
		/// Indicates wether to check for the file existence or not
		/// N/A
		/// </summary>
		private bool mShowNewFolderButton;

		/// <summary>
		/// Initializes a new instance of the <see cref="DnwDirectoryPicker"/> class.
		/// </summary>
		public DnwDirectoryPicker()
		{
			InitializeComponent();
			InitializeComponent();
			this.DataContext = this;
			mDescription = DnwDirectoryPickerRx.txtDDPDialogTitle;
		}

		/// <summary>
		/// Handles the Click event of the btnSearch control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
		private void btnSearch_Click(object sender, RoutedEventArgs e)
		{
			System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
			fbd.Description = Description;
			fbd.RootFolder = RootFolder;
			fbd.ShowNewFolderButton = ShowNewFolderButton;

			System.Windows.Forms.DialogResult ret = fbd.ShowDialog();
			if (ret == System.Windows.Forms.DialogResult.OK)
			{
				this.DirectoryName = fbd.SelectedPath;
			}
		}


		/// <summary>
		/// File window title
		/// N/A
		/// </summary>
		public string Description
		{
			get
			{
				return mDescription;
			}
			set
			{
				mDescription = value;
			}
		}

		/// <summary>
		/// Filters for the search
		/// N/A
		/// </summary>
		public Environment.SpecialFolder RootFolder
		{
			get
			{
				return mRootFolder;
			}
			set
			{
				mRootFolder = value;
			}
		}

		/// <summary>
		/// Indicates wether to check for the file existence or not
		/// N/A
		/// </summary>
		public bool ShowNewFolderButton
		{
			get
			{
				return mShowNewFolderButton;
			}
			set
			{
				mShowNewFolderButton = value;
			}
		}

		/// <summary>
		/// The Text property of the textbox control
		/// </summary>
		///<remarks>
		///</remarks>
		public string DirectoryName
		{
			get
			{
				return (string)this.GetValue(DirectoryNameProperty);
			}
			set
			{
				this.SetValue(DirectoryNameProperty, value);
			}
		}

		/// <summary>
		/// Dependency property that allows the use of binding on the Text property of the textbox
		/// Of this user control. 
		/// </summary>
		public static readonly DependencyProperty DirectoryNameProperty = DependencyProperty.Register(
			FLD_DirectoryName, typeof(string), typeof(DnwDirectoryPicker), 
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
	}
}