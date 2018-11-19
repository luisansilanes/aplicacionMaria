using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario : IEquatable<Usuario>
    {
        public int IdUsuario { get; set; }
        public String Password { get; set; }
        public String Nombre { get; set; }
        public String Foto { get; set; }

        public Usuario()
        {
        }

        public Usuario(int idUsuario)
        {
            IdUsuario = idUsuario;
        }

        public Usuario(int idUsuario, string password, string nombre, string foto) : this(idUsuario)
        {
            Password = password;
            Nombre = nombre;
            Foto = foto;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Usuario);
        }

        public bool Equals(Usuario other)
        {
            return other != null &&
                   IdUsuario == other.IdUsuario;
        }

        public override int GetHashCode()
        {
            return 2132068464 + IdUsuario.GetHashCode();
        }
    }
}
