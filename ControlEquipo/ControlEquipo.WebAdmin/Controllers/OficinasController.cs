using ControlEquipo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEquipo.WebAdmin.Controllers
{
    [Authorize]
    public class OficinasController : Controller
    {
        OficinaBL _oficinaBL;
        EmpresaBL _empresaBL;
        CiudadBL _ciudadBL;

        List<Oficina> listaOficinas;

        public OficinasController()
        {
            _oficinaBL = new OficinaBL();
            _empresaBL = new EmpresaBL();
            _ciudadBL = new CiudadBL();
            listaOficinas = new List<Oficina>();
        }

        // GET: Oficinas
        public ActionResult Index()
        {
            listaOficinas = _oficinaBL.obtenerOficinas();
            return View(listaOficinas);
        }

        public ActionResult Crear()
        {
            var nuevaOficina = new Oficina();
            var empresas = _empresaBL.obtenerEmpresas();
            var ciudades = _ciudadBL.obtenerCiudades();

            ViewBag.EmpresaId = new SelectList(empresas, "Id", "Nombre");
            ViewBag.CiudadId = new SelectList(ciudades, "Id", "Nombre");

            return View(nuevaOficina);
        }

        [HttpPost]
        public ActionResult Crear(Oficina oficina)
        {
            var empresas = _empresaBL.obtenerEmpresas();
            var ciudades = _ciudadBL.obtenerCiudades();

            if (ModelState.IsValid)
            {
                if (oficina.Nombre != oficina.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al incio ni al final");

                    ViewBag.EmpresaId = new SelectList(empresas, "Id", "Nombre");
                    ViewBag.CiudadId = new SelectList(ciudades, "Id", "Nombre");

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

                    ViewBag.EmpresaId = new SelectList(empresas, "Id", "Nombre");
                    ViewBag.CiudadId = new SelectList(ciudades, "Id", "Nombre");
                    return View(oficina);
                }

                _oficinaBL.guardarOficina(oficina);
                return RedirectToAction("Index");
            }

            ViewBag.EmpresaId = new SelectList(empresas, "Id", "Nombre");
            ViewBag.CiudadId = new SelectList(ciudades, "Id", "Nombre");

            return View(oficina);
        }


        public ActionResult Editar(int id)
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
        }

    }
}