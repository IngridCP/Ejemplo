using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ejemplo.Models.DATA.DDL
{
    public class TipoVehiculo
    {
        public int Id { get; set; }
        public int nombre { get; set; }

        //muchos a uno

        public ICollection<Vehiculo> vehiculos { get; set; }
    }
}

