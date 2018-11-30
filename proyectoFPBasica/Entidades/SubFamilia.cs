using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SubFamilia : IEquatable<SubFamilia>
    {
        public string IdFamilia { get; set; }
        public string IdSubFamilia { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public SubFamilia()
        {
        }

        public SubFamilia(string idFamilia, string idSubFamilia)
        {
            this.IdFamilia = idFamilia;
            this.IdSubFamilia = idSubFamilia;
        }

        public SubFamilia(string idFamilia, string idSubFamilia, string nombre, string descripcion) : this(idFamilia, idSubFamilia)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SubFamilia);
        }

        public bool Equals(SubFamilia other)
        {
            return other != null &&
                   IdFamilia == other.IdFamilia &&
                   IdSubFamilia == other.IdSubFamilia;
        }

        public override int GetHashCode()
        {
            var hashCode = -1530756240;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(IdFamilia);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(IdSubFamilia);
            return hashCode;
        }
    }
}
