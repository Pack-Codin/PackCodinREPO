using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PCodin_Sinlacc.Datos;
using PCodin_Sinlacc.Clases;

namespace PCodin_Sinlacc.Formularios.Configuracion
{
    public partial class frmConfigConfiguracion : Form
    {
        public frmConfigConfiguracion()
        {
            InitializeComponent();
        }

        public int UsuarioID;
        public string TemaSeleccionado;
        private void btnEditar_Click(object sender, EventArgs e)
        {
            MostrarFotoSeleccionada();
        }
        private void MostrarFotoSeleccionada()
        {
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK) // abre el explorador archivos
            {
                txtDireccion.Text = openFileDialog1.FileName;
            }

            if (txtDireccion.TextLength == 0)
            {
                MessageBox.Show("No se ha elegido ninguna imagen");
                return;
            }
            picLogo.ImageLocation = txtDireccion.Text;
        }
        private void InicializarForm()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from C in hb.PcnConfiguraciones
                                select C).FirstOrDefault();

                var ConsultaTema = (from UT in hb.USUARIOTEMA
                                    where UT.Usuario == UsuarioID
                                    select UT).FirstOrDefault();

                var ConsultaUsuarioConfig = (from UC in hb.USUARIOCONFIG
                                             where UC.Usuario_ID == UsuarioID
                                             select UC).FirstOrDefault();

                if (Consulta.FondoInicio != null)
                {
                    var img = hb.PcnConfiguraciones.Find(Consulta.ID);

                    MemoryStream ms = new MemoryStream(img.FondoInicio);
                    Bitmap bit = new Bitmap(ms);

                    picLogo.Image = bit;
                }
                if(ConsultaTema == null)
                {
                    btnTemaPackCodin.BackColor = Color.DarkOrange;
                    TemaSeleccionado = "PACK-CODIN";
                    picPrevisializarTema.Image = Image.FromFile(@"C:\Program Files (x86)\Pack-Codin\Images\Temas\Pack-codin.png");
                }
                else
                {
                    foreach(var Control in pnlTemas.Controls)
                    {
                        if (((Control)Control) is Button) 
                        {
                            if(((Button)Control).Text == ConsultaTema.Tema)
                            {
                                if (ConsultaTema.Tema == "PACK-CODIN")
                                {
                                    btnTemaPackCodin.BackColor = Color.DarkOrange;
                                    picPrevisializarTema.Image = Image.FromFile(@"C:\Program Files (x86)\Pack-Codin\Images\Temas\Pack-codin.png");
                                }
                                if (ConsultaTema.Tema == "PINKY")
                                {
                                    btnTemaPinky.BackColor = Color.Pink;
                                    picPrevisializarTema.Image = Image.FromFile(@"C:\Program Files (x86)\Pack-Codin\Images\Temas\Pack-codin.png");
                                }
                                if (ConsultaTema.Tema == "CARBON")
                                {
                                    btnTemaCarbon.BackColor = Color.DimGray;
                                    btnTemaCarbon.ForeColor = Color.MediumTurquoise;
                                   // picPrevisializarTema.Image = Image.FromFile(@"C:\Program Files (x86)\Pack-Codin\Images\Temas\Pack-codin.png");
                                }

                                TemaSeleccionado = ConsultaTema.Tema;
                            }
                        }
                    }
                }
                if(ConsultaUsuarioConfig != null)
                {
                    txtAncho.Text = ConsultaUsuarioConfig.AnchoPantalla.ToString();
                    txtAlto.Text = ConsultaUsuarioConfig.AltoPantalla.ToString();
                }
                else
                {
                    txtAncho.Text = clsVariablesGenerales.WPantalla.ToString();
                    txtAlto.Text = clsVariablesGenerales.HPantalla.ToString();
                }    

            }
        }     
        private void SeleccionarBotonTema(Button BotonSeleccionado)
        {
            foreach (var Control in pnlTemas.Controls)
            {
                if (((Control)Control) is Button)
                {
                    if (((Button)Control).Name == BotonSeleccionado.Name)
                    {
                        if(BotonSeleccionado.Text == "PACK-CODIN")
                            ((Button)Control).BackColor = Color.DarkOrange;
                        if (BotonSeleccionado.Text == "PINKY")
                            ((Button)Control).BackColor = Color.Pink;
                        if (BotonSeleccionado.Text == "CARBON")
                        {
                            ((Button)Control).BackColor = Color.FromName("DimGray");
                            ((Button)Control).ForeColor = Color.MediumTurquoise;
                        }
                            
                    }
                    else
                    {
                        ((Button)Control).BackColor = Color.White;
                    }
                }

            }
        }
        private void frmConfigConfiguracion_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }

        private void btnTemaPackCodin_Click(object sender, EventArgs e)
        {
            var boton = sender as Button;
            TemaSeleccionado = boton.Text;
            SeleccionarBotonTema(boton);

            picPrevisializarTema.Image = Image.FromFile(@"C:\Program Files (x86)\Pack-Codin\Images\Temas\Pack-codin.png");
        }

        private void btnTemaPinky_Click(object sender, EventArgs e)
        {
            var boton = sender as Button;
            TemaSeleccionado = boton.Text;
            SeleccionarBotonTema(boton);

            picPrevisializarTema.Image = Image.FromFile(@"C:\Program Files (x86)\Pack-Codin\Images\Temas\Pinky.png");
        }

        private void btnTemaCarbon_Click(object sender, EventArgs e)
        {
            var boton = sender as Button;
            TemaSeleccionado = boton.Text;
            SeleccionarBotonTema(boton);

            //picPrevisializarTema.Image = Image.FromFile(@"C:\Program Files (x86)\Pack-Codin\Images\Temas\Pinky.png");
        }

        private void txtAncho_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtAlto_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
