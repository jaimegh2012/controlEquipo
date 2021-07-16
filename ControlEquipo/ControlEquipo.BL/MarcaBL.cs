using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class MarcaBL
    {
        Contexto _contexto;
        List<Marca> listaMarcas;

        public MarcaBL()
        {
            _contexto = new Contexto();
            listaMarcas = new List<Marca>();
        }

        public List<Marca> obtenerMarcas()
        {
            listaMarcas = _contexto.Marcas.OrderBy(a => a.Nombre).ToList();
            return listaMarcas;
        }

        public Marca obtenerMarca(int id)
        {
            var marca = _contexto.Marcas.Find(id);
            return marca;
        }

        public void guardarMarca(Marca marca)
        {
            if (marca.Id == 0)
            {
                _contexto.Marcas.Add(marca);
            }
            else
            {
                var marcaExistente = _contexto.Marcas.Find(marca.Id);
                marcaExistente.Nombre = marca.Nombre;
                marcaExistente.Disponible = marca.Disponible;
            }

            _contexto.SaveChanges();
        }
    }
}
