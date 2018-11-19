using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class PosiblesDescuentos : IEquatable<PosiblesDescuentos>
    {
        public String Descripcion { get; set; }
        public int Porcentaje { get; set; }

        public PosiblesDescuentos()
        {
        }

        public PosiblesDescuentos(string descripcion, int porcentaje)
        {
            Descripcion = descripcion;
            Porcentaje = porcentaje;
        }

        public PosiblesDescuentos(string descripcion)
        {
            Descripcion = descripcion;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PosiblesDescuentos);
        }

        public bool Equals(PosiblesDescuentos other)
        {
            return other != null &&
                   Descripcion.ToUpper() == other.Descripcion.ToUpper();
        }

        public override int GetHashCode()
        {
            return -1607886294 + EqualityComparer<string>.Default.GetHashCode(Descripcion);
        }
    }
}
