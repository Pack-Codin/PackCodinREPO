using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using PCodin_Sinlacc.Clases;


namespace PCodin_Sinlacc.Formularios.Notificación
{
    public partial class frmAlertas : Form
    {
        public string Tipo;
        public string Cumpleañero;
        public int UsuarioID;
        public frmAlertas Formulario;

        public frmAlertas()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmAlertas_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            if(Tipo == "Cumpleaños")
            {              
                picCumple1.Visible = true;
                picCumple2.Visible = true;
                lblSubtitulo.Visible = true;

                lblTitulo.Text = "Feliz cumpleaños !!";
                lblSubtitulo.Text = Cumpleañero;
            }
            else
            {
                picCumple1.Visible = false;
                picCumple2.Visible = false;
                //lblDescripcion.Visible = false;              
            }
            SoundPlayer SonidoSalida = new SoundPlayer(@"C:\Program Files (x86)\Pack-Codin\Sound\Notificación.wav");
            SonidoSalida.Play();
            //clsNotificacion.MostrarCantidadNotificacionesNoLeidas(lblCantidadNotificaciones);
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            //this.Close();

        }

        private void frmNotificaciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblDescripcion_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
