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
    public class GestorEmpresa
    {

        /// <summary>
        /// Método para añadir una Empresa. Si todo sale bien devuelve un String "vacio". Si no, mostrará un mensaje de error.
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns></returns>
        public String DarAltaUsuario(Empresa empresa)
        {
            MySqlConnectionStringBuilder builder = this.StringConexion();
            using (MySqlConnection conexion = new MySqlConnection(builder.ToString()))
            {
                try
                {
                    conexion.Open();
                    string sqlInsertEmpresa = "INSERT INTO empresa (Nif,Nombre,Direccion,Logo) VALUES(@Nif,@Nombre,@Direccion,@Logo)";
                    MySqlCommand cmdInsertEmpresa = new MySqlCommand(sqlInsertEmpresa, conexion);
                    cmdInsertEmpresa.Parameters.AddWithValue("@Nif", empresa.Nif);
                    cmdInsertEmpresa.Parameters.AddWithValue("@Nombre", empresa.Nombre);
                    cmdInsertEmpresa.Parameters.AddWithValue("@Direccion", empresa.Direccion);
                    cmdInsertEmpresa.Parameters.AddWithValue("@Logo", empresa.Logo);
                    int resultado = cmdInsertEmpresa.ExecuteNonQuery();
                    if (resultado == 0) return "No se ha podido añadir la empresa...";
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
