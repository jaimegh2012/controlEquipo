using ControlEquipo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEquipo.WebAdmin.Controllers
{
    public class ComputadorasController : Controller
    {
        ComputadoraBL _computadoraBL;
        MarcaBL _marcaBL;
        ProcesadorBL _procesadorBL;
        TipoMemoriaBL _tipoMemoriaBL;
        TipoComputadoraBL _tipoComputadoraBL;
        TipoDiscoBL _tipoDiscoBL;
        EmpleadoBL _empleadoBL;
        AccesorioBL _accesorioBL;
        TipoAccesorioBL _tipoAccesorioBL;

        List<Computadora> listaComputadoras;

        public ComputadorasController()
        {
            _computadoraBL = new ComputadoraBL();
            _marcaBL = new MarcaBL();
            _procesadorBL = new ProcesadorBL();
            _tipoMemoriaBL = new TipoMemoriaBL();
            _tipoComputadoraBL = new TipoComputadoraBL();
            _tipoDiscoBL = new TipoDiscoBL();
            _empleadoBL = new EmpleadoBL();
            _accesorioBL = new AccesorioBL();
            _tipoAccesorioBL = new TipoAccesorioBL();

        }


        #region FUNCIONES
        #endregion
        // GET: Oficinas
        public ActionResult Index(bool disponible, int tipoComputadoraId)
        {
            var tiposComputadora = new List<TipoComputadora>();
            var tipoComputadora = new TipoComputadora();
            tipoComputadora.Id = 0;
            tipoComputadora.Nombre = "---Todos---";

            tiposComputadora = _tipoComputadoraBL.obtenerTipoComputadoras();
            tiposComputadora.Insert(0, tipoComputadora);
            ViewBag.tipoComputadoraId = new SelectList(tiposComputadora, "Id", "Nombre");

            listaComputadoras = _computadoraBL.obtenerComputadorasDisponiblesPorTipo(disponible, tipoComputadoraId);
            return View(listaComputadoras);
        }

        public ActionResult AccesoriosAsignados(int computadoraId, int empleadoId) //si empleadoId viene con valor 0, significa que fue llamado desde computadoras
        {
            var listaAccesorios = _accesorioBL.obtenerAccesoriosPorComputadora(computadoraId);
            ViewBag.ComputadoraId = computadoraId;

            var computadora = _computadoraBL.obtenerComputadora(computadoraId);
            ViewBag.empleadoId = empleadoId;

            return View(listaAccesorios);
        }

        public ActionResult EditarAccesorioAsignado(int id)
        {
            var accesorio = _accesorioBL.obtenerAccesorio(id);
            var tiposAccesorios = _tipoAccesorioBL.obtenerTiposAccesorio();
            var marcas = _marcaBL.obtenerMarcas();
            var computadoras = _computadoraBL.obtenerComputadoras();

            ViewBag.TipoAccesorioId = new SelectList(tiposAccesorios, "Id", "Nombre", accesorio.TipoAccesorioId);
            ViewBag.IdMarca = new SelectList(marcas, "Id", "Nombre", accesorio.IdMarca);
            ViewBag.ComputadoraId = new SelectList(computadoras, "Id", "Hostname", accesorio.ComputadoraId);

            return View(accesorio);
        }

        [HttpPost]
        public ActionResult EditarAccesorioAsignado(Accesorio accesorio)
        {
            var tiposAccesorios = _tipoAccesorioBL.obtenerTiposAccesorio();
            var marcas = _marcaBL.obtenerMarcas();
            var computadoras = _computadoraBL.obtenerComputadoras();

            if (ModelState.IsValid)
            {

                if (accesorio.TipoAccesorioId == 0 || accesorio.IdMarca == 0)
                {
                    if (accesorio.TipoAccesorioId == 0)
                    {
                        ModelState.AddModelError("Empresa", "Seleccione una empresa");
                    }

                    if (accesorio.IdMarca == 0)
                    {
                        ModelState.AddModelError("Ciudad", "Seleccione una ciudad");
                    }

                    ViewBag.TipoAccesorioId = new SelectList(tiposAccesorios, "Id", "Nombre", accesorio.TipoAccesorioId);
                    ViewBag.IdMarca = new SelectList(marcas, "Id", "Nombre", accesorio.IdMarca);
                    ViewBag.ComputadoraId = new SelectList(computadoras, "Id", "Hostname", accesorio.ComputadoraId);

                    return View(accesorio);
                }


                _accesorioBL.guardarAccesorio(accesorio);
                return RedirectToAction("AccesoriosAsignados", "Computadoras", new {computadoraId = accesorio.ComputadoraId });
            }

            ViewBag.TipoAccesorioId = new SelectList(tiposAccesorios, "Id", "Nombre", accesorio.TipoAccesorioId);
            ViewBag.IdMarca = new SelectList(marcas, "Id", "Nombre", accesorio.IdMarca);
            ViewBag.ComputadoraId = new SelectList(computadoras, "Id", "Hostname", accesorio.ComputadoraId);

            return View(accesorio);
        }

        public ActionResult DetalleAccesorioAsignado(int id)
        {
            var accesorio = _accesorioBL.obtenerAccesorio(id);

            return View(accesorio);
        }

        public ActionResult Crear(int empleadoId)
        {
            var nuevaComputadora = new Computadora();
            var marcas = _marcaBL.obtenerMarcas();
            var Procesadores = _procesadorBL.obtenerProcesadores();
            var tiposMemorias = _tipoMemoriaBL.obtenerTipoMemorias();
            var tipoComputadoras = _tipoComputadoraBL.obtenerTipoComputadoras();
            var tipoDiscos = _tipoDiscoBL.obtenerTipoDiscos();
            

            ViewBag.MarcaId = new SelectList(marcas, "Id", "Nombre");
            ViewBag.ProcesadorId = new SelectList(Procesadores, "Id", "Nombre");
            ViewBag.TipoMemoriaId = new SelectList(tiposMemorias, "Id", "Nombre");
            ViewBag.TipoComputadoraId = new SelectList(tipoComputadoras, "Id", "Nombre");
            ViewBag.TipoDiscoId = new SelectList(tipoDiscos, "Id", "Nombre");

            //consultar el empleado y asignarselo al objeto de tipo computadora, para utilizarlo en la vista
            var Empleado = _empleadoBL.obtenerEmpleado(empleadoId);
            nuevaComputadora.EmpleadoId = empleadoId;
            nuevaComputadora.Empleado = Empleado;

            return View(nuevaComputadora);
        }

        [HttpPost]
        public ActionResult Crear(Computadora computadora)
        {
            var marcas = _marcaBL.obtenerMarcas();
            var Procesadores = _procesadorBL.obtenerProcesadores();
            var tiposMemorias = _tipoMemoriaBL.obtenerTipoMemorias();
            var tipoComputadoras = _tipoComputadoraBL.obtenerTipoComputadoras();
            var tipoDiscos = _tipoDiscoBL.obtenerTipoDiscos();


            if (ModelState.IsValid)
            {

                if (computadora.MarcaId == 0 || computadora.ProcesadorId == 0 || computadora.TipoMemoriaId == 0)
                {
                    if (computadora.MarcaId == 0)
                    {
                        ModelState.AddModelError("Marca", "Seleccione una marca");
                    }

                    if (computadora.ProcesadorId == 0)
                    {
                        ModelState.AddModelError("Procesador", "Seleccione un procesador");
                    }

                    if (computadora.TipoMemoriaId == 0)
                    {
                        ModelState.AddModelError("TipoMemoria", "Seleccione un tipo de memoria");
                    }

                    ViewBag.MarcaId = new SelectList(marcas, "Id", "Nombre");
                    ViewBag.ProcesadorId = new SelectList(Procesadores, "Id", "Nombre");
                    ViewBag.TipoMemoriaId = new SelectList(tiposMemorias, "Id", "Nombre");
                    ViewBag.TipoComputadoraId = new SelectList(tipoComputadoras, "Id", "Nombre");
                    ViewBag.TipoDiscoId = new SelectList(tipoDiscos, "Id", "Nombre");

                    return View(computadora);
                }

                _computadoraBL.guardarComputadora(computadora);
                return RedirectToAction("ComputadorasAsignadas", "Empleados", new {empleadoId = computadora.EmpleadoId});
            }

            ViewBag.MarcaId = new SelectList(marcas, "Id", "Nombre");
            ViewBag.ProcesadorId = new SelectList(Procesadores, "Id", "Nombre");
            ViewBag.TipoMemoriaId = new SelectList(tiposMemorias, "Id", "Nombre");
            ViewBag.TipoComputadoraId = new SelectList(tipoComputadoras, "Id", "Nombre");
            ViewBag.TipoDiscoId = new SelectList(tipoDiscos, "Id", "Nombre");

            return View(computadora);
        }


        public ActionResult Editar(int id)
        {
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
            ViewBag.EmpleadoId = new SelectList(empleados, "Id", "Nombres", computadora.EmpleadoId);

            return View(computadora);
        }

        [HttpPost]
        public ActionResult Editar(Computadora computadora)
        {
            var marcas = _marcaBL.obtenerMarcas();
            var Procesadores = _procesadorBL.obtenerProcesadores();
            var tiposMemorias = _tipoMemoriaBL.obtenerTipoMemorias();
            var tipoComputadoras = _tipoComputadoraBL.obtenerTipoComputadoras();
            var tipoDiscos = _tipoDiscoBL.obtenerTipoDiscos();
            var empleados = _empleadoBL.obtenerEmpleados();


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
                    ViewBag.EmpleadoId = new SelectList(empleados, "Id", "Nombres", computadora.EmpleadoId);

                    return View(computadora);
                }

                computadora.FechaUltimaActualiacion = DateTime.Now;
                _computadoraBL.guardarComputadora(computadora);
                return RedirectToAction("Index", "Computadoras", new {disponible = true, tipoComputadoraId = 0 });
            }

            ViewBag.MarcaId = new SelectList(marcas, "Id", "Nombre", computadora.MarcaId);
            ViewBag.ProcesadorId = new SelectList(Procesadores, "Id", "Nombre", computadora.ProcesadorId);
            ViewBag.TipoMemoriaId = new SelectList(tiposMemorias, "Id", "Nombre", computadora.TipoMemoriaId);
            ViewBag.TipoComputadoraId = new SelectList(tipoComputadoras, "Id", "Nombre", computadora.TipoComputadoraId);
            ViewBag.TipoDiscoId = new SelectList(tipoDiscos, "Id", "Nombre", computadora.TipoDiscoId);
            ViewBag.EmpleadoId = new SelectList(empleados, "Id", "Nombres", computadora.EmpleadoId);

            return View(computadora);
        }

        public ActionResult Detalle(int id)
        {
            var computadora = _computadoraBL.obtenerComputadora(id);

            return View(computadora);
        }

    }
}