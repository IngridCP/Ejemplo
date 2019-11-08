using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ejemplo.Models.DATA.DDL;

namespace ejemplo.Models
{
    public class ejemploContext : DbContext
    {
        public ejemploContext (DbContextOptions<ejemploContext> options)
            : base(options)
        {
        }

        public DbSet<ejemplo.Models.DATA.DDL.Clientes> Clientes { get; set; }

        public DbSet<ejemplo.Models.DATA.DDL.TipoVehiculo> TipoVehiculo { get; set; }

        public DbSet<ejemplo.Models.DATA.DDL.Vehiculo> Vehiculo { get; set; }
    }
}
