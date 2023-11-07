using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClienteRepository : BaseDeDatos
    {
        public ClienteRepository() : base() { }

        public string InsertarActualizarCliente(Cliente cliente)
        {
            try
            {
                if (cliente == null)
                {
                    return "Datos inválidos del cliente.";
                }
                AbrirConexion();
                // Verificar si el producto ya existe
                string sqlVerificar = "SELECT COUNT(1) FROM Cliente WHERE idCliente = @idCliente";
                SqlCommand cmdVerificar = new SqlCommand(sqlVerificar, conexion);
                cmdVerificar.Parameters.AddWithValue("@idCliente", cliente.IdCliente);
                int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                string ssql;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;

                if (existe > 0)
                {
                    // Actualizar el producto existente
                    ssql = "UPDATE Cliente SET nombre = @Nombre, telefono = @Telefono, email = @Email " +
                           "WHERE idCliente = @IdCliente";// Cantidad a añadir a la existente
                }
                else
                {
                    // Insertar el nuevo producto
                    ssql = "INSERT INTO Cliente (idCliente, nombre, telefono, email) VALUES " +
                           "(@IdCliente, @Nombre, @Telefono, @Email)";
                }

                cmd.CommandText = ssql;
                cmd.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre); 
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);

                // Ejecutar la consulta de inserción o actualización
                int i = cmd.ExecuteNonQuery();

                // Se cierra la conexión
                CerrarConexion();
                    
                if (i >= 1)
                {
                    return existe > 0
                        ? $"El cliente con ID {cliente.IdCliente} ha sido actualizado."
                        : $"El cliente con ID {cliente.IdCliente} ha sido agregado.";
                }

                return "No se pudo agregar o actualizar el producto.";
            }
            catch
            {
                CerrarConexion();
                return "Error interno";
            }

        }

        public string EliminarCliente(string idCliente)
        {
            if (idCliente == "")
            {
                return "ID de cliente inválido.";
            }

            try
            {
                // Se abre la conexión
                AbrirConexion();

                // Crear el comando para eliminar el producto
                string sqlEliminar = "DELETE FROM Cliente WHERE idCliente = @IdCliente";
                SqlCommand cmdEliminar = new SqlCommand(sqlEliminar, conexion);
                cmdEliminar.Parameters.AddWithValue("@IdCliente", idCliente);

                // Ejecutar la consulta de eliminación
                int resultado = cmdEliminar.ExecuteNonQuery();

                // Se cierra la conexión
                CerrarConexion();

                if (resultado > 0)
                {
                    return $"Cliente con ID {idCliente} ha sido eliminado con éxito.";
                }
                else
                {
                    return $"Cliente con ID {idCliente} no existe o no pudo ser eliminado.";
                }
            }
            catch (Exception ex)
            {
                CerrarConexion();
                return "Ocurrió un error al intentar eliminar el cliente: " + ex.Message;
            }
        }

        public List<Cliente> ObtenerTodosLosClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            try
            {
                // Se abre la conexión
                AbrirConexion();

                // Crear la consulta SQL para seleccionar todos los productos
                string sqlSeleccionar = "SELECT idCliente, nombre, telefono, email FROM Cliente";
                SqlCommand cmdSeleccionar = new SqlCommand(sqlSeleccionar, conexion);

                // Ejecutar la consulta y obtener el resultado en un SqlDataReader
                using (SqlDataReader reader = cmdSeleccionar.ExecuteReader())
                {
                    while (reader.Read()) // Leer el siguiente registro mientras haya datos
                    {
                        Cliente cliente = new Cliente
                        {
                            IdCliente = Convert.ToString(reader["idCliente"]),
                            Nombre = Convert.ToString(reader["nombre"]),
                            Telefono = Convert.ToString(reader["telefono"]),
                            Email = Convert.ToString(reader["email"])
                        };
                        listaClientes.Add(cliente);
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
                throw new Exception("Ocurrió un error al obtener los clientes: " + ex.Message);
            }

            return listaClientes;
        }

        public Cliente ObtenerClientePorId(string idCliente)
        {
            Cliente cliente = null;

            try
            {
                // Se abre la conexión
                AbrirConexion();

                // Crear la consulta SQL para seleccionar el producto por su ID
                string sqlSeleccionar = "SELECT idCliente, nombre, telefono, email FROM Cliente WHERE idCliente = @IdCliente";
                SqlCommand cmdSeleccionar = new SqlCommand(sqlSeleccionar, conexion);
                cmdSeleccionar.Parameters.AddWithValue("@IdCliente", idCliente);

                // Ejecutar la consulta y obtener el resultado en un SqlDataReader
                using (SqlDataReader reader = cmdSeleccionar.ExecuteReader())
                {
                    if (reader.Read()) // Si hay resultados, leer el primer registro
                    {
                        cliente = new Cliente
                        {
                            IdCliente = Convert.ToString(reader["idCliente"]),
                            Nombre = Convert.ToString(reader["nombre"]),
                            Telefono = Convert.ToString(reader["telefono"]),
                            Email = Convert.ToString(reader["email"])
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
                throw new Exception("Ocurrió un error al obtener el cliente: " + ex.Message);
            }

            return cliente;
        }



    }
}
