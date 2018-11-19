using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SubFormaPago : IEquatable<SubFormaPago>
    {
        public int codPago { get; set; }
        public string subTipo { get; set; }

        public SubFormaPago()
        {
        }

        public SubFormaPago(int codPago)
        {
            this.codPago = codPago;
        }

        public SubFormaPago(int codPago, string subTipo) : this(codPago)
        {
            this.subTipo = subTipo;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SubFormaPago);
        }

        public bool Equals(SubFormaPago other)
        {
            return other != null &&
                   codPago == other.codPago;
        }

        public override int GetHashCode()
        {
            return 748314300 + codPago.GetHashCode();
        }
    }
}
