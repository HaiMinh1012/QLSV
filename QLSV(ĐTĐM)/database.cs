using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLSV_ĐTĐM_
{
    internal class database
    {
        private static string connectionString = @"Data Source = ADMIN-PC;Initial Catalog=QLSV;Integrated Security=True";
        private static SqlConnection connection;
        public static DataTable Query(string sql)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql,connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            return table;
        }
        public static void Execute (string sql)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sql,connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
