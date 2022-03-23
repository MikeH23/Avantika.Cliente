using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClienteCore.Models.DTO;
using ClienteCore.Models.Entity;
using ClienteCore.Service.Cuenta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClienteCore.Controllers
{
    
    public class CuentasController : Controller
    {
        //------------------------------------------------------------------
        private readonly ICuentaService _cuentaService;
        private readonly IMapper _mapper;
        //------------------------------------------------------------------
        public CuentasController(ICuentaService cuentaService, IMapper mapper)
        {
            this._cuentaService = cuentaService;
            this._mapper = mapper;
        }
        //------------------------------------------------------------------
        public IActionResult ObtenerCuenta(int idCliente)
        {
            var lstCuentas = _cuentaService.obtenerCuentasXCliente(idCliente);
            return View(lstCuentas);
        }
        //------------------------------------------------------------------
        public IActionResult ObtenerSaldoXCuenta(int numeroCuenta)
        {
            var lstCuentas = _cuentaService.obtenerCuentasXCliente(numeroCuenta);
            return View(lstCuentas);
        }
        //------------------------------------------------------------------
        public IActionResult GuardarCuenta()
        {
            return View();
        }
        //------------------------------------------------------------------
        [HttpPost]
        public IActionResult GuardarCuenta(Cuentas objCuenta)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var respuesta = _cuentaService.guardarCuenta(objCuenta);
                if (respuesta)
                    return RedirectToAction("Obtener","Cliente");
                else
                    return View();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //------------------------------------------------------------------
        public IActionResult ActualizarSaldo(int idCuenta)
        {
            var lstCuentas = _cuentaService.ObtenerSaldoXCuenta(idCuenta);
            return View(lstCuentas);
        }
        //------------------------------------------------------------------
        [HttpPost]       
        public IActionResult ActualizarSaldo(CuentasDTO objCuenta, bool bRetiro)
        {
            try
            {
                var respuesta =_cuentaService.actualizarSaldo(objCuenta, bRetiro);
                if (respuesta)
                    return RedirectToAction("Obtener", "Cliente");
                else
                    return View();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //------------------------------------------------------------------
        public IActionResult RetirarSaldo(int idCuenta)
        {
            var lstCuentas = _cuentaService.ObtenerSaldoXCuenta(idCuenta);
            return View(lstCuentas);
        }
        //------------------------------------------------------------------
        [HttpPost]
        public IActionResult RetirarSaldo(CuentasDTO objCuenta, double dblMonto, bool bRetiro)
        {
            try
            {
                var respuesta = _cuentaService.actualizarSaldo(objCuenta, bRetiro);
                if (respuesta)
                    return RedirectToAction("Obtener", "Cliente");
                else
                    return View();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //------------------------------------------------------------------
    }
}
