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

namespace PCodin_Sinlacc.Formularios.Productos___Insumos.Insumos
{
    public partial class frmRelacionesInsumos : Form
    {
        public long ID;
        public frmRelacionesInsumos()
        {
            InitializeComponent();
        }

        private void frmRelacionesInsumos_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            using (var hb = new DBdatos())
            {
                var ConsultaInsumos = (from EI in hb.ExistenciaProducto_ExistenciaInsumo
                                       where EI.ExistenciaInsumo_ID == ID
                                       orderby EI.ExitenciaProducto_ID
                                       select new
                                       {
                                           EI.ExitenciaProducto_ID,
                                           Producto = EI.Existencia_ProductoTerminado.Productos_Insumos.Descripcion,
                                           EI.Cantidad
                                       });

                var ResultadosInsumo = ConsultaInsumos.ToList();

                colProduccion.DataPropertyName = "ExitenciaProducto_ID";
                colProducto.DataPropertyName = "Producto";
                colCantidad.DataPropertyName = "Cantidad";

                dgvInsumo.AutoGenerateColumns = false;
                dgvInsumo.DataSource = ResultadosInsumo;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
