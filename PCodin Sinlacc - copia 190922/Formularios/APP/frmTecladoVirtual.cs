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
    public partial class frmTecladoVirtual : Form
    {
        public frmTecladoVirtual()
        {
            InitializeComponent();
        }
        public TextBox txtSelecionado;
        bool EmpiezoEscribir = true;
        private void Escribir(Button botonSeleccionado)
        {
            try
            {
                
                if(EmpiezoEscribir == true)
                txtResultado.SelectionStart = txtResultado.TextLength + 1;

                if (botonSeleccionado.Name == "btnEspacio")
                {
                    string cadenaOriginal = txtResultado.Text;
                    char caracterNuevo = ' ';
                    int PosicionCursor = txtResultado.SelectionStart + 1;
                    string cadenaNueva = cadenaOriginal.Insert(txtResultado.SelectionStart, caracterNuevo.ToString());
                    txtResultado.Text = cadenaNueva;
                    txtResultado.SelectionStart = PosicionCursor;
                    txtResultado.SelectionLength = 0;
                    
                }
                    
                if (botonSeleccionado.Name == "btnBorrar")
                {
                    if(txtResultado.TextLength > 0 && txtResultado.SelectionStart != 0)
                    {
                        int PosicionCursor = txtResultado.SelectionStart - 1;
                        txtResultado.Text = txtResultado.Text.Remove(txtResultado.SelectionStart - 1, 1);
                        txtResultado.SelectionStart = PosicionCursor;
                        txtResultado.SelectionLength = 0;
                        txtResultado.ScrollToCaret();
                    }
                        
                }                    
                if (botonSeleccionado.Name != "btnEspacio" && botonSeleccionado.Name != "btnBorrar")
                {                   
                    string cadenaOriginal = txtResultado.Text;
                    int PosicionCursor = txtResultado.SelectionStart + 1;
                    string cadenaNueva = cadenaOriginal.Insert(txtResultado.SelectionStart, botonSeleccionado.Text);
                    txtResultado.Text = cadenaNueva;
                    txtResultado.SelectionStart = PosicionCursor;
                    txtResultado.SelectionLength = 0;
                    EmpiezoEscribir = false;
                }                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");

            }
            
            
        }
        private void button12_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            txtSelecionado.Text = txtResultado.Text;
            this.Close();
        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void btnEspacio_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            Escribir(Boton);
        }

        private void frmTecladoVirtual_Load(object sender, EventArgs e)
        {

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

        private void button27_Click(object sender, EventArgs e)
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

        private void button28_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
