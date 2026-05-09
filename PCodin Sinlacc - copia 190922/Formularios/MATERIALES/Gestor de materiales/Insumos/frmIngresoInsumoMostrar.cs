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
using PCodin_Sinlacc.Formularios.Productos___Insumos.Insumos;
using PCodin_Sinlacc.Formularios.MATERIALES.frmIngresoInsumo;
using PCodin_Sinlacc.Clases.UsuarioTema;

namespace PCodin_Sinlacc.Formularios.Productos___Insumos
{
    public partial class frmIngresoInsumoMostrar : Form
    {
        public frmIngresoInsumoMostrar()
        {
            InitializeComponent();
        }

        string CrearEditar;
        string IDEditar;

        private void frmCompraInsumo_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            Reutilizables.RenderizarForm(this);
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
            dtpFechaHasta.Value = DateTime.Now.Date;
            dtpFechaDesde.Value = DateTime.Now.Date.AddDays(-30);
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from IM in hb.INGRESOMERCADERIA
                                orderby IM.Fecha , IM.ID 
                                select new
                                {
                                    IM.ID,
                                    IM.Fecha,
                                    IM.Proveedor_ID,
                                    Proveedor = IM.Clientes.Descripcion,
                                    IM.Movimiento_ID,
                                    Movimiento = IM.MOVIMIENTOS.Descripcion,
                                    IM.Estado,
                                    IM.ImporteTotal
                                });

