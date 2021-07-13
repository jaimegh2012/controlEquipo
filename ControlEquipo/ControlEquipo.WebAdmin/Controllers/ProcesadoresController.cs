using ControlEquipo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEquipo.WebAdmin.Controllers
{
    public class ProcesadoresController : Controller
    {
        ProcesadorBL _procesadorBL;
        List<Procesador> listaProcesadores;

        public ProcesadoresController()
        {
            _procesadorBL = new ProcesadorBL();
            listaProcesadores = new List<Procesador>();
        }

        // GET: Procesador
        public ActionResult Index()
        {
            listaProcesadores = _procesadorBL.obtenerProcesadores();

            return View(listaProcesadores);
        }

        public ActionResult Crear()
        {
            var nuevoProcesador = new Procesador();

            return View(nuevoProcesador);
        }

        [HttpPost]
        public ActionResult Crear(Procesador procesador)
        {
            if (ModelState.IsValid)
            {
                if (procesador.Nombre != procesador.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al incio ni al final");
                    return View(procesador);
                }
                _procesadorBL.guardarProcesador(procesador);
                return RedirectToAction("Index");
            }

            return View(procesador);
        }

        public ActionResult Editar(int id)
        {
            var procesador = _procesadorBL.obtenerProcesador(id);

            return View(procesador);
        }

        [HttpPost]
        public ActionResult Editar(Procesador procesador)
        {
            if (ModelState.IsValid)
            {
                if (procesador.Nombre != procesador.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al inicio ni al final");
                    return View(procesador);
                }
                _procesadorBL.guardarProcesador(procesador);
                return RedirectToAction("Index");
            }

            return View(procesador);
        }


    }
}