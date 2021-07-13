using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class ProcesadorBL
    {
        Contexto _contexto;
        List<Procesador> listaProcesadores;
        public ProcesadorBL()
        {
            _contexto = new Contexto();
            listaProcesadores = new List<Procesador>();
        }


        public List<Procesador> obtenerProcesadores()
        {
            listaProcesadores = _contexto.Procesadores.OrderBy(a => a.Nombre).ToList();
            return listaProcesadores;
        }

        public Procesador obtenerProcesador(int id)
        {
            var procesador = _contexto.Procesadores.Find(id);
            return procesador;
        }

        public void guardarProcesador(Procesador procesador)
        {
            if (procesador.Id == 0)
            {
                _contexto.Procesadores.Add(procesador);
            }
            else
            {
                var procesadorExistente = _contexto.Procesadores.Find(procesador.Id);
                procesadorExistente.Nombre = procesador.Nombre;
                procesadorExistente.Disponible = procesador.Disponible;
            }

            _contexto.SaveChanges();
        }
    }
}
