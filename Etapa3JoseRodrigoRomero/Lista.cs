using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etapa3JoseRodrigoRomero
{
    class Lista
    {
        private decimal Bonificacion = 0;
        private string TiempoLaborado;
        private int TotalEmpleados;
        private decimal TotalBonificacion;
        private Empleado UnEmpleado;
        List<Empleado> ListaEmpleados = new List<Empleado>();

        

        public void Registrar(Empleado unEmpleado)
        {
            TotalEmpleados = TotalEmpleados + 1;
            ListaEmpleados.Add(unEmpleado);
        }
        
        public Empleado Consultar(string unaCedula)
        {
            UnEmpleado = null;
            foreach(Empleado e in ListaEmpleados)
            {
                if(e.Cedula == unaCedula)
                {
                    UnEmpleado = e;
                    break;
                }
            }
            return UnEmpleado;
        }

        public bool Eliminar()
        {
            return ListaEmpleados.Remove(UnEmpleado);
        }

        public void Reportar()
        {
            TiempoLaborado = UnEmpleado.CalcularTiempoLaborado();


        }

        public decimal DarBonificacion()
        {
            char[] ser = { ':' };

            string[] separador = TiempoLaborado.Split(ser);

            if(Int32.Parse(separador[0]) > 8 || (Int32.Parse(separador[0])==8 && Int32.Parse(separador[1]) > 0))
            {
                if (Int32.Parse(separador[0]) == 8 && Int32.Parse(separador[1]) > 0)
                {
                    Bonificacion = Int32.Parse(separador[1]) * Cargo.VALOR_BONIFICACION;
                    TotalBonificacion = TotalBonificacion + Bonificacion;
                }
                else
                {
                    int h = Int32.Parse(separador[0]);
                    int resta = h - 8;
                    Bonificacion = ((resta * 60) + Int32.Parse(separador[1])) * Cargo.VALOR_BONIFICACION;
                    TotalBonificacion = TotalBonificacion + Bonificacion;
                }
            }


            return Bonificacion;
        }

        public string DarTiempoLaborado()
        {
            return TiempoLaborado;
        }

        public int DarTotalEmpleados()
        {
            return TotalEmpleados;
        }

        public decimal DarTotalBonificacion()
        {
            return TotalBonificacion;
        }

        public Empleado[] darLista()
        {
            return ListaEmpleados.ToArray();
        }

    }
}
