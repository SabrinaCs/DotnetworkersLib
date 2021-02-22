// ---------------------------------------------------------------
// DATI FILE DnwFilePicker.xaml.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseWpf
// File....................: DnwFilePicker.xaml.cs
// Namespace...............: Dnw.Base.Wpf.Controls
// Classi..................: public partial DnwFilePicker : UserControl
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 250
// Dimensione..............: 5,22 Kb
// Data Creazione..........: 15/05/2013 10:52:39
// Data ultima Modifica....: 20/05/2013 15:41:20
// ---------------------------------------------------------------

using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Dnw.Base.Wpf.Controls
{
	/// <summary>
	/// Interaction logic for DnwFilePicker.xaml
	/// </summary>
	public partial class DnwFilePicker : UserControl
	{
		/// <summary>
		/// File name
		/// N/A
		/// </summary>
		public const string FLD_FileName = "FileName";


		/// <summary>
		/// Indicates wether to check for the file existence or not
		/// N/A
		/// </summary>
		private bool mCheckFileExists;

		/// <summary>
		/// Check if the folder exists
		/// </summary>
		private bool mCheckFolderExists;

		/// <summary>
		/// Default extension
		/// </summary>
		private string mDefaultExt;

		/// <summary>
		/// Filter index
		/// N/A
		/// </summary>
		private int mFilterIndex;

		/// <summary>
		/// Accept multiple selections
		/// </summary>
		private bool mMultiSelect;

		/// <summary>
		/// Filters for the search
		/// N/A
		/// </summary>
		private string mSearchFilters;

		/// <summary>
		/// File window title
		/// N/A
		/// </summary>
		private string mTitle;

		/// <summary>
		/// Initializes a new instance of the <see cref="DnwFilePicker"/> class.
		/// </summary>
		public DnwFilePicker()
		{
			InitializeComponent();
			this.DataContext = this;
			mTitle = "Select a file";
			mSearchFilters = "All files (*.*)|*.*";
			mFilterIndex = 1;
			mCheckFileExists = false;
			mCheckFolderExists = false;
			mMultiSelect = false;
		}

		private void btnSearch_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = Title;
			ofd.Multiselect = MultiSelect;
			ofd.DefaultExt = DefaultExt;
			ofd.Filter = SearchFilters;
			ofd.FilterIndex = FilterIndex;
			ofd.CheckFileExists = CheckFileExists;
			ofd.CheckPathExists = CheckFolderExists;
			bool? ret = ofd.ShowDialog();
			if (ret.HasValue && ret.Value)
			{
				if (ofd.Multiselect)
				{
					string sep = "";
					StringBuilder sb = new StringBuilder();
					for (int i = 0; i < ofd.FileNames.Length; i++)
					{

						sb.Append(sep);
						sb.Append(ofd.FileNames[i]);
						sep = ", ";
					}
					this.FileName = sb.ToString();
				}
				else
				{
					this.FileName = ofd.FileName;
				}
			}

		}

		/// <summary>
		/// File window title
		/// N/A
		/// </summary>
		public string Title
		{
			get
			{
				return mTitle;
			}
			set
			{
				mTitle = value;
			}
		}

		/// <summary>
		/// Filters for the search
		/// N/A
		/// </summary>
		public string SearchFilters
		{
			get
			{
				return mSearchFilters;
			}
			set
			{
				mSearchFilters = value;
			}
		}

		/// <summary>
		/// Filter index
		/// N/A
		/// </summary>
		public int FilterIndex
		{
			get
			{
				return mFilterIndex;
			}
			set
			{
				mFilterIndex = value;
			}
		}

		/// <summary>
		/// Indicates wether to check for the file existence or not
		/// N/A
		/// </summary>
		public bool CheckFileExists
		{
			get
			{
				return mCheckFileExists;
			}
			set
			{
				mCheckFileExists = value;
			}
		}

		/// <summary>
		/// Check if the folder exists
		/// </summary>
		///<remarks>
		///</remarks>
		public bool CheckFolderExists
		{
			get
			{
				return mCheckFolderExists;
			}
			set
			{
				mCheckFolderExists = value;
			}
		}

		/// <summary>
		/// Accept multiple selections
		/// </summary>
		///<remarks>
		///</remarks>
		public bool MultiSelect
		{
			get
			{
				return mMultiSelect;
			}
			set
			{
				mMultiSelect = value;
			}
		}

		/// <summary>
		/// Default extension
		/// </summary>
		///<remarks>
		///</remarks>
		public string DefaultExt
		{
			get
			{
				return mDefaultExt;
			}
			set
			{
				mDefaultExt = value;
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
		/// Dependency property that allows the use of binding on the Text property of the textbox
		/// Of this user control. 
		/// </summary>
		public static readonly DependencyProperty FileNameProperty = DependencyProperty.Register(
			FLD_FileName, typeof(string), typeof(DnwFilePicker), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	}
}
