using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Familia : IEquatable<Familia>
    {
        public string IdFamilia { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        List<SubFamilia> Subfamilias = new List<SubFamilia>();

        public Familia()
        {
        }

        public Familia(string idFamilia)
        {
            this.IdFamilia = idFamilia;
        }

        public Familia(string idFamilia, string nombre, string descripcion, List<SubFamilia> subfamilias) : this(idFamilia)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            Subfamilias = subfamilias;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Familia);
        }

        public bool Equals(Familia other)
        {
            return other != null &&
                   IdFamilia == other.IdFamilia;
        }

        public override int GetHashCode()
        {
            return -1674788533 + EqualityComparer<string>.Default.GetHashCode(IdFamilia);
        }
    }
}
