using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCodin_Sinlacc.Formularios.Orden_Produccion
{
    public partial class frmAgregarOrdenProduccion : Form
    {
        public frmAgregarOrdenProduccion()
        {
            InitializeComponent();
        }

        private void frmAgregarOrdenProduccion_Load(object sender, EventArgs e)
        {

        }

        private void chkFiltraCliente_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboCliente(chkFiltraCliente, cmbFiltraCliente, txtBuscarCliente, btnBuscarCliente);
        }

        private void txtBuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            txtBuscarCliente.Visible = true;
            txtBuscarCliente.Visible = true;
        }
    }
}
