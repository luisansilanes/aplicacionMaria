using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FormaPago : IEquatable<FormaPago>
    {
        public int CodPago { get; set; }
        public string Tipo { get; set; }
        public List<SubFormaPago> SubFormasPago = new List<SubFormaPago>();

        public FormaPago()
        {
        }

        public FormaPago(int codPago)
        {
            this.CodPago = codPago;
        }

        public FormaPago(int codPago, string tipo, List<SubFormaPago> subFormasPago) : this(codPago)
        {
            this.Tipo = tipo;
            SubFormasPago = subFormasPago;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as FormaPago);
        }

        public bool Equals(FormaPago other)
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
