using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class AreaBL
    {
        Contexto _contexto;
        List<Area> listaAreas;
        public AreaBL()
        {
            _contexto = new Contexto();
            listaAreas = new List<Area>();
        }


        public List<Area> obtenerAreas()
        {
            listaAreas = _contexto.Areas.OrderBy(a => a.Nombre).ToList();
            return listaAreas;
        }

        public Area obtenerArea(int id)
        {
            var area = _contexto.Areas.Find(id);
            return area;
        }

        public void guardarArea(Area area)
        {
            if (area.Id == 0)
            {
                _contexto.Areas.Add(area);
            }else
            {
                var areaExistente = _contexto.Areas.Find(area.Id);
                areaExistente.Nombre = area.Nombre;
                areaExistente.Disponible = area.Disponible;
            }

            _contexto.SaveChanges();
        }

        public void eliminarSeccion(int id)
        {
            var area = _contexto.Areas.Find(id);

            _contexto.Areas.Remove(area);
            _contexto.SaveChanges();
        }
    }
}
