using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etapa3JoseRodrigoRomero
{
    class Fecha
    {
        public int TipoFormato { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
        public int Hora { get; set; }
        public int Minuto { get; set; }

        public string CalcularTiempo(Fecha unaFecha)
        {
            int tiempoA = (60 * Hora)+Minuto;
            int tiempoB = (60 * unaFecha.Hora) + unaFecha.Minuto;

            int resTiempo = tiempoB - tiempoA;

            int h = resTiempo / 60;
            int m = resTiempo % 60;

            return "" + h+":"+m;
        }
        
        
        public override string ToString()
        {
            string formato = "";
            switch (TipoFormato)
            {
                case 0:
                    formato = "" + Dia + "/" + Mes + "/" + Anio;
                    break;
                case 1:
                    formato = "" + Dia + "/" + Mes + "/" + Anio + " " + Hora + ":" + Minuto;
                    break;
                default:
                    break;
            }
            return formato;
        }


    }
}
