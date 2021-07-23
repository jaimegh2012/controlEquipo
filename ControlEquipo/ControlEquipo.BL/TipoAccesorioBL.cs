using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class TipoAccesorioBL
    {
        Contexto _contexto;
        List<TipoAccesorio> listaTiposAccesorio;

        public TipoAccesorioBL()
        {
            _contexto = new Contexto();
            listaTiposAccesorio = new List<TipoAccesorio>();
        }


        public List<TipoAccesorio> obtenerTiposAccesorio()
        {
            listaTiposAccesorio = _contexto.TipoAccesorios.OrderBy(a => a.Nombre).ToList();
            return listaTiposAccesorio;
        }

        public TipoAccesorio obtenerTipoAccesorio(int id)
        {
            var tipoAccesorio = _contexto.TipoAccesorios.Find(id);
            return tipoAccesorio;
        }

        public void guardarTipoAccesorio(TipoAccesorio tipoAccesorio)
        {
            if (tipoAccesorio.Id == 0)
            {
                _contexto.TipoAccesorios.Add(tipoAccesorio);
            }
            else
            {
                var tipoAccesorioExistente = _contexto.TipoAccesorios.Find(tipoAccesorio.Id);
                tipoAccesorioExistente.Nombre = tipoAccesorio.Nombre;
                tipoAccesorioExistente.Disponible = tipoAccesorio.Disponible;
            }

            _contexto.SaveChanges();
        }
    }
}
