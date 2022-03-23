using ClienteCore.Models.Entity;
using ClienteCore.Repository.Repositorio;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCore.Service.Clientes
{
    public class ClienteService : IClienteService
    {
        //-------------------------------------------------------
        private readonly IRepositorioCliente _repositorioCliente;
        private readonly ILogger<ClienteService> _logger;
        //-------------------------------------------------------
        public ClienteService(ILogger<ClienteService> logger, IRepositorioCliente repositorioCliente)
        {
            this._logger = logger;
            this._repositorioCliente = repositorioCliente;
        }
        //-------------------------------------------------------
        public List<Cliente> obtenerClientes()
        {
            try
            {
                var lstCliente = _repositorioCliente.obtenerClientes();
                return lstCliente;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //-------------------------------------------------------
        public bool guardarCliente(Cliente objCliente)
        {
            try
            {
                return _repositorioCliente.guardarCliente(objCliente);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //-------------------------------------------------------
    }
}
