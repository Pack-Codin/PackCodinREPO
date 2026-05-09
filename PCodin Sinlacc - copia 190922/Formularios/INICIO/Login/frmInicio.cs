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
using PCodin_Sinlacc.Formularios;
using System.IO;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }
       // private frmInicio GestorPersonal = new frmInicio();
        private void button1_Click(object sender, EventArgs e)
        {
          
        }
        
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void InicializarForm()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from C in hb.PcnConfiguraciones
                                select C).FirstOrDefault();

                if (Consulta.FondoInicio != null)
                {
                    var img = hb.PcnConfiguraciones.Find(Consulta.ID);

                    MemoryStream ms = new MemoryStream(img.FondoInicio);
                    Bitmap bit = new Bitmap(ms);

                    this.BackgroundImage = bit;
                    this.WindowState = FormWindowState.Maximized;
                }
            }
            AbrirFormLogin();
        }
        private void frmInicio_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void AbrirFormLogin()
        {
            var f = new frmLogin();
            AddOwnedForm(f);
            f.FormularioInicio = this;
            //f.Location = new Point(450, 160);
            f.Location = new Point((this.Width /2) - (f.Width /2), 93);
            f.TopLevel = true;
            f.Show();
            //DateTime FechaActual = Convert.ToDateTime("28/01/2022");
            //DateTime FechaVencimiento = DateTime.Now.Date;

            //if (FechaActual < FechaVencimiento)
            //{

            //}
            //else
            //{
            //    MessageBox.Show("La licencia de prueba caducó. Para renovarla pongance en contacto con el administrador del sistema", "Atención");
            //    Application.Exit();
            //}
        }
        
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void frmInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.F5))
            {
                InicializarForm();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
