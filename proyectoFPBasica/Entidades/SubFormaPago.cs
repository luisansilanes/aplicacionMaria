using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SubFormaPago : IEquatable<SubFormaPago>
    {
        public int CodPago { get; set; }
        public string SubTipo { get; set; }

        public SubFormaPago()
        {
        }

        public SubFormaPago(int codPago)
        {
            this.CodPago = codPago;
        }

        public SubFormaPago(int codPago, string subTipo) : this(codPago)
        {
            this.SubTipo = subTipo;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SubFormaPago);
        }

        public bool Equals(SubFormaPago other)
        {
            return other != null &&
                   CodPago == other.CodPago;
        }

        public override int GetHashCode()
        {
            return 748314300 + CodPago.GetHashCode();
        }
    }
}
