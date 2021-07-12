using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class Empresa
    {
        public Empresa()
        {
            Disponible = true;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese el nombre de la empresa")]
        public string Nombre { get; set; }
        public bool Disponible { get; set; }
    }
}
