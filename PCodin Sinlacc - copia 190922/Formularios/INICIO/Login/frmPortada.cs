using PCodin_Sinlacc.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCodin_Sinlacc.Formularios.INICIO.Login
{
    public partial class frmPortada : Form
    {
        public frmPortada()
        {
            InitializeComponent();
        }

        private void pnlGeneral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmPortada_Load(object sender, EventArgs e)
        {
            this.Width = clsVariablesGenerales.WPantalla;
            this.Height = clsVariablesGenerales.HPantalla;

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Close();
        }
    }
}
