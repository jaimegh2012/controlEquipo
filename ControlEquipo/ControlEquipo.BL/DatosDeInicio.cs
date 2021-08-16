using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class DatosDeInicio: CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            #region TipoComputadoras
            var tipoComputadora1 = new TipoComputadora();
            tipoComputadora1.Id = 1;
            tipoComputadora1.Nombre = "Laptop";

            contexto.TipoComputadoras.Add(tipoComputadora1);

            base.Seed(contexto);

            var tipoComputadora2 = new TipoComputadora();
            tipoComputadora2.Id = 2;
            tipoComputadora2.Nombre = "Escritorio";

            contexto.TipoComputadoras.Add(tipoComputadora2);

            base.Seed(contexto);

            #endregion

            #region Tipo Discos

            var tipoDisco1 = new TipoDisco();
            tipoDisco1.Id = 1;
            tipoDisco1.Nombre = "HDD";

            contexto.TipoDiscos.Add(tipoDisco1);

            base.Seed(contexto);

            var tipoDisco2 = new TipoDisco();
            tipoDisco2.Id = 2;
            tipoDisco2.Nombre = "SSD";

            contexto.TipoDiscos.Add(tipoDisco2);

            base.Seed(contexto);

            #endregion

            #region Areas
            var area1 = new Area();
            area1.Id = 1;
            area1.Nombre = "Gerencia";

            contexto.Areas.Add(area1);

            base.Seed(contexto);

            var area2 = new Area();
            area2.Id = 2;
            area2.Nombre = "RRHH";

            contexto.Areas.Add(area2);

            base.Seed(contexto);

            #endregion

            #region Empresas
            var empresa1 = new Empresa();
            empresa1.Id = 1;
            empresa1.Nombre = "Anave";

            contexto.Empresas.Add(empresa1);

            base.Seed(contexto);


            var empresa2 = new Empresa();
            empresa2.Id = 2;
            empresa2.Nombre = "Honduras Logistic";

            contexto.Empresas.Add(empresa2);

            base.Seed(contexto);

            #endregion

            #region Ciudades
            var cidudad1 = new Ciudad();
            cidudad1.Id = 1;
            cidudad1.Nombre = "San Pedro Sula";

            contexto.Ciudades.Add(cidudad1);

            var cidudad2 = new Ciudad();
            cidudad2.Id = 2;
            cidudad2.Nombre = "Pto Cortes";

            contexto.Ciudades.Add(cidudad2);

            base.Seed(contexto);

            #endregion

            

            #region Marcas
            var marca1 = new Marca();
            marca1.Id = 1;
            marca1.Nombre = "Dell";

            contexto.Marcas.Add(marca1);

            base.Seed(contexto);

            var marca2 = new Marca();
            marca2.Id = 2;
            marca2.Nombre = "Lenovo";

            contexto.Marcas.Add(marca2);

            base.Seed(contexto);

            #endregion

            #region Procesadores
            var procesador1 = new Procesador();
            procesador1.Id = 1;
            procesador1.Nombre = "Core i5";

            contexto.Procesadores.Add(procesador1);

            base.Seed(contexto);

            var procesador2 = new Procesador();
            procesador2.Id = 2;
            procesador2.Nombre = "Core i7";

            contexto.Procesadores.Add(procesador2);

            base.Seed(contexto);

            #endregion

            #region Tipos Memoria
            var tipoMemoria1 = new TipoMemoria();
            tipoMemoria1.Id = 1;
            tipoMemoria1.Nombre = "DDR3";

            contexto.TipoMemorias.Add(tipoMemoria1);

            base.Seed(contexto);

            var tipoMemoria2 = new TipoMemoria();
            tipoMemoria2.Id = 2;
            tipoMemoria2.Nombre = "DDR4";

            contexto.TipoMemorias.Add(tipoMemoria2);

            base.Seed(contexto);

            #endregion

            #region Oficinas
            var oficina1 = new Oficina();
            oficina1.Id = 1;
            oficina1.Nombre = "Importaciones";
            oficina1.EmpresaId = 1;
            oficina1.CiudadId = 1;

            contexto.Oficinas.Add(oficina1);

            base.Seed(contexto);

            var oficina2 = new Oficina();
            oficina2.Id = 2;
            oficina2.Nombre = "Exportaciones";
            oficina2.EmpresaId = 2;
            oficina2.CiudadId = 2;

            contexto.Oficinas.Add(oficina2);

            base.Seed(contexto);

            #endregion

            #region Empleados
            /*var empleado1 = new Empleado();
            empleado1.Id = 1;
            empleado1.Nombres = "Esther";
            empleado1.Apellidos = "Aguirre";
            empleado1.Correo = "micorreo@anave.hn";
            empleado1.Password = "12345";
            empleado1.AreaId = 2;
            empleado1.EmpresaId = 1;
            empleado1.CiudadId = 1;

            contexto.Empleados.Add(empleado1);

            base.Seed(contexto);

            var empleado2 = new Empleado();
            empleado2.Id = 2;
            empleado2.Nombres = "Julio";
            empleado2.Apellidos = "Maradiaga";
            empleado2.Correo = "micorreo@anave.com";
            empleado2.Password = "54321";
            empleado2.EmpresaId = 1;
            empleado2.CiudadId = 2;

            contexto.Empleados.Add(empleado2);

            base.Seed(contexto);
            */

            #endregion

            #region Usuarios
            var usuario1 = new Usuario();
            usuario1.Id = 1;
            usuario1.Nombre = "Soporte";
            usuario1.Correo = "soporteit";
            usuario1.Password = "An@v32020*";
            usuario1.Disponible = true;

            usuario1.Password = Encriptar.CodificarContrasena(usuario1.Password);

            contexto.Usuarios.Add(usuario1);

            base.Seed(contexto);


            #endregion
        }
    }
}
