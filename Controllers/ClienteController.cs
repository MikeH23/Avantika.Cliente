using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClienteCore.Models.Entity;
using ClienteCore.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClienteCore.Controllers
{    
    public class ClienteController : Controller
    {
        //------------------------------------------------------------------
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;
        //------------------------------------------------------------------
        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            this._clienteService = clienteService;
            this._mapper = mapper;
        }
        //------------------------------------------------------------------        
        public IActionResult Obtener()
        {
            var lstCliente = _clienteService.obtenerClientes();
            return View(lstCliente);
        }
        //------------------------------------------------------------------
        public IActionResult GuardarCliente()
        {
            return View();
        }
        //------------------------------------------------------------------
        [HttpPost]
        public IActionResult GuardarCliente(Cliente objCliente)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var respuesta = _clienteService.guardarCliente(objCliente);
                if (respuesta)
                    return RedirectToAction("Obtener");
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
