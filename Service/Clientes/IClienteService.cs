using ClienteCore.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCore.Service
{
    public interface IClienteService
    {
        List<Cliente> obtenerClientes();
        bool guardarCliente(Cliente cliente);
    }
}
