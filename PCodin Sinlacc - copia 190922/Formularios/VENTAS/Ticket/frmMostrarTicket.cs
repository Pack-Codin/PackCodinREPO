using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Datos;
using PCodin_Sinlacc.Formularios.VENTAS;

namespace PCodin_Sinlacc.Formularios.VENTAS.Ticket
{
    public partial class frmMostrarTicket : Form
    {
        public frmMostrarTicket()
        {
            InitializeComponent();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirForm("1");
        }
        private void AbrirForm(string Accion)
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
                        var f = new frmAgregarTicket();
                        f.Accion = Accion;
                        f.CajaUsuarioID = ConsultaValCaja.ID;
                        if (Accion != "1")
                        {
                            if (dgvTicket.RowCount > 0)
                                f.IDRecibido = Convert.ToInt64(dgvTicket.CurrentRow.Cells["colID"].Value);
                        }
                        AddOwnedForm(f);
                        f.WindowState = FormWindowState.Maximized;
                        f.TopLevel = false;
                        this.Controls.Add(f);
                        this.Tag = f;
                        f.BringToFront();
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
        private void MostrarDatos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from IM in hb.TICKET
                                orderby IM.Fecha, IM.ID
                                select new
                                {
                                    IM.ID,
                                    IM.Fecha,
                                    IM.Cliente_ID,
                                    Cliente = IM.Clientes.Descripcion,
                                    IM.Movimiento_ID,
                                    Movimiento = IM.MOVIMIENTOS.Descripcion,
                                    IM.MedioPago,
                                    IM.ImporteTotal,
                                    NumeroTicket = IM.NumeroTicket.Substring(0, 4) + "-" + IM.NumeroTicket.Substring(4, 11),
                                    IM.Estado
                                });

                //if (cmbOrdenar.SelectedIndex == 1)
                //{
                //    if (btnBuscarAsc.Visible == true)
                //        Consulta = (from C in Consulta
                //                    orderby C.Fecha ascending
                //                    select C);
                //    else
                //        Consulta = (from C in Consulta
                //                    orderby C.Fecha descending
                //                    select C);
                //}
                //if (cmbOrdenar.SelectedIndex == 2)
                //{
                //    if (btnBuscarAsc.Visible == true)
                //        Consulta = (from C in Consulta
                //                    orderby C.Movimiento_ID ascending
                //                    select C);
                //    else
                //        Consulta = (from C in Consulta
                //                    orderby C.Movimiento_ID descending
                //                    select C);
                //}
                //if (cmbOrdenar.SelectedIndex == 4)
                //{
                //    if (btnBuscarAsc.Visible == true)
                //        Consulta = (from C in Consulta
                //                    orderby C.Proveedor ascending
                //                    select C);
                //    else
                //        Consulta = (from C in Consulta
                //                    orderby C.Proveedor descending
                //                    select C);
                //}
                ////if (cmbOrdenar.SelectedIndex == 6)
                //{
                //    if (btnBuscarAsc.Visible == true)
                //        Consulta = (from C in Consulta
                //                    orderby C.Cantidad_Utilizada ascending
                //                    select C);
                //    else
                //        Consulta = (from C in Consulta
                //                    orderby C.Cantidad_Utilizada descending
                //                    select C);
                //}
                //if (cmbOrdenar.SelectedIndex == 7)
                //{
                //    if (btnBuscarAsc.Visible == true)
                //        Consulta = (from C in Consulta
                //                    orderby C.CantidadDisp ascending
                //                    select C);
                //    else
                //        Consulta = (from C in Consulta
                //                    orderby C.CantidadDisp descending
                //                    select C);
                //}





                if (chkFiltraMovimiento.Checked)
                    Consulta = (from C in Consulta
                                where C.Movimiento_ID == (int)cmbFiltraMovimiento.SelectedValue
                                select C);

                if (chkFiltraCliente.Checked)
                    Consulta = (from C in Consulta
                                where C.Cliente_ID == (int)cmbFiltraCliente.SelectedValue
                                select C);

                if (chkFiltraNumComprobante.Checked)
                {
                    string Numero = txtFiltraPtoVenta.Text + "-" + txtFiltraNumComprobante.Text;

                    Consulta = (from C in Consulta
                                where C.NumeroTicket == Numero
                                select C);
                }

                if (chkFiltraEstado.Checked)
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
                colComprobante.DataPropertyName = "Movimiento";
                colCliente.DataPropertyName = "Cliente";
                colNroTicket.DataPropertyName = "NumeroTicket";
                colImporte.DataPropertyName = "ImporteTotal";
                colEstado.DataPropertyName = "Estado";

                lblResultados.Text = Resultados.Count.ToString();

                dgvTicket.AutoGenerateColumns = false;
                dgvTicket.DataSource = Resultados;
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            AbrirForm("2");
        }

        private void dgvTicket_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirForm("2");
        }
        private void btnCopiar_Click(object sender, EventArgs e)
        {
            AbrirForm("3");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
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

        private void frmMostrarTicket_Load(object sender, EventArgs e)
        {
            Reutilizables.RenderizarForm(this);
            dtpFechaDesde.Value = DateTime.Now.Date;
            dtpFechaHasta.Value = DateTime.Now.Date;
        }

        private void chkFiltraEstado_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraEstado, cmbFiltraEstado);
        }

        private void chkFiltraNumComprobante_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDobleTexbox(txtFiltraPtoVenta, txtFiltraNumComprobante, chkFiltraNumComprobante);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscaCliente_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtFiltraPtoVenta_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtFiltraNumComprobante_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void chkFiltraCliente_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboCliente(chkFiltraCliente, cmbFiltraCliente, txtBuscaCliente, btnBuscarCliente);
        }

        private void dgvTicket_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTicket.RowCount > 0)
            {
                if (this.dgvTicket.Columns[e.ColumnIndex].Name == "colEstado")
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
            }
        }

        private void txtBuscaCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaCliente.Visible = false;
                clsCargarCombos.MostrarComboClientes(cmbFiltraCliente, txtBuscaCliente, true, "CLI", 0);
                txtBuscaCliente.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaCliente.Visible = false;
                txtBuscaCliente.Focus();
                e.Handled = true;
            }
        }

        private void cmbFiltraCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboClientes(cmbFiltraCliente, txtBuscaCliente, false, "CLI", 0);
                txtBuscaCliente.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            txtBuscaCliente.Visible = true;
            txtBuscaCliente.Select();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
