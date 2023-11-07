using DAL;
using Entity;
using System.Collections.Generic;

namespace BLL
{
    public class ClienteService
    {
        private ClienteRepository _repository = new ClienteRepository();

        public string InsertarActualizarCliente(Cliente cliente)
        {
            return _repository.InsertarActualizarCliente(cliente);
        }

        public string EliminarCliente(string idCliente)
        {
            return _repository.EliminarCliente(idCliente);
        }

        public List<Cliente> ObtenerTodosLosClientes()
        {
            return _repository.ObtenerTodosLosClientes();
        }

        public Cliente ObtenerClientePorId(string idCliente)
        {
            return _repository.ObtenerClientePorId(idCliente);
        }
    }
}
