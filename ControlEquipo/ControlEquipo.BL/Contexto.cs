using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEquipo.BL
{
    public class Contexto: DbContext
    {
        public Contexto(): base(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDBFilename=" +
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ControlEquipoDB.mdf")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new DatosDeInicio()); // Agregar datos de inicio al momento de crear la base de datos
        }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Oficina> Oficinas { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Procesador> Procesadores { get; set; }
        public DbSet<TipoMemoria> TipoMemorias { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Computadora> Computadoras { get; set; }
        public DbSet<TipoComputadora> TipoComputadoras { get; set; }
        public DbSet<TipoDisco> TipoDiscos { get; set; }

    }
}
