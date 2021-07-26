using ControlEquipo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEquipo.WebAdmin.Controllers
{
    [Authorize]
    public class TipoAccesoriosController : Controller
    {
        TipoAccesorioBL _tipoAccesorioBL;
        List<TipoAccesorio> listaTiposAccesorio;

        public TipoAccesoriosController()
        {
            _tipoAccesorioBL = new TipoAccesorioBL();
            listaTiposAccesorio = new List<TipoAccesorio>();
        }

        // GET: Areas
        public ActionResult Index()
        {
            listaTiposAccesorio = _tipoAccesorioBL.obtenerTiposAccesorio();

            return View(listaTiposAccesorio);
        }

        public ActionResult Crear()
        {
            var nuevoTipoAccesorio = new TipoAccesorio();

            return View(nuevoTipoAccesorio);
        }

        [HttpPost]
        public ActionResult Crear(TipoAccesorio tipoAccesorio)
        {
            if (ModelState.IsValid)
            {
                if (tipoAccesorio.Nombre != tipoAccesorio.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al incio ni al final");
                    return View(tipoAccesorio);
                }
                _tipoAccesorioBL.guardarTipoAccesorio(tipoAccesorio);
                return RedirectToAction("Index");
            }

            return View(tipoAccesorio);
        }

        public ActionResult Editar(int id)
        {
            var tipoAccesorio = _tipoAccesorioBL.obtenerTipoAccesorio(id);

            return View(tipoAccesorio);
        }

        [HttpPost]
        public ActionResult Editar(TipoAccesorio tipoAccesorio)
        {
            if (ModelState.IsValid)
            {
                if (tipoAccesorio.Nombre != tipoAccesorio.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al inicio ni al final");
                    return View(tipoAccesorio);
                }
                _tipoAccesorioBL.guardarTipoAccesorio(tipoAccesorio);
                return RedirectToAction("Index");
            }

            return View(tipoAccesorio);
        }
    }
}