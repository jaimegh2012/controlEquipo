using ControlEquipo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEquipo.WebAdmin.Controllers
{
    [Authorize]
    public class EmpresasController : Controller
    {
        EmpresaBL _empresaBL;
        List<Empresa> listaEmpresas;
        public EmpresasController()
        {
            _empresaBL = new EmpresaBL();
            listaEmpresas = new List<Empresa>();
        }

        // GET: Empresas
        public ActionResult Index()
        {
            listaEmpresas = _empresaBL.obtenerEmpresas();
            return View(listaEmpresas);
        }

        public ActionResult Crear()
        {
            var nuevaEmpresa = new Empresa();

            return View(nuevaEmpresa);
        }

        [HttpPost]
        public ActionResult Crear(Empresa empresa)
        {
            if (ModelState.IsValid)
            {

                if (empresa.Nombre != empresa.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al inicio ni al final");
                    return View(empresa);
                }
                _empresaBL.guardarEmpresa(empresa);
                return RedirectToAction("Index");
            }

            return View(empresa);
        }

        public ActionResult Editar(int id)
        {
            var empresa = _empresaBL.obtenerEmpresa(id);

            return View(empresa);
        }

        [HttpPost]
        public ActionResult Editar(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                if (empresa.Nombre != empresa.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al inicio ni al final");
                    return View(empresa);
                }

                _empresaBL.guardarEmpresa(empresa);
                return RedirectToAction("Index");
            }
            return View(empresa);
        }

    }
}