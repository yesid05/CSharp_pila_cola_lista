using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etapa3JoseRodrigoRomero
{
    public partial class winInicial : Form
    {
        public winInicial()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(txtContraseña.Text == "" || txtContraseña.Text != "123")
            {
                MessageBox.Show(this,"Debe ingresar la contraseña correcta","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtContraseña.Clear();
                txtContraseña.Focus();
            }
            else
            {
                WinMenu wm = new WinMenu();
                wm.Visible = true;
                this.Visible = false;
            }
        }
    }
}
