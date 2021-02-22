// ---------------------------------------------------------------
// DATI FILE CloseableTabItem.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseWpf
// File....................: CloseableTabItem.cs
// Namespace...............: Dnw.Base.Wpf.Components
// Classi..................: public CloseableTabItem : TabItem
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 201
// Dimensione..............: 6,62 Kb
// Data Creazione..........: 10/06/2013 17:33:05
// Data ultima Modifica....: 18/10/2013 11:41:51
// ---------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dnw.Base.Wpf.Components
{

	/// <summary>
	/// The Closeable TabItem Class
	/// </summary>
	public class CloseableTabItem : TabItem
	{
		static CloseableTabItem()
		{
			//This style is defined in themes\generic.xaml
			DefaultStyleKeyProperty.OverrideMetadata(typeof(CloseableTabItem),
				new FrameworkPropertyMetadata(typeof(CloseableTabItem)));
		}

		/// <summary>
		/// Definition of the close tab routed event
		/// </summary>
		public static readonly RoutedEvent CloseTabEvent =
			EventManager.RegisterRoutedEvent("CloseTab", RoutingStrategy.Direct,
				typeof(RoutedEventHandler), typeof(CloseableTabItem));
		/// <summary>
		/// Field name for dependency property
		/// </summary>
		public const string FLD_TabUniqueID = "TabUniqueID";

		/// <summary>
		/// Occurs when [close tab].
		/// </summary>
		public event RoutedEventHandler CloseTab
		{
			add { AddHandler(CloseTabEvent, value); }
			remove { RemoveHandler(CloseTabEvent, value); }
		}

		private const string FLD_CloseButtonTooltip = "CloseButtonTooltip";

		/// <summary>
		/// When overridden in a derived class, is 
		/// invoked whenever application code or internal processes call
		/// <see cref="M:System.Windows.FrameworkElement.ApplyTemplate" />.
		/// </summary>
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			Button closeButton = base.GetTemplateChild("PART_Close") as Button;
			if (closeButton != null)
				closeButton.Click += new System.Windows.RoutedEventHandler(closeButton_Click);
		}

		/// <summary>
		/// Closes this instance.
		/// </summary>
		public void Close()
		{
			this.RaiseEvent(new RoutedEventArgs(CloseTabEvent, this));
		}

		/// <summary>
		/// Handles the Click event of the closeButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
		private void closeButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.RaiseEvent(new RoutedEventArgs(CloseTabEvent, this));
		}


		/// <summary>
		/// The Unique ID for this tab to be used to avoid creating 2 times the same tab
		/// when tabs are built programmatically
		/// </summary>
		///<remarks>
		///</remarks>
		public string TabUniqueID
		{
			get
			{
				return (string)this.GetValue(TabUniqueIDProperty);
			}
			set
			{
				this.SetValue(TabUniqueIDProperty, value);
			}
		}

		/// <summary>
		/// Dependency property that allows the use of binding on the Text property of the textbox
		/// Of this user control. 
		/// </summary>
		public static readonly DependencyProperty TabUniqueIDProperty = DependencyProperty.Register(
			FLD_TabUniqueID, typeof(string), typeof(CloseableTabItem), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


		/// <summary>
		/// The principal object contained in the closeable tab item can be set and used for control purposes
		/// </summary>
		public const string FLD_PrimaryContainedControl = "PrimaryContainedControl";
		/// <summary>
		/// The principal object contained in the closeable tab item can be set and used for control purposes
		/// </summary>
		public object PrimaryContainedControl
		{
			get
			{
				return (object)this.GetValue(PrimaryContainedControlProperty);
			}
			set
			{
				this.SetValue(PrimaryContainedControlProperty, value);
			}
		}

		/// <summary>
		/// The principal object contained in the closeable tab item can be set and used for control purposes
		/// </summary>
		public static readonly DependencyProperty PrimaryContainedControlProperty = DependencyProperty.Register(
			FLD_PrimaryContainedControl, typeof(object), typeof(CloseableTabItem), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	


		/// <summary>
		/// Indicates the parent tab control of this closeable tab item
		/// </summary>
		public const string FLD_ParentTabControl = "ParentTabControl";


		/// <summary>
		/// Indicates the parent tab control of this closeable tab item
		/// </summary>
		public TabControl ParentTabControl
		{
			get
			{
				return (TabControl)this.GetValue(ParentTabControlProperty);
			}
			set
			{
				this.SetValue(ParentTabControlProperty, value);
			}
		}

		/// <summary>
		/// Indicates the parent tab control of this closeable tab item
		/// </summary>
		public static readonly DependencyProperty ParentTabControlProperty = DependencyProperty.Register(
			FLD_ParentTabControl, typeof(TabControl), typeof(CloseableTabItem), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	
		
		
		

		/// <summary>
		/// The Unique ID for this tab to be used to avoid creating 2 times the same tab
		/// when tabs are built programmatically
		/// </summary>
		///<remarks>
		///</remarks>
		public string CloseButtonTooltip
		{
			get
			{
				return (string)this.GetValue(CloseButtonTooltipProperty);
			}
			set
			{
				this.SetValue(CloseButtonTooltipProperty, value);
			}
		}

		/// <summary>
		/// Dependency property that allows the use of binding on the Text property of the textbox
		/// Of this user control. 
		/// </summary>
		public static readonly DependencyProperty CloseButtonTooltipProperty = DependencyProperty.Register(
			FLD_CloseButtonTooltip, typeof(string), typeof(CloseableTabItem), new FrameworkPropertyMetadata("Closes this Tab", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	
	}
}
