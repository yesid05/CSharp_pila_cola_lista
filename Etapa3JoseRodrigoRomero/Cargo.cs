using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etapa3JoseRodrigoRomero
{
    class Cargo
    {
        public const int VALOR_BONIFICACION = 100;

        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
