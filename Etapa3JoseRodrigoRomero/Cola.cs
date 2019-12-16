using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etapa3JoseRodrigoRomero
{
    class Cola
    {
        private decimal PagoPorServicio = 0;
        private int ClientesAtendidos = 0;
        private bool Pagado = false;
        private Queue<ClienteCola> miCola = new Queue<ClienteCola>();

        public ClienteCola ClienteC { get; set; }

        public void Registrar(ClienteCola unClienteC)
        {
            miCola.Enqueue(unClienteC);
        }

        public ClienteCola Eliminar()
        {
            ClienteC = miCola.Dequeue();
            return ClienteC;
        }

        public void Reportar()
        {
            ClientesAtendidos = ClientesAtendidos + 1;
            PagoPorServicio = ClienteC.Valor;
            PagoPorServicio = PagoPorServicio + Convert.ToDecimal((Convert.ToDouble(ClienteC.Valor) * Plato.IVA));
        }

        public int DarClientesAtendidos()
        {
            return ClientesAtendidos;
        }

        public decimal DarPagoPorServicios()
        {
            return PagoPorServicio;
        }

        public bool ColaVacia()
        {
            if(miCola.Count != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public ClienteCola[] darCola()
        {
            return miCola.ToArray();
        }
    }
}
