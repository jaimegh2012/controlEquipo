using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class Procesador
    {
        public Procesador()
        {
            Disponible = true;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del procesador")]
        public string Nombre { get; set; }
        public bool Disponible { get; set; }
    }
}
