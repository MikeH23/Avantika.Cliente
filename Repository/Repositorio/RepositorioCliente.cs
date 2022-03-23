using ClienteCore.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCore.Repository.Repositorio
{
    public class RepositorioCliente : IRepositorioCliente
    {
        //--------------------------------------------------
        private ClienteDBContext _contexto;
        private DbSet<Cliente> _dbSet;
        //--------------------------------------------------
        public RepositorioCliente(ClienteDBContext contexto)
        {
            _contexto = contexto;
            this._dbSet = _contexto.Set<Cliente>();
        }
        //--------------------------------------------------
        public List<Cliente> obtenerClientes()
        {
            try
            {
                var lstCliente = _dbSet.OrderBy(x => x.IdCliente).ToList();
                return lstCliente;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }
        //--------------------------------------------------
        public bool guardarCliente(Cliente objCliente)
        {
            try
            {
                Cliente cliente = new Cliente();
                List<Cliente> lstCliente;
                int intExist = 0;
                
                //var jCliente = JsonConvert.DeserializeObject<Cliente>(objCliente);

                //Obtenemos todos los clientes de BD
                lstCliente = (List<Cliente>) obtenerClientes();

                //Buscamos si ya existe algun registro dado de alta con el numero de cliente proporcionado
                intExist = lstCliente.Where(x => x.IdCliente == objCliente.IdCliente).Count();

                if (intExist == 0)
                {
                    cliente.IdCliente = objCliente.IdCliente;
                    cliente.Nombre = objCliente.Nombre;
                    cliente.Apellidos = objCliente.Apellidos;
                    cliente.Edad = objCliente.Edad;
                    _dbSet.Add(cliente);
                    _contexto.SaveChanges();
                    return true;
                }
                else
                {
                    throw new DbUpdateException("El cliente ya se encuentra dado de alta, favor de verificar...?");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //--------------------------------------------------
    }
}
