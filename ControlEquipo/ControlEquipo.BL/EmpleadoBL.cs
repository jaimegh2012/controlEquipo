using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class EmpleadoBL
    {
        Contexto _contexto;
        List<Empleado> listaEmpleados;

        public EmpleadoBL()
        {
            _contexto = new Contexto();
            listaEmpleados = new List<Empleado>();
        }

        public List<Empleado> obtenerEmpleados()
        {
            listaEmpleados = _contexto.Empleados.Include("Empresa").Include("Ciudad").Include("Area")
                .OrderBy(a => a.Nombres).ToList()
                .Select(x => { x.NombreCompleto = x.Nombres + " " + x.Apellidos; return x; }).ToList(); //select se utiliza para concatenar los nombres con los apellidos del empleado y agregarlo en la propiedad NombreCompleto 
            return listaEmpleados;
        }

        public List<Empleado> obtenerEmpleadosPorNombre(string nombre)
        {
            if (nombre == null)
            {
                listaEmpleados = _contexto.Empleados.Include("Empresa").Include("Ciudad").Include("Area").OrderBy(a => a.Nombres).ToList().Select(x => { x.NombreCompleto = x.Nombres + " " + x.Apellidos; return x; }).ToList();
            }else
            {
                listaEmpleados = _contexto.Empleados.Include("Empresa").Include("Ciudad").Include("Area").Where(b => b.Nombres.Contains(nombre) || b.Apellidos.Contains(nombre)).OrderBy(a => a.Nombres).ToList().Select(x => { x.NombreCompleto = x.Nombres + " " + x.Apellidos; return x; }).ToList();

            }

            return listaEmpleados;
        }

        
        public Empleado obtenerEmpleado(int id)
        {
            var empleado = _contexto.Empleados.Include("Area").Include("Empresa").Include("Ciudad").FirstOrDefault(a => a.Id == id);
            return empleado;
        }

        public void guardarEmpleado(Empleado empleado)
        {
            if (empleado.Id == 0)
            {
                _contexto.Empleados.Add(empleado);
            }
            else
            {
                var empleadoExistente = _contexto.Empleados.Find(empleado.Id);
                empleadoExistente.Nombres = empleado.Nombres;
                empleadoExistente.Apellidos = empleado.Apellidos;
                empleadoExistente.Correo = empleado.Correo;
                empleadoExistente.Password = empleado.Password;
                empleadoExistente.AreaId = empleado.AreaId;
                empleadoExistente.EmpresaId = empleado.EmpresaId;
                empleadoExistente.CiudadId = empleado.CiudadId;
                empleadoExistente.Disponible = empleado.Disponible;

            }

            _contexto.SaveChanges();

        }
    }
}
