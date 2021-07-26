using ControlEquipo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEquipo.WebAdmin.Controllers
{
    [Authorize]
    public class AccesoriosController : Controller
    {
        AccesorioBL _accesorioBL;
        TipoAccesorioBL _tipoAccesorioBL;
        MarcaBL _marcaBL;
        ComputadoraBL _computadoraBL;

        List<Accesorio> listaAccesorios;

        public AccesoriosController()
        {
            _accesorioBL = new AccesorioBL();
            _tipoAccesorioBL = new TipoAccesorioBL();
            _marcaBL = new MarcaBL();
            _computadoraBL = new ComputadoraBL();
            listaAccesorios = new List<Accesorio>();
        }

        // GET: Oficinas
        public ActionResult Index()
        {
            listaAccesorios = _accesorioBL.obtenerAccesorios();
            return View(listaAccesorios);
        }

        int empleado = 0;
        public ActionResult Crear(int computadoraId, int empleadoId)
        {
            TempData["empleadoId"] = empleadoId;
            empleado = empleadoId;
            var nuevoAccesorio = new Accesorio();
            var computadora = _computadoraBL.obtenerComputadora(computadoraId);
            nuevoAccesorio.ComputadoraId = computadora.Id;
            nuevoAccesorio.Computadora = computadora;


            var tiposAccesorios = _tipoAccesorioBL.obtenerTiposAccesorio();
            var marcas = _marcaBL.obtenerMarcas();

            ViewBag.TipoAccesorioId = new SelectList(tiposAccesorios, "Id", "Nombre");
            ViewBag.IdMarca = new SelectList(marcas, "Id", "Nombre");
            ViewBag.empleadoId = empleadoId;


            return View(nuevoAccesorio);
        }

        [HttpPost]
        public ActionResult Crear(Accesorio accesorio)
        {
            var tiposAccesorios = _tipoAccesorioBL.obtenerTiposAccesorio();
            var marcas = _marcaBL.obtenerMarcas();

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

                    ViewBag.TipoAccesorioId = new SelectList(tiposAccesorios, "Id", "Nombre");
                    ViewBag.IdMarca = new SelectList(marcas, "Id", "Nombre");
                    return View(accesorio);
                }

                _accesorioBL.guardarAccesorio(accesorio);
                return RedirectToAction("AccesoriosAsignados", "Computadoras", new { computadoraId = accesorio.ComputadoraId, empleadoId = TempData["empleadoId"] });
            }

            ViewBag.TipoAccesorioId = new SelectList(tiposAccesorios, "Id", "Nombre");
            ViewBag.IdMarca = new SelectList(marcas, "Id", "Nombre");

            return View(accesorio);
        }


        public ActionResult Editar(int id)
        {
            var accesorio = _accesorioBL.obtenerAccesorio(id);
            var tiposAccesorios = _tipoAccesorioBL.obtenerTiposAccesorio();
            var marcas = _marcaBL.obtenerMarcas();

            ViewBag.TipoAccesorioId = new SelectList(tiposAccesorios, "Id", "Nombre", accesorio.TipoAccesorioId);
            ViewBag.IdMarca = new SelectList(marcas, "Id", "Nombre", accesorio.IdMarca);

            return View(accesorio);
        }

        [HttpPost]
        public ActionResult Editar(Accesorio accesorio)
        {
            var tiposAccesorios = _tipoAccesorioBL.obtenerTiposAccesorio();
            var marcas = _marcaBL.obtenerMarcas();

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
                    return View(accesorio);
                }


                _accesorioBL.guardarAccesorio(accesorio);
                return RedirectToAction("Index");
            }

            ViewBag.TipoAccesorioId = new SelectList(tiposAccesorios, "Id", "Nombre", accesorio.TipoAccesorioId);
            ViewBag.IdMarca = new SelectList(marcas, "Id", "Nombre", accesorio.IdMarca);

            return View(accesorio);
        }
    }
}