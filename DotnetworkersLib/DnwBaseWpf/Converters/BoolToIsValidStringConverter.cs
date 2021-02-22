// ---------------------------------------------------------------
// DATI FILE BoolToIsValidStringConverter.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseWpf
// File....................: BoolToIsValidStringConverter.cs
// Namespace...............: Dnw.Base.Wpf.Converters
// Classi..................: public BoolToIsValidStringConverter : IValueConverter
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 68
// Dimensione..............: 2,44 Kb
// Data Creazione..........: 30/04/2013 12:08:38
// Data ultima Modifica....: 30/04/2013 12:13:18
// ---------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

namespace Dnw.Base.Wpf.Converters
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	[ValueConversion(typeof(bool), typeof(string))]
	public class BoolToIsValidStringConverter : IValueConverter
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
			string result = null;
			bool input = (bool)value;

			if (input)
			{

				result = BoolToIsValidStringConverterRx.txtIsValidToolTip;

			}
			else
			{
				result = BoolToIsValidStringConverterRx.txtIsInvalidToolTip;
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