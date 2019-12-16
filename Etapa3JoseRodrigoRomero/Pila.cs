using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etapa3JoseRodrigoRomero
{
    class Pila
    {

        private int ClientesAtendidos = 0;
        private decimal ServiciosPrestados = 0;
        
        public ClientePila ClienteP { get; set; }

        private Stack<ClientePila> miPila = new Stack<ClientePila>();

        public void Registrar(ClientePila unClienteP)
        {
            miPila.Push(unClienteP);

        }

        public ClientePila Eliminar()
        {
            ClienteP = miPila.Pop();
            return ClienteP;
        }

        public void Reportar()
        {
            ClientesAtendidos = ClientesAtendidos + 1;
            ServiciosPrestados = ServiciosPrestados + ClienteP.ValorServicio;
        }

        public int DarClientesAtendidos()
        {
            return ClientesAtendidos;
        }

        public decimal DarServiciosPrestados()
        {
            return ServiciosPrestados;
        }

        public bool PilaVacia()
        {
            if(miPila.Count != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public ClientePila[] darPila()
        {
            return miPila.ToArray();
        }
        
    }
}
