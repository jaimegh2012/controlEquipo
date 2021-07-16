using ControlEquipo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEquipo.WebAdmin.Controllers
{
    public class EmpleadosController : Controller
    {
        EmpleadoBL _empleadoBL;
        AreaBL _areaBL;
        OficinaBL _oficinaBL;
        ComputadoraBL _computadoraBL;

        List<Empleado> listaEmpleados;

        public EmpleadosController()
        {
            _empleadoBL = new EmpleadoBL();
            _areaBL = new AreaBL();
            _oficinaBL = new OficinaBL();
            _computadoraBL = new ComputadoraBL();
            listaEmpleados = new List<Empleado>();
        }

        // GET: Empleados
        public ActionResult Index()
        {
            listaEmpleados = _empleadoBL.obtenerEmpleados();
            return View(listaEmpleados);
        }

        public ActionResult ComputadorasAsignadas(int id)
        {
            var listaComputadoras = _computadoraBL.obtenerComputadorasPorEmpleado(id);
            return View(listaComputadoras);
        }

        public ActionResult Crear()
        {
            var nuevoEmpleado = new Empleado();
            var areas = _areaBL.obtenerAreas();
            var oficinas = _oficinaBL.obtenerOficinas();

            ViewBag.AreaId = new SelectList(areas, "Id", "Nombre");
            ViewBag.OficinaId = new SelectList(oficinas, "Id", "Nombre");

            return View(nuevoEmpleado);
        }

        [HttpPost]
        public ActionResult Crear(Empleado empleado)
        {
            var areas = _areaBL.obtenerAreas();
            var oficinas = _oficinaBL.obtenerOficinas();

            if (ModelState.IsValid)
            {
                if (empleado.Nombres != empleado.Nombres.Trim())
                {
                    ModelState.AddModelError("Nombres", "No debe haber espacios al inicio ni al final");

                    ViewBag.AreaId = new SelectList(areas, "Id", "Nombre");
                    ViewBag.OficinaId = new SelectList(oficinas, "Id", "Nombre");

                    return View(empleado);
                }

                if (empleado.Apellidos != empleado.Apellidos.Trim())
                {
                    ModelState.AddModelError("Apellidos", "No debe haber espacios al inicio ni al final");

                    ViewBag.AreaId = new SelectList(areas, "Id", "Nombre");
                    ViewBag.OficinaId = new SelectList(oficinas, "Id", "Nombre");

                    return View(empleado);
                }

                _empleadoBL.guardarEmpleado(empleado);
                return RedirectToAction("Index");
            }

            ViewBag.AreaId = new SelectList(areas, "Id", "Nombre");
            ViewBag.OficinaId = new SelectList(oficinas, "Id", "Nombre");

            return View(empleado);
        }

        public ActionResult Editar(int id)
        {
            var empleado = _empleadoBL.obtenerEmpleado(id);
            var areas = _areaBL.obtenerAreas();
            var oficinas = _oficinaBL.obtenerOficinas();

            ViewBag.AreaId = new SelectList(areas, "Id", "Nombre", empleado.AreaId);
            ViewBag.OficinaId = new SelectList(oficinas, "Id", "Nombre", empleado.OficinaId);

            return View(empleado);
        }

        [HttpPost]
        public ActionResult Editar(Empleado empleado)
        {
            var areas = _areaBL.obtenerAreas();
            var oficinas = _oficinaBL.obtenerOficinas();

            if (ModelState.IsValid)
            {
                if (empleado.Nombres != empleado.Nombres.Trim())
                {
                    ModelState.AddModelError("Nombres", "No debe haber espacios al inicio ni al final");

                    ViewBag.AreaId = new SelectList(areas, "Id", "Nombre", empleado.AreaId);
                    ViewBag.OficinaId = new SelectList(oficinas, "Id", "Nombre", empleado.OficinaId);

                    return View(empleado);
                }

                if (empleado.Apellidos != empleado.Apellidos.Trim())
                {
                    ModelState.AddModelError("Apellidos", "No debe haber espacios al inicio ni al final");

                    ViewBag.AreaId = new SelectList(areas, "Id", "Nombre", empleado.AreaId);
                    ViewBag.OficinaId = new SelectList(oficinas, "Id", "Nombre", empleado.OficinaId);

                    return View(empleado);
                }

                _empleadoBL.guardarEmpleado(empleado);
                return RedirectToAction("Index");
            }
            ViewBag.AreaId = new SelectList(areas, "Id", "Nombre", empleado.AreaId);
            ViewBag.OficinaId = new SelectList(oficinas, "Id", "Nombre", empleado.OficinaId);

            return View(empleado);
        }

        public ActionResult Detalle(int id)
        {
            var empleado = _empleadoBL.obtenerEmpleado(id);

            return View(empleado);
        }

    }
}