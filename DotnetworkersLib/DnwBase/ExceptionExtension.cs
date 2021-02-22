// ---------------------------------------------------------------
// DATI FILE ExceptionExtension.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: ExceptionExtension.cs
// Namespace...............: Dnw.Base
// Classi..................: public static ExceptionExtension
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 120
// Dimensione..............: 4,1 Kb
// Data Creazione..........: 15/04/2013 14:45:20
// Data ultima Modifica....: 23/04/2013 12:44:36
// ---------------------------------------------------------------

using System;
using System.Reflection;
using System.Text;

namespace Dnw.Base
{
	///<summary>
	/// Descrizione della classe: Funzioni statiche per la formattazione dell'output delle eccezioni
	///</summary>
	///<remarks>
	///</remarks>
	public static class ExceptionExtension
	{


		#region Fields

		private readonly static string m80Dashes = new string('-', 80);

		#endregion

		#region Public Methods

		/// <summary>
		/// Generates a message with the informations of the exception who executes it
		/// </summary>
		/// <param name="ex">Eccezione</param>
		/// <returns></returns>
		public static string XDwBuildExceptionMessage(this Exception ex)
		{
			MethodBase method = ex.TargetSite;

			string name = "Unknown";
			if (method != null)
			{
				name = method.Name;
			}

			return ex.XDwBuildExceptionMessage(name);

		}

		/// <summary>
		/// Generates a message with the informations of the exception who executes it
		/// </summary>
		/// <param name="exceptionToParse">The exception to parse.</param>
		/// <param name="methodName">Name of the method.</param>
		/// <returns>A string representing the content of the exception for logging or display purpouses</returns>
		public static string XDwBuildExceptionMessage(this Exception exceptionToParse, string methodName)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(m80Dashes);
			sb.AppendFormat("Exception Time: {0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());

			sb.AppendLine();
			sb.AppendLine(m80Dashes);

			try
			{
				sb.AppendFormat("Exception type:{0}", exceptionToParse.GetType());
				sb.AppendLine();

				MethodBase method = exceptionToParse.TargetSite;
				if (method != null)
				{
					object[] attribs = method.Module.Assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
					sb.AppendLine(m80Dashes);
					sb.AppendFormat("Class name: {0}", method.ReflectedType.FullName);
					sb.AppendLine();
					sb.AppendFormat("Method name: {0}", methodName);
					sb.AppendLine();
					sb.AppendFormat("Assembly name: {0}", method.Module.Assembly.FullName);
					sb.AppendLine();
					if (attribs != null && attribs.Length > 0)
					{
						AssemblyFileVersionAttribute att = attribs[0] as AssemblyFileVersionAttribute;
						if (att != null)
						{
							sb.AppendFormat("File Version: {0}", att.Version);
							sb.AppendLine();
						}
					}
					sb.AppendFormat("Runtime Version:  {0}", method.Module.Assembly.ImageRuntimeVersion);
					sb.AppendLine();


				}


				sb.AppendLine(m80Dashes);
				sb.AppendFormat("Message: {0}", exceptionToParse.Message);
				sb.AppendLine();
			}

			catch (Exception ex1)
			{
				sb.AppendLine(string.Format("Error reading error in exception"));
				sb.AppendLine(ex1.Message);
			}

			sb.AppendLine(m80Dashes);
			sb.AppendLine("StackTrace:");
			sb.AppendLine(exceptionToParse.StackTrace);
			sb.AppendLine(m80Dashes);

			return (sb.ToString());
		}








		#endregion

	}
}