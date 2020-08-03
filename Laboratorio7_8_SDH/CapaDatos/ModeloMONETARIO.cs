using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CapaDatos
{
    public class ModeloMONETARIO : DbContext
    {
        public ModeloMONETARIO() : base("name=MONETARIOConnectionString")
        {

        }

        public virtual DbSet<GESTIONPRESTAMO> GESTIONPRESTAMO { get; set; }

        public virtual DbSet<IDIOMA> IDIOMA { get; set; }

        public virtual DbSet<PAIS> PAIS { get; set; }

    }
}
