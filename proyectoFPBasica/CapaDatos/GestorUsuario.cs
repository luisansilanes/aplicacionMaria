using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class GestorUsuario
    {
    

        public GestorUsuario()
        {
        }

        /// <summary>
        /// Método para dar de alta un Usuario. Si todo sale bien devuelve un String "vacio". Si no, mostrará un mensaje de error.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public String DarAltaUsuario(Usuario usuario)
        {
            MySqlConnectionStringBuilder builder = this.StringConexion();
            using (MySqlConnection conexion= new MySqlConnection(builder.ToString()))
            {
                try
                {
                    conexion.Open();
                    string sqlInsertUsuario = "INSERT INTO usuario VALUES(Password,Nombre,Foto) VALUES(@Password,@Nombre,@Foto)";
                    MySqlCommand cmdInsertUsuario = new MySqlCommand(sqlInsertUsuario,conexion);
                    cmdInsertUsuario.Parameters.AddWithValue("@Password", usuario.Password);
                    cmdInsertUsuario.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmdInsertUsuario.Parameters.AddWithValue("@Foto", usuario.Foto);
                    int resultado = cmdInsertUsuario.ExecuteNonQuery();
                    if (resultado == 0) return "No se ha podido insertar el usuario";
                } catch(Exception e)
                {
                    this.guardarMensajeError(e);
                }
            }
                return "";
        }
        public List<Usuario> ListaUsuarios()
        {
            MySqlConnectionStringBuilder builder = this.StringConexion();
            List<Usuario> listaDevuelta = new List<Usuario>();

            using (MySqlConnection conexion = new MySqlConnection(builder.ToString()))
            {
                try
                {
                    conexion.Open();
                    string sqlDevolver = "SELECT * FROM usuario";
                    MySqlCommand cmdDevolver = new MySqlCommand(sqlDevolver, conexion);
                    MySqlDataReader lector = cmdDevolver.ExecuteReader();
                    while (lector.Read())
                    {
                        Usuario auxUser = new Usuario(lector.GetInt32(0), lector.GetString(1), lector.GetString(2), lector.GetString(3));
                        listaDevuelta.Add(auxUser);
                    }
                } catch(Exception e)
                {
                    this.guardarMensajeError(e);
                }
            }

                return listaDevuelta;
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
