using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public int OficinaId { get; set; }
        public Oficina Oficina { get; set; }
        public bool Disponible { get; set; }

    }
}
