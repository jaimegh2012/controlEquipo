using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class Usuario
    {
        public Usuario()
        {
            Disponible = true;
        }

        public int Id { get; set; }
        [Required (ErrorMessage = "Ingrese el nombre completo")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese una dirección de correo electrónico")]
        public string Correo { get; set; }
        public string Password { get; set; }
        public bool Disponible { get; set; }

    }
}
