namespace Entity
{
    public class DetalleFactura
    {
        public int IdDetalle { get; set; }
        public string IdProducto { get; set; }
        public int Cantidad { get; set; }
        public Producto Producto { get; set; } 

        public decimal CalcularSubTotal()
        {
            return Producto.Precio * Cantidad;
        }
    }

}
