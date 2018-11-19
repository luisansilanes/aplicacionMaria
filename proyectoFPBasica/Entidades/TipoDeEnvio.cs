using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoDeEnvio : IEquatable<TipoDeEnvio>
    {
        public String TipoEnvio { get; set; }
        public String Plus { get; set; }

        public TipoDeEnvio()
        {
        }

        public TipoDeEnvio(string tipoEnvio)
        {
            TipoEnvio = tipoEnvio;
        }

        public TipoDeEnvio(string tipoEnvio, string plus)
        {
            TipoEnvio = tipoEnvio;
            Plus = plus;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TipoDeEnvio);
        }


        public bool Equals(TipoDeEnvio other)
        {
            return other != null &&
                   TipoEnvio.ToUpper() == other.TipoEnvio.ToUpper();
        }

        public override int GetHashCode()
        {
            return -920209974 + EqualityComparer<string>.Default.GetHashCode(TipoEnvio);
        }
    }
}
