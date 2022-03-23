using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCore.Models.Entity
{
    public class Cuentas
    {
        public int Id { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente cliente { get; set; }
        [Required(ErrorMessage = "El número de cliente es requerido")]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "El número de cuenta es requerido")]
        public int NumeroCuenta { get; set; }  
        public double Saldo { get; set; }

        public Cuentas()
        {

        }
    }
}
