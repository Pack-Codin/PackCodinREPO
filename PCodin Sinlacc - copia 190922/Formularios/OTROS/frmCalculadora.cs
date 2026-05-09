using PCodin_Sinlacc.Formularios.MATERIALES.Gestor_de_materiales.Insumos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PCodin_Sinlacc.Formularios.OTROS
{
    public enum Operacion
    {
        NoDefinida = 0,
        Suma = 1,
        Resta = 2,
        Division = 3,
        Multiplicacion = 4,
        Modulo = 5
    }

    public partial class frmCalculadora : Form
    {
        decimal Acumulado = 0;
        decimal valor1 = 0;
        decimal valor2 = 0;
        Operacion operador = Operacion.NoDefinida;
        bool unNumeroLeido = false;
        string Resultado = "0,00";
        public frmIngresoInsumoAgregar frmIngresoInsumoAgregar;
        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void LeerNumero(string numero)
        {
            unNumeroLeido = true;
            if (cajaResultado.Text == "0" && cajaResultado.Text != null)
            {
                cajaResultado.Text = numero;
            }
            else
            {
                cajaResultado.Text += numero;
            }
            cajaResultado.Select();
            cajaResultado.Focus();
        }

        private decimal EjecutarOperacion()
        {
            decimal resultado = 0;
            switch (operador)
            {
                case Operacion.Suma:
                    resultado = valor1 + valor2;
                    break;
                case Operacion.Resta:
                    resultado = valor1 - valor2;
                    break;
                case Operacion.Division:
                    if (valor2 == 0)
                    {
                        //MessageBox.Show("No se puede dividir entre 0");
                        lblHistorial.Text = "No se puede dividir entre 0";
                        resultado = 0;
                    }
                    else
                    {
                        resultado = valor1 / valor2;
                    }
                    break;
                case Operacion.Multiplicacion:
                    resultado = valor1 * valor2;
                    break;
                case Operacion.Modulo:
                    resultado = valor1 % valor2;
                    break;
            }
            Acumulado = resultado;
            return resultado;
        }
        private void btnCero_Click(object sender, EventArgs e)
        {
            unNumeroLeido = true;
            if (cajaResultado.Text == "0")
            {
                return;
            }
            else
            {
                cajaResultado.Text += "0";
            }
            cajaResultado.Focus();
        }
        private void frmCalculadora_Load(object sender, EventArgs e)
        {
            
        }
        private void btnUno_Click(object sender, EventArgs e)
        {
            LeerNumero("1");

        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            LeerNumero("2");
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            LeerNumero("3");
        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            LeerNumero("4");
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            LeerNumero("5");
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            LeerNumero("6");
        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            LeerNumero("7");
        }

        private void btnOcho_Click(object sender, EventArgs e)
        {
            LeerNumero("8");
        }

        private void btnNueve_Click(object sender, EventArgs e)
        {
            LeerNumero("9");
        }

        private void ObtenerValor(string operador)
        {
            valor1 = Convert.ToDecimal(cajaResultado.Text);
            if (operador == "+")
            {
                Acumulado = Acumulado + valor1;
                Resultado = Acumulado.ToString("N2");
            }
            if (operador == "-")
            {
                // cajaResultado.Text = "0";

                if (Acumulado == 0)
                {
                    Acumulado = valor1 - Acumulado;
                    Resultado = Acumulado.ToString("N2");
                }
                else
                {
                    Acumulado = Acumulado - valor1;
                    Resultado = Acumulado.ToString("N2"); ;
                }

                Acumulado = Acumulado - valor1;
            }

            if (operador == "*")
                Acumulado = Acumulado * valor1;
            if (operador == "/")
                Acumulado = Acumulado / valor1;

            lblHistorial.Text = Resultado;//Acumulado.ToString("N2") + operador;

            int LongitubCadena = lblHistorial.Text.Length;
            string Cadena = lblHistorial.Text.Substring(LongitubCadena);

            //if(Cadena = "")
            //{
            //    if (valor2 == 0 && unNumeroLeido)
            //    {
            //        valor2 = Convert.ToDecimal(cajaResultado.Text);
            //        lblHistorial.Text += valor2 + "=";
            //        decimal resultado = EjecutarOperacion();
            //        valor1 = 0;
            //        valor2 = 0;
            //        unNumeroLeido = false;
            //        cajaResultado.Text = Convert.ToString(resultado);
            //    }
            //}




            // int Longitub = lblHistorial.Text.IndexOf("+") + "+".Length;
            // MessageBox.Show(Longitub.ToString());


            cajaResultado.Text = "0";
            cajaResultado.Focus();
        }
        private void btnSuma_Click(object sender, EventArgs e)
        {
            operador = Operacion.Suma;
            ObtenerValor("+");
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            if (valor2 == 0 && unNumeroLeido)
            {
                valor2 = Convert.ToDecimal(cajaResultado.Text);

                decimal resultado = EjecutarOperacion();
                valor1 = 0;
                valor2 = 0;
                unNumeroLeido = false;
                cajaResultado.Text = Convert.ToString(resultado);
                lblHistorial.Text = Acumulado.ToString("N2");
            }
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            operador = Operacion.Resta;
            ObtenerValor("-");
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            operador = Operacion.Multiplicacion;
            ObtenerValor("x");
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            operador = Operacion.Division;
            ObtenerValor("/");
            this.Focus();

        }

        private void btnModulo_Click(object sender, EventArgs e)
        {
            operador = Operacion.Modulo;
            ObtenerValor("%");
            cajaResultado.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cajaResultado.Text = "0";
            lblHistorial.Text = "";
            cajaResultado.Focus();
            Acumulado = 0;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (cajaResultado.Text.Length > 1)
            {
                string txtResultado = cajaResultado.Text;
                txtResultado = txtResultado.Substring(0, txtResultado.Length - 1);

                if (txtResultado.Length == 1 && txtResultado.Contains("-"))
                {
                    cajaResultado.Text = "0";
                }
                else
                {
                    cajaResultado.Text = txtResultado;
                }


            }
            else
            {
                cajaResultado.Text = "0";
            }
            cajaResultado.Focus();
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if (cajaResultado.Text.Contains("."))
            {
                return;
            }
            cajaResultado.Text += ",";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Focus();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ////if (e.KeyChar == Convert.ToChar(Keys.D1))
            ////{
            ////    LeerNumero("1");
            ////}
            ////if (e.KeyChar == Convert.ToChar(Keys.D2))
            ////{
            ////    LeerNumero("2");
            ////}
        }

        private void cajaResultado_KeyDown(object sender, KeyEventArgs e)
        {
           


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cajaResultado_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.NumPad1 || e.KeyData == Keys.D1)
                LeerNumero("1");
            if (e.KeyData == Keys.NumPad2 || e.KeyData == Keys.D2)
                LeerNumero("2");
            if (e.KeyData == Keys.NumPad3 || e.KeyData == Keys.D3)
                LeerNumero("3");
            if (e.KeyData == Keys.NumPad4 || e.KeyData == Keys.D4)
                LeerNumero("4");
            if (e.KeyData == Keys.NumPad5 || e.KeyData == Keys.D5)
                LeerNumero("5");
            if (e.KeyData == Keys.NumPad6 || e.KeyData == Keys.D6)
                LeerNumero("6");
            if (e.KeyData == Keys.NumPad7 || e.KeyData == Keys.D7)
                LeerNumero("7");
            if (e.KeyData == Keys.NumPad8 || e.KeyData == Keys.D8)
                LeerNumero("8");
            if (e.KeyData == Keys.NumPad9 || e.KeyData == Keys.D9)
                LeerNumero("9");
            if (e.KeyData == Keys.NumPad0 || e.KeyData == Keys.D0)
                LeerNumero("0");

            //OPERANDOS
            if (e.KeyData == Keys.Add)
            {
                operador = Operacion.Suma;
                ObtenerValor("+");
            }
            //if (e.KeyData == Keys.Subtract)
            //{
            //    operador = Operacion.Resta;
            //    ObtenerValor("-");
            //}
            //if (e.KeyData == Keys.Multiply)
            //{
            //    operador = Operacion.Multiplicacion;
            //    ObtenerValor("*");
            //}
            //if (e.KeyData == Keys.Divide)
            //{
            //    operador = Operacion.Division;
            //    ObtenerValor("/");
            //}

            //OTROS
            if (e.KeyData == Keys.Decimal)
            {
                if (cajaResultado.Text.Contains("."))
                {
                    return;
                }
                cajaResultado.Text += ",";
            }
            if (e.KeyData == Keys.Back)
            {
                if (cajaResultado.Text.Length > 1)
                {
                    string txtResultado = cajaResultado.Text;
                    txtResultado = txtResultado.Substring(0, txtResultado.Length - 1);

                    if (txtResultado.Length == 1 && txtResultado.Contains("-"))
                    {
                        cajaResultado.Text = "0";
                    }
                    else
                    {
                        cajaResultado.Text = txtResultado;
                    }


                }
                else
                {
                    cajaResultado.Text = "0";
                }
            }
            if (e.KeyData == Keys.Enter)
            {
                operador = Operacion.Suma;
                ObtenerValor("+");
            }
            ////MessageBox.Show(e.KeyCode.ToString(), "KeyDown");

            ////KeysConverter kc = new KeysConverter();
            ////MessageBox.Show(kc.ConvertToString(e.KeyCode), "KeyDown");

        }

        private void btnSuma_Click_1(object sender, EventArgs e)
        {

        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            cajaResultado.Text = "0";
            lblHistorial.Text = "";
            cajaResultado.Focus();
            Acumulado = 0;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            frmIngresoInsumoAgregar.txtCosto.Text = lblHistorial.Text;
            this.Close();
        }

        private void lblHistorial_Click(object sender, EventArgs e)
        {

        }

        private void btnBorrar_Click_1(object sender, EventArgs e)
        {

        }
    }
}