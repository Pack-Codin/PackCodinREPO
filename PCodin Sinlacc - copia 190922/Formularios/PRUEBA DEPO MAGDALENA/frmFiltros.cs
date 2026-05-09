using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Formularios.PRUEBA_DEPO_MAGDALENA;

namespace PCodin_Sinlacc.Formularios.PRUEBA_DEPO_MAGDALENA
{
    public partial class frmFiltros : Form
    {
        public frmFiltros()
        {
            InitializeComponent();
        }
        public DataSet1 DS;
        public Pruebadepo PantallaPrincipal;
        public string SeccionActiva;

        private void pnlFiltros_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (chkFiltraProducto.Checked && cmbFiltraProducto.SelectedValue != null)
            {
                PantallaPrincipal.FiltroCodProducto = cmbFiltraProducto.SelectedValue.ToString();
                PantallaPrincipal.FiltrosActivos = true;
            }
            else
            {
                PantallaPrincipal.FiltroCodProducto = "";
                PantallaPrincipal.FiltrosActivos = false;
            }
          
            PantallaPrincipal.FiltrarDatos();

            frmDepositoA.AbrirFormSegunLetraPresionaFiltros(SeccionActiva, PantallaPrincipal);

            this.Close();
                    
        }

        private void chkFiltraProducto_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboArticulosMagdalena(chkFiltraProducto, cmbFiltraProducto, txtBuscaProducto, btnBuscarProducto);
        }

        private void txtBuscaProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaProducto.Visible = false;
                clsCargarCombos.MostrarComboArticulosMagdalena(cmbFiltraProducto, txtBuscaProducto, true);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaProducto.Visible = false;
            }
        }

        private void cmbFiltraProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboArticulosMagdalena(cmbFiltraProducto, txtBuscaProducto, false);
            }
        }

        private void btnCerrarFiltros_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            txtBuscaProducto.Visible = true;
            txtBuscaProducto.Select();
        }

        private void frmFiltros_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
