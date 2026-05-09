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
using PCodin_Sinlacc.Clases.UsuarioTema;
using PCodin_Sinlacc.Datos;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmReporting : Form
    {
        public frmReporting()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            var f = new frmFiltrosReportes();
            f.Show();
        }

        private void frmReporting_Load(object sender, EventArgs e)
        {
            InicializarForm();
            cmbInformes.SelectedIndex = -1;           
        }
        private void InicializarForm()
        {
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
            //clsCargarCombos.MostrarModulo(cmbModulo);
            clsCargarCombos.MostrarModuloPorUsuario(cmbModulo);
            clsCargarCombos.MostrarComboInformes(cmbInformes,txtBuscarInforme,false);
            
            cmbModulo.SelectedIndex = -1;
            cmbInformes.SelectedIndex = -1;
        }
        private void MostrarInformesSegunModulo()
        {
            if(cmbModulo.SelectedValue != null)
            {
                cmbInformes.Enabled = true;

                using (var hb = new DBdatos())
                {
                    var Consulta = (from I in hb.Acceso_Usuario
                                    where I.Usuario_ID == clsVariablesGenerales.UsuarioID
                                        && I.Menu_Item.Tipo == "Informe"
                                        && I.Menu_Item.Modulo_ID == (int)cmbModulo.SelectedValue
                                    select new
                                    {
                                        ID = I.Menu_ID,
                                        Tittle = I.Menu_Item.Descripcion
                                    });

                    var Resultados = Consulta.ToList();

                    cmbInformes.ValueMember = "ID";
                    cmbInformes.DisplayMember = "Tittle";
                    cmbInformes.DataSource = Resultados;
                }
            }
            else
            {
                cmbInformes.Enabled = false;
            }
        }
        private void AbrirFormEnPanel()
        {
            if (cmbInformes.SelectedIndex != -1)
            {
                var f = new frmFiltrosReportes();
                f.TopLevel = false;
                pnlFiltros.Controls.Add(f);
                pnlFiltros.Tag = f;
                f.InformeID = (int)cmbInformes.SelectedValue;
                f.Informe = cmbInformes.Text;
                f.WindowState = FormWindowState.Maximized;
                lblInformeSeleccionado.Text = cmbInformes.Text;
                f.Show();
            }
        }
        private void cmbInformes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtBuscarInforme_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbModulo.SelectedValue != null)
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    txtBuscarInforme.Visible = false;
                    clsCargarCombos.MostrarComboInformesSegunModulo(cmbInformes, txtBuscarInforme, true, (int)cmbModulo.SelectedValue);
                    txtBuscarInforme.Focus();
                    e.Handled = true;
                }
                if (e.KeyChar == Convert.ToChar(Keys.Escape))
                {
                    txtBuscarInforme.Visible = false;
                    txtBuscarInforme.Focus();
                    e.Handled = true;
                }
            }
        }

        private void btnBuscarInforme_Click(object sender, EventArgs e)
        {
            txtBuscarInforme.Visible = true;
            txtBuscarInforme.Select();
        }

        private void cmbInformes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbModulo.SelectedValue != null)
            {
                if (e.KeyChar == Convert.ToChar(Keys.Escape))
                {
                    clsCargarCombos.MostrarComboInformesSegunModulo(cmbInformes, txtBuscarInforme, false, (int)cmbModulo.SelectedValue);
                    txtBuscarInforme.Focus();
                    e.Handled = true;
                }
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnMontarInforme_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel();
        }

        private void cmbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarInformesSegunModulo();
        }

        private void btnMontar_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pnlInferiorSub1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlInferior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlFiltros_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlInferiorLine_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
