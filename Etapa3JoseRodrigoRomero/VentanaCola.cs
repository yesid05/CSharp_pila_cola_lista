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
    public partial class WinCola : Form
    {

        private Plato[] unosPlatos;
        private Cola UnaCola;

        public WinCola()
        {
            InitializeComponent();

            Plato p1 = new Plato();
            p1.Descripcion = "Ajiaco con pollo";

            Plato p2 = new Plato();
            p2.Descripcion = "Caldo de Pollo";

            Plato p3 = new Plato();
            p3.Descripcion = "Bagre en salsa";

            unosPlatos = new Plato[3];
            unosPlatos[0] = p1;
            unosPlatos[1] = p2;
            unosPlatos[2] = p3;

            cmbPlato.Items.Add(p1.Descripcion);
            cmbPlato.Items.Add(p2.Descripcion);
            cmbPlato.Items.Add(p3.Descripcion);

            UnaCola = new Cola();
        }

        private void ActualizarLista()
        {
            dgvDatosCola.DataSource = null;
            dgvDatosCola.DataSource = UnaCola.darCola();

            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtIdentificacion.Clear();
            txtIdentificacion.Focus();
            txtNombre.Clear();
            txtValor.Clear();
            txtFactura.Clear();

            cmbPlato.SelectedIndex = -1;

        }
        
        private bool ValidarCampos()
        {
            Regex r = new Regex(@"[0-9]{1,9}(\.[0-9]{0,2})?$");
            if (txtIdentificacion.Text == "")
            {
                msgError.SetError(txtIdentificacion, "Debe ingresar una identificación.");
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
                msgError.SetError(txtNombre, "Debe ingresar un nombre.");
                txtNombre.Focus();
                return false;
            }
            msgError.SetError(txtNombre, "");

            if(txtValor.Text == "")
            {
                msgError.SetError(txtValor, "Debe ingresar un valor.");
                txtValor.Focus();
                return false;
            }
            msgError.SetError(txtValor, "");

            if (!r.IsMatch(txtValor.Text))
            {
                msgError.SetError(txtValor, "Debe ingresar un número.");
                txtValor.Focus();
                return false;
            }
            msgError.SetError(txtValor, "");

            if (txtFactura.Text == "")
            {
                msgError.SetError(txtFactura, "Debe ingresar una factura.");
                txtFactura.Focus();
                return false;
            }
            msgError.SetError(txtFactura, "");

            if(cmbPlato.SelectedIndex == -1)
            {
                msgError.SetError(cmbPlato, "Debe escoger un plato.");
                cmbPlato.Focus();
                return false;
            }
            msgError.SetError(cmbPlato, "");

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
                ClienteCola cl = new ClienteCola();
                cl.Identificacion = txtIdentificacion.Text;
                cl.Nombre = txtNombre.Text;
                cl.TipoPlato = unosPlatos[cmbPlato.SelectedIndex];
                cl.Valor = Decimal.Parse(txtValor.Text);
                cl.NumeroFactura = txtFactura.Text;

                UnaCola.Registrar(cl);

                ActualizarLista();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (!UnaCola.ColaVacia())
            {
                ClienteCola cl = UnaCola.Eliminar();
                UnaCola.Reportar();//Reportar
                txtIdentificacion.Text = cl.Identificacion;
                txtNombre.Text = cl.Nombre;
                txtValor.Text = ""+cl.Valor;
                txtFactura.Text = cl.NumeroFactura;

                int indice = 0;
                while (indice < unosPlatos.Length)
                {
                    if (unosPlatos[indice].Equals(cl.TipoPlato))
                    {
                        break;
                    }
                    indice = indice + 1;
                }

                cmbPlato.SelectedIndex = indice;

                MessageBox.Show("Eliminación exitosa");

                ActualizarLista();

            }
            else
            {
                MessageBox.Show("La cola esta vacía", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            txtClientesAtendidos.Text = "" + UnaCola.DarClientesAtendidos();
            txtPagarPorServicio.Text = "" + UnaCola.DarPagoPorServicios();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            CerrarVentana();
        }

        private void WinCola_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarVentana();
        }

        
    }
}