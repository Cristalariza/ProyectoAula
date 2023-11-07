using DAL;
using Entity;
using System.Collections.Generic;

namespace BLL
{
    public class ProductoService
    {
        private ProductoRepository _repository = new ProductoRepository();

        public string InsertarOActualizarProducto(Producto producto)
        {
            return _repository.InsertarOActualizarProducto(producto);
        }

        public string EliminarProducto(string idProducto)
        {
            return _repository.EliminarProducto(idProducto);
        }

        public List<Producto> ObtenerTodosLosProductos()
        {
            return _repository.ObtenerTodosLosProductos();
        }

        public Producto ObtenerProductoPorId(string idProducto)
        {
            return _repository.ObtenerProductoPorId(idProducto);
        }
    }
}
