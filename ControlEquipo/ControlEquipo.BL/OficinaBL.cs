using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class OficinaBL
    {
        Contexto _contexto;
        List<Oficina> listaOficinas;

        public OficinaBL()
        {
            _contexto = new Contexto();
            listaOficinas = new List<Oficina>();
        }
/*
        public List<Oficina> obtenerOficinas()
        {
            listaOficinas = _contexto.Oficinas.Include("Empresa").Include("Ciudad").OrderBy(a => a.Nombre).ToList();
            return listaOficinas;
        }

        public Oficina obtenerOficina(int id)
        {
            var oficina = _contexto.Oficinas.Include("Empresa").Include("Ciudad").FirstOrDefault(a => a.Id == id);
            return oficina;
        }

        public void guardarOficina(Oficina oficina)
        {
            if (oficina.Id == 0)
            {
                _contexto.Oficinas.Add(oficina);
            }
            else
            {
                var oficinaExistente = _contexto.Oficinas.Find(oficina.Id);
                oficinaExistente.Nombre = oficina.Nombre;
                oficinaExistente.Direccion = oficina.Direccion;
                oficinaExistente.Disponible = oficina.Disponible;
                oficinaExistente.EmpresaId = oficina.EmpresaId;
                oficinaExistente.CiudadId = oficina.CiudadId;

            }

            _contexto.SaveChanges();

        }
*/
    }
}
