using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class Computadora
    {
        public Computadora()
        {
            Disponible = true;
            FechaUltimaActualiacion = DateTime.Now;
        }

        public int Id { get; set; }
        public string TipoComputadora { get; set; }
        public string Hostname { get; set; }
        public string DirecionIP { get; set; }
        public string Serie { get; set; }
        public string MarcaId { get; set; }
        public string Modelo { get; set; }
        public int ProcesadorId { get; set; }
        public Procesador Procesador { get; set; }
        public int GeneracionProcesador { get; set; }
        public int TipoMemoriaId { get; set; }
        public TipoMemoria TipoMemoria { get; set; }
        public int CapacidadAlmacenamiento { get; set; }
        public string TipoDisco { get; set; }
        public string OtraInformacion { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaUltimaActualiacion { get; set; }
        public bool Disponible { get; set; }
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
    }
}
