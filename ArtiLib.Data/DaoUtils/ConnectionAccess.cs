using System.Data;
using System.Data.SqlClient;

namespace ArtiLib.Data.DaoUtils
{
    public abstract class ConnectionAccess
    {
        private static readonly string ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=ArtiLib;Integrated Security=True;";
        public IDbConnection Connection = new SqlConnection(ConnectionString);

        public void ChangeConnection(string connectionString)
        {
            if (Connection == null)
            {
                Connection = new SqlConnection(connectionString);
            }
            else
            {
                Connection.ConnectionString = connectionString;
            }
        }

        public void OpenConnection()
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();
        }

        public void CloseConnection()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}