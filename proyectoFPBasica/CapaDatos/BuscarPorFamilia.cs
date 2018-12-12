using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class BuscarPorFamilia
    {

        /// <summary>
        /// Método para añadir una Empresa. Si todo sale bien devuelve un String "vacio"... Si no, mostrará un mensaje de error.
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns></returns>
        public string Buscar(string nombre)
        {
            MySqlConnectionStringBuilder builder = this.StringConexion();
            using (MySqlConnection conexion = new MySqlConnection(builder.ToString()))
            {
                try
                {
                    conexion.Open();
                    string sqlBuscarIdFamilia = "SELECT IdFamilia From Familia WHERE Nombre = @Nombre";
                    MySqlCommand cmdBuscarIdFamilia = new MySqlCommand(sqlBuscarIdFamilia, conexion);
                    cmdBuscarIdFamilia.Parameters.AddWithValue("@Nombre", nombre);
                    MySqlDataReader drBuscarIdFamilia = cmdBuscarIdFamilia.ExecuteReader();

                    if (!drBuscarIdFamilia.Read()) return "No se ha podido encontrar la familia...";
                }
                catch (Exception e)
                {
                    this.guardarMensajeError(e);
                }
            }
            return "";
        }

        private MySqlConnectionStringBuilder StringConexion()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.UserID = "root";
            builder.Server = "localhost";
            builder.Password = "";
            builder.Database = "almacenespela";
            return builder;
        }

        private void guardarMensajeError(Exception ex)
        {
            using (StreamWriter sw = new StreamWriter("error.log", true))
            {
                sw.WriteLine(ex.Message);
            }
        }

    }
}
