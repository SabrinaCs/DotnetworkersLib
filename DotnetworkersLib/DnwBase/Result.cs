// ---------------------------------------------------------------
// DATI FILE Result.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: Result.cs
// Namespace...............: Dnw.Base
// Classi..................: public Result<T>; public static Result
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 85
// Dimensione..............: 3,07 Kb
// Data Creazione..........: 25/06/2013 16:35:49
// Data ultima Modifica....: 25/06/2013 16:51:45
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Runtime.Serialization;



namespace Dnw.Base
{
	/// <summary>
	/// A generic result class to be used by data providers or function operating
	/// with services (HTTP for instance or WCF) to provide data and if necessary
	/// error informations without using exceptions
	/// In the case of services they can be asynchronous so exceptions are not a good
	/// way to inform the caller of an error occurred.
	/// </summary>
	/// <typeparam name="T">The data type</typeparam>
	public class Result<T>
	{
		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>The data.</value>
		[DataMember(Name = "DT")]
		public T Data { get; set; }

		/// <summary>
		/// Gets or sets the last error.
		/// </summary>
		/// <value>The error.</value>
		public BaseError Error { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance has error.
		/// </summary>
		/// <value><c>true</c> if this instance has error; otherwise, <c>false</c>.</value>
		public bool HasError { get { return (this.Error != null); } }

		/// <summary>
		/// Sets the error.
		/// </summary>
		/// <param name="errorDescription">The error description.</param>
		/// <param name="errorCode">The error code.</param>
		public void SetError(string errorDescription, string errorCode = null) { this.Error = new BaseError(errorDescription, errorCode); }

		/// <summary>
		/// Sets the error.
		/// </summary>
		/// <param name="error">The error.</param>
		public void SetError(BaseError error) { this.Error = error; }

		/// <summary>
		/// Sets the error.
		/// </summary>
		/// <param name="ex">The ex.</param>
		/// <param name="errorDescription">The error description.</param>
		/// <param name="errorCode">The error code.</param>
		public void SetError(Exception ex, string errorDescription = null, string errorCode = null) { new  BaseError(ex); }

		/// <summary>
		/// Clears the error.
		/// </summary>
		public void ClearError() { this.Error = null; }
	}

	/// <summary>
	/// A static class to conveniently create generic  result objects
	/// </summary>
	public static class Result
	{
		/// <summary>
		/// Gets this instance by creating the data too.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static Result<T> Get<T>() where T : new()
		{
			Result<T> output = new Result<T>();
			output.Data = new T();

			return output;
		}
	}
}