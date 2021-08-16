using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class Empleado
    {
        public Empleado()
        {
            Disponible = true;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese el nombre o los nombres del empleado")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Ingrese el apellido o los apellidos del empleado")]
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }
        public bool Disponible { get; set; }

    }
}
