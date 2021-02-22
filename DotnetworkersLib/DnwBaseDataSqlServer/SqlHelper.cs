// ---------------------------------------------------------------
// DATI FILE SqlHelper.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBaseDataSqlServer
// File....................: SqlHelper.cs
// Namespace...............: Dnw.Base.Data.SqlServer
// Classi..................: public static SqlHelper
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 114
// Dimensione..............: 3,53 Kb
// Data Creazione..........: 17/06/2013 13:27:59
// Data ultima Modifica....: 11/09/2013 11:24:53
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Dnw.Base.Data.SqlServer.Entities;



namespace Dnw.Base.Data.SqlServer
{
	///<summary>
	/// Execution helper for sql server common queries.
	///</summary>
	public static class SqlHelper
	{

		/// <summary>
		/// Executes a query that does not return a result
		/// typically the insert, update and delete or the
		/// alter database queries are this kind of query
		/// </summary>
		/// <param name="cnString">The connection string.</param>
		/// <param name="sqlCommand">The SQL command.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <param name="commandTimeout">The command timeout.</param>
		/// <returns></returns>
		public static int ExecuteNonQuery( 
			string cnString, 
			string sqlCommand, 
			CommandType commandType = CommandType.Text,
			SqlParameter[] sqlParameters =null, 
			int commandTimeout = -1)
		{
			int ret = -1;
			using (SqlConnection cn = 
				new SqlConnection(cnString))
			{
				cn.Open();
				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.Connection = cn;
					cmd.CommandText = sqlCommand;
					cmd.CommandType = commandType;
					if (sqlParameters != null)
					{
						cmd.Parameters.AddRange(sqlParameters);
					}
					if (commandTimeout != -1)
					{
						cmd.CommandTimeout = commandTimeout;
					}
					ret = cmd.ExecuteNonQuery();
				}
				cn.Close();
			}
			return ret;
		}

		/// <summary>
		/// Executes a query returning a datatable as the result
		/// </summary>
		/// <param name="cnString">The connection string.</param>
		/// <param name="sqlCommand">The SQL command.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <param name="commandTimeout">The command timeout.</param>
		/// <returns>
		/// A datatable containing the data read or null
		/// </returns>
		public static DataTable ExecuteDataTable(
			string cnString,
			string sqlCommand,
			CommandType commandType = CommandType.Text,
			SqlParameter[] sqlParameters = null,
			int commandTimeout = -1)
		{
			DataTable ret = null;
			using (SqlConnection cn =
				new SqlConnection(cnString))
			{
				cn.Open();
				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.Connection = cn;
					cmd.CommandText = sqlCommand;
					cmd.CommandType = commandType;
					if (sqlParameters != null)
					{
						cmd.Parameters.AddRange(sqlParameters);
					}
					if (commandTimeout != -1)
					{
						cmd.CommandTimeout = commandTimeout;
					}
					using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (dr.HasRows)
						{
							ret = new DataTable();
							ret.Load(dr);
						}
						dr.Close();
					}
				}
				cn.Close();
			}
			return ret;
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <typeparam name="T">A generic return type for the value retrieved</typeparam>
		/// <param name="cnString">The connection string.</param>
		/// <param name="sqlCommand">The SQL command.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <param name="commandTimeout">The command timeout.</param>
		/// <returns></returns>
		public static T ExecuteScalar<T>(
			string cnString,
			string sqlCommand,
			CommandType commandType = CommandType.Text,
			SqlParameter[] sqlParameters = null,
			int commandTimeout = -1)
		{
			object ret = null;
			using (SqlConnection cn =
				new SqlConnection(cnString))
			{
				cn.Open();
				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.Connection = cn;
					cmd.CommandText = sqlCommand;
					cmd.CommandType = commandType;
					if (sqlParameters != null)
					{
						cmd.Parameters.AddRange(sqlParameters);
					}
					if (commandTimeout != -1)
					{
						cmd.CommandTimeout = commandTimeout;
					}
					ret = cmd.ExecuteScalar();
				}
				cn.Close();
			}
			if (ret != null)
			{
				return (T)ret;
			}
			return default(T);
		}


	}
}