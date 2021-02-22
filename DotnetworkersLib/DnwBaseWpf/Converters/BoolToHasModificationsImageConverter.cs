// ---------------------------------------------------------------
// DATI FILE BoolToHasModificationsImageConverter.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseWpf
// File....................: BoolToHasModificationsImageConverter.cs
// Namespace...............: Dnw.Base.Wpf.Converters
// Classi..................: public BoolToHasModificationsImageConverter : IValueConverter
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 70
// Dimensione..............: 2,65 Kb
// Data Creazione..........: 17/10/2013 16:39:24
// Data ultima Modifica....: 17/10/2013 16:53:25
// ---------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;



namespace Dnw.Base.Wpf.Converters
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	[ValueConversion(typeof(bool), typeof(BitmapImage))]
	public class BoolToHasModificationsImageConverter : IValueConverter
	{
		/// <summary>
		/// Converts a value.
		/// 
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
			BitmapImage result = null;
			bool input = (bool)value;

			if (input)
			{

				result = new BitmapImage(new Uri("pack://application:,,,/Dnw.Base.Wpf.v4.0;component/Images/btn_032_153.png"));

			}
			else
			{
				result = new BitmapImage(new Uri("pack://application:,,,/Dnw.Base.Wpf.v4.0;component/Images/btn_032_152.png"));
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