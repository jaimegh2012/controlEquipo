using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class TipoComputadoraBL
    {
        Contexto _contexto;
        List<TipoComputadora> listaTipoComputadoras;
        public TipoComputadoraBL()
        {
            _contexto = new Contexto();
            listaTipoComputadoras = new List<TipoComputadora>();
        }


        public List<TipoComputadora> obtenerTipoComputadoras()
        {
            listaTipoComputadoras = _contexto.TipoComputadoras.OrderBy(a => a.Nombre).ToList();
            return listaTipoComputadoras;
        }

        public TipoComputadora obtenerTipoComputadora(int id)
        {
            var tipoComputadora = _contexto.TipoComputadoras.Find(id);
            return tipoComputadora;
        }
    }
}
