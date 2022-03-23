using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCore.Models.DTO
{
    public class CuentasDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El número de cliente es requerido")]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "El número de cuenta es requerido")]
        public int NumeroCuenta { get; set; }
        public double Saldo { get; set; }
        public double Monto { get; set; }

        public CuentasDTO()
        {

        }
    }
}
