using ControlEquipo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEquipo.WebAdmin.Controllers
{
    public class TipoMemoriasController : Controller
    {
        TipoMemoriaBL _tipoMemoriaBL;
        List<TipoMemoria> listaTipoMemorias;

        public TipoMemoriasController()
        {
            _tipoMemoriaBL = new TipoMemoriaBL();
            listaTipoMemorias = new List<TipoMemoria>();
        }

        // GET: Procesador
        public ActionResult Index()
        {
            listaTipoMemorias = _tipoMemoriaBL.obtenerTipoMemorias();

            return View(listaTipoMemorias);
        }

        public ActionResult Crear()
        {
            var nuevoTipoMemoria = new TipoMemoria();

            return View(nuevoTipoMemoria);
        }

        [HttpPost]
        public ActionResult Crear(TipoMemoria tipoMemoria)
        {
            if (ModelState.IsValid)
            {
                if (tipoMemoria.Nombre != tipoMemoria.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al incio ni al final");
                    return View(tipoMemoria);
                }
                _tipoMemoriaBL.guardarTipoMemoria(tipoMemoria);
                return RedirectToAction("Index");
            }

            return View(tipoMemoria);
        }

        public ActionResult Editar(int id)
        {
            var tipoMemoria = _tipoMemoriaBL.obtenerTipoMemoria(id);

            return View(tipoMemoria);
        }

        [HttpPost]
        public ActionResult Editar(TipoMemoria tipoMemoria)
        {
            if (ModelState.IsValid)
            {
                if (tipoMemoria.Nombre != tipoMemoria.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al inicio ni al final");
                    return View(tipoMemoria);
                }
                _tipoMemoriaBL.guardarTipoMemoria(tipoMemoria);
                return RedirectToAction("Index");
            }

            return View(tipoMemoria);
        }
    }
}