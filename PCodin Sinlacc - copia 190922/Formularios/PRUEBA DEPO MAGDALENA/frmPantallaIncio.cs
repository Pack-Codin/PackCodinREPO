using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCodin_Sinlacc.Datos;

namespace PCodin_Sinlacc.Formularios.PRUEBA_DEPO_MAGDALENA
{
    public partial class frmPantallaIncio : Form
    {
        public frmPantallaIncio()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            IngresarSistema();
        }
        private void IngresarSistema()
        {
            if (txtUsuario.Text != "" && txtPass.Text != "")
            {
                using (var hb = new DBdatos2())
                {
                    var Consulta = (from C in hb.USUARIO
                                    where C.Nombre == txtUsuario.Text
                                        && C.Clave == txtPass.Text
                                        && C.Activo == "SI"
                                    select C).FirstOrDefault();

                    if (Consulta != null)
                    {
                        var f = new Pruebadepo();

                        f.PantallaIncio = this;
                        f.Focus();
                        f.Select();
                        f.FormPrincipal = f;
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string Clave = txtPass.Text;
                txtPass.Text = Clave.Replace(" ", string.Empty);
                e.Handled = true;
                IngresarSistema();
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string Usuario = txtPass.Text;
                txtPass.Text = Usuario.Replace(" ", string.Empty);
                e.Handled = true;
                IngresarSistema();
            }
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            IngresarSistema();
        }
    }
}
