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
    public partial class frmAfectarPedido : Form
    {
        public int IDRecibido;
        public frmAfectarPedido()
        {
            InitializeComponent();
        }
        private void MostrarOrdenesPedido()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from OP in hb.Registro_Pedidos
                                join PC in hb.Pedido_Cuerpo on OP.ID equals PC.Pedido_ID
                                join PRO in hb.Productos_Insumos on PC.Producto_ID equals PRO.Codigo
                                where OP.Cliente_ID == IDRecibido
                                orderby OP.Fecha descending
                                select new
                                {
                                    OP.ID,
                                    OP.Fecha,
                                    OP.Cliente_ID,
                                    Cliente = OP.Clientes.Descripcion,
                                    OP.Ciudad_ID,
                                    Ciudad = OP.Ciudades.Descripcion,
                                  //  OP.Estado,
                                    PC.Cantidad,
                                    OP.Observaciones,
                                    PRO.Codigo,
                                }).Take(1000);

                //if (chkFiltraCliente.Checked)
                //    Consulta = (from C in Consulta
                //                where C.Cliente_ID == (int)cmbCliente.SelectedValue
                //                select C);

                //if (chkFiltraCiudad.Checked)
                //    Consulta = (from C in Consulta
                //                where C.Ciudad_ID == (int)cmbCiudad.SelectedValue
                //                select C);

                if (chkFiltraNroPedido.Checked)
                {
                    long NroPedido = Convert.ToInt64(txtFiltraNroPedido.Text);

                    Consulta = (from C in Consulta
                                where C.ID == NroPedido
                                select C);
                }

                if (chkFiltraProducto.Checked)
                    Consulta = (from C in Consulta
                                where C.Codigo == cmbProducto.SelectedValue.ToString()
                                select C);

                //if (chkFiltraEstado.Checked)
                //    Consulta = (from C in Consulta
                //                where C.Estado == cmbFiltraEstado.Text
                //                select C);

                if (chkFechaDesde.Checked && chkFechaHasta.Checked == false)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha >= dtpFechaDesde.Value.Date
                                select C);
                }
                else if (chkFechaDesde.Checked == false && chkFechaHasta.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha <= dtpFechaHasta.Value.Date
                                select C);
                }
                else if (chkFechaDesde.Checked && chkFechaHasta.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha >= dtpFechaDesde.Value.Date && C.Fecha <= dtpFechaHasta.Value.Date
                                select C);
                }

                var Resultados = Consulta.ToList();

                colID.DataPropertyName = "ID";
                colFecha.DataPropertyName = "Fecha";
                colCliente.DataPropertyName = "Cliente";
                colCiudad.DataPropertyName = "Ciudad";
                colEstado.DataPropertyName = "Estado";
                colObservacion.DataPropertyName = "Observaciones";

                txtCantidadResultados.Text = Resultados.Count.ToString();

                dgvOrdenPedido.AutoGenerateColumns = false;
                dgvOrdenPedido.DataSource = Resultados;
            }
        }

        private void frmAfectarPedido_Load(object sender, EventArgs e)
        {
            dtpFechaHasta.Value = DateTime.Now.Date;
            dtpFechaDesde.Value = DateTime.Now.Date.AddDays(-30);
            MostrarOrdenesPedido();
        }
        private void AfectarAfecciónCuerpo()
        {
            var f = new frmAfeccionCuerpo();
            //  f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmAgregarOrdenCarga_FormClosed);
            //f.PulsoAgregarEditar = AgregarEditar;
            //f.IDRecibido = this.IDRecibido;
            f.IDPedidoRecibido = (long)dgvOrdenPedido.CurrentRow.Cells[0].Value;
            AddOwnedForm(f);
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.Controls.Add(f);
            this.Tag = f;
            f.BringToFront();
            f.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvOrdenPedido_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AfectarAfecciónCuerpo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarOrdenesPedido();
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros,btnMostrarfiltros,lblfiltros);
        }

        private void chkFiltraProducto_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsProConCheck(chkFiltraProducto, cmbProducto, txtBuscarProducto, chkMuestraInsProActInac, btnBuscarIProducto);
        }

        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarProducto.Visible = false;
                clsCargarCombos.MostrarComboProducto(cmbProducto, txtBuscarProducto, true, chkMuestraInsProActInac);
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarProducto.Visible = false;
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void cmbProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboProducto(cmbProducto, txtBuscarProducto, false, chkMuestraInsProActInac);
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarIProducto_Click(object sender, EventArgs e)
        {
            txtBuscarProducto.Visible = true;
            txtBuscarProducto.Select();
        }

        private void chkFiltraNroPedido_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraNroPedido, chkFiltraNroPedido);
        }
    }
}
