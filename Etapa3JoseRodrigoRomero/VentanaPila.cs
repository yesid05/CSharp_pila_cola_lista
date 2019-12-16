using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Etapa3JoseRodrigoRomero
{
    public partial class WinPila : Form
    {
        
        private Servicio[] unServicio;
        private Pila UnaPila;
  
        public WinPila()
        {
            InitializeComponent();
            
            Servicio s1 = new Servicio();
            s1.Descripcion = "Ahorro";

            Servicio s2 = new Servicio();
            s2.Descripcion = "CDT";

            Servicio s3 = new Servicio();
            s3.Descripcion = "Acciones";

            unServicio = new Servicio[3];
            unServicio[0] = s1;
            unServicio[1] = s2;
            unServicio[2] = s3;

            cmbServicio.Items.Add(s1.Descripcion);
            cmbServicio.Items.Add(s2.Descripcion);
            cmbServicio.Items.Add(s3.Descripcion);

            UnaPila = new Pila();
            
        }

        

        

        private void WinPila_Load(object sender, EventArgs e)
        {

        }
        
        private void ActualizarLista()
        {
            dgvDatosPila.DataSource = null;
            dgvDatosPila.DataSource = UnaPila.darPila();

            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtIdentificacion.Clear();
            txtIdentificacion.Focus();
            txtValor.Clear();

            cmbServicio.SelectedIndex = -1;

        }

        private bool ValidarCampos()
        {
            Regex r = new Regex(@"[0-9]{1,9}(\.[0-9]{0,2})?$");

            if (txtIdentificacion.Text == "" )
            {
                msgError.SetError(txtIdentificacion, "Debe ingresar una identificación");
                txtIdentificacion.Focus();
                return false;
            }
            msgError.SetError(txtIdentificacion, "");

            if (!r.IsMatch(txtIdentificacion.Text))
            {
                msgError.SetError(txtIdentificacion, "Debe ingresar un número.");
                txtIdentificacion.Focus();
                return false;
            }
            msgError.SetError(txtIdentificacion, "");

            if (txtNombre.Text == "")
            {
                msgError.SetError(txtNombre, "Debe ingresar un nombre");
                txtNombre.Focus();
                return false;
            }
            msgError.SetError(txtNombre, "");


            if (cmbServicio.SelectedIndex == -1)
            {
                msgError.SetError(cmbServicio, "Debe elegir un tipo de servicio.");
                cmbServicio.Focus();
                return false;
            }
            msgError.SetError(cmbServicio, "");


            if (txtValor.Text == "")
            {
                msgError.SetError(txtValor, "Debe ingresar un valor");
                txtValor.Focus();
                return false;
            }
            msgError.SetError(txtValor, "");

            if (!r.IsMatch(txtValor.Text))
            {
                msgError.SetError(txtValor, "Debe ingresar un número");
                txtValor.Focus();
                return false;
            }
            msgError.SetError(txtValor, "");

            return true;
        }

        private void CerrarVentana()
        {
            WinMenu wm = new WinMenu();
            wm.Visible = true;
            this.Dispose();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                //Console.WriteLine("Dia " + dtpFecha.Value.Day + " Mes " + dtpFecha.Value.Month + " Año " + dtpFecha.Value.Year);
                ClientePila cp = new ClientePila();
                cp.Identificacion = txtIdentificacion.Text;
                cp.Nombre = txtNombre.Text;
                cp.TipoServicio = unServicio[cmbServicio.SelectedIndex];
                cp.ValorServicio = Decimal.Parse(txtValor.Text);

                Fecha UnaFecha = new Fecha();
                UnaFecha.TipoFormato = 0;
                UnaFecha.Dia = dtpFecha.Value.Day;
                UnaFecha.Mes = dtpFecha.Value.Month;
                UnaFecha.Anio = dtpFecha.Value.Year;

                cp.FechaS = UnaFecha;

                UnaPila.Registrar(cp);

                ActualizarLista();
                
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (!UnaPila.PilaVacia())
            {
                ClientePila cp = UnaPila.Eliminar();
                UnaPila.Reportar();

                txtNombre.Text = cp.Nombre;
                txtIdentificacion.Text = cp.Identificacion;
                txtValor.Text = "" + cp.ValorServicio;

                int indice = 0;
                while (indice < unServicio.Length)
                {
                    if (unServicio[indice].Equals(cp.TipoServicio))
                    {
                        break;
                    }
                    indice = indice + 1;
                }

                cmbServicio.SelectedIndex = indice;

                MessageBox.Show("Eliminación exitosa");

                ActualizarLista();
            }
            else
            {
                MessageBox.Show("La pila esta vacía", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            txtClientesAtendidos.Text = ""+UnaPila.DarClientesAtendidos();
            txtServiciosPrestados.Text = "" + UnaPila.DarServiciosPrestados();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            CerrarVentana();
        }

        private void WinPila_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarVentana();
        }

        
    }
}
