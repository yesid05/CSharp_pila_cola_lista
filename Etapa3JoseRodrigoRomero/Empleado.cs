using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etapa3JoseRodrigoRomero
{
    class Empleado
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Empresa { get; set; }

        public Cargo TipoCargo { get; set; }

        public Fecha FechaHoraIngreso { get; set; }
        public Fecha FechaHoraSalida { get; set; }

        public string CalcularTiempoLaborado()
        {
            return FechaHoraIngreso.CalcularTiempo(FechaHoraSalida);
        }

        public override string ToString()
        {
            return Cedula + " " + Nombre + " " + Empresa + " " + TipoCargo + " " + FechaHoraIngreso+" "+FechaHoraIngreso;
        }
    }
}
