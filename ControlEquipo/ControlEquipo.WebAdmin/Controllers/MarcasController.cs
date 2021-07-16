using ControlEquipo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEquipo.WebAdmin.Controllers
{
    public class MarcasController : Controller
    {
        MarcaBL _marcaBL;
        List<Marca> listaMarcas;
        public MarcasController()
        {
            _marcaBL = new MarcaBL();
            listaMarcas = new List<Marca>();
        }

        // GET: Empresas
        public ActionResult Index()
        {
            listaMarcas = _marcaBL.obtenerMarcas();
            return View(listaMarcas);
        }

        public ActionResult Crear()
        {
            var nuevaMarca = new Marca();

            return View(nuevaMarca);
        }

        [HttpPost]
        public ActionResult Crear(Marca marca)
        {
            if (ModelState.IsValid)
            {

                if (marca.Nombre != marca.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al inicio ni al final");
                    return View(marca);
                }
                _marcaBL.guardarMarca(marca);
                return RedirectToAction("Index");
            }

            return View(marca);
        }

        public ActionResult Editar(int id)
        {
            var marca = _marcaBL.obtenerMarca(id);

            return View(marca);
        }

        [HttpPost]
        public ActionResult Editar(Marca marca)
        {
            if (ModelState.IsValid)
            {
                if (marca.Nombre != marca.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al inicio ni al final");
                    return View(marca);
                }

                _marcaBL.guardarMarca(marca);
                return RedirectToAction("Index");
            }
            return View(marca);
        }
    }
}