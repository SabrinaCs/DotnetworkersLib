// ---------------------------------------------------------------
// DATI FILE SettingsPage.xaml.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwUISettings
// File....................: SettingsPage.xaml.cs
// Namespace...............: Dnw.UI.Settings.Controls
// Classi..................: public partial SettingsPage : UserControl
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 698
// Dimensione..............: 19,85 Kb
// Data Creazione..........: 15/05/2013 16:00:02
// Data ultima Modifica....: 22/10/2013 15:03:47
// ---------------------------------------------------------------


using Dnw.Base;
using Dnw.Base.Collections;
using Dnw.Base.Entities;
using Dnw.Base.Wpf.Controls;
using Dnw.UI.SqlServer.Controls;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace Dnw.UI.Settings.Controls
{
	/// <summary>
	/// Interaction logic for SettingsPage.xaml
	/// </summary>
	public partial class SettingsPage : UserControl
	{
		/// <summary>
		/// The model attached to the window
		/// </summary>
		private DnwSettingsCollection mSettings;

		/// <summary>
		/// Initializes a new instance of the <see cref="SettingsPage"/> class.
		/// </summary>
		public SettingsPage()
		{

			InitializeComponent();
		}


		/// <summary>
		/// Inits the controls from the specified file name.
		/// </summary>
		/// <param name="settingsToManage">The settings to manage.</param>
		public void Init(DnwSettingsCollection settingsToManage)
		{
			mSettings = settingsToManage;
			this.DataContext = this;
			GenerateControls();
		}

		/// <summary>
		/// Generates the controls.
		/// </summary>
		private void GenerateControls()
		{

			try
			{

				int rows = mSettings.GridRowsCount();
				grdScaffold.Children.Clear();
				Grid innerGrid = new Grid();
				innerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(15, GridUnitType.Star) });
				innerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(40, GridUnitType.Star) });
				innerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(60, GridUnitType.Star) });
				for (int i = 0; i < rows; i++)
				{
					innerGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
				}

				innerGrid.Margin = new Thickness(5);

				grdScaffold.Children.Add(innerGrid);
				Grid.SetRow(innerGrid, 0);

				int countRows = 0;
				string oldCat = null;
				foreach (DnwSetting item in mSettings.GetOrderedList().ToList())
				{
					if (item.Category != oldCat)
					{
						GenerateCategoryHeader(innerGrid, item, countRows);
						SetGridBorder(innerGrid, Colors.Gray, 1, 0, countRows, true);
						countRows++;
						oldCat = item.Category;
					}

					switch (item.EditorType)
					{
						case EditorType.NumericInteger:
							GenerateNumericIntegerRow(innerGrid, item, countRows);
							break;
						case EditorType.NumericDouble:
							GenerateNumericDoubleRow(innerGrid, item, countRows);
							break;
						case EditorType.CheckBox:
							GenerateCheckboxRow(innerGrid, item, countRows);
							break;
						case EditorType.Date:
							GenerateDateRow(innerGrid, item, countRows);
							break;
						case EditorType.TimeShort:
							GenerateTimeShortRow(innerGrid, item, countRows);
							break;
						case EditorType.TimeLong:
							GenerateTimeLongRow(innerGrid, item, countRows);
							break;
						case EditorType.FileName:
							GenerateFileNameRow(innerGrid, item, countRows);
							break;
						case EditorType.DirectoryName:
							GenerateDirectoryNameRow(innerGrid, item, countRows);
							break;
						case EditorType.SqlConnectionsFile:
							GenerateSqlConnectionsFileRow(innerGrid, item, countRows);
							break;
						case EditorType.DropDown:
							GenerateDropdownRow(innerGrid, item, countRows);
							break;
						default:
							GenerateTextBoxRow(innerGrid, item, countRows);
							break;
					}
					SetGridBorder(innerGrid, Colors.Gray, 1, 0, countRows, false);
					countRows++;
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}


		///<summary>
		/// 
		///</summary>
		private void GenerateCategoryHeader(Grid gridToSet, DnwSetting item, int row)
		{
			try
			{

				Grid categoryGrid = new Grid();
				categoryGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });
				categoryGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
				categoryGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
				TextBlock txt = new TextBlock();
				txt.Text = item.Category;
				txt.Margin = new Thickness(5, 10, 3, 5);
				txt.Style = Resources["Header"] as Style;
				categoryGrid.Children.Add(txt);
				Grid.SetColumn(txt, 0);
				Grid.SetRow(txt, 0);
				Rectangle rect = new Rectangle();
				rect.Margin = new Thickness(5, 0, 5, 0);
				rect.HorizontalAlignment = HorizontalAlignment.Stretch;
				rect.VerticalAlignment = VerticalAlignment.Stretch;
				rect.Height = 1;
				rect.Stroke = new SolidColorBrush(Colors.DarkGray);
				rect.StrokeThickness = 1;
				categoryGrid.Children.Add(rect);
				Grid.SetColumn(rect, 1);
				Grid.SetRow(rect, 0);
				gridToSet.Children.Add(categoryGrid);
				Grid.SetRow(categoryGrid, row);
				Grid.SetColumnSpan(categoryGrid, 3);
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}


		/// <summary>
		/// Generates the numeric integer row.
		/// </summary>
		/// <param name="gridContainer">The grid container.</param>
		/// <param name="item">The item.</param>
		/// <param name="row">The row.</param>
		private void GenerateNumericIntegerRow(Grid gridContainer, DnwSetting item, int row)
		{
			try
			{

				GenerateDescriptions(gridContainer, item, row);
				IntegerUpDown iud = new IntegerUpDown();
				if (item.Mask.XDwIsNullOrTrimEmpty())
				{
					iud.FormatString = "N0";
				}
				else
				{
					iud.FormatString = item.Mask;
				}
				iud.Padding = new Thickness(2);
				iud.Margin = new Thickness(5);
				Binding vBinding = new Binding(DnwSetting.FLD_Value);
				vBinding.Source = item;
				iud.SetBinding(IntegerUpDown.ValueProperty, vBinding);
				gridContainer.Children.Add(iud);
				Grid.SetRow(iud, row);
				Grid.SetColumn(iud, 2);
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}


		/// <summary>
		/// Generates the numeric double row.
		/// </summary>
		/// <param name="gridContainer">The grid container.</param>
		/// <param name="item">The item.</param>
		/// <param name="row">The row.</param>
		private void GenerateNumericDoubleRow(Grid gridContainer, DnwSetting item, int row)
		{
			try
			{

				GenerateDescriptions(gridContainer, item, row);
				DoubleUpDown dud = new DoubleUpDown();
				if (item.Mask.XDwIsNullOrTrimEmpty())
				{
					dud.FormatString = "F6";
				}
				else
				{
					dud.FormatString = item.Mask;
				}
				dud.Padding = new Thickness(2);
				dud.Margin = new Thickness(5);
				Binding vBinding = new Binding(DnwSetting.FLD_Value);
				vBinding.Source = item;
				dud.SetBinding(DoubleUpDown.ValueProperty, vBinding);
				gridContainer.Children.Add(dud);
				Grid.SetRow(dud, row);
				Grid.SetColumn(dud, 2);

			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}


		/// <summary>
		/// Generates the checkbox row.
		/// </summary>
		/// <param name="gridContainer">The grid container.</param>
		/// <param name="item">The item.</param>
		/// <param name="row">The row.</param>
		private void GenerateCheckboxRow(Grid gridContainer, DnwSetting item, int row)
		{
			try
			{

				GenerateDescriptions(gridContainer, item, row);
				CheckBox chk = new CheckBox();

				chk.Padding = new Thickness(2);
				chk.Margin = new Thickness(5);
				chk.VerticalAlignment = System.Windows.VerticalAlignment.Center;
				chk.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
				Binding vBinding = new Binding(DnwSetting.FLD_Value);
				vBinding.Source = item;
				chk.SetBinding(CheckBox.IsCheckedProperty, vBinding);
				gridContainer.Children.Add(chk);
				Grid.SetRow(chk, row);
				Grid.SetColumn(chk, 2);

			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}


		/// <summary>
		/// Generates the date row.
		/// </summary>
		/// <param name="gridContainer">The grid container.</param>
		/// <param name="item">The item.</param>
		/// <param name="row">The row.</param>
		private void GenerateDateRow(Grid gridContainer, DnwSetting item, int row)
		{
			try
			{

				GenerateDescriptions(gridContainer, item, row);
				DateTimePicker dtl = new DateTimePicker();
				dtl.Format = DateTimeFormat.ShortDate;
				dtl.Padding = new Thickness(2);
				dtl.Margin = new Thickness(5);
				Binding vBinding = new Binding(DnwSetting.FLD_Value);
				vBinding.Source = item;
				dtl.SetBinding(DateTimePicker.ValueProperty, vBinding);
				gridContainer.Children.Add(dtl);
				Grid.SetRow(dtl, row);
				Grid.SetColumn(dtl, 2);

			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}


		/// <summary>
		/// Generates the time short row.
		/// </summary>
		/// <param name="gridContainer">The grid container.</param>
		/// <param name="item">The item.</param>
		/// <param name="row">The row.</param>
		private void GenerateTimeShortRow(Grid gridContainer, DnwSetting item, int row)
		{
			try
			{

				GenerateDescriptions(gridContainer, item, row);
				DateTimeUpDown dts = new DateTimeUpDown();
				dts.Format = DateTimeFormat.ShortTime;
				dts.Padding = new Thickness(2);
				dts.Margin = new Thickness(5);

				Binding vBinding = new Binding(DnwSetting.FLD_Value);
				vBinding.Source = item;
				dts.SetBinding(DateTimeUpDown.ValueProperty, vBinding);
				gridContainer.Children.Add(dts);
				Grid.SetRow(dts, row);
				Grid.SetColumn(dts, 2);

			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}


		/// <summary>
		/// Generates the time long row.
		/// </summary>
		/// <param name="gridContainer">The grid container.</param>
		/// <param name="item">The item.</param>
		/// <param name="row">The row.</param>
		private void GenerateTimeLongRow(Grid gridContainer, DnwSetting item, int row)
		{
			try
			{

				GenerateDescriptions(gridContainer, item, row);
				DateTimeUpDown dtl = new DateTimeUpDown();
				dtl.Format = DateTimeFormat.LongTime;
				dtl.Padding = new Thickness(2);
				dtl.Margin = new Thickness(5);

				Binding vBinding = new Binding(DnwSetting.FLD_Value);
				vBinding.Source = item;
				dtl.SetBinding(DateTimeUpDown.ValueProperty, vBinding);
				gridContainer.Children.Add(dtl);
				Grid.SetRow(dtl, row);
				Grid.SetColumn(dtl, 2);

			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}


		/// <summary>
		/// Generates the SQL connections file row.
		/// </summary>
		/// <param name="gridContainer">The grid container.</param>
		/// <param name="item">The item.</param>
		/// <param name="row">The row.</param>
		private void GenerateSqlConnectionsFileRow(Grid gridContainer, DnwSetting item, int row)
		{
			try
			{

				GenerateDescriptions(gridContainer, item, row);
				SqlConnectionFileEditorControl dp = new SqlConnectionFileEditorControl();
				dp.Padding = new Thickness(2);

				Binding vBinding = new Binding(DnwSetting.FLD_Value);
				vBinding.Source = item;
				vBinding.Mode = BindingMode.TwoWay;
				dp.SetBinding(SqlConnectionFileEditorControl.FileNameProperty, vBinding);
				gridContainer.Children.Add(dp);
				Grid.SetRow(dp, row);
				Grid.SetColumn(dp, 2);

			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}


		/// <summary>
		/// Generates the directory name row.
		/// </summary>
		/// <param name="gridContainer">The grid container.</param>
		/// <param name="item">The item.</param>
		/// <param name="row">The row.</param>
		private void GenerateDirectoryNameRow(Grid gridContainer, DnwSetting item, int row)
		{
			try
			{

				GenerateDescriptions(gridContainer, item, row);
				DnwDirectoryPicker dp = new DnwDirectoryPicker();
				dp.Padding = new Thickness(2);
				Binding vBinding = new Binding(DnwSetting.FLD_Value);
				vBinding.Source = item;
				vBinding.Mode = BindingMode.TwoWay;
				dp.SetBinding(DnwDirectoryPicker.DirectoryNameProperty, vBinding);
				gridContainer.Children.Add(dp);
				Grid.SetRow(dp, row);
				Grid.SetColumn(dp, 2);

			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}


		/// <summary>
		/// Generates the file name row.
		/// </summary>
		/// <param name="gridContainer">The grid container.</param>
		/// <param name="item">The item.</param>
		/// <param name="row">The row.</param>
		private void GenerateFileNameRow(Grid gridContainer, DnwSetting item, int row)
		{
			try
			{

				GenerateDescriptions(gridContainer, item, row);
				DnwFilePicker fp = new DnwFilePicker();
				fp.Padding = new Thickness(2);
				Binding vBinding = new Binding(DnwSetting.FLD_Value);
				vBinding.Source = item;
				vBinding.Mode = BindingMode.TwoWay;
				fp.SetBinding(DnwFilePicker.FileNameProperty, vBinding);
				gridContainer.Children.Add(fp);
				Grid.SetRow(fp, row);
				Grid.SetColumn(fp, 2);

			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}

		/// <summary>
		/// Generates the dropdown row.
		/// </summary>
		/// <param name="gridContainer">The grid container.</param>
		/// <param name="item">The item.</param>
		/// <param name="row">The row.</param>
		private void GenerateDropdownRow(Grid gridContainer, DnwSetting item, int row)
		{
			try
			{

				GenerateDescriptions(gridContainer, item, row);
				ComboBox cbo = new ComboBox();
				cbo.ItemsSource = item.DropdownValues;
				cbo.SelectedValuePath = DnwDropDownItem.FLD_Value;
				cbo.Margin = new Thickness(5);
				cbo.Padding = new Thickness(2);
				Binding vBinding = new Binding(DnwSetting.FLD_Value);
				vBinding.Source = item;
				vBinding.Mode = BindingMode.TwoWay;
				cbo.SetBinding(ComboBox.SelectedValueProperty, vBinding);
				gridContainer.Children.Add(cbo);
				Grid.SetRow(cbo, row);
				Grid.SetColumn(cbo, 2);

				//var dt = this.FindResource("cboDT") as DataTemplate;
				//cbo.ItemTemplate = dt;


				//create the data template
				DataTemplate cboDT = new DataTemplate();
				cboDT.DataType = typeof(ComboBox);

				//set up the stack panel
				FrameworkElementFactory spFactory = new FrameworkElementFactory(typeof(StackPanel));
				spFactory.SetValue(StackPanel.OrientationProperty, Orientation.Vertical);
				spFactory.SetValue(StackPanel.FlowDirectionProperty, FlowDirection.LeftToRight);
				spFactory.SetValue(StackPanel.MarginProperty, new Thickness(4));


				//set up the card holder textblock
				FrameworkElementFactory txtData = new FrameworkElementFactory(typeof(TextBlock));
				txtData.SetBinding(TextBlock.TextProperty, new Binding(DnwDropDownItem.FLD_Description));
				spFactory.AppendChild(txtData);

				//set the visual tree of the data template
				cboDT.VisualTree = spFactory;

				//set the item template to be our shiny new data template
				cbo.ItemTemplate = cboDT;



			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}

		/// <summary>
		/// Generates a textbox control
		/// </summary>
		/// <param name="gridContainer">The grid container.</param>
		/// <param name="item">The item.</param>
		/// <param name="row">The row.</param>
		private void GenerateTextBoxRow(Grid gridContainer, DnwSetting item, int row)
		{
			try
			{

				GenerateDescriptions(gridContainer, item, row);

				TextBox txb = new TextBox();
				txb.HorizontalAlignment = HorizontalAlignment.Stretch;
				txb.VerticalAlignment = VerticalAlignment.Center;
				txb.Margin = new Thickness(5);
				txb.Padding = new Thickness(2);

				Binding vBinding = new Binding(DnwSetting.FLD_Value);
				vBinding.Source = item;
				txb.SetBinding(TextBox.TextProperty, vBinding);
				gridContainer.Children.Add(txb);
				Grid.SetRow(txb, row);
				Grid.SetColumn(txb, 2);

			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}


		/// <summary>
		/// Generates the descriptions.
		/// </summary>
		/// <param name="gridContainer">The grid container.</param>
		/// <param name="item">The item.</param>
		/// <param name="row">The row.</param>
		private void GenerateDescriptions(Grid gridContainer, DnwSetting item, int row)
		{
			try
			{

				TextBlock txt = new TextBlock();
				txt.Text = item.ID;
				txt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0C670A"));
				txt.FontWeight = FontWeights.Bold;
				txt.Margin = new Thickness(5, 2, 5, 2);
				txt.Padding = new Thickness(2);
				txt.HorizontalAlignment = HorizontalAlignment.Center;
				txt.VerticalAlignment = VerticalAlignment.Center;
				gridContainer.Children.Add(txt);
				Grid.SetRow(txt, row);
				Grid.SetColumn(txt, 0);
				txt = new TextBlock();
				txt.Text = item.Description;
				txt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#062a7b"));
				txt.Margin = new Thickness(5, 2, 5, 2);
				txt.TextWrapping = TextWrapping.Wrap;
				txt.HorizontalAlignment = HorizontalAlignment.Left;
				txt.VerticalAlignment = VerticalAlignment.Center;
				txt.Padding = new Thickness(2);

				gridContainer.Children.Add(txt);
				Grid.SetRow(txt, row);
				Grid.SetColumn(txt, 1);

			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}



		/// <summary>
		/// Sets the grid border.
		/// </summary>
		/// <param name="gridToSet">The grid to set.</param>
		/// <param name="borderColor">Color of the border.</param>
		/// <param name="borderThickness">The border thickness.</param>
		/// <param name="radius">The radius.</param>
		/// <param name="row">The row.</param>
		/// <param name="isCategory">if set to <c>true</c> [is category].</param>
		private void SetGridBorder(Grid gridToSet, Color borderColor, int borderThickness, int radius, int row, bool isCategory)
		{
			try
			{

				int rows = gridToSet.RowDefinitions.Count;
				int cols = gridToSet.ColumnDefinitions.Count;


				for (int j = 0; j < cols; j++)
				{
					Border b = new Border() { BorderBrush = new SolidColorBrush(borderColor) };
					if (isCategory)
					{
						if (row == 0)
						{
							b.BorderThickness = new Thickness(0);
						}
						else
						{
							b.BorderThickness = new Thickness(0, borderThickness, 0, 0);
						}
					}
					else
					{
						if (j == 0)
						{
							if (row == rows - 1)
							{
								b.BorderThickness = new Thickness(borderThickness);
							}
							else
							{
								b.BorderThickness = new Thickness(borderThickness, borderThickness, borderThickness, 0);
							}
						}
						else
						{
							if (row == rows - 1)
							{
								b.BorderThickness = new Thickness(0, borderThickness, borderThickness, borderThickness);
							}
							else
							{
								b.BorderThickness = new Thickness(0, borderThickness, borderThickness, 0);
							}
						}
					}
					if (radius != 0)
					{
						b.CornerRadius = new CornerRadius(radius);
					}
					gridToSet.Children.Add(b);
					Grid.SetColumn(b, j);
					Grid.SetRow(b, row);
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}

		}

	}



}
