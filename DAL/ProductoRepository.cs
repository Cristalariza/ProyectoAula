using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductoRepository : BaseDeDatos
    {
        public ProductoRepository(): base() { }

        public string InsertarOActualizarProducto(Producto producto)
        {
            try
            {
                if (producto == null)
                {
                    return "Datos inválidos del producto.";
                }
                AbrirConexion();
                // Verificar si el producto ya existe
                string sqlVerificar = "SELECT COUNT(1) FROM Producto WHERE idProducto = @idProducto";
                SqlCommand cmdVerificar = new SqlCommand(sqlVerificar, conexion);
                cmdVerificar.Parameters.AddWithValue("@idProducto", producto.IdProducto);
                int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                string ssql;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;

                if (existe > 0)
                {
                    // Actualizar el producto existente
                    ssql = "UPDATE Producto SET precio = @Precio, cantidadEnStock = cantidadEnStock + @CantidadAAnadir " +
                           "WHERE idProducto = @IdProducto";
                    cmd.Parameters.AddWithValue("@CantidadAAnadir", producto.CantidadEnStock); // Cantidad a añadir a la existente
                }
                else
                {
                    // Insertar el nuevo producto
                    ssql = "INSERT INTO Producto (idProducto, nombre, precio, cantidadEnStock) VALUES " +
                           "(@IdProducto, @Nombre, @Precio, @CantidadEnStock)";
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre); // Nombre solo se añade al insertar
                    cmd.Parameters.AddWithValue("@CantidadEnStock", producto.CantidadEnStock);
                }

                cmd.CommandText = ssql;
                cmd.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);

                // Ejecutar la consulta de inserción o actualización
                int i = cmd.ExecuteNonQuery();

                // Se cierra la conexión
                CerrarConexion();

                if (i >= 1)
                {
                    return existe > 0
                        ? $"El producto con ID {producto.IdProducto} ha sido actualizado."
                        : $"El producto con ID {producto.IdProducto} ha sido agregado.";
                }

                return "No se pudo agregar o actualizar el producto.";
            }
            catch
            {
                CerrarConexion();
                return "Error interno";
            }

        }

        public string EliminarProducto(string idProducto)
        {
            if (idProducto == "")
            {
                return "ID de producto inválido.";
            }

            try
            {
                // Se abre la conexión
                AbrirConexion();

                // Crear el comando para eliminar el producto
                string sqlEliminar = "DELETE FROM Producto WHERE idProducto = @IdProducto";
                SqlCommand cmdEliminar = new SqlCommand(sqlEliminar, conexion);
                cmdEliminar.Parameters.AddWithValue("@IdProducto", idProducto);

                // Ejecutar la consulta de eliminación
                int resultado = cmdEliminar.ExecuteNonQuery();

                // Se cierra la conexión
                CerrarConexion();

                if (resultado > 0)
                {
                    return $"Producto con ID {idProducto} ha sido eliminado con éxito.";
                }
                else
                {
                    return $"Producto con ID {idProducto} no existe o no pudo ser eliminado.";
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                // Aquí deberías registrar el error en un log o algo similar para poder revisarlo después
                // Cerrar la conexión si está abierta
                CerrarConexion();
                return "Ocurrió un error al intentar eliminar el producto: " + ex.Message;
            }
        }

        public List<Producto> ObtenerTodosLosProductos()
        {
            List<Producto> listaProductos = new List<Producto>();

            try
            {
                // Se abre la conexión
                AbrirConexion();

                // Crear la consulta SQL para seleccionar todos los productos
                string sqlSeleccionar = "SELECT idProducto, nombre, precio, cantidadEnStock FROM Producto";
                SqlCommand cmdSeleccionar = new SqlCommand(sqlSeleccionar, conexion);

                // Ejecutar la consulta y obtener el resultado en un SqlDataReader
                using (SqlDataReader reader = cmdSeleccionar.ExecuteReader())
                {
                    while (reader.Read()) // Leer el siguiente registro mientras haya datos
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

                // Se cierra la conexión
                CerrarConexion();
            }
            catch (Exception ex)
            {
                // Cerrar la conexión si está abierta
                CerrarConexion();
                // Podrías lanzar la excepción o manejarla según sea el caso de uso.
                throw new Exception("Ocurrió un error al obtener los productos: " + ex.Message);
            }

            return listaProductos;
        }

        public Producto ObtenerProductoPorId(string idProducto)
        {
            Producto producto = null;

            try
            {
                // Se abre la conexión
                AbrirConexion();

                // Crear la consulta SQL para seleccionar el producto por su ID
                string sqlSeleccionar = "SELECT idProducto, nombre, precio, cantidadEnStock FROM Producto WHERE idProducto = @IdProducto";
                SqlCommand cmdSeleccionar = new SqlCommand(sqlSeleccionar, conexion);
                cmdSeleccionar.Parameters.AddWithValue("@IdProducto", idProducto);

                // Ejecutar la consulta y obtener el resultado en un SqlDataReader
                using (SqlDataReader reader = cmdSeleccionar.ExecuteReader())
                {
                    if (reader.Read()) // Si hay resultados, leer el primer registro
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

                // Se cierra la conexión
                CerrarConexion();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                CerrarConexion();
                throw new Exception("Ocurrió un error al obtener el producto: " + ex.Message);
            }

            return producto;
        }



    }
}
