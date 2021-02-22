// ---------------------------------------------------------------
// DATI FILE BoolToIsValidImageConverter.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseWpf
// File....................: BoolToIsValidImageConverter.cs
// Namespace...............: Dnw.Base.Wpf.Converters
// Classi..................: public BoolToIsValidImageConverter : IValueConverter
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 74
// Dimensione..............: 2,71 Kb
// Data Creazione..........: 30/04/2013 11:41:41
// Data ultima Modifica....: 09/05/2013 09:56:28
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Globalization;



namespace Dnw.Base.Wpf.Converters
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	[ValueConversion(typeof(bool), typeof(BitmapImage))]
	public class BoolToIsValidImageConverter : IValueConverter
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

				result = new BitmapImage(new Uri("pack://application:,,,/Dnw.Base.Wpf.v4.0;component/Images/btn_032_752.png")); ;

			}
			else
			{
				result = new BitmapImage(new Uri("pack://application:,,,/Dnw.Base.Wpf.v4.0;component/Images/btn_032_355.png")); ;
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