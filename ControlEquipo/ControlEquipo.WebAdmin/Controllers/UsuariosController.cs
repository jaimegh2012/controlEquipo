using ControlEquipo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEquipo.WebAdmin.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        UsuarioBL _usuarioBL;
        EmpleadoBL _empleadoBL;
        SeguridadBL _seguridadBL;
        List<Usuario> listaUsuarios;



        public UsuariosController()
        {
            _usuarioBL = new UsuarioBL();
            _empleadoBL = new EmpleadoBL();
            _seguridadBL = new SeguridadBL();
            listaUsuarios = new List<Usuario>();
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            listaUsuarios = _usuarioBL.obtenerUsuarios();
            return View(listaUsuarios);
        }

        public ActionResult Crear()
        {
            var nuevoUsuario = new Usuario();
           

            return View(nuevoUsuario);
        }

        [HttpPost]
        public ActionResult Crear(Usuario usuario)
        {
           
            if (ModelState.IsValid)
            {
                if (usuario.Nombre != usuario.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al incio ni al final");

                    return View(usuario);
                }

                if (usuario.Password == null)
                {
                    ModelState.AddModelError("Password", "Ingrese una contraseña");

                    return View(usuario);
                }

                if (usuario.Password != usuario.Password.Trim())
                {
                    ModelState.AddModelError("Password", "No debe haber espacios al incio ni al final");

                    return View(usuario);
                }


                usuario.Password = Encriptar.CodificarContrasena(usuario.Password);
                _usuarioBL.guardarUsuario(usuario);
                return RedirectToAction("Index");
            }

           
            return View(usuario);
        }

        public ActionResult Editar(int id)
        {
            var usuario = _usuarioBL.obtenerUsuario(id);
            TempData["password"] = usuario.Password;

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (usuario.Nombre != usuario.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al incio ni al final");

                    return View(usuario);
                }

                if (usuario.Password != null)
                {
                    if (usuario.Password != usuario.Password.Trim())
                    {
                        ModelState.AddModelError("Password", "No debe haber espacios al incio ni al final");

                        return View(usuario);
                    }

                    //si la contraseña no viene nula, significa que fue cambiada y debe encriptarse
                    usuario.Password = Encriptar.CodificarContrasena(usuario.Password); 
                }
                else //si contraseña viene nula, significa que no se cambio la contraseña y por eso se deja la que ya estaba y no se encripta.
                {
                    usuario.Password = TempData["password"].ToString();
                }

                

                _usuarioBL.guardarUsuario(usuario);
                return RedirectToAction("Index");
            }


            return View(usuario);
        }
    }
}