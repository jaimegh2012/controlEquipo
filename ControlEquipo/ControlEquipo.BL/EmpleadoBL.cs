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
            listaEmpleados = _contexto.Empleados.Include("Oficina").Include("Area").OrderBy(a => a.Nombres).ToList();
            return listaEmpleados;
        }

        public Empleado obtenerEmpleado(int id)
        {
            var empleado = _contexto.Empleados.Include("Area").Include("Oficina").FirstOrDefault(a => a.Id == id);
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
                empleadoExistente.OficinaId = empleado.OficinaId;
                empleadoExistente.Disponible = empleado.Disponible;

            }

            _contexto.SaveChanges();

        }
    }
}
