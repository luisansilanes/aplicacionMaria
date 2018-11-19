using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente : IEquatable<Cliente>
    {
        public string Nif { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string LugarEntrega { get; set; }

        public Cliente()
        {
        }

        public Cliente(string nif)
        {
            Nif = nif;
        }

        public Cliente(string nif, string nombre, string direccion, string lugarEntrega) : this(nif)
        {
            Nombre = nombre;
            Direccion = direccion;
            LugarEntrega = lugarEntrega;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Cliente);
        }

        public bool Equals(Cliente other)
        {
            return other != null &&
                   Nif == other.Nif;
        }

        public override int GetHashCode()
        {
            return -146653734 + EqualityComparer<string>.Default.GetHashCode(Nif);
        }
    }
}
