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
using PCodin_Sinlacc.Formularios;
using PCodin_Sinlacc.Formularios.Movimiento_de_Produccion;
using PCodin_Sinlacc.Clases.UsuarioTema;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmRegistroDePedidos : Form
    {
        
        public frmRegistroDePedidos()
        {
            InitializeComponent();
        }
        public frmMenu FormMenu;
        public int UsuarioID;
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirformAgregarEditarPedido("1", 0);
        }

        private void AbrirformAgregarEditarPedido(string AgregarEditar, long ID)
        {
            if(clsVariablesGenerales.Modo == "Mobile")
            {
                var f = new frmAgregarNuevoPedidoMOB();
                f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmAgregarNuevoPedido_FormClosed);
                f.PulsoAgregarEditar = AgregarEditar;
                f.IdRecibido = ID;
                f.FormMenu = FormMenu;
                AddOwnedForm(f);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                this.Controls.Add(f);
                this.Tag = f;
                f.BringToFront();
                f.Show();
            }
            if (clsVariablesGenerales.Modo == "Escritorio")
            {
                var f = new frmAgregarNuevoPedido();
                f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmAgregarNuevoPedido_FormClosed);
                f.PulsoAgregarEditar = AgregarEditar;
                f.IdRecibido = ID;
                f.FormMenu = FormMenu;
                AddOwnedForm(f);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                this.Controls.Add(f);
                this.Tag = f;
                f.BringToFront();
                f.Show();
            }

        }
        private void frmAgregarNuevoPedido_FormClosed(object sender, FormClosedEventArgs e)
        {
            MostrarOrdenesPedido();
        }

        private void frmRegistroDePedidos_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            if(clsVariablesGenerales.Modo == "Mobile")
            {
                dgvOrdenPedido.RowTemplate.DefaultCellStyle.Font = new Font("Roboto Condensed", 13);
                dgvOrdenPedido.ColumnHeadersDefaultCellStyle.Font = new Font("Roboto Condensed", 13);
            }
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
            dtpFechaHasta.Value = DateTime.Now.Date;
            dtpFechaDesde.Value = DateTime.Now.Date;           

            cmbFiltraEstado.Text = "AU";

            MostrarOrdenesPedido();
        }
        private void MostrarOrdenesPedido()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from OP in hb.VistaPedidos002
                                orderby OP.FechaPedido, OP.PedidoID
                                select new
                                {
                                    OP.PedidoID,
                                    OP.NumeroPedido,
                                    OP.FechaPedido,
                                    OP.ClienteID,
                                    OP.Cliente,
                                    OP.CiudadID,
                                    OP.Ciudad,
                                    OP.EstadoPedido,                             
                                    OP.VendedorID,
                                    OP.Vendedor,
                                    OP.Zona_ID,
                                    OP.Zona,
                                    OP.Observaciones

                                }).Take(1000);



                if (cmbOrdenar.SelectedIndex == 1) // Nro
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.NumeroPedido ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.NumeroPedido descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 2) // Fecha
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.FechaPedido ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.FechaPedido descending
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
                                    orderby C.EstadoPedido ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.EstadoPedido descending
                                    select C);
                }
                if (chkFiltraNroPedido.Checked && txtFiltraNroPedido.TextLength > 0)
                {
                    string Pedido_ID = txtFiltraNroPedido.Text;

                    Consulta = (from C in Consulta
                                where C.NumeroPedido == Pedido_ID
                                select C);
                }

                if (chkFiltraCliente.Checked)
                    Consulta = (from C in Consulta
                                where C.ClienteID == (int)cmbCliente.SelectedValue
                                select C);

                if (chkFiltraCiudad.Checked)
                    Consulta = (from C in Consulta
                                where C.ClienteID == (int)cmbCiudad.SelectedValue
                                select C);

                if (chkFiltraZona.Checked)
                    Consulta = (from C in Consulta
                                where C.Zona_ID == (int)cmbFiltraZona.SelectedValue
                                select C);

                if (chkFiltraVendedor.Checked)
                    Consulta = (from C in Consulta
                                where C.VendedorID == (int)cmbFiltraVendedor.SelectedValue
                                select C);

                if (chkFiltraProducto.Checked)
                {
                    List<long?> ListaID = new List<long?>();

                    var ConsultaProducto = (from PC in hb.Pedido_Cuerpo
                                            where PC.Producto_ID == cmbProducto.SelectedValue.ToString()
                                            group PC by new { PC.Pedido_ID } into Grupo
                                            select new
                                            {
                                                Grupo.Key.Pedido_ID
                                            });

                    var ResultadosProducto = ConsultaProducto.ToList();

                    if (ResultadosProducto.Count > 0)
                    {
                        foreach (var item in ResultadosProducto)
                        {
                            ListaID.Add(item.Pedido_ID);
                        }
                    }

                    Consulta = (from C in Consulta
                                where ListaID.Contains(C.PedidoID)
                                select C);

                }
                if (chkFiltraEstado.Checked)
                    Consulta = (from C in Consulta
                                where C.EstadoPedido == cmbFiltraEstado.Text
                                select C);

                if (chkFechaDesde.Checked && chkFechaHasta.Checked == false)
                {
                    Consulta = (from C in Consulta
                                where C.FechaPedido >= dtpFechaDesde.Value.Date
                                select C);
                }
                else if (chkFechaDesde.Checked == false && chkFechaHasta.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.FechaPedido <= dtpFechaHasta.Value.Date
                                select C);
                }
                else if (chkFechaDesde.Checked && chkFechaHasta.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.FechaPedido >= dtpFechaDesde.Value.Date && C.FechaPedido <= dtpFechaHasta.Value.Date
                                select C);
                }

                var Resultados = Consulta.ToList();              

                colID.DataPropertyName = "PedidoID";
                colNumeroPedido.DataPropertyName = "NumeroPedido";
                colFecha.DataPropertyName = "FechaPedido";
                colCliente.DataPropertyName = "Cliente";
                colCiudad.DataPropertyName = "Ciudad";
                colZona.DataPropertyName = "Zona";
                colVendedor.DataPropertyName = "Vendedor";
                colEstado.DataPropertyName = "EstadoPedido";
                colObservacion.DataPropertyName = "Observaciones";

                lblResultados.Text = Resultados.Count.ToString();

                dgvOrdenPedido.AutoGenerateColumns = false;
                dgvOrdenPedido.DataSource = Resultados;
            }
        }
        private void EliminarPedido()
        {
            if (dgvOrdenPedido.RowCount > 0)
            {
                DialogResult R = MessageBox.Show("¿Seguró que desea eliminar este pedido?", "Atención", MessageBoxButtons.YesNo);
                if (R == DialogResult.Yes)
                {
                    using (var hb = new DBdatos())
                    {
                        long Pedido_ID = (long)dgvOrdenPedido.CurrentRow.Cells[0].Value;

                        var ConsultaOP = (from OP in hb.Registro_Pedidos
                                          where OP.ID == Pedido_ID
                                          select OP);

                        var ResultadosOP = ConsultaOP.FirstOrDefault();

                        if (ResultadosOP.Estado_ID == "AN" || ResultadosOP.Estado_ID == "INF")
                        {
                            var ConsultaPC = (from OPC in hb.Pedido_Cuerpo
                                               where OPC.Pedido_ID == Pedido_ID
                                               select OPC).ToList();

                            var ConsultaTTPC = (from TTPC in hb.TT_Pedido_Cuerpo
                                                select TTPC).ToList();

                            var ConsultaOCC = (from OCC in hb.OrdenCarga_Cuerpo
                                               where OCC.Pedido_ID == Pedido_ID
                                               select OCC).ToList();

                            var ConsultaTTOCC = (from TTOCC in hb.TT_Orden_Carga_Cuerpo
                                                 where TTOCC.Pedido_ID == Pedido_ID
                                                 select TTOCC);

                            var ConsultaOPC = (from OPC in hb.OrdenProduccion_Cuerpo
                                               where OPC.Pedido_ID == Pedido_ID
                                               select OPC).ToList();

                            if(ConsultaOCC.Count > 0)
                            {
                                MessageBox.Show("El pedido " + ResultadosOP.Numero_Pedido + " está asociado a una o varias ordenes de carga", "Atencion");
                                return;
                            }
                            if (ConsultaOPC.Count > 0)
                            {
                                MessageBox.Show("El pedido " + ResultadosOP.Numero_Pedido + " está asociado a una o varias ordenes de producción", "Atencion");
                                return;
                            }

                            hb.TT_Pedido_Cuerpo.RemoveRange(ConsultaTTPC);
                            hb.Pedido_Cuerpo.RemoveRange(ConsultaPC);
                            hb.Registro_Pedidos.Remove(ResultadosOP);



                            ////hb.OrdenCarga_Cuerpo.RemoveRange(ConsultaOCC);
                            //hb.TT_Orden_Carga_Cuerpo.RemoveRange(ConsultaTTOCC);
                            //hb.TT_Pedido_Cuerpo.RemoveRange(ConsultaTTPC);
                            //hb.Pedido_Cuerpo.RemoveRange(ConsultaPC);                           
                            //hb.Registro_Pedidos.Remove(ResultadosOP);
                            
                        }
                        else
                        {
                            MessageBox.Show("Solo se pueden eliminar pedidos en estado 'Anulado' y 'Informativo'", "Atencion");
                            return;
                        }
                        
                        hb.SaveChanges();
                        MessageBox.Show("Pedido eliminado correctamente", "Atención");
                        MostrarOrdenesPedido();
                    }
                }

            }
        }
        private void dgvOrdenPedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            txtBuscarCliente.Visible = true;
            txtBuscarCliente.Select();
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
                txtBuscarCliente.Focus();
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

        private void btnBuscarCiudad_Click(object sender, EventArgs e)
        {
            txtBuscarCiudad.Visible = true;
            txtBuscarCiudad.Select();
        }

        private void txtBuscaInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarProducto.Visible = false;
                clsCargarCombos.MostrarComboInsProSinCheck(cmbProducto, txtBuscarProducto,"PRO" , true, "NO");
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

        private void cmbFiltraInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProSinCheck(cmbProducto, txtBuscarProducto, "PRO", true, "NO");
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarInsPro_Click(object sender, EventArgs e)
        {
            txtBuscarProducto.Visible = true;
            txtBuscarProducto.Select();
        }

        private void chkFiltraCliente_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboCliente(chkFiltraCliente, cmbCliente, txtBuscarCliente, btnBuscarCliente);
        }

        private void chkFiltraCiudad_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboCiudad(chkFiltraCiudad,cmbCiudad,txtBuscarCiudad,btnBuscarCiudad);
        }

        private void chkFiltraProducto_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraProducto, cmbProducto, txtBuscarProducto, btnBuscarIProducto ,"PRO","NO");
        }

        private void chkFechaDesde_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDtpFecha(chkFechaDesde, dtpFechaDesde);
        }

        private void chkFechaHasta_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDtpFecha(chkFechaHasta, dtpFechaHasta);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarOrdenesPedido();
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }

        private void chkFiltraEstado_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraEstado,cmbFiltraEstado);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenPedido.RowCount > 0)
            {
                long ID = (long)dgvOrdenPedido.CurrentRow.Cells[0].Value;
                AbrirformAgregarEditarPedido("2", ID);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarOrdenesPedido();
        }

        private void chkFiltraNroPedido_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraNroPedido, chkFiltraNroPedido);
        }

        private void dgvOrdenPedido_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrdenPedido.RowCount > 0)
            {
                long ID = (long)dgvOrdenPedido.CurrentRow.Cells[0].Value;
                AbrirformAgregarEditarPedido("2", ID);
            }
        }
        private void MostrarEstadosEnColores(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvOrdenPedido.RowCount > 0)
            {
                if (this.dgvOrdenPedido.Columns[e.ColumnIndex].Name == "colEstado")
                {
                    if (e.Value.ToString() == "AN")
                    {
                        e.Value = "Anulado";
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                       // e.CellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    }
                    if (e.Value.ToString() == "IN")
                    {
                        e.Value = "Informativo";
                        e.CellStyle.ForeColor = Color.Blue;
                        e.CellStyle.SelectionForeColor = Color.Blue;
                        if (clsVariablesGenerales.Modo != "Mobile")
                            e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                        if (clsVariablesGenerales.Modo == "Mobile")
                            e.CellStyle.Font = new Font("Roboto Condensed", 13, FontStyle.Bold);
                    }
                    if (e.Value.ToString() == "FI")
                    {
                        e.Value = "Entregado";
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        e.CellStyle.SelectionForeColor = Color.DarkGreen;
                        if (clsVariablesGenerales.Modo != "Mobile")
                            e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                        if (clsVariablesGenerales.Modo == "Mobile")
                            e.CellStyle.Font = new Font("Roboto Condensed", 13, FontStyle.Bold);
                    }
                    if (e.Value.ToString() == "AU")
                    {
                        e.Value = "Autorizado";
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.SelectionForeColor = Color.Black;
                        if (clsVariablesGenerales.Modo != "Mobile")
                            e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                        if (clsVariablesGenerales.Modo == "Mobile")
                            e.CellStyle.Font = new Font("Roboto Condensed", 13, FontStyle.Bold);
                    }
                    //e.CellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                }
            }
        }
       
        private void dgvOrdenPedido_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            MostrarEstadosEnColores(e);
        }
        private void AbrirEditarCopiar(string CrearEditarCopiar)
        {
            if (dgvOrdenPedido.RowCount > 0)
            {
                long ID = (long)dgvOrdenPedido.CurrentRow.Cells[0].Value;
                AbrirformAgregarEditarPedido(CrearEditarCopiar, ID);
            }
        }
        private void btnCopiar_Click(object sender, EventArgs e)
        {
            AbrirEditarCopiar("3");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reutilizables.ExportarExcel(dgvOrdenPedido);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarPedido();
        }

        private void btnBuscarDesc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarOrdenesPedido();
        }

        private void btnBuscarAsc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarOrdenesPedido();
        }

        private void btnCopiar_Click_1(object sender, EventArgs e)
        {
            if (dgvOrdenPedido.RowCount > 0)
            {
                long ID = (long)dgvOrdenPedido.CurrentRow.Cells[0].Value;
                AbrirformAgregarEditarPedido("3", ID);
            }
        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRelacion_Click(object sender, EventArgs e)
        {
            if (dgvOrdenPedido.RowCount > 0)
            {
                long PedidoID = (long)dgvOrdenPedido.CurrentRow.Cells["colID"].Value;

                var f = new frmRelacionesMovProduccion();
                f.Formulario = "PED";
                f.IDRecibido = PedidoID;
                f.Show();
            }
        }

        private void chkFiltraZona_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboZona(chkFiltraZona, cmbFiltraZona);
        }

        private void chkFiltraVendedor_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboVendedor(chkFiltraVendedor, cmbFiltraVendedor, txtFiltraVendedor, btnBuscaVendedor);
        }

        private void txtFiltraVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarCliente.Visible = false;
                clsCargarCombos.MostrarComboVendores(cmbCliente, txtBuscarCliente, true);
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

        private void cmbFiltraVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboVendores(cmbCliente, txtBuscarCliente, false);
                txtBuscarCliente.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscaVendedor_Click(object sender, EventArgs e)
        {
            txtFiltraVendedor.Visible = true;
            txtFiltraVendedor.Select();
        }

        private void txtBuscarCliente_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscarCiudad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscarCiudad_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtFiltraVendedor_Click(object sender, EventArgs e)
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
