using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseDeDatos
    {
        protected SqlConnection conexion;
        protected string cadenaConexion = "Server=LAPTOP-AIP7TQ3E\\SQLEXPRESS;Database=ProyectoInventario;Trusted_Connection=True;"; 

        public BaseDeDatos()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        public string AbrirConexion()
        {
            conexion.Open();
            return conexion.State.ToString();
        }

        public string CerrarConexion()
        {
            conexion.Close();
            return conexion.State.ToString();
        }
    }
}
