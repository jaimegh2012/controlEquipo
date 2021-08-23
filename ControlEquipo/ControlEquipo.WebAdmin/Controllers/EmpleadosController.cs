using ControlEquipo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEquipo.WebAdmin.Controllers
{
    [Authorize]
    public class EmpleadosController : Controller
    {
        EmpleadoBL _empleadoBL;
        AreaBL _areaBL;
        EmpresaBL _empresaBL;
        CiudadBL _ciudadBL;
        ComputadoraBL _computadoraBL;
        MarcaBL _marcaBL;
        ProcesadorBL _procesadorBL;
        TipoMemoriaBL _tipoMemoriaBL;
        TipoComputadoraBL _tipoComputadoraBL;
        TipoDiscoBL _tipoDiscoBL;

        int _empleadoId = 0;

        List<Empleado> listaEmpleados;

        public EmpleadosController()
        {
            _empleadoBL = new EmpleadoBL();
            _areaBL = new AreaBL();
            _empresaBL = new EmpresaBL();
            _ciudadBL = new CiudadBL();
            _marcaBL = new MarcaBL();
            _procesadorBL = new ProcesadorBL();
            _tipoMemoriaBL = new TipoMemoriaBL();
            _tipoComputadoraBL = new TipoComputadoraBL();
            _tipoDiscoBL = new TipoDiscoBL();
            _computadoraBL = new ComputadoraBL();
            listaEmpleados = new List<Empleado>();
        }

        // GET: Empleados
        public ActionResult Index(string nombre)
        {
            listaEmpleados = _empleadoBL.obtenerEmpleadosPorNombre(nombre);

            return View(listaEmpleados);
        }

        public ActionResult ComputadorasAsignadas(int empleadoId)
        {
            var empleado = _empleadoBL.obtenerEmpleado(empleadoId);
            var listaComputadoras = _computadoraBL.obtenerComputadorasPorEmpleado(empleadoId);
            ViewBag.EmpleadoId = empleadoId;
            ViewBag.nombreEmpleado = empleado.Nombres + " " + empleado.Apellidos;
            return View(listaComputadoras);
        }

        public ActionResult EditarComputadoraAsignada(int id, int empleadoId)
        {
            TempData["empleadoId"] = empleadoId;
            var computadora = _computadoraBL.obtenerComputadora(id);
            var marcas = _marcaBL.obtenerMarcas();
            var Procesadores = _procesadorBL.obtenerProcesadores();
            var tiposMemorias = _tipoMemoriaBL.obtenerTipoMemorias();
            var tipoComputadoras = _tipoComputadoraBL.obtenerTipoComputadoras();
            var tipoDiscos = _tipoDiscoBL.obtenerTipoDiscos();
            var empleados = _empleadoBL.obtenerEmpleados();


            ViewBag.MarcaId = new SelectList(marcas, "Id", "Nombre", computadora.MarcaId);
            ViewBag.ProcesadorId = new SelectList(Procesadores, "Id", "Nombre", computadora.ProcesadorId);
            ViewBag.TipoMemoriaId = new SelectList(tiposMemorias, "Id", "Nombre", computadora.TipoMemoriaId);
            ViewBag.TipoComputadoraId = new SelectList(tipoComputadoras, "Id", "Nombre", computadora.TipoComputadoraId);
            ViewBag.TipoDiscoId = new SelectList(tipoDiscos, "Id", "Nombre", computadora.TipoDiscoId);
            ViewBag.EmpleadoId = new SelectList(empleados, "Id", "NombreCompleto", computadora.EmpleadoId);
            return View(computadora);
        }

        [HttpPost]
        public ActionResult EditarComputadoraAsignada(Computadora computadora)
        {
            var marcas = _marcaBL.obtenerMarcas();
            var Procesadores = _procesadorBL.obtenerProcesadores();
            var tiposMemorias = _tipoMemoriaBL.obtenerTipoMemorias();
            var tipoComputadoras = _tipoComputadoraBL.obtenerTipoComputadoras();
            var tipoDiscos = _tipoDiscoBL.obtenerTipoDiscos();
            var empleados = _empleadoBL.obtenerEmpleados();
            var empleado = _empleadoBL.obtenerEmpleado(computadora.EmpleadoId);


            if (ModelState.IsValid)
            {


                if (computadora.TipoComputadoraId == 0 || computadora.TipoDiscoId == 0 || computadora.ProcesadorId == 0 || computadora.TipoMemoriaId == 0)
                {
                    if (computadora.TipoComputadoraId == 0)
                    {
                        ModelState.AddModelError("TipoComputadora", "Seleccione un tipo de computadora");
                    }

                    if (computadora.TipoDiscoId == 0)
                    {
                        ModelState.AddModelError("TipoDisco", "Seleccione un tipo de disco");
                    }

                    if (computadora.ProcesadorId == 0)
                    {
                        ModelState.AddModelError("Procesador", "Seleccione un tipo de procesador");
                    }

                    if (computadora.TipoMemoriaId == 0)
                    {
                        ModelState.AddModelError("TipoMemoria", "Seleccione un tipo de memoria");
                    }

                    ViewBag.MarcaId = new SelectList(marcas, "Id", "Nombre", computadora.MarcaId);
                    ViewBag.ProcesadorId = new SelectList(Procesadores, "Id", "Nombre", computadora.ProcesadorId);
                    ViewBag.TipoMemoriaId = new SelectList(tiposMemorias, "Id", "Nombre", computadora.TipoMemoriaId);
                    ViewBag.TipoComputadoraId = new SelectList(tipoComputadoras, "Id", "Nombre", computadora.TipoComputadoraId);
                    ViewBag.TipoDiscoId = new SelectList(tipoDiscos, "Id", "Nombre", computadora.TipoDiscoId);
                    ViewBag.EmpleadoId = new SelectList(empleados, "Id", "NombreCompleto", computadora.EmpleadoId);

                    return View(computadora);
                }

                computadora.FechaUltimaActualiacion = DateTime.Now;
                _computadoraBL.guardarComputadora(computadora);
                return RedirectToAction("ComputadorasAsignadas", "Empleados", new {empleadoId = TempData["empleadoId"] });
            }

            ViewBag.MarcaId = new SelectList(marcas, "Id", "Nombre", computadora.MarcaId);
            ViewBag.ProcesadorId = new SelectList(Procesadores, "Id", "Nombre", computadora.ProcesadorId);
            ViewBag.TipoMemoriaId = new SelectList(tiposMemorias, "Id", "Nombre", computadora.TipoMemoriaId);
            ViewBag.TipoComputadoraId = new SelectList(tipoComputadoras, "Id", "Nombre", computadora.TipoComputadoraId);
            ViewBag.TipoDiscoId = new SelectList(tipoDiscos, "Id", "Nombre", computadora.TipoDiscoId);
            ViewBag.EmpleadoId = new SelectList(empleados, "Id", "NombreCompleto", computadora.EmpleadoId);

            return View(computadora);
        }

        public ActionResult DetalleComputadoraAsignada(int id)
        {
            var computadora = _computadoraBL.obtenerComputadora(id);

            return View(computadora);
        }

        public ActionResult Crear()
        {
            var nuevoEmpleado = new Empleado();
            var areas = _areaBL.obtenerAreas();
            var empresas = _empresaBL.obtenerEmpresas();
            var ciudades = _ciudadBL.obtenerCiudades();

            ViewBag.AreaId = new SelectList(areas, "Id", "Nombre");
            ViewBag.EmpresaId = new SelectList(empresas, "Id", "Nombre");
            ViewBag.CiudadId = new SelectList(ciudades, "Id", "Nombre");

            return View(nuevoEmpleado);
        }

        [HttpPost]
        public ActionResult Crear(Empleado empleado)
        {
            var areas = _areaBL.obtenerAreas();
            var empresas = _empresaBL.obtenerEmpresas();
            var ciudades = _ciudadBL.obtenerCiudades();

            if (ModelState.IsValid)
            {
                if (empleado.Nombres != empleado.Nombres.Trim())
                {
                    ModelState.AddModelError("Nombres", "No debe haber espacios al inicio ni al final");

                    ViewBag.AreaId = new SelectList(areas, "Id", "Nombre");
                    ViewBag.EmpresaId = new SelectList(empresas, "Id", "Nombre");
                    ViewBag.CiudadId = new SelectList(ciudades, "Id", "Nombre");

                    return View(empleado);
                }

                if (empleado.Apellidos != empleado.Apellidos.Trim())
                {
                    ModelState.AddModelError("Apellidos", "No debe haber espacios al inicio ni al final");

                    ViewBag.AreaId = new SelectList(areas, "Id", "Nombre");
                    ViewBag.EmpresaId = new SelectList(empresas, "Id", "Nombre");
                    ViewBag.CiudadId = new SelectList(ciudades, "Id", "Nombre");

                    return View(empleado);
                }

                _empleadoBL.guardarEmpleado(empleado);
                return RedirectToAction("Index");
            }

            ViewBag.AreaId = new SelectList(areas, "Id", "Nombre");
            ViewBag.EmpresaId = new SelectList(empresas, "Id", "Nombre");
            ViewBag.CiudadId = new SelectList(ciudades, "Id", "Nombre");

            return View(empleado);
        }

        public ActionResult Editar(int id)
        {
            var empleado = _empleadoBL.obtenerEmpleado(id);
            var areas = _areaBL.obtenerAreas();
            var empresas = _empresaBL.obtenerEmpresas();
            var ciudades = _ciudadBL.obtenerCiudades();

            ViewBag.AreaId = new SelectList(areas, "Id", "Nombre", empleado.AreaId);
            ViewBag.EmpresaId = new SelectList(empresas, "Id", "Nombre", empleado.EmpresaId);
            ViewBag.CiudadId = new SelectList(ciudades, "Id", "Nombre", empleado.CiudadId);

            return View(empleado);
        }

        [HttpPost]
        public ActionResult Editar(Empleado empleado)
        {
            var areas = _areaBL.obtenerAreas();
            var empresas = _empresaBL.obtenerEmpresas();
            var ciudades = _ciudadBL.obtenerCiudades();

            if (ModelState.IsValid)
            {
                if (empleado.Nombres != empleado.Nombres.Trim())
                {
                    ModelState.AddModelError("Nombres", "No debe haber espacios al inicio ni al final");

                    ViewBag.AreaId = new SelectList(areas, "Id", "Nombre", empleado.AreaId);
                    ViewBag.EmpresaId = new SelectList(empresas, "Id", "Nombre", empleado.EmpresaId);
                    ViewBag.CiudadId = new SelectList(ciudades, "Id", "Nombre", empleado.CiudadId);

                    return View(empleado);
                }

                if (empleado.Apellidos != empleado.Apellidos.Trim())
                {
                    ModelState.AddModelError("Apellidos", "No debe haber espacios al inicio ni al final");

                    ViewBag.AreaId = new SelectList(areas, "Id", "Nombre", empleado.AreaId);
                    ViewBag.EmpresaId = new SelectList(empresas, "Id", "Nombre", empleado.EmpresaId);
                    ViewBag.CiudadId = new SelectList(ciudades, "Id", "Nombre", empleado.CiudadId);

                    return View(empleado);
                }

                _empleadoBL.guardarEmpleado(empleado);
                return RedirectToAction("Index");
            }
            ViewBag.AreaId = new SelectList(areas, "Id", "Nombre", empleado.AreaId);
            ViewBag.EmpresaId = new SelectList(empresas, "Id", "Nombre", empleado.EmpresaId);
            ViewBag.CiudadId = new SelectList(ciudades, "Id", "Nombre", empleado.CiudadId);

            return View(empleado);
        }

        public ActionResult Detalle(int id)
        {
            var empleado = _empleadoBL.obtenerEmpleado(id);

            return View(empleado);
        }

    }
}