using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class AccesorioBL
    {
        Contexto _contexto;
        MarcaBL _marcaBL;
        List<Accesorio> listaAccesorios;

        public AccesorioBL()
        {
            _contexto = new Contexto();
            _marcaBL = new MarcaBL();
            listaAccesorios = new List<Accesorio>();
        }

        public List<Accesorio> obtenerAccesorios()
        {
            listaAccesorios = _contexto.Accesorios.Include("TipoAccesorio").Include("Marca").Include("Computadora")
                .OrderBy(a => a.TipoAccesorioId).ToList();

            //agregar datos de  la marca al accesorio, porque no se hace el innerjoin de marca por alguna razon
            var nuevaLista = new List<Accesorio>();
            foreach (var item in listaAccesorios)
            {
                item.Marca = _marcaBL.obtenerMarca(item.IdMarca);
                nuevaLista.Add(item);
            }

            return nuevaLista;
        }

        public List<Accesorio> obtenerAccesoriosPorComputadora(int id)
        {
            listaAccesorios = _contexto.Accesorios.Include("Marca").Include("TipoAccesorio").Include("Computadora")
                .Where(x => x.ComputadoraId == id).OrderBy(a => a.Computadora.Hostname).ToList();

            //agregar datos de  la marca al accesorio, porque no se hace el innerjoin de marca por alguna razon
            var nuevaLista = new List<Accesorio>();
            foreach (var item in listaAccesorios)
            {
                item.Marca = _marcaBL.obtenerMarca(item.IdMarca);
                nuevaLista.Add(item);
            }

            return nuevaLista;
        }

        public Accesorio obtenerAccesorio(int id)
        {
            var accesorio = _contexto.Accesorios.Include("TipoAccesorio").Include("Marca").Include("Computadora")
                .FirstOrDefault(a => a.Id == id);
            var marca = _contexto.Marcas.Find(accesorio.IdMarca);
            accesorio.Marca = marca;
            return accesorio;
        }

        public void guardarAccesorio(Accesorio accesorio)
        {
            if (accesorio.Id == 0)
            {
                _contexto.Accesorios.Add(accesorio);
            }
            else
            {
                var accesorioExistente = _contexto.Accesorios.Find(accesorio.Id);
                accesorioExistente.TipoAccesorioId = accesorio.TipoAccesorioId;
                accesorioExistente.IdMarca = accesorio.IdMarca;
                accesorioExistente.ComputadoraId = accesorio.ComputadoraId;
                accesorioExistente.Serie = accesorio.Serie;
                accesorioExistente.Observaciones = accesorio.Observaciones;
                accesorioExistente.Disponible = accesorio.Disponible;            
            }

            _contexto.SaveChanges();
        }
    }
}
