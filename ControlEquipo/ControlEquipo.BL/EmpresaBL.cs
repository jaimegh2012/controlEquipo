using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class EmpresaBL
    {
        Contexto _contexto;
        List<Empresa> listaEmpresas;

        public EmpresaBL()
        {
            _contexto = new Contexto();
            listaEmpresas = new List<Empresa>();
        }

        public List<Empresa> obtenerEmpresas()
        {
            listaEmpresas = _contexto.Empresas.OrderBy(a => a.Nombre).ToList();
            return listaEmpresas;
        }

        public Empresa obtenerEmpresa(int id)
        {
            var empresa = _contexto.Empresas.Find(id);
            return empresa;
        }

        public void guardarEmpresa(Empresa empresa)
        {
            if (empresa.Id == 0)
            {
                _contexto.Empresas.Add(empresa);
            }else
            {
                var empresaExistente = _contexto.Empresas.Find(empresa.Id);
                empresaExistente.Nombre = empresa.Nombre;
                empresaExistente.Disponible = empresa.Disponible;
            }

            _contexto.SaveChanges();
        }
    }
}
