using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class GestorCliente
    {

        private MySqlConnection connection;
        private string stringDeConexion;



        private MySqlConnectionStringBuilder CadenaConexion()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "almacen";
            builder.SslMode = MySqlSslMode.None;
            return builder;
            // Server=Servidor;Database=Nombre_de_la_base_de_datos; Uid=Nombre_de_usuario

        }

      //  using (MySqlConnection con = new MySqlConnection(CadenaConexion().ToString()))



    }
}
