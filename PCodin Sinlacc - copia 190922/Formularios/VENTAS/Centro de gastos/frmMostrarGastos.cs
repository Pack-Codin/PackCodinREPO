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

namespace PCodin_Sinlacc.Formularios.Gastos
{
    public partial class frmMostrarGastos : Form
    {
        public frmMostrarGastos()
        {
            InitializeComponent();
        }
        private void frmMostrarGastos_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            Reutilizables.RenderizarForm(this);
            dtpFechaDesde.Value = DateTime.Now.Date;
            dtpFechaHasta.Value = DateTime.Now.Date;
            MostrarMovimientos();
        }
        private void MostrarMovimientos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from G in hb.MOVIMIENTOCUENTACORRIENTE
                                orderby G.Fecha , G.ID
                                select new
                                {
                                    G.ID,
                                    G.Movimiento_ID,
                                    G.Cliente_ID,
                                    Cliente = G.Clientes.Descripcion,
                                    Descripcion = G.MOVIMIENTOS.Descripcion,
                                    NumeroComprobante = G.NumeroComprobante.Substring(0, 4) + "-" + G.NumeroComprobante.Substring(4, 11),
                                    G.Fecha,
                                    G.Tipo_Gasto_ID,
                                    TipoGasto = G.Tipo_Gasto.Descripcion,                                 
                                    G.Valor,
                                    G.Observaciones,
                                    G.Estado_ID
                                }).Take(1000);

                if (cmbOrdenar.SelectedIndex == 1) // FECha
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Fecha descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Fecha ascending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 2) 
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Descripcion descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Descripcion ascending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 3) 
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Valor descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Valor ascending
                                    select C);
                }

                if (chkFiltraMovimiento.Checked)
                    Consulta = (from C in Consulta
                                where C.Movimiento_ID == (int)cmbMovimiento.SelectedValue
                                select C);

                if (chkFiltraCliente.Checked)
                    Consulta = (from C in Consulta
                                where C.Cliente_ID == (int)cmbCliente.SelectedValue
                                select C);

                if (chkFiltraConcepto.Checked)
                    Consulta = (from C in Consulta
                                where C.Tipo_Gasto_ID == (int)cmbFiltraConcepto.SelectedValue
                                select C);

                if (chkFiltraEstado.Checked)
                    Consulta = (from C in Consulta
                                where C.Estado_ID == cmbFiltraEstado.Text
                                select C);

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

                colGastoID.DataPropertyName = "ID";
                colFecha.DataPropertyName = "Fecha";
                ColMovimiento.DataPropertyName = "Descripcion";
                colNumeroComprobante.DataPropertyName = "NumeroComprobante";
                colImporte.DataPropertyName = "Valor";
                colEstado.DataPropertyName = "Estado_ID";
                colObservacion.DataPropertyName = "Observacion";

                lblResultados.Text = Resultados.Count().ToString();

                dgvGastos.AutoGenerateColumns = false;
                dgvGastos.DataSource = Resultados;
            }
        }
        private void AbrirForm(string CrearEditarCopiar)
        {
            try
            {
                using (var hb = new DBdatos())
                {
                    var ConsultaUsuario = (from U in hb.Usuarios where U.ID == clsVariablesGenerales.UsuarioID select U).FirstOrDefault();

                    var ConsultaValCaja = (from C in hb.CAJAUSUARIO
                                           where C.Estado == "PEN"
                                                && C.Usuario_ID == clsVariablesGenerales.UsuarioID
                                           select C).FirstOrDefault();

                    if(ConsultaValCaja != null)
                    {
                        var f = new frmAgregarGastos();
                        //f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmInicioProductoInsumo_FormClosed);
                        f.CrearEditarCopiar = CrearEditarCopiar;
                        f.CajaUsuarioID = ConsultaValCaja.ID;
                        f.ModuloID = 6;
                        if (CrearEditarCopiar != "1")
                            f.ID = (long)dgvGastos.CurrentRow.Cells[0].Value;
                        AddOwnedForm(f);
                        f.TopLevel = false;
                        f.Dock = DockStyle.Fill;
                        this.Controls.Add(f);
                        this.Tag = f;
                        f.BringToFront();
                        f.WindowState = FormWindowState.Maximized;
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("No hay ninguna caja abierta para el usuario " + ConsultaUsuario.Nombre + ". Por favor aperture una CAJA para poder cargar movimientos con dicho usuario");
                        return;
                    }
       
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }                
        }
        private void EliminarGasto()
        {
            if (dgvGastos.RowCount > 0)
            {
                DialogResult R = MessageBox.Show("¿Seguro que desea eliminar este registro?", "Atención", MessageBoxButtons.YesNo);
                if (R == DialogResult.Yes)
                {
                    long IDaEliminar = (long)dgvGastos.CurrentRow.Cells[0].Value;

                    using (var hb = new DBdatos())
                    {
                        var Consulta = (from G in hb.Gastos
                                        where G.ID == IDaEliminar
                                        select G).FirstOrDefault();

                        hb.Gastos.Remove(Consulta);
                        hb.SaveChanges();
                        MessageBox.Show("El gasto fue eliminado correctamente", "Atención");
                        MostrarMovimientos();
                    }
                }
            }
        }
        private void FormatearCeldas(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvGastos.RowCount > 0)
            {
                if (this.dgvGastos.Columns[e.ColumnIndex].Name == "colEstado")
                {
                    if (e.Value.ToString() == "FI")
                    {
                        e.Value = "Finalizado";
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        e.CellStyle.SelectionForeColor = Color.Green;
                        e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                    }
                    else
                    {
                        e.Value = "Anulado";
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                        e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                    }
                }
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirForm("1");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvGastos.RowCount > 0)
                AbrirForm("2");
        }

        private void dgvGastos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGastos.RowCount > 0)
                AbrirForm("2");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarMovimientos();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Reutilizables.ExportarExcel(dgvGastos);
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (dgvGastos.RowCount > 0)
                AbrirForm("3");
        }

        private void btnBuscarDesc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarMovimientos();
        }

        private void btnBuscarAsc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarMovimientos();
        }

        private void txtBuscaConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaConcepto.Visible = false;
                clsCargarCombos.MostrarComboConcepto(cmbFiltraConcepto, txtBuscaConcepto, true);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaConcepto.Visible = false;
            }
        }

        private void cmbFiltraConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboConcepto(cmbFiltraConcepto, txtBuscaConcepto, false);
            }
        }

        private void btnBuscarConcepto_Click(object sender, EventArgs e)
        {
            txtBuscaConcepto.Visible = true;
            txtBuscaConcepto.Select();
        }

        private void chkFiltraConcepto_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboConceptos(chkFiltraConcepto, cmbFiltraConcepto, txtBuscaConcepto, btnBuscarConcepto);
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarMovimientos();
        }

        private void txtBuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarCliente.Visible = false;
                clsCargarCombos.MostrarComboClientes(cmbCliente, txtBuscarCliente, true, "CLI", 0);
                txtBuscarCliente.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarCliente.Visible = false;
                txtBuscarCliente.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            txtBuscarCliente.Visible = true;
            txtBuscarCliente.Select();
        }

        private void cmbCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboClientes(cmbCliente, txtBuscarCliente, false, "CLI", 0);
                txtBuscarCliente.Focus();
                e.Handled = true;
            }
        }

        private void chkFiltraMovimiento_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraMovimiento, cmbMovimiento);
            clsCargarCombos.MostrarComboMovimientos(cmbMovimiento, 6,"");
        }

        private void gbxFiltros_Enter(object sender, EventArgs e)
        {

        }

        private void chkFiltraCliente_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboCliente(chkFiltraCliente, cmbCliente, txtBuscarCliente, btnBuscarCliente);
        }

        private void btnBuscarConcepto_Click_1(object sender, EventArgs e)
        {
            txtBuscaConcepto.Visible = true;
            txtBuscaConcepto.Select();
        }

        private void dgvGastos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatearCeldas(e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraEstado,cmbFiltraEstado);
        }
    }
}