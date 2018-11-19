using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Marca
    {

        public int IdMarca { get; set; }

        public string Nombre { get; set; }

        public Marca()
        {
        }

        public Marca(int idMarca)
        {
            IdMarca = idMarca;
        }

        public Marca(int idMarca, string nombre) : this(idMarca)
        {
            Nombre = nombre;
        }

        public override bool Equals(object obj)
        {
            var marca = obj as Marca;
            return marca != null &&
                   IdMarca == marca.IdMarca;
        }

        public override int GetHashCode()
        {
            return -1086534504 + IdMarca.GetHashCode();
        }
    }
}
