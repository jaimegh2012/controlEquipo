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

        }


        #region FUNCIONES
        #endregion
        // GET: Oficinas
        public ActionResult Index()
        {
            listaComputadoras = _computadoraBL.obtenerComputadoras();
            return View(listaComputadoras);
        }

        public ActionResult Crear()
        {
            var nuevaComputadora = new Computadora();
            var marcas = _marcaBL.obtenerMarcas();
            var Procesadores = _procesadorBL.obtenerProcesadores();
            var tiposMemorias = _tipoMemoriaBL.obtenerTipoMemorias();
            var tipoComputadoras = _tipoComputadoraBL.obtenerTipoComputadoras();
            var tipoDiscos = _tipoDiscoBL.obtenerTipoDiscos();
            var empleados = _empleadoBL.obtenerEmpleados();

            ViewBag.MarcaId = new SelectList(marcas, "Id", "Nombre");
            ViewBag.ProcesadorId = new SelectList(Procesadores, "Id", "Nombre");
            ViewBag.TipoMemoriaId = new SelectList(tiposMemorias, "Id", "Nombre");
            ViewBag.TipoComputadoraId = new SelectList(tipoComputadoras, "Id", "Nombre");
            ViewBag.TipoDiscoId = new SelectList(tipoDiscos, "Id", "Nombre");
            ViewBag.EmpleadoId = new SelectList(empleados, "Id", "Nombres");

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
                return RedirectToAction("Index");
            }

            ViewBag.MarcaId = new SelectList(marcas, "Id", "Nombre");
            ViewBag.ProcesadorId = new SelectList(Procesadores, "Id", "Nombre");
            ViewBag.TipoMemoriaId = new SelectList(tiposMemorias, "Id", "Nombre");
            ViewBag.TipoComputadoraId = new SelectList(tipoComputadoras, "Id", "Nombre");
            ViewBag.TipoDiscoId = new SelectList(tipoDiscos, "Id", "Nombre");

            return View(computadora);
        }


        /*public ActionResult Editar(int id)
        {
            var oficina = _oficinaBL.obtenerOficina(id);
            var empresas = _empresaBL.obtenerEmpresas();
            var ciudades = _ciudadBL.obtenerCiudades();

            ViewBag.EmpresaId = new SelectList(empresas, "Id", "Nombre", oficina.EmpresaId);
            ViewBag.CiudadId = new SelectList(ciudades, "Id", "Nombre", oficina.CiudadId);

            return View(oficina);
        }

        [HttpPost]
        public ActionResult Editar(Oficina oficina)
        {
            var empresas = _empresaBL.obtenerEmpresas();
            var ciudades = _ciudadBL.obtenerCiudades();

            if (ModelState.IsValid)
            {
                if (oficina.Nombre != oficina.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al incio ni al final");

                    ViewBag.EmpresaId = new SelectList(empresas, "Id", "Nombre", oficina.EmpresaId);
                    ViewBag.CiudadId = new SelectList(ciudades, "Id", "Nombre", oficina.CiudadId);

                    return View(oficina);
                }

                if (oficina.EmpresaId == 0 || oficina.CiudadId == 0)
                {
                    if (oficina.EmpresaId == 0)
                    {
                        ModelState.AddModelError("Empresa", "Seleccione una empresa");
                    }

                    if (oficina.CiudadId == 0)
                    {
                        ModelState.AddModelError("Ciudad", "Seleccione una ciudad");
                    }

                    ViewBag.EmpresaId = new SelectList(empresas, "Id", "Nombre", oficina.EmpresaId);
                    ViewBag.CiudadId = new SelectList(ciudades, "Id", "Nombre", oficina.CiudadId);
                    return View(oficina);
                }

                _oficinaBL.guardarOficina(oficina);
                return RedirectToAction("Index");
            }

            ViewBag.EmpresaId = new SelectList(empresas, "Id", "Nombre", oficina.EmpresaId);
            ViewBag.CiudadId = new SelectList(ciudades, "Id", "Nombre", oficina.CiudadId);

            return View(oficina);
        }*/
    }
}