using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class TipoMemoria
    {
        public TipoMemoria()
        {
            Disponible = true;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Ingresar el nombre del tipo de memoria")]
        public string Nombre { get; set; }
        public bool Disponible { get; set; }
    }
}
