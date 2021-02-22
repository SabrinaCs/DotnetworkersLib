// ---------------------------------------------------------------
// DATI FILE DpCore.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseDataSqlServer
// File....................: DpCore.cs
// Namespace...............: Dnw.Base.Data.SqlServer.DataProviders
// Classi..................: public abstract DpCore<T> where T : class
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 132
// Dimensione..............: 3,56 Kb
// Data Creazione..........: 13/05/2013 15:45:36
// Data ultima Modifica....: 11/09/2013 10:47:04
// ---------------------------------------------------------------

using Dnw.Base.Data.SqlServer.Entities;
using System.Collections.Generic;
using System.Data;



namespace Dnw.Base.Data.SqlServer.DataProviders
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	public abstract class DpCore<T> where T : class
	{

		/// <summary>
		/// Sql Insert string
		/// </summary>
		protected static string Sql_Insert;
		/// <summary>
		/// Sql delete string
		/// </summary>
		protected static string Sql_Delete;
		/// <summary>
		/// Sql Update string
		/// </summary>
		protected static string Sql_Update;
		/// <summary>
		/// Sql select all string
		/// </summary>
		protected static string Sql_SelectAll;

		/// <summary>
		/// Generates an entity from a datarow
		/// </summary>
		/// <param name="row">The row.</param>
		/// <returns></returns>
		protected abstract T FromDataRow(DataRow row);


		/// <summary>
		/// Method to get all content of a table
		/// </summary>
		/// <returns></returns>
		public abstract List<T> GetAll();

		/// <summary>
		/// Inserts one row in the database.
		/// </summary>
		/// <param name="item">The item.</param>
		public abstract void InsertRow(T item);
		/// <summary>
		/// Updates one row in the database.
		/// </summary>
		/// <param name="item">The item.</param>
		public abstract void UpdateRow(T item);
		/// <summary>
		/// Deletes one row in the database.
		/// </summary>
		/// <param name="item">The item.</param>
		public abstract void DeleteRow(T item);

		///// <summary>
		///// The Sql Data context for the Data provider
		///// </summary>
		//private SqlContext mContext;

		///// <summary>
		///// The Sql Data context for the Data provider
		///// </summary>
		/////<remarks>
		/////</remarks>
		//public SqlContext Context
		//{
		//	get
		//	{
		//		return mContext;
		//	}
		//	protected set
		//	{
		//		mContext = value;
		//	}
		//}

		/// <summary>
		/// Connection string
		/// </summary>
		private string mCnString;

		/// <summary>
		/// Connection string
		/// </summary>
		///<remarks>
		///</remarks>
		public string CnString
		{
			get
			{
				return mCnString;
			}
			set
			{
				mCnString = value;
			}
		}




		/// <summary>
		/// Initializes a new instance of the <see cref="DpCore{T}"/> class.
		/// </summary>
		/// <param name="cnString">The cn string.</param>
		public DpCore(string cnString)
		{
			CnString = cnString;
		}


		/// <summary>
		/// Inserts a collection of rows in the database.
		/// </summary>
		/// <param name="items">The items.</param>
		public virtual void InsertRows(List<T> items)
		{
			foreach (T item in items)
			{
				InsertRow(item);
			}
		}

		/// <summary>
		/// Updates a collection of rows in the database.
		/// </summary>
		/// <param name="items">The items.</param>
		public virtual void UpdateRows(List<T> items)
		{
			foreach (T item in items)
			{
				UpdateRow(item);
			}
		}

		/// <summary>
		/// Deletes a collection of rows in the database.
		/// </summary>
		/// <param name="items">The items.</param>
		public virtual void DeleteRows(List<T> items)
		{
			foreach (T item in items)
			{
				DeleteRow(item);
			}
		}
	}
}