using System.Collections.Generic;

namespace Entity
{
    public class Cliente
    {
        public string IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        // Considerando que un cliente puede tener múltiples facturas
        public List<Factura> HistorialDeCompras { get; set; }
    }
}
