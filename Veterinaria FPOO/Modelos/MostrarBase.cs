using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria_FPOO
{
    public class MostrarBase
    {
        public int ProductID { get; set; }
        public string CategoriaProducto { get; set; }
        public float PrecioProducto { get; set; }
        public float CantidadProducto { get; set; }
        public string FechaIngreso { get; set; }
        public string HoraIngreso { get; set; }

        public override string ToString()
        {
            return "Producto "+ this.ProductID + "\nCategoría: " + this.CategoriaProducto + "\nCantidad: " + this.CantidadProducto + " \nPrecio: $" + this.PrecioProducto + "\nFecha Registro: " + this.FechaIngreso + "\n" + this.HoraIngreso;
        }
    }

    public class MostrarProximasCitas
    {
        public int CitaID { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteApellido { get; set; }

        public string CitaFecha { get; set; }
        public string CitaHora { get; set; }
        public override string ToString()
        {
            return "Número de Cita: " + this.CitaID + "\n" + "Cliente: " + this.ClienteNombre + "\n" + "Fecha: " + this.CitaFecha + this.CitaHora;
        }
    }
}
