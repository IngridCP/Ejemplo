using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ejemplo.Models.DATA.DDL
{
    public class Clientes
    {
        public int Id { get; set; }
        public string nombre { get; set; }


        //muchos a uno

        public ICollection<Vehiculo> vehiculos { get; set; }

    }
}
