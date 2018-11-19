using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Familia : IEquatable<Familia>
    {
        public string idFamilia { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        List<SubFamilia> Subfamilias = new List<SubFamilia>();

        public Familia()
        {
        }

        public Familia(string idFamilia)
        {
            this.idFamilia = idFamilia;
        }

        public Familia(string idFamilia, string nombre, string descripcion, List<SubFamilia> subfamilias) : this(idFamilia)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            Subfamilias = subfamilias;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Familia);
        }

        public bool Equals(Familia other)
        {
            return other != null &&
                   idFamilia == other.idFamilia;
        }

        public override int GetHashCode()
        {
            return -1674788533 + EqualityComparer<string>.Default.GetHashCode(idFamilia);
        }
    }
}
