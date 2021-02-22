// ---------------------------------------------------------------
// DATI FILE SqlConstants.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseDataSqlServer
// File....................: SqlConstants.cs
// Namespace...............: Dnw.Base.Data.SqlServer
// Classi..................: public SqlConstants
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 37
// Dimensione..............: 2,13 Kb
// Data Creazione..........: 17/04/2013 16:05:50
// Data ultima Modifica....: 23/04/2013 12:45:27
// ---------------------------------------------------------------





namespace Dnw.Base.Data.SqlServer
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	public class SqlConstants
	{

		/// <summary>
		/// Format provider connessione SQL Server non trusted
		/// </summary>
		public const string FMP_SQL_Connection = "data source={0};persist security info=True;initial catalog={1};user id={2};password={3};";

		/// <summary>
		/// Format provider connessione SQL Server non trusted con timeout
		/// </summary>
		public const string FMP_SQL_ConnectionTimeouted = "data source={0};persist security info=True;initial catalog={1};user id={2};password={3};connection timeout={4};";

		/// <summary>
		/// Format provider connessione SQL Server trusted
		/// </summary>
		public const string FMP_SQL_ConnectionTrusted = "integrated security=SSPI;data source={0};initial catalog={1};";

		/// <summary>
		/// Format provider connessione SQL Server trusted con timeout
		/// </summary>
		public const string FMP_SQL_ConnectionTrustedTimeouted = "integrated security=SSPI;data source={0};initial catalog={1};connection timeout={2};";



	}
}