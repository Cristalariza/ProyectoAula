using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioService
    {
        private UsuarioRepository _repository = new UsuarioRepository();
        public string InsertarOActualizar(Usuario usuario)
        {
            return _repository.InsertarActualizar(usuario);
        }

        public string Eliminar(string idUsuario)
        {
            return _repository.Eliminar(idUsuario);
        }

        public List<Usuario> ObtenerTodos()
        {
            return _repository.ObtenerTodosLosClientes();
        }

        public Usuario ObtenerProductoPorId(string idUsuario)
        {
            return _repository.Obtener(idUsuario);
        }
    }
}
