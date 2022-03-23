using ClienteCore.Models.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCore.Repository.Repositorio
{
    public interface IRepositorioCliente 
    {
        List<Cliente> obtenerClientes();
        bool guardarCliente(Cliente cliente);
    }
}
