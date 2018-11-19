using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empresa : IEquatable<Empresa>
    {
        public string Nif { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Logo { get; set; }

        public Empresa()
        {
        }

        public Empresa(string nif)
        {
            Nif = nif;
        }

        public Empresa(string nif, string nombre, string direccion, string logo) : this(nif)
        {
            Nombre = nombre;
            Direccion = direccion;
            Logo = logo;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Empresa);
        }

        public bool Equals(Empresa other)
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
