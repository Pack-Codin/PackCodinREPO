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
using PCodin_Sinlacc.Clases;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmCotizacionMoneda : Form
    {
        public frmCotizacionMoneda()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if(txtValor.TextLength > 0)
            {
                DateTime FechaHoy = DateTime.Now.Date;
                decimal Valor = Convert.ToDecimal(txtValor.Text);

                if (Valor > 0)
                {
                    using (var hb = new DBdatos())
                    {
                        var Consulta = (from CO in hb.MonedaCotizacion
                                        where CO.Moneda_ID == "DO"  
                                            && CO.Fecha == FechaHoy
                                        select CO).FirstOrDefault();

                        if(Consulta == null)
                        {
                            var i = new MonedaCotizacion();

                            i.Fecha = DateTime.Now.Date;
                            i.Moneda_ID = "DO";
                            i.Valor = Valor;

                            hb.MonedaCotizacion.Add(i);
                        }
                        else
                        {
                            Consulta.Valor = Valor;
                        }
                        hb.SaveChanges();
                        MessageBox.Show("Cotización cargada correctamente", "Atención");
                    }
                }
                else
                {
                    MessageBox.Show("La cotización no puede ser 0", "Atención");
                }
            }
            else
            {
                MessageBox.Show("No digitó ningun valor", "Atención");
            }
        }
        private void InicializarForm()
        {
            linkLabel1.Links.Add(0, 0, linkLabel1.Text);

            using (var hb = new DBdatos())
            {
                var Consulta = (from CO in hb.MonedaCotizacion
                                where CO.Moneda_ID == "DO"
                                orderby CO.Fecha descending
                                select CO).FirstOrDefault();

                if(Consulta != null)
                {
                    txtValor.Text = Consulta.Valor.ToString();
                }
                else
                {
                    txtValor.Text = "0,00";
                }
            }
        }
        private void frmCotizacionMoneda_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtValor);
        }

        private void txtValor_TextChanged_1(object sender, EventArgs e)
        {
          //  Reutilizables.ValidarSoloNumeros2(txtValor);
        }

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
    }
}
