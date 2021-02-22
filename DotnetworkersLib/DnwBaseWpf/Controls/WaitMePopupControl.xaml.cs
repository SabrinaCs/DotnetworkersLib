// ---------------------------------------------------------------
// DATI FILE WaitMePopupControl.xaml.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseWpf
// File....................: WaitMePopupControl.xaml.cs
// Namespace...............: Dnw.Base.Wpf.Controls
// Classi..................: public partial WaitMePopupControl : UserControl, INotifyPropertyChanged
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 320
// Dimensione..............: 6 Kb
// Data Creazione..........: 21/06/2013 12:59:15
// Data ultima Modifica....: 21/06/2013 13:39:48
// ---------------------------------------------------------------


using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Dnw.Base.Wpf.Controls
{
	/// <summary>
	/// Interaction logic for WaitMePopupControl.xaml
	/// </summary>
	public partial class WaitMePopupControl : UserControl, INotifyPropertyChanged
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="WaitMePopupControl"/> class.
		/// </summary>
		public WaitMePopupControl()
		{
			InitializeComponent();
			this.DataContext = this;

		}




		/// <summary>
		/// Gets or sets the target control for the popup
		/// positioning is relative to this control.
		/// </summary>
		/// <value>
		/// The placement target.
		/// </value>
		public UIElement PlacementTarget
		{
			get
			{
				return popWait.PlacementTarget;
			}
			set
			{
				popWait.PlacementTarget = value;
			}
		}


		/// <summary>
		/// Centers the popup in the parent control
		/// </summary>
		/// <param name="actualWidth">The actual width.</param>
		/// <param name="actualHeight">The actual height.</param>
		public void CenterInParent(double actualWidth, double actualHeight)
		{
			double centerwidth = actualWidth / 2;
			double centerHeight = -actualHeight / 2;
			popWait.HorizontalOffset = centerwidth - (popWait.Width / 2) - 10;
			popWait.VerticalOffset = centerHeight - (popWait.Height / 2) - 10;
		}


		/// <summary>
		/// Gets or sets the popup opening animation.
		/// </summary>
		/// <value>
		/// The popup opening animation.
		/// </value>
		public PopupAnimation PopupOpeningAnimation
		{
			get
			{
				return popWait.PopupAnimation;
			}
			set
			{
				popWait.PopupAnimation = value;
			}
		}



		/// <summary>
		/// Gets or sets the horizontal offset.
		/// </summary>
		/// <value>
		/// The horizontal offset.
		/// </value>
		public double HorizontalOffset
		{
			get
			{
				return popWait.HorizontalOffset;
			}
			set
			{
				popWait.HorizontalOffset = value;
			}
		}


		/// <summary>
		/// Gets or sets the vertical offset.
		/// </summary>
		/// <value>
		/// The vertical offset.
		/// </value>
		public double VerticalOffset
		{
			get
			{
				return popWait.VerticalOffset;
			}
			set
			{
				popWait.VerticalOffset = value;
			}
		}




		/// <summary>
		/// Message Font Size
		/// DbField
		/// </summary>
		public double MessageFontSize
		{
			get
			{

				return txtMessage.FontSize;
			}
			set
			{
				txtMessage.FontSize = value;
			}
		}

		/// <summary>
		/// Message Foreground
		/// DbField
		/// </summary>
		public Brush MessageForeground
		{
			get
			{
				return txtMessage.Foreground;
			}
			set
			{
				txtMessage.Foreground = value;
			}
		}


		/// <summary>
		/// Margin of the message text
		/// DbField
		/// </summary>
		public Thickness MessageTextMargin
		{
			get
			{
				return txtMessage.Margin;
			}
			set
			{
				txtMessage.Margin = value;
			}
		}



		/// <summary>
		/// Horizontal message alignment
		/// DbField
		/// </summary>
		public HorizontalAlignment MessageHorizontalAlignment
		{
			get
			{
				return txtMessage.HorizontalAlignment;
			}
			set
			{
				txtMessage.HorizontalAlignment = value;
			}
		}


		/// <summary>
		/// Message Vertical alignment
		/// DbField
		/// </summary>
		public VerticalAlignment MessageVerticalAlignment
		{
			get
			{
				return txtMessage.VerticalAlignment;
			}
			set
			{
				txtMessage.VerticalAlignment = value;
			}
		}


		/// <summary>
		/// Width of the popup
		/// DbField
		/// </summary>
		public double PopupWidth
		{
			get
			{
				return popWait.Width;
			}
			set
			{
				popWait.Width = value;
			}
		}


		/// <summary>
		/// Popup height
		/// DbField
		/// </summary>
		public double PopupHeight
		{
			get
			{
				return popWait.Height;
			}
			set
			{
				popWait.Height = value;
			}
		}









		/// <summary>
		/// The Text of the control
		/// N/A
		/// </summary>
		public const string FLD_MessageText = "MessageText";

		/// <summary>
		/// The Text of the control
		/// N/A
		/// </summary>
		private string mMessageText = "Wait me!";

		/// <summary>
		/// The Text of the control
		/// N/A
		/// </summary>
		public string MessageText
		{
			get
			{
				return mMessageText;
			}
			set
			{
				mMessageText = value;
				OnPropertyChanged(FLD_MessageText);
			}
		}





		/// <summary>
		/// Shows the popup
		/// </summary>
		public void ShowMe()
		{
			popWait.IsOpen = true;
			popWait.StaysOpen = true;

		}

		/// <summary>
		/// Hides the popup
		/// </summary>
		public void HideMe()
		{
			popWait.IsOpen = false;
			popWait.StaysOpen = false;

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


	}
}
