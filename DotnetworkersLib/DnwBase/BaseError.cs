// ---------------------------------------------------------------
// DATI FILE BaseError.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: BaseError.cs
// Namespace...............: Dnw.Base
// Classi..................: public BaseError
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 94
// Dimensione..............: 2,99 Kb
// Data Creazione..........: 25/06/2013 16:25:26
// Data ultima Modifica....: 25/06/2013 17:07:13
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Runtime.Serialization;



namespace Dnw.Base
{
	/// <summary>
	/// A class representing the user authentication error
	/// </summary>
	public class BaseError
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseError" /> 
		/// class starting from a generic exception.
		/// </summary>
		/// <param name="ex">The ex.</param>
		/// <param name="errorDescription">The p description.</param>
		/// <param name="specificCode">The specific code.</param>
		public BaseError(Exception ex,  string errorDescription = null, string specificCode = null)
		{
			this.Details = ex.XDwBuildExceptionMessage();
			this.Code = (specificCode == null) ? "GENERIC_0001" : specificCode;
			this.Description = (errorDescription == null)? ex.Message : errorDescription;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseError" /> class.
		/// </summary>
		/// <param name="errorDescription">The description.</param>
		/// <param name="specificCode">The code.</param>
		public BaseError( string errorDescription = null, string specificCode = null)
		{
			this.Description = errorDescription;
			this.Code = (specificCode == null) ? "GENERIC_0001" : specificCode;
		}

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("{0} {1}", this.Code, this.Description);
			if (!this.Details.XDwIsNullOrTrimEmpty())
			{
				sb.AppendLine();
				sb.AppendLine(this.Details);
			}
			return (sb.ToString());
		}

		/// <summary>
		/// Error description
		/// </summary>
		public string Description
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the code.
		/// </summary>
		/// <value>The code.</value>
		/// <remarks>The code should be spcified as follows: 
		/// SHORTDOMAINPREFIX_FOURDIGITNUMBER e.g. AUTH_0001 , 
		/// LIC_0222, DOCS_3400</remarks>
		public string Code
		{
			get;
			set;
		}

		///<summary>
		/// Exception details
		///</summary>
		public string Details
		{
			get;
			set;
		}

	}
}