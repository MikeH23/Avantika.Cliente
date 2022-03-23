using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCore.Models.Entity
{
    public class Cliente
    {
        [Required(ErrorMessage ="El número de cliente es requerido")]
        public int IdCliente { get; set; }
        
        [Required(ErrorMessage ="El nombre es requerido")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "El apellido es requerido")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "La edad es requerida")]
        public int Edad { get; set; }

        public Cliente()
        {

        }
    }
}
