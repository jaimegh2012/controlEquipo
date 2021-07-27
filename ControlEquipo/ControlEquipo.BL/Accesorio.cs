using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class Accesorio
    {
        public Accesorio()
        {
            Disponible = true;
        }

        public int Id { get; set; }
        [Display(Name = "Tipo de Accesorio")]
        public int TipoAccesorioId { get; set; }
        [Display(Name = "Tipo de Accesorio")]
        public TipoAccesorio TipoAccesorio { get; set; }
        [Display(Name = "Marca")]
        public int IdMarca { get; set; }
        public Marca Marca { get; set; }
        [Display(Name = "Computadora")]
        public int ComputadoraId { get; set; }
        public Computadora Computadora { get; set; }
        public string Serie { get; set; }
        public string Observaciones { get; set; }
        public bool Disponible { get; set; }
    }
}
