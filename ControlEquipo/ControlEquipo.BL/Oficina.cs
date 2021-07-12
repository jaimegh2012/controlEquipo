using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class Oficina
    {

        public Oficina()
        {
            Disponible = true;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese el nombre de la oficina")]
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }
        public bool Disponible { get; set; }
    }
}
