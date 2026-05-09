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
using PCodin_Sinlacc.Formularios.VENTAS.OrdenCarga;
using PCodin_Sinlacc.Clases.UsuarioTema;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmMostrarOrdenesCarga : Form
    {
        
        public frmMostrarOrdenesCarga()
        {
            InitializeComponent();
            Reutilizables.RenderizarForm(this);
        }

        private void frmMostrarOrdenesCarga_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
            dtpFechaHasta.Value = DateTime.Now.Date;
            dtpFechaDesde.Value = DateTime.Now.Date.AddDays(-30);
            MostrarOrdenesCarga();

        }
        private void MostrarOrdenesCarga()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from OC in hb.Orden_Carga
                                orderby OC.Fecha  , OC.ID 
                                select new
                                {
                                    OC.ID,
                                    OC.Fecha,
                                    OC.Cliente_ID,
                                    Cliente = OC.Clientes.Descripcion,
                                    OC.Ciudad_ID,
                                    Ciudad = OC.Ciudades.Descripcion,
                                    OC.Estado_ID,
                                    Estado = OC.Estado_Ord_Carga.Descripcion,
                                    OC.Observaciones,
                                    OC.Modo
                                
                                }).Take(1000);

                if (cmbOrdenar.SelectedIndex == 1) // Nro
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.ID ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.ID descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 2) // Fecha
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
                if (cmbOrdenar.SelectedIndex == 3) // Clientes
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Cliente ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Cliente descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 4) // Ciudad
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Ciudad ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Ciudad descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 4) // Estado
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Estado ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Estado descending
                                    select C);
                }

                if (chkFiltraNumero.Checked && txtFiltraNumero.TextLength > 0)
                {
                    long Orden_ID = Convert.ToInt64(txtFiltraNumero.Text);

                    Consulta = (from C in Consulta
                                where C.ID == Orden_ID
                                select C);
                }

                if(chkFiltraPedido.Checked)
                {
                    List<long>ListIDOC = new List<long>();

                    var ConsultaOCC = (from OCC in hb.OrdenCarga_Cuerpo
                                       where OCC.NumeroPedido == txtFiltraPedido.Text
                                       select OCC).ToList();

                    foreach(var item in ConsultaOCC)
                    {
                        ListIDOC.Add(item.Orden_ID);
                    }

                    Consulta = (from C in Consulta
                                where ListIDOC.Contains(C.ID)
                                select C);
                }

                if (chkFiltraCliente.Checked)
                    Consulta = (from C in Consulta
                                where C.Cliente_ID == (int)cmbCliente.SelectedValue
                                select C);

                if (chkFiltraCiudad.Checked)
                    Consulta = (from C in Consulta
                                where C.Ciudad_ID == (int)cmbCiudad.SelectedValue
                                select C);

                if (chkFiltraProducto.Checked)
                {
                    List<long?> ListaID = new List<long?>();

                    var ConsultaProducto = (from OCC in hb.OrdenCarga_Cuerpo
                                            where OCC.Producto_ID == cmbProducto.SelectedValue.ToString()
                                            group OCC by new { OCC.Orden_ID } into Grupo
                                            select new
                                            {
                                                Grupo.Key.Orden_ID
                                            });

                    var ResultadosProducto = ConsultaProducto.ToList();

                    if (ResultadosProducto.Count > 0)
                    {
                        foreach (var item in ResultadosProducto)
                        {
                            ListaID.Add(item.Orden_ID);
                        }
                    }

                    Consulta = (from C in Consulta
                                where ListaID.Contains(C.ID)
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

                var Resultados = Consulta.ToList();

                colID.DataPropertyName = "ID";
                colFecha.DataPropertyName = "Fecha";
                colCliente.DataPropertyName = "Cliente";
                colCiudad.DataPropertyName = "Ciudad";
                colEstado.DataPropertyName = "Estado";
                colObservacion.DataPropertyName = "Observaciones";
                colModo.DataPropertyName = "Modo";

                lblResultados.Text = Resultados.Count.ToString();

                dgvOrdenCarga.AutoGenerateColumns = false;
                dgvOrdenCarga.DataSource = Resultados;
            }
        }
        
        private void AbrirformAgregarEditarPedido(string AgregarEditar, long ID)
        {
            if (AgregarEditar == "1")
            {
                
                    var f = new frmAgregarOrdenCarga();

                    f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmAgregarOrdenCarga_FormClosed);
                    f.CrearEditar = AgregarEditar;
                    f.IDRecibido = ID;
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
                if (dgvOrdenCarga.CurrentRow.Cells["colModo"].Value.ToString() == "1")
                {
                    var f = new frmAgregarOrdenCarga();

                    f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmAgregarOrdenCarga_FormClosed);
                    f.CrearEditar = AgregarEditar;
                    f.IDRecibido = ID;
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
                    var f = new frmExpedicion();

                    f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmAgregarOrdenCarga_FormClosed);
                    f.Accion = AgregarEditar;
                    f.IDRecibido = ID;
                    AddOwnedForm(f);
                    f.TopLevel = false;
                    f.Dock = DockStyle.Fill;
                    this.Controls.Add(f);
                    this.Tag = f;
                    f.BringToFront();
                    f.WindowState = FormWindowState.Maximized;

                    if (AgregarEditar != "2")
                        f.btnCargar.Visible = true;
                    else
                        f.btnCargar.Visible = false;

                    f.Show();
                }
            }
                
             
            //f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmAgregarOrdenCarga_FormClosed);

            //f.CrearEditar = AgregarEditar;
            //f.IDRecibido = ID;
            //AddOwnedForm(f);
            //f.TopLevel = false;
            //f.Dock = DockStyle.Fill;
            //this.Controls.Add(f);
            //this.Tag = f;
            //f.BringToFront();
            //f.WindowState = FormWindowState.Maximized;
            //f.Show();
        }
        private void AbrirformExpedicion(string Accion, long ID)
        {
            var f = new frmExpedicion();
            //f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(_FormClosed);
            f.Accion = Accion;
            f.IDRecibido = ID;
            AddOwnedForm(f);
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.Controls.Add(f);
            this.Tag = f;
            f.BringToFront();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
        private void EliminarOrden()
        {
            if (dgvOrdenCarga.RowCount > 0)
            {
                DialogResult R = MessageBox.Show("¿Seguró que desea eliminar esta orden de carga?", "Atención", MessageBoxButtons.YesNo);
                if (R == DialogResult.Yes)
                {
                    try
                    {
                        using (var hb = new DBdatos())
                        {
                            long Orden_ID = (long)dgvOrdenCarga.CurrentRow.Cells[0].Value;

                            var ConsultaOC = (from OC in hb.Orden_Carga
                                              where OC.ID == Orden_ID
                                              select OC);

                            var ResultadosOC = ConsultaOC.FirstOrDefault();

                            if (ResultadosOC.Estado_ID == "AN")
                            {
                                var ConsultaOCC = (from OCC in hb.OrdenCarga_Cuerpo
                                                   where OCC.Orden_ID == Orden_ID
                                                   select OCC).ToList();

                                var ConsultaTTOCC = (from TTOCC in hb.TT_Orden_Carga_Cuerpo
                                                     select TTOCC).ToList();

                                var ConsultaAFEC = (from AFEC in hb.Producto_Afec_OrdenCarga
                                                    where AFEC.Orden_ID == Orden_ID
                                                    select AFEC).ToList();

                                var ConsultaEPT = (from EPT in hb.Existencia_ProductoTerminado
                                                   where EPT.OrdenCargaID == Orden_ID
                                                   select EPT).ToList();

                                hb.TT_Orden_Carga_Cuerpo.RemoveRange(ConsultaTTOCC);
                                hb.Producto_Afec_OrdenCarga.RemoveRange(ConsultaAFEC);
                                hb.OrdenCarga_Cuerpo.RemoveRange(ConsultaOCC);
                                hb.Existencia_ProductoTerminado.RemoveRange(ConsultaEPT);
                                hb.Orden_Carga.Remove(ResultadosOC);

                            }
                            else
                            {
                                MessageBox.Show("Solo se pueden eliminar ordenes de cargar en estado anulado", "Atencion");
                                return;
                            }
                            hb.SaveChanges();
                            MessageBox.Show("Orden eliminada correctamente", "Atención");
                            MostrarOrdenesCarga();
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }
                   
                }
                
            }
        }
        private void MostrarEstadosEnColores(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvOrdenCarga.RowCount > 0)
            {
                if (this.dgvOrdenCarga.Columns[e.ColumnIndex].Name == "colEstado")
                {
                    if (e.Value.ToString() == "Finalizado")
                    {
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        e.CellStyle.SelectionForeColor = Color.DarkGreen;
                        e.CellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    }
                    if (e.Value.ToString() == "Anulado")
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                        e.CellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    }
                }
            }
        }
        private void frmAgregarOrdenCarga_FormClosed(object sender, FormClosedEventArgs e)
        {
            MostrarOrdenesCarga();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirformAgregarEditarPedido("1", 0);
        }

        private void chkFiltraProducto_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsProConCheck(chkFiltraProducto, cmbProducto, txtBuscarProducto, chkMuestraInsProActInac, btnBuscarIProducto);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarOrdenesCarga();
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }

        private void chkFiltraCliente_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboCliente(chkFiltraCliente, cmbCliente, txtBuscarCliente, btnBuscarCliente);
        }

        private void chkFiltraCiudad_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboCiudad(chkFiltraCiudad, cmbCiudad, txtBuscarCiudad, btnBuscarCiudad);
        }

        private void chkFiltraEstado_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraEstado, cmbFiltraEstado);
        }
        private void AbrirEditar(string CrearEditarCopiar)
        {
            if (dgvOrdenCarga.RowCount > 0)
            {
                long ID = (long)dgvOrdenCarga.CurrentRow.Cells[0].Value;
                AbrirformAgregarEditarPedido(CrearEditarCopiar, ID);
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            AbrirEditar("2");
        }

        private void dgvOrdenCarga_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirEditar("2");
        }

        private void dgvOrdenCarga_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            MostrarEstadosEnColores(e);
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenCarga.RowCount > 0)
            {
                string Estado = dgvOrdenCarga.CurrentRow.Cells["colEstado"].Value.ToString();

                if (Estado == "Anulado")
                    AbrirEditar("3");
                else
                    MessageBox.Show("Solo se pueden copiar comprobantes ANULADOS", "Atención");
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarOrdenesCarga();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reutilizables.ExportarExcel(dgvOrdenCarga);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraNumero, chkFiltraNumero);
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

        private void cmbCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboClientes(cmbCliente, txtBuscarCliente, false, "CLI", 0);
                txtBuscarCliente.Focus();
                e.Handled = true;
            }
        }

        private void txtBuscarCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarCiudad.Visible = false;
                clsCargarCombos.MostrarComboCiudades(cmbCiudad, txtBuscarCiudad, true);
                txtBuscarCiudad.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarCiudad.Visible = false;
                txtBuscarCiudad.Focus();
                e.Handled = true;
            }
        }

        private void cmbCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboCiudades(cmbCiudad, txtBuscarCiudad, false);
                txtBuscarCiudad.Focus();
                e.Handled = true;
            }
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarOrden();
        }

        private void btnBuscarDesc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarOrdenesCarga();
        }

        private void btnBuscarAsc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarOrdenesCarga();
        }

        private void btnBuscarIProducto_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarCiudad_Click(object sender, EventArgs e)
        {
            txtBuscarCiudad.Visible = true;
            cmbCiudad.Visible = false;
            txtBuscarCiudad.Select();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {

        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscarCiudad_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAsistente_Click(object sender, EventArgs e)
        {
            AbrirformExpedicion("1", 0);
        }

        private void chkFechaDesde_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chkFiltraPedido_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraPedido, chkFiltraPedido);
        }

        private void txtFiltraNumero_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtFiltraPedido_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscarCliente_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscarCiudad_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscarProducto_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
