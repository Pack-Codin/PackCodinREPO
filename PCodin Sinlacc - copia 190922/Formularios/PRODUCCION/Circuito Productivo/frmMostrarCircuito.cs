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
using PCodin_Sinlacc.Clases.UsuarioTema;
using PCodin_Sinlacc.Clases;

namespace PCodin_Sinlacc.Formularios.Circuito_Productivo
{
    public partial class frmMostrarCircuito : Form
    {
        public int UsuarioID;
        public int AA;
        public frmMostrarCircuito()
        {
            InitializeComponent();
        }
        
        private void frmMostrarCircuito_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            Reutilizables.RenderizarForm(this);
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);        
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from PI in hb.Seccion_Circuito
                               group PI by new { PI.Producto_ID , PI.Productos_Insumos.Descripcion } into Group
                               orderby Group.Key.Descripcion
                               select new
                               {
                                   Group.Key.Producto_ID,
                                   Group.Key.Descripcion
                               });

                var Resultados = Consulta.ToList();

                colProductoID.DataPropertyName = "Producto_ID";
                colProducto.DataPropertyName = "Descripcion";

                lblResultados.Text = Resultados.Count().ToString();
                dgvCircuitoProd.AutoGenerateColumns = false;
                dgvCircuitoProd.DataSource = Resultados;

            }
        }
        private void AbrirformAgregarCircuitoProd(string AgregarEditar)
        {
            var f = new frmAgregarCircuito();
            f.CrearEditar = AgregarEditar;
            if (AgregarEditar == "2")
            {
                f.CodigoProduto = dgvCircuitoProd.CurrentRow.Cells[columnName: "colProductoID"].Value.ToString();
                f.Producto = dgvCircuitoProd.CurrentRow.Cells[1].Value.ToString();
            }
            AddOwnedForm(f);
            f.TopLevel = false;
            //f.UsuarioID = UsuarioID;
            f.Dock = DockStyle.Fill;
            this.Controls.Add(f);
            this.Tag = f;
            f.BringToFront();
            f.WindowState = FormWindowState.Maximized; 
            f.Show();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirformAgregarCircuitoProd("1");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(dgvCircuitoProd.RowCount > 0)
                AbrirformAgregarCircuitoProd("2");
        }

        private void dgvSeccion_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvCircuitoProd.RowCount > 0)
                AbrirformAgregarCircuitoProd("2");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvCircuitoProd.RowCount > 0)
            {
                DialogResult R = MessageBox.Show("¿Seguro que desea eliminar este circuito productivo?", "Atención", MessageBoxButtons.YesNoCancel);

                if(R == DialogResult.Yes)
                {
                    string ProductoID = dgvCircuitoProd.CurrentRow.Cells[columnName: "colProductoID"].Value.ToString();

                    using (var hb = new DBdatos())
                    {
                        var ConsultaCircuito = (from CIR in hb.Seccion_Circuito
                                                where CIR.Producto_ID == ProductoID
                                                select CIR).ToList();

                        hb.Seccion_Circuito.RemoveRange(ConsultaCircuito);
                        hb.SaveChanges();
                        MessageBox.Show("Circuito productivo eliminado correctamente");
                        MostrarDatos();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Reutilizables.ExportarExcel(dgvCircuitoProd);
        }

        private void chkFiltraProducto_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraProducto, cmbProducto, txtBuscarProducto, btnBuscarIProducto, "PRO", "NO");
        }

        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsFiltros.FiltroProductoInsumoBuscar("Text",sender, e, txtBuscarProducto, cmbProducto, "PRO", "NO");
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
            Reutilizables.ReubicarFiltros(gbxFiltros, pnlInferior, btnMostrarfiltros);
        }

        private void btnBuscarIProducto_Click(object sender, EventArgs e)
        {
            clsFiltros.FiltroActivar(txtBuscarProducto);
        }

        private void cmbProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsFiltros.FiltroProductoInsumoBuscar("Combo", sender, e, txtBuscarProducto, cmbProducto, "PRO", "NO");
        }

        private void cmbProducto_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
