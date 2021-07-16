using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class TipoDiscoBL
    {
        Contexto _contexto;
        List<TipoDisco> listaTipoDiscos;
        public TipoDiscoBL()
        {
            _contexto = new Contexto();
            listaTipoDiscos = new List<TipoDisco>();
        }


        public List<TipoDisco> obtenerTipoDiscos()
        {
            listaTipoDiscos = _contexto.TipoDiscos.OrderBy(a => a.Nombre).ToList();
            return listaTipoDiscos;
        }

        public TipoDisco obtenerTipoDisco(int id)
        {
            var tipoDisco = _contexto.TipoDiscos.Find(id);
            return tipoDisco;
        }
    }
}
