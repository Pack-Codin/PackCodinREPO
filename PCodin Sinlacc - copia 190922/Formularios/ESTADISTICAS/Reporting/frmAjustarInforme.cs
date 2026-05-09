using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using PCodin_Sinlacc.Datos;

namespace PCodin_Sinlacc.Formularios.Reportes
{
    public partial class frmAjustarInforme : Form
    {
        public frmAjustarInforme()
        {
            InitializeComponent();
        }
        public ReportDocument Informe;
        private void InicializarForm()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from L in hb.ClientesLogo
                                select L).FirstOrDefault();

                if (Consulta != null)
                {
                    txtAlto.Text = Consulta.Largo.ToString();
                    txtAncho.Text = Consulta.Ancho.ToString();
                }
                else
                {
                    txtAlto.Text = "0";
                    txtAncho.Text = "0";
                }
            }
        }
        private void AjustarDatos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from L in hb.ClientesLogo
                                select L).FirstOrDefault();

                Consulta.Largo = Convert.ToInt32(txtAlto.Text);
                Consulta.Ancho = Convert.ToInt32(txtAncho.Text);
              
                hb.SaveChanges();
                this.Close();
            }
        }
        private void frmAjustarInforme_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }

        private void btnAjustar_Click(object sender, EventArgs e)
        {
            AjustarDatos();
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
