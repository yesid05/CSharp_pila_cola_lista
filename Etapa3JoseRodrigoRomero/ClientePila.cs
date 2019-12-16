using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etapa3JoseRodrigoRomero
{
    class ClientePila
    {
        //Atributos
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public decimal ValorServicio { get; set; }

        public Servicio TipoServicio { get; set; }
        public Fecha FechaS { get; set; }
        
    }
}
