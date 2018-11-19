using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SubFamilia : IEquatable<SubFamilia>
    {
        public string idFamilia { get; set; }
        public string idSubFamilia { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public SubFamilia()
        {
        }

        public SubFamilia(string idFamilia, string idSubFamilia)
        {
            this.idFamilia = idFamilia;
            this.idSubFamilia = idSubFamilia;
        }

        public SubFamilia(string idFamilia, string idSubFamilia, string nombre, string descripcion) : this(idFamilia, idSubFamilia)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SubFamilia);
        }

        public bool Equals(SubFamilia other)
        {
            return other != null &&
                   idFamilia == other.idFamilia &&
                   idSubFamilia == other.idSubFamilia;
        }

        public override int GetHashCode()
        {
            var hashCode = -1530756240;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(idFamilia);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(idSubFamilia);
            return hashCode;
        }
    }
}
