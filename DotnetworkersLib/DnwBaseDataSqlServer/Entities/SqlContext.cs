//// ---------------------------------------------------------------
//// DATI FILE SqlContext.cs
//// ---------------------------------------------------------------
//// Soluzione...............: DnwLibraries
//// Progetto................: DnwBaseDataSqlServer
//// File....................: SqlContext.cs
//// Namespace...............: Dnw.Base.Data.SqlServer.Entities
//// Classi..................: public SqlContext : IBusinessContext
//// Interfacce..............:
//// Enumerazioni............:
//// Linee di codice.........: 356
//// Dimensione..............: 7,91 Kb
//// Data Creazione..........: 13/05/2013 15:45:37
//// Data ultima Modifica....: 11/09/2013 10:11:28
//// ---------------------------------------------------------------


//using System;
//using System.Data;
//using System.Data.SqlClient;
//namespace Dnw.Base.Data.SqlServer.Entities
//{
//	///<summary>
//	/// Descrizione della classe: 
//	///</summary>
//	public class SqlContext : IBusinessContext
//	{

//		///<summary>
//		/// Costruttore
//		///</summary>
//		public SqlContext(string contextName,
//			string connectionString,
//			bool supportTransaction,
//			int commandTimeout = -1)
//		{
//			ContextName = contextName;
//			CnString = connectionString;
//			SupportTransaction = supportTransaction;
//			CommandTimeout = commandTimeout;
//		}


//		/// <summary>
//		/// Context name
//		/// </summary>
//		private string mContextName;

//		/// <summary>
//		/// Context name
//		/// </summary>
//		///<remarks>
//		///</remarks>
//		public string ContextName
//		{
//			get
//			{
//				return mContextName;
//			}
//			private set
//			{
//				mContextName = value;
//			}
//		}


//		/// <summary>
//		///  Context Type
//		/// </summary>
//		public string ContextType
//		{
//			get
//			{
//				return "SQL";
//			}
//		}

//		/// <summary>
//		/// Connection String
//		/// </summary>
//		private string mCnString;

//		/// <summary>
//		/// Connection String
//		/// </summary>
//		///<remarks>
//		///</remarks>
//		public string CnString
//		{
//			get
//			{
//				return mCnString;
//			}
//			private set
//			{
//				mCnString = value;
//			}
//		}

//		/// <summary>
//		/// Connection, can be used to make multiple operations on a single open connection
//		/// </summary>
//		private SqlConnection mConnection;

//		/// <summary>
//		/// Connection, can be used to make multiple operations on a single open connection
//		/// </summary>
//		///<remarks>
//		///</remarks>
//		public SqlConnection Connection
//		{
//			get
//			{
//				return mConnection;
//			}
//			private set
//			{
//				mConnection = value;
//			}
//		}

//		/// <summary>
//		/// Transaction for use with transactional operations on database
//		/// </summary>
//		private SqlTransaction mTransaction;

//		/// <summary>
//		/// Transaction for use with transactional operations on database
//		/// </summary>
//		///<remarks>
//		///</remarks>
//		public SqlTransaction Transaction
//		{
//			get
//			{
//				return mTransaction;
//			}
//			private set
//			{
//				mTransaction = value;
//			}
//		}


//		/// <summary>
//		///  Indicates wether there is a transaction open on this context
//		/// </summary>
//		public bool HasTransaction
//		{
//			get
//			{
//				return this.Transaction != null;
//			}
//		}

//		/// <summary>
//		/// Indicates wether this context supports transactions or not
//		/// </summary>
//		private bool mSupportTransaction;

//		/// <summary>
//		/// Indicates wether this context supports transactions or not
//		/// </summary>
//		///<remarks>
//		///</remarks>
//		public bool SupportTransaction
//		{
//			get
//			{
//				return mSupportTransaction;
//			}
//			private set
//			{
//				mSupportTransaction = value;
//			}
//		}

//		/// <summary>
//		/// Command timeout
//		/// </summary>
//		private int mCommandTimeout;

//		/// <summary>
//		/// Command timeout
//		/// </summary>
//		///<remarks>
//		///</remarks>
//		public int CommandTimeout
//		{
//			get
//			{
//				return mCommandTimeout;
//			}
//			set
//			{
//				mCommandTimeout = value;
//			}
//		}

