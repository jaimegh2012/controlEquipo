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
        [Display(Name = "Tipo de Computadora")]
        public int TipoComputadoraId { get; set; }
        [Display(Name = "Tipo de Computadora")]
        public TipoComputadora TipoComputadora { get; set; }
        public string Hostname { get; set; }
        [Display(Name = "Dirección IP")]
        public string DirecionIP { get; set; }
        public string Serie { get; set; }
        [Display(Name = "Marca")]
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
        public string Modelo { get; set; }
        [Display(Name = "Procesador")]
        public int ProcesadorId { get; set; }
        public Procesador Procesador { get; set; }
        [Range(minimum:1, maximum:50, ErrorMessage = "Ingrese un número válido")]
        [Display(Name = "Generación del Procesador")]
        public int GeneracionProcesador { get; set; }
        [Display(Name = "Tipo de RAM")]
        public int TipoMemoriaId { get; set; }
        [Display(Name = "Tipo de RAM")]
        public TipoMemoria TipoMemoria { get; set; }

        [Range(minimum: 1, maximum: 100, ErrorMessage = "Ingrese un número válido")]
        [Display(Name = "Memoria RAM (GB)")]
        public int Memoria { get; set; }
        [Display(Name = "Disco Duro (GB)")]
        public int CapacidadAlmacenamiento { get; set; }
        [Display(Name = "Tipo de Disco")]
        public int TipoDiscoId { get; set; }
        [Display(Name = "Tipo de Disco")]
        public TipoDisco TipoDisco { get; set; }
        [Display(Name = "Otra Información")]
        public string OtraInformacion { get; set; }
        public string Observaciones { get; set; }
        [Display(Name = "Fecha Ultima Actualización")]
        public DateTime FechaUltimaActualiacion { get; set; }
        public bool Disponible { get; set; }
        [Display(Name = "Empleado")]
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
