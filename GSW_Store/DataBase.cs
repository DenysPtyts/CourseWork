using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

namespace GSW_Store
{
    internal class DataBase
    {

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DENYS\SQLEXPRESS;Initial Catalog=GSW_Store;Integrated Security=True");

        public void openConnection()
        {
            Console;
            //dfffdsfdfggtrggdd
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getSqlConnection()
        {
            return sqlConnection;
        }
    }
}
