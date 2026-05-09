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

namespace PCodin_Sinlacc.Formularios.Configuracion
{
    public partial class frmConfigMateriales : Form
    {
        public frmConfigMateriales()
        {
            InitializeComponent();
        }
        public int ModuloID;
        private void frmConfigMateriales_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            using (var hb = new DBdatos())
            {
                var ConsultaConfig = (from CONF in hb.PcnConfiguraciones
                                      where CONF.Modulo_ID == ModuloID
                                      select CONF).FirstOrDefault();

                var Consulta = (from IP in hb.ConfigDiasProduccion                                                            
                                select IP);

                var Resultados = Consulta.FirstOrDefault();

                if(Resultados != null)
                {
                    txtProdDiaria.Text = Resultados.DiasProduccion.ToString();
                }
                else
                {
                    txtProdDiaria.Text = "";
                }
                if (ConsultaConfig.TrabajaConStockNegativo == "SI")
                    chkTrabajaStockNegativo.Checked = true;
                else
                    chkTrabajaStockNegativo.Checked = false;
                
            }
        }

        private void txtProdDiaria_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
