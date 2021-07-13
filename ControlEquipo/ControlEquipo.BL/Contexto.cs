using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Oficina> Oficinas { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Procesador> Procesadores { get; set; }
        public DbSet<TipoMemoria> TipoMemorias { get; set; }
    }
}
