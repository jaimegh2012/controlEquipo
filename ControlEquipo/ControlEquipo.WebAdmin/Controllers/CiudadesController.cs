using ControlEquipo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEquipo.WebAdmin.Controllers
{
    public class CiudadesController : Controller
    {
        CiudadBL _ciudadBL;
        List<Ciudad> listaCiudades;

        public CiudadesController()
        {
            _ciudadBL = new CiudadBL();
            listaCiudades = new List<Ciudad>();
        }

        // GET: Ciudades
        public ActionResult Index()
        {
            listaCiudades = _ciudadBL.obtenerCiudades();
            return View(listaCiudades);
        }

        public ActionResult Crear()
        {
            var nuevaCiudad = new Ciudad();

            return View(nuevaCiudad);
        }

        [HttpPost]
        public ActionResult Crear(Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {

                if (ciudad.Nombre != ciudad.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al inicio ni al final");
                    return View(ciudad);
                }
                _ciudadBL.guardarCiudad(ciudad);
                return RedirectToAction("Index");
            }

            return View(ciudad);
        }

        public ActionResult Editar(int id)
        {
            var ciudad = _ciudadBL.obtenerCiudad(id);

            return View(ciudad);
        }

        [HttpPost]
        public ActionResult Editar(Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                if (ciudad.Nombre != ciudad.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al inicio ni al final");
                    return View(ciudad);
                }

                _ciudadBL.guardarCiudad(ciudad);
                return RedirectToAction("Index");
            }
            return View(ciudad);
        }
    }
}