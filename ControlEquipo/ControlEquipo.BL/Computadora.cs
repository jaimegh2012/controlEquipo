using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int TipoComputadoraId { get; set; }
        public TipoComputadora TipoComputadora { get; set; }
        public string Hostname { get; set; }
        public string DirecionIP { get; set; }
        public string Serie { get; set; }
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
        public string Modelo { get; set; }
        public int ProcesadorId { get; set; }
        public Procesador Procesador { get; set; }
        [Range(minimum:1, maximum:50, ErrorMessage = "Ingrese un número válido")]
        public int GeneracionProcesador { get; set; }
        public int TipoMemoriaId { get; set; }
        public TipoMemoria TipoMemoria { get; set; }

        [Range(minimum: 1, maximum: 100, ErrorMessage = "Ingrese un número válido")]
        public int Memoria { get; set; }
        public int CapacidadAlmacenamiento { get; set; }
        public int TipoDiscoId { get; set; }
        public TipoDisco TipoDisco { get; set; }
        public string OtraInformacion { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaUltimaActualiacion { get; set; }
        public bool Disponible { get; set; }
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }

        public List<ComputadoraDetalle> ListaAccesorios { get; set; }
    }

    public class ComputadoraDetalle
    {
        public ComputadoraDetalle()
        {

        }

        public int Id { get; set; }
        public int AccesorioId { get; set; }
        public int ComputadoraId { get; set; }
        public Computadora Computadora { get; set; }

    }
}
