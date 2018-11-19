using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estanteria
    {
        public int IdEstante { get; set; }

        public int NumAltura { get; set; }

        public int NumEstante { get; set; }

        public Estanteria()
        {
        }

        public Estanteria(int idEstante)
        {
            IdEstante = idEstante;
        }

        public Estanteria(int idEstante, int numAltura, int numEstante) : this(idEstante)
        {
            NumAltura = numAltura;
            NumEstante = numEstante;
        }

        public override bool Equals(object obj)
        {
            var estanteria = obj as Estanteria;
            return estanteria != null &&
                   IdEstante == estanteria.IdEstante;
        }

        public override int GetHashCode()
        {
            return -411862092 + IdEstante.GetHashCode();
        }


    }
}
