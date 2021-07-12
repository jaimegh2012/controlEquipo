using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class CiudadBL
    {
        Contexto _contexto;
        List<Ciudad> listaCiudades;

        public CiudadBL()
        {
            _contexto = new Contexto();
            listaCiudades = new List<Ciudad>();
        }

        public List<Ciudad> obtenerCiudades()
        {
            listaCiudades = _contexto.Ciudades.OrderBy(a => a.Nombre).ToList();
            return listaCiudades;
        }

        public Ciudad obtenerCiudad(int id)
        {
            var ciudad = _contexto.Ciudades.Find(id);
            return ciudad;
        }

        public void guardarCiudad(Ciudad ciudad)
        {
            if (ciudad.Id == 0)
            {
                _contexto.Ciudades.Add(ciudad);
            }
            else
            {
                var ciudadExistente = _contexto.Ciudades.Find(ciudad.Id);
                ciudadExistente.Nombre = ciudad.Nombre;
                ciudadExistente.Disponible = ciudad.Disponible;
            }

            _contexto.SaveChanges();
        }
    }
}
