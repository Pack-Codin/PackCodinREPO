using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCodin_Sinlacc.Formularios.APP
{
    public partial class frmTecladoNumerico : Form
    {
        public frmTecladoNumerico()
        {
            InitializeComponent();
        }
        public TextBox txtSeleccionado;
        private void Escribir(Button botonSeleccionado)
        {
            if (botonSeleccionado.Name == "btnClear")
                txtResultado.Text = txtResultado.Text + " ";
            if (botonSeleccionado.Name == "btnBorrar")
                txtResultado.Text = txtResultado.Text.Remove(txtResultado.TextLength - 1);
            if (botonSeleccionado.Name != "btnClear" && botonSeleccionado.Name != "btnBorrar")
            {
                if(txtResultado.Text == "0,00" || txtResultado.Text == "0")
                {
                    txtResultado.Text = "";
                    txtResultado.Text = txtResultado.Text + botonSeleccionado.Text;
                }
                else
                {
                    txtResultado.Text = txtResultado.Text + botonSeleccionado.Text;
                }
            }
                
            //var Boton = sender as Button;
        }
        private void btnUno_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void frmTecladoNumerico_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if(txtResultado.Text != "")
            {
                txtSeleccionado.Text = txtResultado.Text;
                this.Close();
            }
        }

        private void btnCero_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void btnOcho_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void btnNueve_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }
    }
}