                if (cmbOrdenar.SelectedIndex == 1) 
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Fecha ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Fecha descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 2)
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Movimiento_ID ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Movimiento_ID descending
                                    select C);
                }              
                if (cmbOrdenar.SelectedIndex == 4)
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Proveedor ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Proveedor descending
                                    select C);
                }                          
                if (chkFiltraMovimiento.Checked)
                    Consulta = (from C in Consulta
                                where C.Movimiento_ID == (int)cmbFiltraMovimiento.SelectedValue
                                select C);

                if (chkFiltraProveedor.Checked)
                    Consulta = (from C in Consulta
                                where C.Proveedor_ID == (int)cmbFiltraProveedor.SelectedValue
                                select C);

                if(chkFiltraEstado.Checked)
                    Consulta = (from C in Consulta
                                where C.Estado == cmbFiltraEstado.Text
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

                var Resultados = Consulta.Take(1000).ToList();

                colID.DataPropertyName = "ID";
                colFecha.DataPropertyName = "Fecha";
                colMovimiento.DataPropertyName = "Movimiento";              
                colProveedor.DataPropertyName = "Proveedor";
                colEstado.DataPropertyName = "Estado";
                colImporte.DataPropertyName = "ImporteTotal";
                lblResultados.Text = Resultados.Count.ToString();

                dgvInsumo.AutoGenerateColumns = false;
                dgvInsumo.DataSource = Resultados;
            }
        }
        private void FormatearCeldas(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvInsumo.RowCount > 0)
            {
                if (this.dgvInsumo.Columns[e.ColumnIndex].Name == "colEstado")
                {
                    if (e.Value.ToString() == "FI")
                    {
                        e.Value = "Finalizado";
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        e.CellStyle.SelectionForeColor = Color.Green;
                        e.CellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    }
                    if (e.Value.ToString() == "AN")
                    {
                        e.Value = "Anulada";
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                        e.CellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    }                   
                }
                if (this.dgvInsumo.Columns[e.ColumnIndex].Name == "colCantidad")
                {
                    e.CellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                }
                //if (this.dgvInsumo.Columns[e.ColumnIndex].Name == "colCantidadUtilzada")
                //{
                //    e.CellStyle.ForeColor = Color.Red;
                //    e.CellStyle.SelectionForeColor = Color.Red;
                //    e.CellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                //}
                //if (this.dgvInsumo.Columns[e.ColumnIndex].Name == "colCantidadDisp")
                //{
                //    e.CellStyle.ForeColor = Color.DarkGreen;
                //    e.CellStyle.SelectionForeColor = Color.DarkGreen;
                //    e.CellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                //}
            }
        }
        private void EliminarInsumo()
        {
            if (dgvInsumo.RowCount > 0)
            {
                DialogResult R = MessageBox.Show("¿Seguro que desea eliminar este registro?", "Atención",MessageBoxButtons.YesNo);
                if (R == DialogResult.Yes)
                {
                    long IDaEliminar = (long)dgvInsumo.CurrentRow.Cells[0].Value;
                   // decimal CantidadUtilizada = (decimal)dgvInsumo.CurrentRow.Cells[6].Value;
                    using (var hb = new DBdatos())
                    {
                        var ConsultaCabezal = (from CAB in hb.INGRESOMERCADERIA
                                               where CAB.ID == IDaEliminar
                                               select CAB).FirstOrDefault();

                        var ConsultaCuerpo = (from CU in hb.INGRESOMERCADERIACUERPO
                                              where CU.Ingreso_ID == IDaEliminar
                                              select CU).ToList();

                        if (ConsultaCabezal.Estado  == "AN")
                        {
                            hb.INGRESOMERCADERIACUERPO.RemoveRange(ConsultaCuerpo);
                            hb.INGRESOMERCADERIA.Remove(ConsultaCabezal);
                        }
                        else
                        {
                            MessageBox.Show("Solo se pueden eliminar movimientos en estado 'Anulado'", "Atención");
                            return;
                        }
                        hb.SaveChanges();
                        MessageBox.Show("El movimiento fue eliminado correctamente", "Atención");
                        MostrarDatos();
                    }
                }                
            }
        }
        private void AbrirForm(string Accion)
        {
            var f = new frmIngresoInsumo();         
            f.Accion = Accion;
            if (Accion != "1" )
                f.IDRecibido = (long)dgvInsumo.CurrentRow.Cells["colID"].Value;
            AddOwnedForm(f);          
            f.TopLevel = false;
           
            //f.Dock = DockStyle.Fill;
            f.StartPosition = FormStartPosition.CenterParent;
            f.WindowState = FormWindowState.Maximized;            
            Clases.Formularios.Inicio.frmMenu.pnlCentral2.Controls.Add(f);
            Clases.Formularios.Inicio.frmMenu.pnlCentral2.Tag = f;
            this.Controls.Add(f);
            this.Tag = f;
            f.BringToFront();
            f.Show();


        }
        private void dgvInsumo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatearCeldas(e);
        }

        private void btnBuscarDesc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarDatos();
        }

        private void btnBuscarAsc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarDatos();
        }
        private void chkFiltraProveedor_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboProveedor(chkFiltraProveedor, cmbFiltraProveedor, txtBuscaProveedor, btnBuscarProveedor);        
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
            Reutilizables.ReubicarFiltros(gbxFiltros, pnlInferior, btnMostrarfiltros);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void chkFiltraEstado_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraEstado, cmbFiltraEstado);
        }      
        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            txtBuscaProveedor.Visible = true;
            txtBuscaProveedor.Select();
        }
        private void txtBuscaProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaProveedor.Visible = false;
                clsCargarCombos.MostrarComboClientes(cmbFiltraProveedor, txtBuscaProveedor, true, "PRO", 0);
                txtBuscaProveedor.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaProveedor.Visible = false;
                txtBuscaProveedor.Focus();
                e.Handled = true;
            }
        }       
        private void cmbFiltraProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboClientes(cmbFiltraProveedor, txtBuscaProveedor, false, "PRO", 0);
                txtBuscaProveedor.Focus();
                e.Handled = true;
            }
        }      
        private void btnExcel_Click(object sender, EventArgs e)
        {
            Reutilizables.ExportarExcel(dgvInsumo);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarInsumo();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirForm("1");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AbrirForm("2");
        }

        private void dgvInsumo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInsumo.RowCount > 0)
                AbrirForm("2");
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (dgvInsumo.RowCount > 0)
                AbrirForm("3");
        }

        private void chkFiltraMovimiento_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraMovimiento, cmbFiltraMovimiento);
            clsCargarCombos.MostrarComboMovimientos(cmbFiltraMovimiento, 1,"");
        }

        private void btnRelacion_Click(object sender, EventArgs e)
        {
            if(dgvInsumo.RowCount > 0)
            {
                var f = new frmRelacionesInsumos();
                f.ID = (long)dgvInsumo.CurrentRow.Cells[0].Value;
                f.Show();
            }
        }

        private void txtBuscaProveedor_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
