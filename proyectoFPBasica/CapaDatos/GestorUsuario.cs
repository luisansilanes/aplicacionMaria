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
                    string sqlInsertUsuario = "INSERT INTO usuario (Password,Nombre,Foto) VALUES(@Password,@Nombre,@Foto)";
                    MySqlCommand cmdInsertUsuario = new MySqlCommand(sqlInsertUsuario,conexion);
                    cmdInsertUsuario.Parameters.AddWithValue("@Password", usuario.Password);
                    cmdInsertUsuario.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmdInsertUsuario.Parameters.AddWithValue("@Foto", usuario.Foto);
                    int resultado = cmdInsertUsuario.ExecuteNonQuery();
                    if (resultado == 0) return "No se ha podido insertar el usuario";
                } catch(Exception e)
                {
                    this.guardarMensajeError(e);
                    return "error consulte administración.";
                }
            }
                return "";
        }

        /// <summary>
        /// Método que recibe un idUsuario del usuario a Borrar. Si sale bien devuelve un String "vacio". Si no, devolverá un mensaje de error.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public String BorrarUsuario(int idUsuario)
        {
            MySqlConnectionStringBuilder builder = this.StringConexion();
            using (MySqlConnection conexion = new MySqlConnection(builder.ToString()))
            {
                try {
                    string sqlBorrar = "DELETE FROM usuario WHERE idUsuario=@idUsuario";
                    MySqlCommand cmdBorrar = new MySqlCommand(sqlBorrar, conexion);
                    cmdBorrar.Parameters.AddWithValue("@idUsuario",idUsuario);
                    int resultado = cmdBorrar.ExecuteNonQuery();
                    if (resultado == 0) return "No se ha podido borrar el usuario";
                }
                catch(Exception e)
                {
                    this.guardarMensajeError(e);
                    return "error consulte administración.";
                }
            }
                return "";
        }
        /// <summary>
        /// Recibe el idUsuario del usuario a modificar, el nuevoNombre. Si sale bien devuelve un String "vacio". Si no, devolverá un mensaje de error.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="nuevoNombre"></param>
        /// <returns></returns>
        public String ActualizarNombreUsuario(int idUsuario,string nuevoNombre)
        {
            MySqlConnectionStringBuilder builder = this.StringConexion();
            using (MySqlConnection conexion = new MySqlConnection(builder.ToString()))
            {
                try {
                    string sqlActualizar = "UPDATE usuario SET Nombre=@Nombre WHERE idUsuario=@idUsuario";
                    MySqlCommand cmdActualizar = new MySqlCommand(sqlActualizar, conexion);
                    cmdActualizar.Parameters.AddWithValue("@Nombre", nuevoNombre);
                    cmdActualizar.Parameters.AddWithValue("@idUsuario", idUsuario);
                    int resultado = cmdActualizar.ExecuteNonQuery();
                    if (resultado == 0) return "No se ha podido actualizar el nombre del usuario";
                } catch (Exception e)
                {
                    this.guardarMensajeError(e);
                    return "error consulte administración.";
                }
            }
            return "";
        }
        /// <summary>
        /// Recibe el idUsuario del usuario a modificar, la nuevaFoto. Si sale bien devuelve un String "vacio". Si no, devolverá un mensaje de error.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="nuevaFoto"></param>
        /// <returns></returns>
        public String ActualizarFotoUsuario(int idUsuario,string nuevaFoto)
        {
            //AHORA QUE ME VIENE A LA CABEZA, PREGUNTAR DONDE LECHES ESTARÁN LAS FOTOS. Y SI TENEMOS QUE GUARDAR EN EL CAMPO FOTO LA RUTA ENTERA
            MySqlConnectionStringBuilder builder = this.StringConexion();
            using (MySqlConnection conexion = new MySqlConnection(builder.ToString()))
            {
                try
                {
                    string sqlActualizar = "UPDATE usuario SET Foto=@Foto WHERE idUsuario=@idUsuario";
                    MySqlCommand cmdActualizar = new MySqlCommand(sqlActualizar, conexion);
                    cmdActualizar.Parameters.AddWithValue("@Foto", nuevaFoto);
                    cmdActualizar.Parameters.AddWithValue("@idUsuario", idUsuario);
                    int resultado = cmdActualizar.ExecuteNonQuery();
                    if (resultado == 0) return "No se ha podido actualizar la foto del usuario";
                }
                catch (Exception e)
                {
                    this.guardarMensajeError(e);
                    return "error consulte administración.";
                }
            }
            return "";
        }

        //PREGUNTAR SI ESTO SOLO LO HACE EL ADMIN BUENO ESTO Y CASI TODOS LOS METODOS DE ESTE GESTOR
        /// <summary>
        /// Recibe el idUsuario del usuario y la nueva contraseña.Si sale bien devuelve un String "vacio". Si no, devolverá un mensaje de error.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="nuevaContrasena"></param>
        /// <returns></returns>
        public String CambiarContrasena(int idUsuario,String nuevaContrasena)
        {
            MySqlConnectionStringBuilder builder = this.StringConexion();
            using (MySqlConnection conexion = new MySqlConnection(builder.ToString()))
            {
                string sqlContrasena = "UPDATE usuario SET Password=@Password WHERE idUsuario=@idUsuario";
                MySqlCommand cmdContrasena = new MySqlCommand(sqlContrasena, conexion);
                cmdContrasena.Parameters.AddWithValue("@Password", nuevaContrasena);
                cmdContrasena.Parameters.AddWithValue("@idUsuario", idUsuario);
            }

                return "";
        }
        /// <summary>
        /// Devuelve una lista de Usuarios con todos los usuarios de la base de datos.
        /// </summary>
        /// <returns></returns>
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
                    return null;
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
