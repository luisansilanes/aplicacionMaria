using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estante
    {

        public int IdEstante { get; set; }

        public int Altura { get; set; }

        public int PosicionEstante { get; set; }

        public Estante()
        {
        }

        public Estante(int idEstante, int altura, int posicionEstante)
        {
            IdEstante = idEstante;
            Altura = altura;
            PosicionEstante = posicionEstante;
        }

        public override bool Equals(object obj)
        {
            var estante = obj as Estante;
            return estante != null &&
                   IdEstante == estante.IdEstante &&
                   Altura == estante.Altura &&
                   PosicionEstante == estante.PosicionEstante;
        }

        public override int GetHashCode()
        {
            var hashCode = 1947700613;
            hashCode = hashCode * -1521134295 + IdEstante.GetHashCode();
            hashCode = hashCode * -1521134295 + Altura.GetHashCode();
            hashCode = hashCode * -1521134295 + PosicionEstante.GetHashCode();
            return hashCode;
        }


    }
}
