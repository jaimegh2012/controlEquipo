using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class UsuarioBL
    {
        Contexto _contexto;
        List<Usuario> listaUsuarios;

        public UsuarioBL()
        {
            _contexto = new Contexto();
            listaUsuarios = new List<Usuario>();
        }

        public List<Usuario> obtenerUsuarios()
        {
            listaUsuarios = _contexto.Usuarios.OrderBy(a => a.Nombre).ToList();
            return listaUsuarios;
        }

        public Usuario obtenerUsuario(int id)
        {
            var usuario = _contexto.Usuarios.Find(id);
            return usuario;
        }

        public void guardarUsuario(Usuario usuario)
        {
            if (usuario.Id == 0)
            {
                _contexto.Usuarios.Add(usuario);
            }
            else
            {
                var usuarioExistente = _contexto.Usuarios.Find(usuario.Id);
                usuarioExistente.Password = usuario.Password;
                usuarioExistente.Nombre = usuario.Nombre;
                usuarioExistente.Correo = usuario.Correo;
                usuarioExistente.Disponible = usuario.Disponible;
            }

            _contexto.SaveChanges();
        }
    }
}
