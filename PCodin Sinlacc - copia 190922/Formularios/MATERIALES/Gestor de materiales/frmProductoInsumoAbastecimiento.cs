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

namespace PCodin_Sinlacc.Formularios.Productos___Insumos
{
    public partial class frmProductoInsumoAbastecimiento : Form
    {
        public string CrearEditar;
        public string ProductoID;
        public string DescripcionMedida;
        public decimal PuntoDePedido;
        public string InsPro;
        public frmProductoInsumoAbastecimiento()
        {
            InitializeComponent();
        }

        private void frmProductoInsumoAbastecimiento_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            using (var hb = new DBdatos())
            {
                var ConsultaDiasProduccion = (from DP in hb.ConfigDiasProduccion
                                              select DP).FirstOrDefault();

                var Consulta = (from PI in hb.Productos_Insumos
                                where PI.Codigo == ProductoID
                                select PI).FirstOrDefault();

                var ConsultaPuntoPedido = (from VPP in hb.Vista_CalcularPuntoPedido
                                           where VPP.Codigo == ProductoID
                                           select VPP).FirstOrDefault();

                if (ConsultaPuntoPedido != null)
                {
                    if (ConsultaDiasProduccion != null)
                        txtDiasProduccion.Text = ConsultaDiasProduccion.DiasProduccion.ToString();
                    else
                        txtDiasProduccion.Text = "0,00";
                    txtProducciónDiaria.Text = ConsultaPuntoPedido.ProduccionDiaria.ToString("N2");
                    txtDemoraProveedor.Text = ConsultaPuntoPedido.DemoraEntrega.ToString("N2");
                    lblPuntoPedido.Text = ConsultaPuntoPedido.PuntoPedido.ToString("N2");                   
                    lblMedida.Text = Consulta.Medidas_Producto.Descripcion.ToString();
                    if (Consulta.NotificaPuntoPedido == "SI")
                        cmbNotifica.SelectedIndex = 1;
                    if (Consulta.NotificaPuntoPedido == "NO")
                        cmbNotifica.SelectedIndex = 2;
                    if (Consulta.NotificaPuntoPedido == null)
                        cmbNotifica.SelectedIndex = 0;
                }              
                if(InsPro == "PRO")
                {
                    txtDiasProduccion.Enabled = false;
                    txtProducciónDiaria.Enabled = false;
                    txtDemoraProveedor.Enabled = false;
                    lblPuntoPedido.Text = "";
                    lblMedida.Text = "";
                    //if (Consulta.NotificaPuntoPedido == "SI")
                    //    cmbNotifica.SelectedIndex = 1;
                    //if (Consulta.NotificaPuntoPedido == "NO")
                    //    cmbNotifica.SelectedIndex = 2;
                    //if (Consulta.NotificaPuntoPedido == null)
                    //    cmbNotifica.SelectedIndex = 0;
                }
            }
        }
        private void CalcularPuntoPedido()
        {
            string PuntoPedido;

            if (txtDiasProduccion.Text != "" && txtProducciónDiaria.Text != "" && txtDemoraProveedor.Text != "")
            {
                decimal DiasProduccion = Convert.ToDecimal(txtDiasProduccion.Text);
                decimal ProduccionDiaria = Convert.ToDecimal(txtProducciónDiaria.Text);
                decimal DemoraProveedor = Convert.ToDecimal(txtDemoraProveedor.Text);

                PuntoDePedido = ProduccionDiaria * DemoraProveedor; // Este es el decimal que se va a la base de datos
                PuntoPedido = PuntoDePedido.ToString("N2");
                lblPuntoPedido.Text = PuntoPedido;
                lblMedida.Text = DescripcionMedida;
            }
            else
            {
                MessageBox.Show("No se realizará el calculo hasta que se completen todos los campos", "Atención");
            }
        }
        private void CalcularProduccionDiaria()
        {
            if (txtDiasProduccion.TextLength > 0)
            {
                decimal ProduccionDiaria;
                using (var hb = new DBdatos())
                {
                    //var Consulta = (from VINS in hb.Vista_CalcularProduccionDiaria
                    //                where VINS.Codigo == ProductoID
                    //                select VINS);

                    //var Resultados = Consulta.ToList();

                    //foreach(var item in Resultados)
                    //{
                    //    var ConsultaInsumo = (from INS in hb.Productos_Insumos
                    //                          where INS.Codigo == item.);
                    //}
                    //if (Resultados != null)
                    //{
                    //    ProduccionDiaria = ((decimal)Resultados.ProduccionDiaria / (Convert.ToDecimal(txtDiasProduccion.Text)));
                    //    txtProducciónDiaria.Text = ProduccionDiaria.ToString("N2");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("No hay producción para el elemto seleccionado", "Atención");
                    //}
                }
            }
            else
            {
                MessageBox.Show("Debe introducir un valor en 'Días productivos' para calcular la produccion diaria", "Atención");
            }
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            CalcularPuntoPedido();
        }

        private void btnCalcularProduccionDiaria_Click(object sender, EventArgs e)
        {
            CalcularProduccionDiaria();
        }
    }
}
