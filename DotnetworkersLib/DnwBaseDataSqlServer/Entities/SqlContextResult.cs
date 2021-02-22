// ---------------------------------------------------------------
// DATI FILE SqlContextResult.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseDataSqlServer
// File....................: SqlContextResult.cs
// Namespace...............: Dnw.Base.Data.SqlServer.Entities
// Classi..................:
// Interfacce..............:
// Enumerazioni............: public SqlContextResult
// Linee di codice.........: 64
// Dimensione..............: 2 Kb
// Data Creazione..........: 23/04/2013 14:02:25
// Data ultima Modifica....: 23/04/2013 16:15:58
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;



namespace Dnw.Base.Data.SqlServer.Entities
{
	/// <summary>
	/// Result of operational context operations
	/// </summary>
	public enum SqlContextResult
	{
		/// <summary>
		/// The ok
		/// </summary>
		Ok,
		/// <summary>
		/// The connection already opened
		/// </summary>
		ConnectionAlreadyOpened,
		/// <summary>
		/// The transaction already opened
		/// </summary>
		TransactionAlreadyOpened,
		/// <summary>
		/// The context not transactional
		/// </summary>
		ContextNotTransactional,
		/// <summary>
		/// The error opening connection
		/// </summary>
		ErrorOpeningConnection,
		/// <summary>
		/// The error opening transaction
		/// </summary>
		ErrorOpeningTransaction,
		/// <summary>
		/// The no transaction to rollback
		/// </summary>
		NoTransactionToRollback,
		/// <summary>
		/// The transaction rollback error
		/// </summary>
		TransactionRollbackError,
		/// <summary>
		/// The commit transaction error
		/// </summary>
		CommitTransactionError,
		/// <summary>
		/// The no transaction to commit
		/// </summary>
		NoTransactionToCommit,
		/// <summary>
		/// The connection close error
		/// </summary>
		ConnectionCloseError


	}
}