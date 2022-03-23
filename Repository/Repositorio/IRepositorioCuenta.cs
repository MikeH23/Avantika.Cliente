using ClienteCore.Models.DTO;
using ClienteCore.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCore.Repository.Repositorio
{
    public interface IRepositorioCuenta
    {
        List<Cuentas> obtenerCuentasXCliente(int idCliente);
        List<Cuentas> obtenerCuentas();
        CuentasDTO ObtenerSaldoXCuenta(int numeroCuenta);
        bool guardarCuenta(Cuentas cuenta);
        bool actualizarSaldo(CuentasDTO objCuenta, bool bRetiro);
    }
}
