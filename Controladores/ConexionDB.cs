using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication7.Controladores
{
    public class ConexionDB
    {
        private static string connectionStrings = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConexionDB"/> class.
        /// Logic.
        /// </summary>
        public ConexionDB()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConexionDB"/> class.
        /// Logic.
        /// </summary>
        /// <param name="connectionString">connectionString.</param>
        public ConexionDB(string connectionString)
        {
            connectionStrings = connectionString;
        }

        /// <summary>
        /// GetDataTable.
        /// </summary>
        /// <param name="connectionString">connectionString.</param>
        public void SetConnectionString(string connectionString)
        {
            ConexionDB.connectionStrings = connectionString;
        }

        /// <summary>
        /// GetDataTable.
        /// </summary>
        /// <param name="query">query.</param>
        /// <returns>DataTable.</returns>
        public DataTable GetCustomSelectQuery(string query)
        {
            DataTable dt = new DataTable();
            string connString = connectionStrings;

            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = query;
                    cmd.CommandTimeout = 300;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {

                        con.Open();
                        cmd.ExecuteNonQuery();
                        da.Fill(dt);
                        con.Close();
                    }
                    cmd.Parameters.Clear();
                }
            }
            return dt;
        }
        public DataTable GetCustomABMQuery(string query)
        {
            DataTable dt = new DataTable();
            string connString = connectionStrings;

            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = query;
                    cmd.CommandTimeout = 300;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {

                        con.Open();
                        da.Fill(dt);
                        con.Close();
                    }
                    cmd.Parameters.Clear();
                }
            }
            return dt;
        }
    }
}