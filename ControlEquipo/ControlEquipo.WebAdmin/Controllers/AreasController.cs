using ControlEquipo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEquipo.WebAdmin.Controllers
{
    public class AreasController : Controller
    {
        AreaBL _areasBL;
        List<Area> listaAreas;

        public AreasController()
        {
            _areasBL = new AreaBL();
            listaAreas = new List<Area>();
        }

        // GET: Areas
        public ActionResult Index()
        {
            listaAreas = _areasBL.obtenerAreas();

            return View(listaAreas);
        }

        public ActionResult Crear()
        {
            var nuevaArea = new Area();

            return View(nuevaArea);
        }

        [HttpPost]
        public ActionResult Crear(Area area)
        {
            if (ModelState.IsValid)
            {
                if (area.Nombre != area.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al incio ni al final");
                    return View(area);
                }
                _areasBL.guardarArea(area);
                return RedirectToAction("Index");
            }

            return View(area);
        }

        public ActionResult Editar(int id)
        {
            var area = _areasBL.obtenerArea(id);

            return View(area);
        }

        [HttpPost]
        public ActionResult Editar(Area area)
        {
            if (ModelState.IsValid)
            {
                if (area.Nombre != area.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al inicio ni al final");
                    return View(area);
                }
                _areasBL.guardarArea(area);
                return RedirectToAction("Index");
            }

            return View(area);
        }

        public ActionResult Detalle(int id)
        {
            var area = _areasBL.obtenerArea(id);
            return View(area);
        }
    }
}