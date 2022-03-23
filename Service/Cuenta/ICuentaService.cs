using System;
using System.Collections.Generic;
using ClienteCore.Models.Entity;
using System.Linq;
using System.Threading.Tasks;
using ClienteCore.Models.DTO;

namespace ClienteCore.Service.Cuenta
{
    public interface ICuentaService
    {
        List<Cuentas> obtenerCuentasXCliente(int idCliente);
        List<Cuentas> obtenerCuentas();
        CuentasDTO ObtenerSaldoXCuenta(int numeroCuenta);
        bool guardarCuenta(Cuentas cuenta);
        bool actualizarSaldo(CuentasDTO objCuenta, bool bRetiro);
    }
}
