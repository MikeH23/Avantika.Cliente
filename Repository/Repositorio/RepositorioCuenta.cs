using ClienteCore.Models.DTO;
using ClienteCore.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCore.Repository.Repositorio
{
    public class RepositorioCuenta : IRepositorioCuenta
    {
        //--------------------------------------------------
        private ClienteDBContext _contexto;
        private DbSet<Cuentas> _dbSet;
        //--------------------------------------------------
        public RepositorioCuenta(ClienteDBContext contexto)
        {
            _contexto = contexto;
            this._dbSet = _contexto.Set<Cuentas>();
        }
        //--------------------------------------------------
        public List<Cuentas> obtenerCuentasXCliente(int idCliente)
        {
            try
            {
                var lstCuentas = _dbSet.Where(x => x.cliente.IdCliente == idCliente).ToList();
                return lstCuentas;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //--------------------------------------------------
        public List<Cuentas> obtenerCuentas()
        {
            try
            {
                var lstCuentas = _dbSet.OrderBy(x => x.IdCliente).ToList();
                return lstCuentas;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //--------------------------------------------------
        public CuentasDTO ObtenerSaldoXCuenta(int numeroCuenta)
        {
            try
            {
                CuentasDTO cuentas = new CuentasDTO();
                var lstCuentas = _dbSet.Where(x => x.NumeroCuenta == numeroCuenta).Include(x => x.cliente).ToList();

                foreach (var item in lstCuentas)
                {
                    cuentas.Id = item.Id;
                    cuentas.IdCliente = item.IdCliente;
                    cuentas.NumeroCuenta = item.NumeroCuenta;
                    cuentas.Saldo = item.Saldo;
                }

                return cuentas;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //--------------------------------------------------
        public bool guardarCuenta(Cuentas objCuenta)
        {
            try
            {
                Cuentas cuentas = new Cuentas();
                List<Cuentas> lstCuentas;
                int intExist = 0;

                //var jCliente = JsonConvert.DeserializeObject<Cliente>(objCliente);

                //Obtenemos todos los clientes de BD
                lstCuentas = (List<Cuentas>)obtenerCuentas();

                //Buscamos si ya existe algun registro dado de alta con el numero de cuenta proporcionado
                intExist = lstCuentas.Where(x => x.NumeroCuenta == objCuenta.NumeroCuenta).Count();

                if (intExist == 0)
                {
                    cuentas.IdCliente = objCuenta.IdCliente;
                    cuentas.NumeroCuenta = objCuenta.NumeroCuenta;
                    cuentas.Saldo = objCuenta.Saldo;                    
                    _dbSet.Add(cuentas);
                    _contexto.SaveChanges();
                    return true;
                }
                else
                {
                    throw new DbUpdateException("El cliente ya cuenta con el número de cuenta asignado, favor de verificar...?");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //--------------------------------------------------
        public bool actualizarSaldo(CuentasDTO objCuenta, bool bRetiro)
        {
            try
            {
                Cuentas cuenta = new Cuentas();

                var cuentas = _contexto.cuentas.Where(x => x.NumeroCuenta == objCuenta.NumeroCuenta).FirstOrDefault();

                _contexto.Remove(cuentas);

                //Verificamos si se realizo un retiro o un deposito a la cuenta
                if (bRetiro == true)
                {
                    objCuenta.Saldo -= objCuenta.Monto;
                } 
                else
                {
                    objCuenta.Saldo += objCuenta.Monto;
                }

                //Asignamos nuevo Saldo a la cuenta
                cuenta.IdCliente = objCuenta.IdCliente;
                cuenta.NumeroCuenta = objCuenta.NumeroCuenta;
                cuenta.Saldo = objCuenta.Saldo;

                //Actualizamos en BD
                _contexto.Add(cuenta);
                _contexto.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //--------------------------------------------------
    }
}
