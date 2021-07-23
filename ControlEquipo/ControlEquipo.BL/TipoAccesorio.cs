using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class TipoAccesorio
    {
        public TipoAccesorio()
        {
            Disponible = true;
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese el nombre del tipo de accesorio")]
        public string Nombre { get; set; }
        public bool Disponible { get; set; }

    }
}
