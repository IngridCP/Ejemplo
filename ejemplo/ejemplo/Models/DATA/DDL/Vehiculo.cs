using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ejemplo.Models.DATA.DDL
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public int placa { get; set; }
        public string nombre { get; set; }

        //Llave foranea

        [ForeignKey("TipoVehiculo")]

        public int TipoVehiculoId { get; set; }

        //uno a muchos
        public TipoVehiculo tipoVehiculo { get; set; }

    
        
        //Llave foranea

        [ForeignKey("Clientes")]

        public int ClientesId { get; set; }

        //uno a muchos
        public Clientes clientes { get; set; }
    }
}
