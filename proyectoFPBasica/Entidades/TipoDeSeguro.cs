using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoDeSeguro : IEquatable<TipoDeSeguro>
    {
        public string Tipo { get; set; }

        public TipoDeSeguro()
        {
        }

        public TipoDeSeguro(string tipo)
        {
            Tipo = tipo;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TipoDeSeguro);
        }

        public bool Equals(TipoDeSeguro other)
        {
            return other != null &&
                   Tipo == other.Tipo;
        }

        public override int GetHashCode()
        {
            return -163569033 + EqualityComparer<string>.Default.GetHashCode(Tipo);
        }
    }
}