//		/// <summary>
//		/// Clones this instance changing the transactional mode if necessary
//		/// </summary>
//		/// <param name="cloneSupportsTransaction">indicates wether the clone has to support transactions or not</param>
//		/// <returns>a clone of this context</returns>
//		public SqlContext Clone(bool? cloneSupportsTransaction = null)
//		{
//			bool supportTransaction = this.SupportTransaction;
//			if (cloneSupportsTransaction.HasValue)
//			{
//				supportTransaction = cloneSupportsTransaction.Value;
//			}
//			SqlContext cloned = new SqlContext(
//				this.ContextName, this.CnString, supportTransaction, this.CommandTimeout);
//			return (cloned);
//		}

//		/// <summary>
//		/// Opens A connection and a transaction on the connection for the current context
//		/// </summary>
//		/// <param name="pTransactionName">Name of the transaction.</param>
//		/// <param name="pIsolationLevel">Transaction isolation level.</param>
//		/// <returns></returns>
//		public Result<bool> OpenTransaction(string pTransactionName, IsolationLevel pIsolationLevel = IsolationLevel.RepeatableRead)
//		{
//			Result<bool> creata = Result.Get<bool>();
//			creata.Data = false;
//			try
//			{
//				if ((SupportTransaction) && (!HasTransaction))
//				{
//					if (Connection == null)
//					{
//						Connection = new SqlConnection(CnString);
//						Connection.Open();
//					}

//					string trName = (pTransactionName.XDwIsNullOrTrimEmpty() ? Guid.NewGuid().ToString() : pTransactionName).XDwLeft(30);
//					Transaction = Connection.BeginTransaction(pIsolationLevel, trName);
//					if (Transaction.Connection == null)
//					{
//						creata.SetError("TR", "Unable to create transaction. Connection is null");
//					}
//					else
//					{
//						creata.Data = true;
//					}
//				}
//			}
//			catch (SqlException sx)
//			{
//				EventLogger.SendMsg(sx);
//				creata.SetError(sx);
//			}
//			catch (Exception ex)
//			{
//				EventLogger.SendMsg(ex);
//				creata.SetError(ex);
//			}
//			finally
//			{
//				if (!creata.Data)
//				{
//					if (Transaction != null)
//					{
//						Transaction.Rollback();
//					}
//					if ((Connection != null) && (Connection.State != System.Data.ConnectionState.Closed))
//					{
//						Connection.Close();
//					}
//					Connection = null;
//					Transaction = null;
//				}
//			}
//			return (creata);
//		}

//		/// <summary>
//		/// Commits the current transaction if exists
//		/// </summary>
//		/// <param name="pAutoRollbackOnError">if set to <c>true</c> [application automatic rollback configuration error].</param>
//		/// <returns></returns>
//		public Result<bool> CommitTransaction(bool pAutoRollbackOnError)
//		{
//			Result<bool> ok = Result.Get<bool>();
//			ok.Data = false;

//			try
//			{
//				if (HasTransaction)
//				{
//					Transaction.Commit();
//					ok.Data = true;
//				}
//			}
//			catch (SqlException sx)
//			{
//				EventLogger.SendMsg(sx);
//				if (pAutoRollbackOnError)
//				{
//					RollbackTransaction();
//				}
//				ok.SetError(sx);
//			}
//			catch (Exception ex)
//			{
//				EventLogger.SendMsg(ex);
//				if (pAutoRollbackOnError)
//				{
//					RollbackTransaction();
//				}
//				ok.SetError(ex);
//			}
//			finally
//			{
//				if ((ok.Data) || (pAutoRollbackOnError))
//				{
//					Transaction = null;
//					if ((Connection != null) && (Connection.State != System.Data.ConnectionState.Closed))
//					{
//						Connection.Close();
//					}
//					Connection = null;
//				}
//			}
//			return (ok);
//		}

//		/// <summary>
//		/// Rollbacks the current open transaction.
//		/// </summary>
//		/// <returns></returns>
//		public Result<bool> RollbackTransaction()
//		{
//			Result<bool> ok = Result.Get<bool>();
//			ok.Data = false;

//			try
//			{
//				if (HasTransaction)
//				{
//					Transaction.Rollback();
//					ok.Data = true;
//				}
//			}
//			catch (SqlException sx)
//			{
//				EventLogger.SendMsg(sx);
//				ok.SetError(sx);
//			}
//			catch (Exception ex)
//			{
//				EventLogger.SendMsg(ex);
//				ok.SetError(ex);
//			}
//			finally
//			{
//				Transaction = null;
//				if ((Connection != null) && (Connection.State != System.Data.ConnectionState.Closed))
//				{
//					Connection.Close();
//				}
//				Connection = null;
//			}
//			return (ok);
//		}



//	}
//}