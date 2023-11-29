using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FacturaService
    {
        private FacturaRepository _repository = new FacturaRepository();

        public string InsertarFactura(Factura factura, List<DetalleFactura> detallesFactura)
        {
            return _repository.InsertarFactura(factura, detallesFactura);
        }

        // Método para obtener facturas por ID de cliente
        public List<Factura> ObtenerFacturasPorCliente(string idCliente)
        {
            return _repository.ObtenerFacturasPorCliente(idCliente);
        }

        // Método para obtener detalles de factura por ID de factura
        public List<DetalleFactura> ObtenerDetallesPorFactura(int idFactura)
        {
            return _repository.ObtenerDetallesPorFactura(idFactura);
        }

        public List<Factura> ObtenerFacturasDesdeFecha(string fechaInicio)
        {
            return _repository.ObtenerFacturasDesdeFecha(fechaInicio);
        }

        public decimal ObtenerTotalGanancias()
        {
            return _repository.ObtenerTotalGanancias();
        }

        public Usuario ObtenerMayorVendedor()
        {
            return _repository.ObtenerEmpleadoMasVendedor();
        }

        public Producto ObtenerProductoMasVendido()
        {
            return _repository.ObtenerProductoMasVendido();
        }
        public Producto ObtenerProductoMenosVendido()
        {
            return _repository.ObtenerProductoMenosVendido();
        }
    }
}

