using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");

        //Clave por defecto a utlizar para la cadena de conexion
        const string consKeyDefaultCnnString = "ConnStringLocalHost";

        protected SqlConnection _SqlConn;
        public SqlConnection SqlConn
        {
            get { return _SqlConn; }
            set { _SqlConn = value; }
        }

        protected void OpenConnection()
        {
           string conStr = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
           SqlConn = new SqlConnection(conStr);
           SqlConn.Open();
        }

        protected void CloseConnection()
        {
            SqlConn.Close();
            SqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
