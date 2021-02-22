// ---------------------------------------------------------------
// DATI FILE SqlErrorCodes.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseDataSqlServer
// File....................: SqlErrorCodes.cs
// Namespace...............: Dnw.Base.Data.SqlServer
// Classi..................: public SqlErrorCodes
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 21
// Dimensione..............: 1,44 Kb
// Data Creazione..........: 25/06/2013 17:05:32
// Data ultima Modifica....: 25/06/2013 17:07:13
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;



namespace Dnw.Base.Data.SqlServer
{
	///<summary>
	/// Contains a list of arbitrary error codes to be used with the
	/// BaseError to give informations to the managers about low level errors
	///</summary>
	public class SqlErrorCodes
	{
		/// <summary>
		/// The sqlins 0001
		/// </summary>
		public readonly static string SQLINS_0001 = "SQLINS_0001";

	}
}