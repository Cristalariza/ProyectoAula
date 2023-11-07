using System;
using System.Collections.Generic;

namespace Entity
{
    public class Factura
    {
        public int IdFactura { get; set; } 
        public string IdCliente { get; set; }
        public string IdEmpleado { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public List<DetalleFactura> DetallesDeFactura { get; set; }
    }
}
