using ControlEquipo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ControlEquipo.WebAdmin.Controllers
{
    public class InicioSesionController : Controller
    {
        SeguridadBL _seguridad;
        public InicioSesionController()
        {
            _seguridad = new SeguridadBL();
        }
        // GET: login
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection data)
        {
            var correo = data["username"];
            var contrasena = data["password"];

            var UsuarioValido = _seguridad.Autorizar(correo, contrasena);

            if (UsuarioValido)
            {
                FormsAuthentication.SetAuthCookie(correo, true);
                return RedirectToAction("Index", "Home");

            }
            ModelState.AddModelError("", "usuario o contraseña invalida");

            return View();
        }
    }
}