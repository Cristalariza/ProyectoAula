using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace DAL
{
    public class FacturaRepository : BaseDeDatos
    {
        public FacturaRepository() : base() { }

        // Método para insertar una factura y sus detalles.
        public string InsertarFactura(Factura factura, List<DetalleFactura> detallesFactura)
        {
            try
            {
                AbrirConexion();
                SqlCommand cmd;
                SqlTransaction transaction = conexion.BeginTransaction();

                // Insertar factura
                string sqlInsertFactura = @"
                INSERT INTO Factura (idCliente, idEmpleado, fecha, total) 
                VALUES (@IdCliente, @IdEmpleado, @Fecha, @Total);
                SELECT SCOPE_IDENTITY();"; // Para obtener el ID de la factura insertada

                cmd = new SqlCommand(sqlInsertFactura, conexion, transaction);
                cmd.Parameters.AddWithValue("@IdCliente", factura.IdCliente);
                cmd.Parameters.AddWithValue("@IdEmpleado", factura.IdEmpleado ?? (object)DBNull.Value); // Si IdEmpleado es null, se envía DBNull
                cmd.Parameters.AddWithValue("@Fecha", factura.Fecha);
                cmd.Parameters.AddWithValue("@Total", factura.Total);

                int idFactura = Convert.ToInt32(cmd.ExecuteScalar());

                foreach (var detalle in detallesFactura)
                {
                    // Insertar detalle de factura
                    string sqlInsertDetalle = @"
                    INSERT INTO DetallesDeFactura (idFactura, idProducto, cantidad) 
                    VALUES (@IdFactura, @IdProducto, @Cantidad)";

                    cmd = new SqlCommand(sqlInsertDetalle, conexion, transaction);
                    cmd.Parameters.AddWithValue("@IdFactura", idFactura);
                    cmd.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);
                    cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                    cmd.ExecuteNonQuery();

                    // Actualizar el stock del producto
                    string sqlActualizarProducto = @"
                    UPDATE Producto 
                    SET cantidadEnStock = cantidadEnStock - @Cantidad 
                    WHERE idProducto = @IdProducto";

                    cmd = new SqlCommand(sqlActualizarProducto, conexion, transaction);
                    cmd.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);
                    cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                    cmd.ExecuteNonQuery();
                }

                // Commit de la transacción
                transaction.Commit();
                CerrarConexion();
                CrearPDFDeFactura(factura, detallesFactura);
                return $"Factura con ID {idFactura} ha sido creada con éxito.";
            }
            catch (Exception ex)
            {
                CerrarConexion();
                throw new Exception("Ocurrió un error al insertar la factura: " + ex.Message);
            }
        }

        public void CrearPDFDeFactura(Factura factura, List<DetalleFactura> detallesFactura)
        {
            string path = $"factura_{factura.IdCliente}_{factura.Fecha}.pdf";
            Document document = new Document(PageSize.A4, 50, 50, 25, 25);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
            document.Open();

            // Añadir información de la factura con un formato más formal
            document.Add(new Paragraph("FACTURA", FontFactory.GetFont("Arial", 20, Font.BOLD)));
            document.Add(new Paragraph("Número de Factura: " + factura.IdFactura));
            document.Add(new Paragraph("Fecha de Emisión: " + factura.Fecha.ToString("dd/MM/yyyy")));
            document.Add(new Paragraph("ID Cliente: " + factura.IdCliente));
            document.Add(new Paragraph("\n"));

            // Añadir la tabla para los detalles de la factura
            PdfPTable table = new PdfPTable(5);
            table.WidthPercentage = 100;

            // Añadir cabeceras de tabla
            table.AddCell("ID Producto");
            table.AddCell("Descripción");
            table.AddCell("Cantidad");
            table.AddCell("Precio Unit.");
            table.AddCell("Subtotal");

            decimal totalFactura = 0;
            foreach (var detalle in detallesFactura)
            {
                // Usar la función para obtener la información del producto
                Producto producto = ObtenerProductoPorId(detalle.IdProducto);

                decimal subtotal = detalle.Cantidad * producto.Precio;
                totalFactura += subtotal;

                // Añadir los datos de cada producto a la tabla
                table.AddCell(producto.IdProducto);
                table.AddCell(producto.Nombre);
                table.AddCell(detalle.Cantidad.ToString());
                table.AddCell(producto.Precio.ToString("C"));
                table.AddCell(subtotal.ToString("C"));
            }

            document.Add(table);
            document.Add(new Paragraph("\n"));

            // Añadir el total de la factura
            document.Add(new Paragraph("Total a Pagar: " + totalFactura.ToString("C"), FontFactory.GetFont("Arial", 14, Font.BOLD)));

            // Cerrar el documento
            document.Close();

            // Opcional: Abrir el PDF automáticamente si se ejecuta en un entorno de escritorio
            System.Diagnostics.Process.Start(path);
        }

        public Producto ObtenerProductoPorId(string idProducto)
        {
            Producto producto = null;

            try
            {
                AbrirConexion();
                string sqlSeleccionar = "SELECT idProducto, nombre, precio, cantidadEnStock FROM Producto WHERE idProducto = @IdProducto";
                SqlCommand cmdSeleccionar = new SqlCommand(sqlSeleccionar, conexion);
                cmdSeleccionar.Parameters.AddWithValue("@IdProducto", idProducto);
                using (SqlDataReader reader = cmdSeleccionar.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        producto = new Producto
                        {
                            IdProducto = Convert.ToString(reader["idProducto"]),
                            Nombre = Convert.ToString(reader["nombre"]),
                            Precio = Convert.ToDecimal(reader["precio"]),
                            CantidadEnStock = Convert.ToInt32(reader["cantidadEnStock"])
                        };
                    }
                }
                CerrarConexion();
            }
            catch (Exception ex)
            {
                CerrarConexion();
                throw new Exception("Ocurrió un error al obtener el producto: " + ex.Message);
            }

            return producto;
        }


    }
}
