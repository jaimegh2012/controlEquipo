using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class TipoMemoriaBL
    {
        Contexto _contexto;
        List<TipoMemoria> listaTipoMemorias;

        public TipoMemoriaBL()
        {
            _contexto = new Contexto();
            listaTipoMemorias = new List<TipoMemoria>();
        }

        public List<TipoMemoria> obtenerTipoMemorias()
        {
            listaTipoMemorias = _contexto.TipoMemorias.OrderBy(a => a.Nombre).ToList();
            return listaTipoMemorias;
        }

        public TipoMemoria obtenerTipoMemoria(int id)
        {
            var tipoMemoria = _contexto.TipoMemorias.Find(id);
            return tipoMemoria;
        }

        public void guardarTipoMemoria(TipoMemoria tipoMemoria)
        {
            if (tipoMemoria.Id == 0)
            {
                _contexto.TipoMemorias.Add(tipoMemoria);
            }
            else
            {
                var tipoMemoriaExistente = _contexto.TipoMemorias.Find(tipoMemoria.Id);
                tipoMemoriaExistente.Nombre = tipoMemoria.Nombre;
                tipoMemoriaExistente.Disponible = tipoMemoria.Disponible;
            }

            _contexto.SaveChanges();
        }
    }
}
