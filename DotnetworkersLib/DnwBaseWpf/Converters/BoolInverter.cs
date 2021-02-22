// ---------------------------------------------------------------
// DATI FILE BoolInverter.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseWpf
// File....................: BoolInverter.cs
// Namespace...............: Dnw.Base.Wpf.Converters
// Classi..................: public BoolInverter : IValueConverter
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 55
// Dimensione..............: 2,23 Kb
// Data Creazione..........: 04/06/2013 12:13:25
// Data ultima Modifica....: 04/06/2013 12:18:04
// ---------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;



namespace Dnw.Base.Wpf.Converters
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	[ValueConversion(typeof(bool), typeof(bool))]
	public class BoolInverter : IValueConverter
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
			bool input = (bool)value;
			return !input;

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

			bool input = (bool)value;
			return !input;

		}

	}
}