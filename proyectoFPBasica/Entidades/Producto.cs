using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {

        public string CodProducto { get; set; }
        public string CodBarras { get; set; }
        public string Descripcion { get; set; }
        public int IdMarca { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int PesoNeto { get; set; }
        public int PesoNuto { get; set; }

        public Producto()
        {
        }

        public Producto(string codProducto)
        {
            CodProducto = codProducto;
        }

        public Producto(string codProducto, string codBarras, string descripcion, int idMarca, decimal precio, int stock, int pesoNeto, int pesoNuto) : this(codProducto)
        {
            CodBarras = codBarras;
            Descripcion = descripcion;
            IdMarca = idMarca;
            Precio = precio;
            Stock = stock;
            PesoNeto = pesoNeto;
            PesoNuto = pesoNuto;
        }

        public override bool Equals(object obj)
        {
            var producto = obj as Producto;
            return producto != null &&
                   CodProducto == producto.CodProducto;
        }

        public override int GetHashCode()
        {
            return -1048562515 + EqualityComparer<string>.Default.GetHashCode(CodProducto);
        }
    }
}
