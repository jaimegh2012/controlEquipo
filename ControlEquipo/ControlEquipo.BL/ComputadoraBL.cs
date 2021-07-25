using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class ComputadoraBL
    {
        Contexto _contexto;
        List<Computadora> listaComputadoras;

        public ComputadoraBL()
        {
            _contexto = new Contexto();
            listaComputadoras = new List<Computadora>();
        }

        public List<Computadora> obtenerComputadoras()
        {
            listaComputadoras = _contexto.Computadoras.Include("Marca").Include("Procesador").Include("TipoMemoria")
                .Include("TipoComputadora").Include("TipoDisco").Include("Empleado")
                .OrderBy(a => a.Hostname).ToList();
            return listaComputadoras;
        }

        public List<Computadora> obtenerComputadorasPorEmpleado(int id)
        {
            listaComputadoras = _contexto.Computadoras.Include("Marca").Include("Procesador").Include("TipoMemoria")
                .Include("TipoComputadora").Include("TipoDisco").Include("Empleado")
                .Where(x => x.EmpleadoId == id).OrderBy(a => a.Hostname).ToList();
            return listaComputadoras;
        }

        public List<Computadora> obtenerComputadorasDisponibles(bool disponible)
        {
            listaComputadoras = _contexto.Computadoras.Include("Marca").Include("Procesador").Include("TipoMemoria")
                .Include("TipoComputadora").Include("TipoDisco").Include("Empleado")
                .Where(x => x.Disponible == disponible).OrderBy(a => a.Hostname).ToList();
            return listaComputadoras;
        }

        public List<Computadora> obtenerComputadorasDisponiblesPorTipo(bool disponible, int tipoComputadoraId)
        {
            if (tipoComputadoraId == 0 || tipoComputadoraId == null)
            {
                listaComputadoras = _contexto.Computadoras.Include("Marca").Include("Procesador").Include("TipoMemoria")
                .Include("TipoComputadora").Include("TipoDisco").Include("Empleado")
                .Where(x => x.Disponible == disponible).OrderBy(a => a.Hostname).ToList();
            }else
            {
                listaComputadoras = _contexto.Computadoras.Include("Marca").Include("Procesador").Include("TipoMemoria")
                .Include("TipoComputadora").Include("TipoDisco").Include("Empleado")
                .Where(x => x.Disponible == disponible && x.TipoComputadoraId == tipoComputadoraId).OrderBy(a => a.Hostname).ToList();
            }
            return listaComputadoras;
        }


        public Computadora obtenerComputadora(int id)
        {
            var computadora = _contexto.Computadoras.Include("Marca").Include("Procesador").Include("TipoMemoria")
                .Include("TipoComputadora").Include("TipoDisco").Include("Empleado")
                .FirstOrDefault(a => a.Id == id);
            return computadora;
        }

        public void guardarComputadora(Computadora computadora)
        {
            if (computadora.Id == 0)
            {
                _contexto.Computadoras.Add(computadora);
            }
            else
            {
                var computadoraExistente = _contexto.Computadoras.Find(computadora.Id);
                computadoraExistente.TipoComputadoraId = computadora.TipoComputadoraId;
                computadoraExistente.Hostname = computadora.Hostname;
                computadoraExistente.DirecionIP = computadora.DirecionIP;
                computadoraExistente.Serie = computadora.Serie;
                computadoraExistente.MarcaId = computadora.MarcaId;
                computadoraExistente.Modelo = computadora.Modelo;
                computadoraExistente.ProcesadorId = computadora.ProcesadorId;
                computadoraExistente.TipoMemoriaId = computadora.TipoMemoriaId;
                computadoraExistente.Memoria = computadora.Memoria;
                computadoraExistente.CapacidadAlmacenamiento = computadora.CapacidadAlmacenamiento;
                computadoraExistente.TipoDiscoId = computadora.TipoDiscoId;
                computadoraExistente.OtraInformacion = computadora.OtraInformacion;
                computadoraExistente.Observaciones = computadora.Observaciones;
                computadoraExistente.EmpleadoId = computadora.EmpleadoId;
                computadoraExistente.FechaUltimaActualiacion = computadora.FechaUltimaActualiacion;
                computadoraExistente.Disponible = computadora.Disponible;
            }

            _contexto.SaveChanges();
        }
    }
}
