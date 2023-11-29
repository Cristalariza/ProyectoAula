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
            string dia = DateTime.Now.Day.ToString();
            string mes = DateTime.Now.Month.ToString();
            string anio = DateTime.Now.Year.ToString();
            string hora = DateTime.Now.Hour.ToString();
            string completo = $"_FAC{dia}_{mes}_{anio}_{hora}";
            string path = $"factura_{factura.IdCliente}{completo}.pdf";
            Document document = new Document(PageSize.A4, 50, 50, 25, 25);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
            document.Open();

            // Añadir información de la factura con un formato más formal
            document.Add(new Paragraph("FACTURA", FontFactory.GetFont("Arial", 20, Font.BOLD)));
            document.Add(new Paragraph("Número de Factura: VISIBLE SOLO POR ADMINISTRACION"));
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

        public List<Factura> ObtenerFacturasPorCliente(string idCliente)
        {
            List<Factura> facturas = new List<Factura>();

            try
            {
                AbrirConexion();
                string sqlSeleccionar = @"
                    SELECT idFactura, idCliente, idEmpleado, fecha, total 
                    FROM Factura 
                    WHERE idCliente = @IdCliente";

                SqlCommand cmdSeleccionar = new SqlCommand(sqlSeleccionar, conexion);
                cmdSeleccionar.Parameters.AddWithValue("@IdCliente", idCliente);

                using (SqlDataReader reader = cmdSeleccionar.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Factura factura = new Factura
                        {
                            IdFactura = Convert.ToInt32(reader["idFactura"]),
                            IdCliente = Convert.ToString(reader["idCliente"]),
                            IdEmpleado = reader["idEmpleado"] != DBNull.Value ? Convert.ToString(reader["idEmpleado"]) : null,
                            Fecha = Convert.ToDateTime(reader["fecha"]),
                            Total = Convert.ToDecimal(reader["total"])
                        };
                        facturas.Add(factura);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener las facturas: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return facturas;
        }

        public List<DetalleFactura> ObtenerDetallesPorFactura(int idFactura)
        {
            var listaProductos = ObtenerTodosLosProductos();
            List<DetalleFactura> detalles = new List<DetalleFactura>();

            try
            {
                AbrirConexion();
                string sqlSeleccionar = @"
                    SELECT idDetalle, idFactura, idProducto, cantidad 
                    FROM DetallesDeFactura 
                    WHERE idFactura = @IdFactura";

                SqlCommand cmdSeleccionar = new SqlCommand(sqlSeleccionar, conexion);
                cmdSeleccionar.Parameters.AddWithValue("@IdFactura", idFactura);

                using (SqlDataReader reader = cmdSeleccionar.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DetalleFactura detalle = new DetalleFactura
                        {
                            IdDetalle = Convert.ToInt32(reader["idDetalle"]),
                            IdProducto = Convert.ToString(reader["idProducto"]),
                            Cantidad = Convert.ToInt32(reader["cantidad"])
                        };

                        // Obtener la información del producto y asignarla al detalle
                        detalle.Producto = listaProductos.Where(x => x.IdProducto == detalle.IdProducto).FirstOrDefault();

                        detalles.Add(detalle);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener los detalles de la factura: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return detalles;
        }

        public List<Producto> ObtenerTodosLosProductos()
        {
            List<Producto> listaProductos = new List<Producto>();

            try
            {
                AbrirConexion();
                string sqlSeleccionar = "SELECT idProducto, nombre, precio, cantidadEnStock FROM Producto";
                SqlCommand cmdSeleccionar = new SqlCommand(sqlSeleccionar, conexion);
                using (SqlDataReader reader = cmdSeleccionar.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Producto producto = new Producto
                        {
                            IdProducto = Convert.ToString(reader["idProducto"]),
                            Nombre = Convert.ToString(reader["nombre"]),
                            Precio = Convert.ToDecimal(reader["precio"]),
                            CantidadEnStock = Convert.ToInt32(reader["cantidadEnStock"])
                        };
                        listaProductos.Add(producto);
                    }
                }
                CerrarConexion();
            }
            catch (Exception ex)
            {
                CerrarConexion();
                throw new Exception("Ocurrió un error al obtener los productos: " + ex.Message);
            }

            return listaProductos;
        }

        public decimal ObtenerTotalGanancias()
        {
            AbrirConexion();
            try
            {
                string sql = "SELECT SUM(total) AS TotalGanancias FROM Factura;";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                return (decimal)cmd.ExecuteScalar();
            }
            finally
            {
                CerrarConexion();
            }
        }

        public List<Factura> ObtenerFacturasDesdeFecha(string fechaInicio)
        {
            List<Factura> facturas = new List<Factura>();
            AbrirConexion();
            try
            {
                string sql = @"
                SELECT idFactura, idCliente, idEmpleado, fecha, total 
                FROM Factura 
                WHERE fecha >= @FechaInicio;";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var factura = new Factura
                        {
                            IdFactura = Convert.ToInt32(reader["idFactura"]),
                            IdCliente = reader["idCliente"].ToString(),
                            IdEmpleado = reader["idEmpleado"] != DBNull.Value ? reader["idEmpleado"].ToString() : null,
                            Fecha = Convert.ToDateTime(reader["fecha"]),
                            Total = Convert.ToDecimal(reader["total"])
                        };
                        facturas.Add(factura);
                    }
                }
                return facturas;
            }
            catch (Exception ex)
            {
                // Maneja la excepción como prefieras
                throw new Exception("Ocurrió un error al obtener las facturas: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

        public Usuario ObtenerEmpleadoMasVendedor()
        {
            AbrirConexion();
            try
            {
                string sql = @"
                SELECT TOP 1 f.idEmpleado, e.Nombre, SUM(f.total) AS VentasTotales
                FROM Factura f
                JOIN Usuario e ON f.idEmpleado = e.idUsuario
                GROUP BY f.idEmpleado, e.Nombre
                ORDER BY VentasTotales DESC;";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Usuario
                        {
                            IdUsuario = reader["idEmpleado"].ToString(),
                            NombreUsuario = reader["Nombre"].ToString(),
                            VentasTotales = (decimal)reader["VentasTotales"]
                        };
                    }
                    return null;
                }
            }
            finally
            {
                CerrarConexion();
            }
        }

        public Producto ObtenerProductoMasVendido()
        {
            Producto productoMasVendido = null;
            AbrirConexion();
            try
            {
                // Asegúrate de que los nombres de las columnas y las tablas coincidan con tu esquema de base de datos
                string sql = @"
                SELECT TOP 1 p.idProducto, p.nombre, SUM(df.cantidad) AS TotalVendido
                FROM DetallesDeFactura df
                INNER JOIN Producto p ON df.idProducto = p.idProducto
                GROUP BY p.idProducto, p.nombre
                ORDER BY TotalVendido DESC";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        productoMasVendido = new Producto
                        {
                            IdProducto = reader["idProducto"].ToString(),
                            Nombre = reader["nombre"].ToString(),
                            CantidadVendida = Convert.ToInt32(reader["TotalVendido"]) // Asegúrate de que esta propiedad exista en tu clase Producto
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción como prefieras
                throw new Exception("Ocurrió un error al obtener el producto más vendido: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
            return productoMasVendido;
        }

        public Producto ObtenerProductoMenosVendido()
        {
            Producto productoMenosVendido = null;
            AbrirConexion();
            try
            {
                // Asegúrate de que los nombres de las columnas y las tablas coincidan con tu esquema de base de datos
                string sql = @"
                SELECT TOP 1 p.idProducto, p.nombre, ISNULL(SUM(df.cantidad), 0) AS TotalVendido
                FROM Producto p
                LEFT JOIN DetallesDeFactura df ON p.idProducto = df.idProducto
                GROUP BY p.idProducto, p.nombre
                ORDER BY TotalVendido ASC, p.idProducto ASC"; // Se añade p.idProducto para garantizar un orden consistente

                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        productoMenosVendido = new Producto
                        {
                            IdProducto = reader["idProducto"].ToString(),
                            Nombre = reader["nombre"].ToString(),
                            CantidadVendida = Convert.ToInt32(reader["TotalVendido"]) // Asegúrate de que esta propiedad exista en tu clase Producto
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción como prefieras
                throw new Exception("Ocurrió un error al obtener el producto menos vendido: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
            return productoMenosVendido;
        }
    } 
}
