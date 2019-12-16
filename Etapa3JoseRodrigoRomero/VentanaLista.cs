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
    public partial class WinLista : Form
    {
        private Cargo[] UnosCargos;
        private Lista UnaLista;

        public WinLista()
        {
            InitializeComponent();

            Cargo c1 = new Cargo();
            c1.Descripcion = "Mercaderista";

            Cargo c2 = new Cargo();
            c2.Descripcion = "Impulsador";

            Cargo c3 = new Cargo();
            c3.Descripcion = "Supervisor";

            Cargo c4 = new Cargo();
            c4.Descripcion = "Vendedor";

            UnosCargos = new Cargo[4];
            UnosCargos[0] = c1;
            UnosCargos[1] = c2;
            UnosCargos[2] = c3;
            UnosCargos[3] = c4;

            cmbCargo.Items.Add(c1.Descripcion);
            cmbCargo.Items.Add(c2.Descripcion);
            cmbCargo.Items.Add(c3.Descripcion);
            cmbCargo.Items.Add(c4.Descripcion);


            UnaLista = new Lista();

            Ejemplo();

        }

        private void ActualizarLista()
        {
            dgvDatosLista.DataSource = null;
            dgvDatosLista.DataSource = UnaLista.darLista();

            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtCedula.Clear();
            txtCedula.Focus();
            txtNombre.Clear();
            txtEmpresa.Clear();

            cmbCargo.SelectedIndex = -1;
        }


        private bool ValidarCampos()
        {
            Regex r = new Regex(@"[0-9]{1,9}(\.[0-9]{0,2})?$");

            if (txtCedula.Text == "")
            {
                msgError.SetError(txtCedula, "Debe ingresar una cedula.");
                txtCedula.Focus();
                return false;
            }
            msgError.SetError(txtCedula, "");

            if (!r.IsMatch(txtCedula.Text))
            {
                msgError.SetError(txtCedula, "Debe ingresar un número.");
                txtCedula.Focus();
                return false;
            }
            msgError.SetError(txtCedula, "");

            if (txtNombre.Text == "")
            {
                msgError.SetError(txtNombre, "Debe ingresar un nombre.");
                txtNombre.Focus();
                return false;
            }
            msgError.SetError(txtNombre, "");

            if(txtEmpresa.Text == "")
            {
                msgError.SetError(txtEmpresa, "Debe ingresar una empresa.");
                txtEmpresa.Focus();
                return false;
            }
            msgError.SetError(txtEmpresa, "");

            if(cmbCargo.SelectedIndex == -1)
            {
                msgError.SetError(cmbCargo, "Debe seleccionar un cargo.");
                cmbCargo.Focus();
                return false;
            }
            msgError.SetError(cmbCargo, "");

            return true;
        }

        private void CerrrarVentana()
        {
            WinMenu wm = new WinMenu();
            wm.Visible = true;
            this.Dispose();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                Empleado em = new Empleado();
                em.Cedula = txtCedula.Text;
                em.Nombre = txtNombre.Text;
                em.Empresa = txtEmpresa.Text;

                em.TipoCargo = UnosCargos[cmbCargo.SelectedIndex];

                Fecha UnaFecha = new Fecha();
                UnaFecha.TipoFormato = 1;
                UnaFecha.Dia = dtpFechaHora.Value.Day;
                UnaFecha.Mes = dtpFechaHora.Value.Month;
                UnaFecha.Anio = dtpFechaHora.Value.Year;

                UnaFecha.Hora = dtpFechaHora.Value.Hour;
                UnaFecha.Minuto = dtpFechaHora.Value.Minute;

                em.FechaHoraIngreso = UnaFecha;

                UnaLista.Registrar(em);

                ActualizarLista();
            }
        }

        public void Ejemplo()
        {
            Empleado em = new Empleado();
            em.Cedula = "1010";
            em.Nombre = "Pepito";
            em.Empresa = "Ninguna";

            em.TipoCargo = UnosCargos[1];

            Fecha UnaFecha = new Fecha();
            UnaFecha.TipoFormato = 1;
            UnaFecha.Dia = 6;
            UnaFecha.Mes = 11;
            UnaFecha.Anio = 2019;

            UnaFecha.Hora = 8;
            UnaFecha.Minuto = 0;

            em.FechaHoraIngreso = UnaFecha;

            UnaLista.Registrar(em);

            ActualizarLista();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(txtCedula.Text == "")
            {
                msgError.SetError(txtCedula, "Debe ingresar una cedula para buscar.");
                txtCedula.Focus();
                return;
            }
            msgError.SetError(txtCedula, "");

            Empleado em = UnaLista.Consultar(txtCedula.Text);

            if(em != null)
            {
                txtCedula.Text = em.Cedula;
                txtNombre.Text = em.Nombre;
                txtEmpresa.Text = em.Empresa;

                int indice = 0;
                while (indice < UnosCargos.Length)
                {
                    if (UnosCargos[indice].Equals(em.TipoCargo))
                    {
                        break;
                    }
                    indice = indice + 1;
                }

                cmbCargo.SelectedIndex = indice;

                Fecha UnaFecha = new Fecha();
                UnaFecha.TipoFormato = 1;
                UnaFecha.Mes = dtpFechaHora.Value.Month;
                UnaFecha.Dia = dtpFechaHora.Value.Day;
                UnaFecha.Anio = dtpFechaHora.Value.Year;

                UnaFecha.Hora = dtpFechaHora.Value.Hour;
                UnaFecha.Minuto = dtpFechaHora.Value.Minute;

                em.FechaHoraSalida = UnaFecha;

                UnaLista.Reportar();



                txtTiempoLaborado.Text = UnaLista.DarTiempoLaborado();
                txtBonificacion.Text = ""+UnaLista.DarBonificacion();

            }
            else
            {
                MessageBox.Show(this, "Error, el empleado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text == "")
            {
                msgError.SetError(txtCedula, "Debe ingresar una cedula para buscar.");
                txtCedula.Focus();
                return;
            }
            msgError.SetError(txtCedula, "");

            if (!UnaLista.Eliminar())
            {
                MessageBox.Show(this, "Error, no se pudo eliminar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            txtEmpleadosRegistrados.Text = ""+UnaLista.DarTotalEmpleados();
            txtSumatoriaBonificaciones.Text = "" + UnaLista.DarTotalBonificacion();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            CerrrarVentana();
        }

        private void WinLista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrrarVentana();
        }
    }
}
