// ---------------------------------------------------------------
// DATI FILE DbnullExtension.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: DbnullExtension.cs
// Namespace...............: Dnw.Base
// Classi..................: public static DbnullExtension
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 106
// Dimensione..............: 3,54 Kb
// Data Creazione..........: 24/06/2013 17:36:10
// Data ultima Modifica....: 24/06/2013 17:39:20
// ---------------------------------------------------------------

using System;




namespace Dnw.Base
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	public static class DbnullExtension
	{

		/// <summary>
		/// Test the object for null or DBNull and returns the value or the default.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static T XDwNull<T>(this object value)
		{
			//return value.XDwNull(default(T));
			return (value == DBNull.Value || value == null) ? default(T) : (T)value;  //  <---- OPTIMIZED TO AVOID NESTED CALLS
		}

		/// <summary>
		/// Tries to convert a value to DbNull if it is the class default or
		/// if it is equal to the value passed as parameter
		/// </summary>
		/// <typeparam name="T">The class to be checked for dbnull</typeparam>
		/// <param name="valueToBeConverted">The value to be converted to dbnull if it is equal to its default</param>
		/// <returns>DbNull or the value</returns>
		public static object XDwTryParseToDBNull<T>(this object valueToBeConverted)
		{
			return XDwTryParseToDBNull<T>(valueToBeConverted, default(T));
		}

		/// <summary>
		/// Returns the object or a DbNull, the latter is returned if the object
		/// is the class default value or if it is the value passed as forced dbnull value
		/// </summary>
		/// <param name="valueToBeConverted">Value to be dbnulled</param>
		/// <param name="forcedDbNullValue">Value to be converted to DBNull for the cases where it is different from the class default value</param>
		/// <returns>The original object value or a DbNull</returns>
		public static object XDwTryParseToDBNull<T>(this object valueToBeConverted, T forcedDbNullValue)
		{
			try
			{
				if (valueToBeConverted == null)
				{
					return (DBNull.Value);
				}
				if (valueToBeConverted == DBNull.Value)
				{
					return (valueToBeConverted);
				}
				if (valueToBeConverted.GetType() == typeof(T))
				{
					T pippo;
					try
					{
						pippo = (T)valueToBeConverted;
					}
					catch (Exception)
					{
						pippo = default(T);
					}
					if (pippo.Equals(default(T)) || pippo.Equals(forcedDbNullValue))
					{
						return (DBNull.Value);
					}
					else
					{
						return (valueToBeConverted);
					}
				}
				else
				{
					return (valueToBeConverted);
				}

			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}

		/// <summary>
		/// Test the object for null or DBNull and returns the value or the default.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value">The value.</param>
		/// <param name="defaultValue">The default value.</param>
		/// <returns></returns>
		public static T XDwNull<T>(this object value, T defaultValue)
		{
			return (value == DBNull.Value || value == null) ? defaultValue : (T)value;
		}



	}
}