using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    class GestorFamilia
    {
        private MySqlConnectionStringBuilder StringConexion()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.UserID = "root";
            builder.Server = "localhost";
            builder.Password = "";
            builder.Database = "almacenespela";
            return builder;
        }


        public string CrearFamilia(Familia familia)
        {
            MySqlConnectionStringBuilder builder = this.StringConexion();
            using (MySqlConnection conexion = new MySqlConnection(builder.ToString()))
            {
                try
                {
                    conexion.Open();
                    string sqlInsertarFamilia = "INSERT INTO familia (IdFamilia, Nombre, Descripcion) VALUES (@IdFamilia, @Nombre, @Descripcion)";
                    MySqlCommand cmdInsertFamilia = new MySqlCommand(sqlInsertarFamilia, conexion);
                    cmdInsertFamilia.Parameters.AddWithValue("@IdFamilia", familia.IdFamilia);
                    cmdInsertFamilia.Parameters.AddWithValue("@Nombre", familia.Nombre);

                }
                catch(Exception e)
                {

                }
            }
                return "";
        }
    }
}
