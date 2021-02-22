// ---------------------------------------------------------------
// DATI FILE BoolToVisibilityConverter.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseWpf
// File....................: BoolToVisibilityConverter.cs
// Namespace...............: Dnw.Base.Wpf.Converters
// Classi..................: public BoolToVisibilityConverter : IValueConverter
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 68
// Dimensione..............: 2,45 Kb
// Data Creazione..........: 24/05/2013 15:03:46
// Data ultima Modifica....: 06/06/2013 10:58:31
// ---------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;



namespace Dnw.Base.Wpf.Converters
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	[ValueConversion(typeof(bool), typeof(Visibility))]
	public class BoolToVisibilityConverter : IValueConverter
	{

		/// <summary>
		/// Converts a value.
		/// </summary>
		/// <param name="value">The value produced by the binding source.</param>
		/// <param name="targetType">The type of the binding target property.</param>
		/// <param name="parameter">The converter parameter to use.</param>
		/// <param name="culture">The culture to use in the converter.</param>
		/// <returns>
		/// A converted value. If the method returns null, the valid null value is used.
		/// </returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Visibility result = Visibility.Visible;
			bool input = (bool)value;

			if (input)
			{

				result = Visibility.Visible;

			}
			else
			{
				result = Visibility.Collapsed;
			}


			return result;

		}


		/// <summary>
		/// Converts a value.
		/// </summary>
		/// <param name="value">The value that is produced by the binding target.</param>
		/// <param name="targetType">The type to convert to.</param>
		/// <param name="parameter">The converter parameter to use.</param>
		/// <param name="culture">The culture to use in the converter.</param>
		/// <returns>
		/// A converted value. If the method returns null, the valid null value is used.
		/// </returns>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{

			return value;

		}

	}
}