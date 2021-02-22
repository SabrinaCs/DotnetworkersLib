// ---------------------------------------------------------------
// DATI FILE SqlOperationalContext.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseDataSqlServer
// File....................: SqlOperationalContext.cs
// Namespace...............: Dnw.Base.Data.SqlServer.Entities
// Classi..................: public SqlOperationalContext : IBusinessContext, IDisposable
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 336
// Dimensione..............: 7,33 Kb
// Data Creazione..........: 13/05/2013 15:45:37
// Data ultima Modifica....: 05/06/2013 15:12:31
// ---------------------------------------------------------------

using System;
using System.Data;
using System.Data.SqlClient;

namespace Dnw.Base.Data.SqlServer.Entities
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	public class SqlOperationalContext : IBusinessContext, IDisposable
	{

		#region Fields

		/// <summary>
		/// The connection for the transaction
		/// </summary>
		private SqlConnection mConnection;

		/// <summary>
		/// Name of the context
		/// </summary>
		private string mContextName;

		/// <summary>
		/// Type of the context
		/// </summary>
		private string mContextType;

		/// <summary>
		/// Indicates wether this context is transactional
		/// </summary>
		private bool mIsTransactional;

		/// <summary>
		/// The transaction of this context 
		/// </summary>
		private SqlTransaction mTransaction;

		#endregion

		#region Public Methods





		/// <summary>
		/// Performs application-defined tasks associated with freeing, 
		/// releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			if (TransactionIsOpen)
			{
				mTransaction.Rollback();
			}
			if (mTransaction != null)
			{
				mTransaction.Dispose();
				mTransaction = null;
			}
			if (ConnectionIsOpen)
			{
				mConnection.Close();
			}
			if (mConnection != null)
			{
				mConnection.Dispose();
				mConnection = null;
			}
		}

		/// <summary>
		/// Opens the connection.
		/// </summary>
		/// <returns></returns>
		public SqlContextResult OpenConnection()
		{
			SqlContextResult isok = SqlContextResult.Ok;
			try
			{
				if (!ConnectionIsOpen)
				{
					mConnection.Open();
				}
				else
				{
					isok = SqlContextResult.ConnectionAlreadyOpened;
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				isok = SqlContextResult.ErrorOpeningConnection;
			}
			return (isok);
		}

		/// <summary>
		/// Closes the connection.
		/// </summary>
		/// <returns></returns>
		public SqlContextResult CloseConnection()
		{
			SqlContextResult isok = SqlContextResult.Ok;
			try
			{
				mConnection.Close();
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				isok = SqlContextResult.ConnectionCloseError;
			}
			return (isok);
		}

		/// <summary>
		/// Opens the transaction.
		/// </summary>
		/// <param name="isolationLevel">The isolation level.</param>
		/// <returns></returns>
		public SqlContextResult OpenTransaction(IsolationLevel isolationLevel = IsolationLevel.RepeatableRead)
		{
			SqlContextResult isok = SqlContextResult.Ok;

			if (mIsTransactional)
			{
				try
				{
					mConnection.Open();
					try
					{
						mTransaction = mConnection.BeginTransaction(isolationLevel, Guid.NewGuid().ToString().XDwLeft(32).ToString());
					}
					catch (Exception ex)
					{
						EventLogger.SendMsg(ex);
						isok = SqlContextResult.ErrorOpeningTransaction;
					}
				}
				catch (Exception ex)
				{
					EventLogger.SendMsg(ex);
					isok = SqlContextResult.ErrorOpeningConnection;
				}

			}
			else
			{
				isok = SqlContextResult.ContextNotTransactional;
			}
			return (isok);
		}

		/// <summary>
		/// Commits the transaction.
		/// </summary>
		public SqlContextResult CommitTransaction()
		{
			SqlContextResult isok = SqlContextResult.Ok;
			try
			{
				if (mTransaction != null)
				{
					this.mTransaction.Commit();
				}
				else
				{
					isok = SqlContextResult.NoTransactionToCommit;
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				isok = SqlContextResult.CommitTransactionError;
			}
			finally
			{
				mTransaction.Dispose();
				mTransaction = null;
				mConnection.Close();
			}
			return (isok);
		}

		/// <summary>
		/// Rollbacks the transaction.
		/// </summary>
		public SqlContextResult RollbackTransaction()
		{
			SqlContextResult isok = SqlContextResult.Ok;
			try
			{
				if (mTransaction != null)
				{
					mTransaction.Rollback();
				}
				else
				{
					isok = SqlContextResult.NoTransactionToRollback;
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				isok = SqlContextResult.TransactionRollbackError;
			}
			finally
			{
				mTransaction.Dispose();
				mTransaction = null;
				mConnection.Close();

			}
			return (isok);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SqlOperationalContext" /> class.
		/// </summary>
		/// <param name="contextName">Name of the context.</param>
		/// <param name="isTransactional">if set to <c>true</c> [is transactional].</param>
		/// <param name="connectionString">The connection string.</param>
		public SqlOperationalContext(string contextName, bool isTransactional, string connectionString)
		{
			mContextName = contextName;
			mContextType = "SQLOC";
			mIsTransactional = isTransactional;
			mConnection = new SqlConnection(connectionString);
		}

		#endregion

		/// <summary>
		/// Gets a value indicating whether [transaction is opened].
		/// </summary>
		/// <value>
		/// <c>true</c> if [transaction is opened]; otherwise, <c>false</c>.
		/// </value>
		public bool TransactionIsOpen
		{
			get
			{
				return (Transaction != null);
			}
		}

		/// <summary>
		/// Gets a value indicating whether [connection is opened].
		/// </summary>
		/// <value>
		///   <c>true</c> if [connection is opened]; otherwise, <c>false</c>.
		/// </value>
		public bool ConnectionIsOpen
		{
			get
			{
				return (Connection.State == ConnectionState.Open);
			}
		}

		/// <summary>
		/// Gets the connection.
		/// </summary>
		/// <value>
		/// The connection.
		/// </value>
		public SqlConnection Connection
		{
			get
			{
				return (mConnection);
			}
		}

		/// <summary>
		/// Gets the transaction.
		/// </summary>
		/// <value>
		/// The transaction.
		/// </value>
		public SqlTransaction Transaction
		{
			get
			{
				return (mTransaction);
			}
		}

		/// <summary>
		/// Gets the type of the context.
		/// </summary>
		/// <value>
		/// The type of the context.
		/// </value>
		public string ContextType
		{
			get
			{
				return (mContextType);
			}
		}

		/// <summary>
		/// Gets the name of the context.
		/// </summary>
		/// <value>
		/// The name of the context.
		/// </value>
		public string ContextName
		{
			get
			{
				return (mContextName);
			}
		}

		/// <summary>
		/// Indicates wether this context is transactional
		/// </summary>
		///<remarks>
		///</remarks>
		public bool IsTransactional
		{
			get
			{
				return mIsTransactional;
			}

		}

	}
}