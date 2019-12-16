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
    public partial class WinMenu : Form
    {
        public WinMenu()
        {
            InitializeComponent();
        }

        private void btnPila_Click(object sender, EventArgs e)
        {
            WinPila wp = new WinPila();
            wp.Visible = true;
            this.Dispose();
        }

        private void btnCola_Click(object sender, EventArgs e)
        {
            WinCola wc = new WinCola();
            wc.Visible = true;
            this.Dispose();
        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            WinLista wl = new WinLista();
            wl.Visible = true;
            this.Dispose();
        }

        private void WinMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
