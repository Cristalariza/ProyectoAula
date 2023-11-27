using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioRepository : BaseDeDatos
    {
        public UsuarioRepository() : base() { }

        public string InsertarActualizar(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                {
                    return "Datos inválidos del usuario.";
                }
                AbrirConexion();
                // Verificar si el producto ya existe
                string sqlVerificar = "SELECT COUNT(1) FROM Usuario WHERE idUsuario = @idUsuario";
                SqlCommand cmdVerificar = new SqlCommand(sqlVerificar, conexion);
                cmdVerificar.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);
                int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                string ssql;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;

                if (existe > 0)
                {
                    // Actualizar el producto existente
                    ssql = "UPDATE Usuario SET nombre = @Nombre, contra = @contra " +
                           "WHERE idUsuario = @idUsuario";// Cantidad a añadir a la existente
                }
                else
                {
                    // Insertar el nuevo producto
                    ssql = "INSERT INTO Usuario (idUsuario, nombre, contra, rol) VALUES " +
                           "(@idUsuario, @nombre, @contra, @rol)";
                }

                cmd.CommandText = ssql;
                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@Nombre", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@Contra", usuario.Contra);
                cmd.Parameters.AddWithValue("@Rol", usuario.Rol);

                // Ejecutar la consulta de inserción o actualización
                int i = cmd.ExecuteNonQuery();

                // Se cierra la conexión
                CerrarConexion();

                if (i >= 1)
                {
                    return existe > 0
                        ? $"El usuario con ID {usuario.IdUsuario} ha sido actualizado."
                        : $"El usuario con ID {usuario.IdUsuario} ha sido agregado.";
                }

                return "No se pudo agregar o actualizar el usuario.";
            }
            catch
            {
                CerrarConexion();
                return "Error interno";
            }

        }

        public string Eliminar(string IdUsuario)
        {
            if (IdUsuario == "")
            {
                return "ID de usuario inválido.";
            }

            try
            {
                // Se abre la conexión
                AbrirConexion();

                // Crear el comando para eliminar el producto
                string sqlEliminar = "DELETE FROM Usuario WHERE idUsuario = @idUsuario";
                SqlCommand cmdEliminar = new SqlCommand(sqlEliminar, conexion);
                cmdEliminar.Parameters.AddWithValue("@idUsuario", IdUsuario);

                // Ejecutar la consulta de eliminación
                int resultado = cmdEliminar.ExecuteNonQuery();

                // Se cierra la conexión
                CerrarConexion();

                if (resultado > 0)
                {
                    return $"Usuario con ID {IdUsuario} ha sido eliminado con éxito.";
                }
                else
                {
                    return $"Cliente con ID {IdUsuario} no existe o no pudo ser eliminado.";
                }
            }
            catch (Exception ex)
            {
                CerrarConexion();
                return "Ocurrió un error al intentar eliminar el Usuario: " + ex.Message;
            }
        }

        public List<Usuario> ObtenerTodosLosClientes()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                // Se abre la conexión
                AbrirConexion();

                // Crear la consulta SQL para seleccionar todos los productos
                string sqlSeleccionar = "SELECT idUsuario, nombre, contra, rol FROM Usuario";
                SqlCommand cmdSeleccionar = new SqlCommand(sqlSeleccionar, conexion);

                // Ejecutar la consulta y obtener el resultado en un SqlDataReader
                using (SqlDataReader reader = cmdSeleccionar.ExecuteReader())
                {
                    while (reader.Read()) // Leer el siguiente registro mientras haya datos
                    {
                        Usuario cliente = new Usuario
                        {
                            IdUsuario= Convert.ToString(reader["idUsuario"]),
                            NombreUsuario = Convert.ToString(reader["nombre"]),
                            Contra = Convert.ToString(reader["contra"]),
                            Rol = Convert.ToString(reader["rol"])
                        };
                        lista.Add(cliente);
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
                throw new Exception("Ocurrió un error al obtener los Usuarios: " + ex.Message);
            }

            return lista;
        }

        public Usuario Obtener(string idUsuario)
        {
            Usuario usuario = null;

            try
            {
                // Se abre la conexión
                AbrirConexion();

                // Crear la consulta SQL para seleccionar el producto por su ID
                string sqlSeleccionar = "SELECT idUsuario, nombre, contra, rol FROM Usuario WHERE idUsuario = @IdUsuario";
                SqlCommand cmdSeleccionar = new SqlCommand(sqlSeleccionar, conexion);
                cmdSeleccionar.Parameters.AddWithValue("@IdUsuario", idUsuario);

                // Ejecutar la consulta y obtener el resultado en un SqlDataReader
                using (SqlDataReader reader = cmdSeleccionar.ExecuteReader())
                {
                    if (reader.Read()) // Si hay resultados, leer el primer registro
                    {
                        usuario = new Usuario
                        {
                            IdUsuario = Convert.ToString(reader["idUsuario"]),
                            NombreUsuario = Convert.ToString(reader["nombre"]),
                            Contra = Convert.ToString(reader["contra"]),
                            Rol = Convert.ToString(reader["rol"])
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

            return usuario;
        }


    }
}
