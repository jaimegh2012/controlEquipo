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
        }
    }
}
