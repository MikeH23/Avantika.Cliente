using ClienteCore.Models.DTO;
using ClienteCore.Models.Entity;
using ClienteCore.Repository.Repositorio;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCore.Service.Cuenta
{
    public class CuentaService : ICuentaService
    {
        //-------------------------------------------------------
        private readonly IRepositorioCuenta _repositorioCuenta;
        private readonly ILogger<CuentaService> _logger;
        //-------------------------------------------------------
        public CuentaService(ILogger<CuentaService> logger, IRepositorioCuenta repositorioCuenta)
        {
            this._logger = logger;
            this._repositorioCuenta = repositorioCuenta;
        }
        //-------------------------------------------------------
        public List<Cuentas> obtenerCuentasXCliente(int idCliente)
        {
            try
            {
                var lstCuentas = _repositorioCuenta.obtenerCuentasXCliente(idCliente);
                return lstCuentas;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //-------------------------------------------------------
        public List<Cuentas> obtenerCuentas()
        {
            try
            {
                var lstCuentas = _repositorioCuenta.obtenerCuentas();
                return lstCuentas;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //-------------------------------------------------------
        public CuentasDTO ObtenerSaldoXCuenta(int numeroCuenta)
        {
            try
            {
                var lstCuentas = _repositorioCuenta.ObtenerSaldoXCuenta(numeroCuenta);
                return lstCuentas;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //-------------------------------------------------------
        public bool guardarCuenta(Cuentas objCuenta)
        {
            try
            {
                return _repositorioCuenta.guardarCuenta(objCuenta);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //-------------------------------------------------------
        public bool actualizarSaldo(CuentasDTO objCuenta, bool bRetiro)
        {
            try
            {
                return _repositorioCuenta.actualizarSaldo(objCuenta, bRetiro);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //-------------------------------------------------------
    }
}
