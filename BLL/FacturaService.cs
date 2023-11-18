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
    }
}
