using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Datos;
using PCodin_Sinlacc.Formularios.Asistentes;
using PCodin_Sinlacc.Formularios.MATERIALES.Gestor_de_materiales.Insumos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Globalization;
using System.Data.SqlTypes;

namespace PCodin_Sinlacc.Formularios.VENTAS.Ticket
{
    public partial class frmAgregarTicket : Form
    {
        private int longpaper;
        clsImprimirPlantilla C = new clsImprimirPlantilla();

        public frmAgregarTicket()
        {
            InitializeComponent();
            
            //C.PD.BeginPrint += new PrintEventHandler(C.PD_BeginPrint);
            //C.PD.PrintPage += new PrintPageEventHandler(C.PD_PrintPage);

        }
        public string Accion;
        public long IDRecibido;
        private frmPantallaEspera PantallaEspera = new frmPantallaEspera();
        private frmReporte VisorReporte = new frmReporte();
        long IDCabezal = 0;
        long IDImprimir = 0;
        public long CajaUsuarioID;
        private bool EsPesable;
        string FormaPagoSeleccionado;
        decimal TotalFormaPago = 0;
        decimal DescRecFormaPago = 0;

        int MedioPagoSeleccionado1 = 0;
        int MedioPagoSeleccionado2 = 0;
        int MedioPagoSeleccionado3 = 0;
        int MedioPagoSeleccionado4 = 0;
        int MedioPagoSeleccionado5 = 0;
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirFormAgregar("1");
        }
        private void frmAgregarTicket_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void txtCodigoBarra_TextChanged(object sender, EventArgs e)
        {
            //if (txtCodigoBarra.TextLength > 0)
            //{
            //    using (var hb = new DBdatos())
            //    {
            //        var ConsultaArticulo = (from A in hb.Productos_Insumos
            //                                where A.CodigoBarra == txtCodigoBarra.Text
            //                                select A).FirstOrDefault();

            //        var ConsultaArticuloCliente = (from A in hb.Productos_Insumos
            //                                       where A.CodigoBarra == txtCodigoBarra.Text
            //                                       select A).FirstOrDefault();



            //        if (ConsultaArticuloCliente == null)
            //            MessageBox.Show("No exite articulo con el codigo de barras ingresado");
            //        else
            //        {
            //            var ConsultaListaPrecio = (from LP in hb.LISTAPRECIOCUERPO
            //                                       where LP.ListaPrecio_ID == (int)cmbListaPrecio.SelectedValue
            //                                           && LP.Articulo_ID == ConsultaArticulo.Codigo
            //                                       select LP).FirstOrDefault();

            //            dgvTicket.Rows.Add("", ConsultaArticulo.Codigo, ConsultaArticulo.Descripcion, "1,00", ConsultaListaPrecio.Precio);
            //        }
            //    }



            //    txtCodigoBarra.Text = "";
            //    txtCodigoBarra.Focus();
            //    txtCodigoBarra.Select();
            //}
            //CalcularTotal();
        }
        private void InicializarForm()
        {
            try
            {
                dgvTicket.Columns["colCantidad"].ValueType = typeof(decimal);
                dgvTicket.Columns["colCantidad"].DefaultCellStyle.Format = "N3";                

                dgvTicket.Columns["colPrecio"].ValueType = typeof(decimal);
                dgvTicket.Columns["colPrecio"].DefaultCellStyle.Format = "N2";

                dgvTicket.Columns["colTotal"].ValueType = typeof(decimal);
                dgvTicket.Columns["colTotal"].DefaultCellStyle.Format = "N2";

                clsCargarCombos.MostrarComboMovimientos(cmbMovimiento, 2, "TICK");
                clsCargarCombos.MostrarComboClientes(cmbCliente, txtBuscarCliente, false, "CLI", 591);
                Reutilizables.AutoNumerarComprobanteVenta(txtPuntoVenta, txtNumeroComprobante);
                clsCargarCombos.MostrarCombomListaPrecio(cmbListaPrecio, 1);
                clsCargarCombos.MostrarComboMedioPago(cmbFormaPago);
                dtpFecha.Value = DateTime.Now.Date;
                ActivarLectorCodigoBarra();
                cmbFormaPago.SelectedIndex = -1;
                //cmbCliente.SelectedIndex = -1;

                txtImporteTotal.BackColor = Color.FromArgb(64, 64, 64);
                txtImporteTotal.ForeColor = Color.Khaki;
                txtCambio.ForeColor = Color.ForestGreen;
                txtCambio.BackColor = Color.White;
                txtDebe.ForeColor = Color.Maroon;
                txtDebe.BackColor = Color.White;

                using (var hb = new DBdatos())
                {
                    if (Accion != "1") //EDITAR o COPIAR
                    {
                        //CABEZAL
                        var ConsultaCabezal = (from CCA in hb.TICKET
                                               where CCA.ID == IDRecibido
                                               select CCA).FirstOrDefault();

                        cmbMovimiento.SelectedValue = ConsultaCabezal.Movimiento_ID;
                        cmbMovimiento.Text = ConsultaCabezal.MOVIMIENTOS.Descripcion;

                        cmbFormaPago.SelectedValue = ConsultaCabezal.MedioPago;
                        cmbFormaPago.Text = ConsultaCabezal.MEDIOPAGO1.Descripcion;

                        //if (ConsultaCabezal.MedioPago == 1)
                        //    rdbEfectivo.Checked = true;
                        //if (ConsultaCabezal.MedioPago == 2)
                        //    rdbDebito.Checked = true;
                        //if (ConsultaCabezal.MedioPago == 3)
                        //    rdbCredito.Checked = true;
                        //if (ConsultaCabezal.MedioPago == 4)
                        //    rdbCC.Checked = true;

                        //if (ConsultaCabezal.MEDIOPAGO1.Codigo == "CC")
                        //    clsCargarCombos.MostrarComboClientes(cmbCliente, txtBuscarCliente, false, "CLI", 0);

                        cmbCliente.SelectedValue = ConsultaCabezal.Cliente_ID;
                        cmbCliente.Text = ConsultaCabezal.Clientes.Descripcion;
                        dtpFecha.Value = (DateTime)ConsultaCabezal.Fecha;
                        txtObservacion.Text = ConsultaCabezal.Observacion;
                        txtLetraComprobante.Text = ConsultaCabezal.Letra.ToUpper();
                        txtEntregado.Text = ConsultaCabezal.Entregado?.ToString("N2");
                        txtDebe.Text = (ConsultaCabezal.ImporteTotal - ConsultaCabezal.Entregado)?.ToString("N2");

                        if (Accion != "3")
                        {
                            txtPuntoVenta.Text = ConsultaCabezal.NumeroTicket.Substring(0, 4);
                            txtNumeroComprobante.Text = ConsultaCabezal.NumeroTicket.Substring(4, 8);
                        }

                        lblEstadoComprobante.Text = ConsultaCabezal.Estado;



                        if (Accion == "3")
                        {
                            rdbEfectivo.Checked = false;
                            rdbDebito.Checked = false;
                            rdbCredito.Checked = false;
                            rdbCC.Checked = false;

                            txtEntregado.Text = "0,00";
                            txtDebe.Text = "0,00";
                        }

                        if (ConsultaCabezal.Estado == "FI")
                        {
                            lblEstadoComprobante.Text = "Finalizado";
                            lblEstadoComprobante.ForeColor = Color.ForestGreen;
                        }
                        if (ConsultaCabezal.Estado == "AN")
                        {
                            if (Accion == "3")
                            {
                                lblEstadoComprobante.Text = "";
                            }
                            else

                            {
                                lblEstadoComprobante.Text = "Anulado";
                                lblEstadoComprobante.ForeColor = Color.FromArgb(192, 0, 0);
                                btnCargar.Enabled = false;
                                btnInvalidar.Enabled = false;
                            }
                        }
                        //CUERPO
                        var CosnultaCuerpo = (from CCU in hb.TICKETCUERPO
                                              where CCU.Ticket_ID == IDRecibido
                                              select new
                                              {
                                                  CCU.ID,
                                                  Codigo = CCU.Insumo_ID,
                                                  Articulo = CCU.Productos_Insumos.Descripcion,
                                                  Cantidad = CCU.Cantidad,
                                                  Precio = CCU.Precio,
                                                  Total = CCU.ImporteTotal
                                              }).ToList();

                        foreach (var item in CosnultaCuerpo)
                        {
                            dgvTicket.Rows.Add(
                                                    item.ID,
                                                    item.Codigo,
                                                    item.Articulo,
                                                    item.Cantidad,
                                                    item.Precio,
                                                    item.Total
                                                    );
                        }
                        CalcularTotal();
                        // CalcularEntregado2();
                    }
                    else
                    {
                        timer1.Enabled = true;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
            
        }
        public void CalcularTotal()
        {
            if (dgvTicket.RowCount > 0)
            {
                decimal Total = 0;
                decimal DescuentoPorcentaje = Convert.ToDecimal(txtDescuentoPorcentaje.Text);
                decimal DescuentoRecargoMedioPago = 0;
                decimal DescuentoAplicado = 0;
                int CantidadItems = 0;

                using (var hb = new DBdatos())
                {
                    if (cmbFormaPago.SelectedIndex != -1)
                    {
                        var ConsultaMedioPago = (from C in hb.MEDIOPAGO
                                                 where C.ID == (int)cmbFormaPago.SelectedValue
                                                 select C).FirstOrDefault();

                        if (ConsultaMedioPago.Porcentaje != null)
                        {
                            DescuentoRecargoMedioPago = (decimal)ConsultaMedioPago.Porcentaje;
                        }
                    }



                    for (var i = 1; i <= dgvTicket.RowCount; i++)
                    {
                       
                        decimal TotalFila = 0;
                        string CodigoProducto = dgvTicket.Rows[i - 1].Cells["colCodigo"].Value.ToString();
                        string Cantidad = dgvTicket.Rows[i - 1].Cells["colCantidad"].Value.ToString();
                        string Costo = dgvTicket.Rows[i - 1].Cells["colPrecio"].Value.ToString();

                        //if(Accion == "2")
                        //{
                            var ConsultaPesable = (from P in hb.Productos_Insumos
                                                   where P.Codigo == CodigoProducto
                                                   select P).FirstOrDefault();

                            if (ConsultaPesable.PLU != null)
                                EsPesable = true;
                            else
                                EsPesable = false;
                        //}
                        

                        if (!Cantidad.Contains(",") && Cantidad.Contains("."))
                            Cantidad = Cantidad.ToString().Replace(".", ",");
                        else
                            Cantidad = Cantidad.ToString();

                        if (!Costo.Contains(",") && Costo.Contains("."))
                            Costo = Costo.ToString().Replace(".", ",");
                        else
                            Costo = Costo.ToString();

                        if (EsPesable == false)
                        {
                            TotalFila = Convert.ToDecimal(Cantidad) * Convert.ToDecimal(Costo);
                            dgvTicket.Rows[i - 1].Cells["colTotal"].Value = TotalFila.ToString("N2");
                            Total = Total + Convert.ToDecimal(dgvTicket.Rows[i - 1].Cells["colTotal"].Value);
                        }
                        else
                        {
                            Total = Total + Convert.ToDecimal(dgvTicket.Rows[i - 1].Cells["colTotal"].Value);
                        }






                        CantidadItems++;
                    }
                    if (DescuentoPorcentaje > 0)
                    {
                        DescuentoAplicado = (Total * DescuentoPorcentaje) / 100;
                        Total = Total - ((Total * DescuentoPorcentaje) / 100);

                    }

                    txtImporteTotal.Text = (Total + ((Total * DescuentoRecargoMedioPago) / 100)).ToString("N2");
                    txtDescuentoAplicado.Text = DescuentoAplicado.ToString("N2");
                    lblItems.Text = CantidadItems.ToString();
                }
            }
            //        if (dgvTicket.RowCount == 0)
            //    return;

            //decimal total = 0;
            //int items = 0;

            //for (int i = 0; i < dgvTicket.RowCount; i++)
            //{
            //    decimal cantidad = (decimal)dgvTicket.Rows[i].Cells["colCantidad"].Value;
            //    decimal precio = (decimal)dgvTicket.Rows[i].Cells["colPrecio"].Value;

            //    decimal totalFila = cantidad * precio;

            //    dgvTicket.Rows[i].Cells["colTotal"].Value = totalFila;

            //    total += totalFila;
            //    items++;
            //}

            //decimal porcentaje = 0;
            //decimal descuento = 0;

            //if (!string.IsNullOrWhiteSpace(txtDescuentoPorcentaje.Text))
            //    porcentaje = decimal.Parse(txtDescuentoPorcentaje.Text);

            //if (porcentaje > 0)
            //{
            //    descuento = total * porcentaje / 100;
            //    total -= descuento;
            //}

            //txtImporteTotal.Text = total.ToString("N2");
            //txtDescuentoAplicado.Text = descuento.ToString("N2");
            //lblItems.Text = items.ToString();

        }
        private void AbrirFormAgregar(string Accion)
        {
            var f = new frmIngresoInsumoAgregar();
            txtCodigoBarra.Focus();
            txtCodigoBarra.Select();
            f.FormClosed += F_FormClosed;
            if (Accion == "2" && dgvTicket.RowCount > 0)
                f.IDRecibido = Convert.ToInt64(dgvTicket.CurrentRow.Cells["colID"].Value);
            f.frmAgregarTicket = this;
            f.ListaPrecio = (int)cmbListaPrecio.SelectedValue;
            f.DGV = dgvTicket;
            f.Accion = Accion;
            f.txtCodigoBara = txtCodigoBarra;
            f.ShowDialog();
        }

        private void F_FormClosed(object sender, FormClosedEventArgs e)
        {
            ActivarLectorCodigoBarra();
            ActivarLectorCodigoBarra();
            ActivarLectorCodigoBarra();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTicket.RowCount > 0)
            {
                if (dgvTicket.RowCount == 1)
                    txtImporteTotal.Text = "0,00";

                dgvTicket.Rows.Remove(dgvTicket.CurrentRow);
                CalcularTotal();
            }
            ActivarLectorCodigoBarra();
        }
        private async void CalcularEntregado2()
        {
            if (txtImporteTotal.TextLength > 0 && txtEntregado.TextLength > 0)
            {
                Reutilizables.ValidarSoloNumeros(txtEntregado);
                decimal ImporteTotal = Convert.ToDecimal(txtImporteTotal.Text);
                decimal Entregado = Convert.ToDecimal(txtEntregado.Text);
                string Cambio = "0,00";
                string Debe = "0,00";

                if (Entregado > ImporteTotal)
                {
                    Cambio = (Entregado - ImporteTotal).ToString("N2");
                    txtCambio.Text = Cambio.Replace(" ", string.Empty);
                    txtDebe.Text = Debe;
                    //e.Handled = true;
                }
                if (Entregado < ImporteTotal)
                {
                    Debe = (ImporteTotal - Entregado).ToString("N2");
                    txtDebe.Text = Debe.Replace(" ", string.Empty);
                    txtCambio.Text = Cambio;
                   // e.Handled = true;
                }
            }
        }
        private async void CalcularEntregado(KeyPressEventArgs e)
        {
            try
            {
                if (txtImporteTotal.TextLength > 0 && txtEntregado.TextLength > 0)
                {
                    Reutilizables.ValidarSoloNumeros(txtEntregado);
                    decimal ImporteTotal = Convert.ToDecimal(txtImporteTotal.Text);
                    decimal Entregado = Convert.ToDecimal(txtEntregado.Text);
                    string Cambio = "0,00";
                    string Debe = "0,00";

                    if(Entregado > ImporteTotal)
                    {
                        Cambio = (Entregado - ImporteTotal).ToString("N2");
                        txtCambio.Text = Cambio.Replace(" ", string.Empty);
                        txtDebe.Text = Debe;
                        e.Handled = true;                       
                    }
                    if(Entregado < ImporteTotal)
                    {
                        Debe = (ImporteTotal - Entregado).ToString("N2");
                        txtDebe.Text = Debe.Replace(" ", string.Empty);
                        txtCambio.Text = Cambio;
                        e.Handled = true;
                    }                  
                }
            }
            catch (Exception E)
            {
                MessageBox.Show("Debe ingresar solo numeros en el campo Entregado", "Atención");
            }
        }
        private async void CambiarCliente()
        {
            if(rdbCC.Checked == false && Convert.ToDecimal(txtDebe.Text) > 0)
            {
                clsCargarCombos.MostrarComboClientes(cmbCliente, txtBuscarCliente, false, "CLI", 0);
                cmbCliente.SelectedIndex = -1;
            }
        }

        private void txtEntregado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CalcularEntregado(e);
                CambiarCliente();
            }
        }
        private void MostrarPantallaEspera()
        {
            PantallaEspera = new frmPantallaEspera();
           // PD_PrintPage(IDRecibido);
           // VisorReporte = new frmReporte();

            PantallaEspera.Shown += new System.EventHandler(frmPantallaEspera_Shown);
            PantallaEspera.ShowDialog();
        }

        private void frmPantallaEspera_Shown(object sender, EventArgs e)
        {
            //SE CREA PARA DIFERENCIAR CUANDO ES IMPRESION DE PLANTILLA AL FINALIZAR O SOLO IMPRIMIR
            long ID;

            //SI ES SOLO IMPREESION
            if (IDCabezal > 0)
                ID = IDCabezal;
            else // SI ES CUANDO FINALIZA EL COMPROBANTE
                ID = IDRecibido;

            clsQueryPlantillas.PlaTicket(ID, VisorReporte); //LISTA LA ORDEN
            PantallaEspera.Close();
        }

        private void dgvTicket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dgvTicket_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalcularTotal();
            ActivarLectorCodigoBarra();
        }

        private void btnInvalidar_Click(object sender, EventArgs e)
        {
            if (Accion == "2")
            {
                using (var hb = new DBdatos())
                {
                    var Consulta = (from C in hb.TICKET
                                    where C.ID == IDRecibido
                                    select C).FirstOrDefault();

                    if (Consulta.Estado != "AN")
                    {
                        DialogResult R = MessageBox.Show("¿Esta seguro que desea anular este pedido", "Atención", MessageBoxButtons.YesNo);
                        if (R == DialogResult.Yes)
                        {
                            Consulta.Estado = "AN";
                            hb.SaveChanges();

                            MessageBox.Show("Ticket invalidado correctamente", "Atención");
                            this.Hide();
                        }
                    }
                }
            }
        
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal DineroEntregado = Convert.ToDecimal(txtEntregado.Text);

                if (cmbMovimiento.SelectedIndex != -1
                   && cmbCliente.SelectedIndex != -1
                   && dgvTicket.RowCount > 0
                   //&& cmbFormaPago.SelectedIndex != -1
                   && ((chkMedioPago1.Checked && cmbFormaPago1.SelectedIndex > 0)
                      || (chkMedioPago2.Checked && cmbFormaPago2.SelectedIndex > 0) 
                      || (chkMedioPago3.Checked && cmbFormaPago3.SelectedIndex > 0) 
                      || (chkMedioPago4.Checked && cmbFormaPago4.SelectedIndex > 0) 
                      || (chkMedioPago5.Checked && cmbFormaPago5.SelectedIndex > 0))
                   && (Convert.ToDecimal(txtFormaPago1.Text) +
                      Convert.ToDecimal(txtFormaPago2.Text) +
                      Convert.ToDecimal(txtFormaPago3.Text) +
                      Convert.ToDecimal(txtFormaPago4.Text) +
                      Convert.ToDecimal(txtFormaPago5.Text) == Convert.ToDecimal(txtFormaPagoTotal.Text)))
                {
                    using (var hb = new DBdatos())
                    {
                        if (Accion != "") //AGREGAR o COPIAR
                        {
                            if (Accion == "2") // Si edita elimina todos los registros de ese ingreso
                            {

                                var ConsultaCuerpoEliminar = (from E in hb.TICKETCUERPO
                                                              where E.Ticket_ID == IDRecibido
                                                              select E);

                                hb.TICKETCUERPO.RemoveRange(ConsultaCuerpoEliminar);

                                var ConsultaEliminar = (from E in hb.TICKET
                                                        where E.ID == IDRecibido
                                                        select E);

                                hb.TICKET.RemoveRange(ConsultaEliminar);
                            }
                            //CABEZAL
                            
                            string NumeroComprobante = "";
                            bool Error = false;

                            var N = new TICKET();

                            var ConsultaID = (from ID in hb.TICKET
                                              orderby ID.ID descending
                                              select ID).FirstOrDefault();

                            //var ConsultaMedioPago = (from MP in hb.MEDIOPAGO
                            //                         where MP.ID == (int)cmbFormaPago.SelectedValue
                            //                         select MP).FirstOrDefault();

                            if (ConsultaID == null)
                            {
                                N.ID = 1;
                                IDCabezal = 1;
                            }
                            else
                            {
                                N.ID = ConsultaID.ID + 1;
                                IDCabezal = ConsultaID.ID + 1;
                            }

                            N.Fecha = dtpFecha.Value.Date;
                            N.Movimiento_ID = (int)cmbMovimiento.SelectedValue;
                            N.Cliente_ID = (int)cmbCliente.SelectedValue;
                            N.Estado = "FI";

                            

                            if(chkMedioPago1.Checked)
                            {
                                var mp = new TICKETMEDIOPAGO();

                                mp.Ticket_ID = IDCabezal;
                                mp.MedioPago_ID = (int)cmbFormaPago1.SelectedValue;
                                mp.Importe = Convert.ToDecimal(txtFormaPago1.Text);

                                hb.TICKETMEDIOPAGO.Add(mp);
                            }
                            if (chkMedioPago2.Checked)
                            {
                                var mp = new TICKETMEDIOPAGO();
                                mp.Ticket_ID = IDCabezal;
                                mp.MedioPago_ID = (int)cmbFormaPago2.SelectedValue;
                                mp.Importe = Convert.ToDecimal(txtFormaPago2.Text);

                                hb.TICKETMEDIOPAGO.Add(mp);
                            }
                            if (chkMedioPago3.Checked)
                            {
                                var mp = new TICKETMEDIOPAGO();
                                mp.Ticket_ID = IDCabezal;
                                mp.MedioPago_ID = (int)cmbFormaPago3.SelectedValue;
                                mp.Importe = Convert.ToDecimal(txtFormaPago3.Text);

                                hb.TICKETMEDIOPAGO.Add(mp);
                            }
                            if (chkMedioPago4.Checked)
                            {
                                var mp = new TICKETMEDIOPAGO();
                                mp.Ticket_ID = IDCabezal;
                                mp.MedioPago_ID = (int)cmbFormaPago4.SelectedValue;
                                mp.Importe = Convert.ToDecimal(txtFormaPago4.Text);

                                hb.TICKETMEDIOPAGO.Add(mp);
                            }
                            if (chkMedioPago5.Checked)
                            {
                                var mp = new TICKETMEDIOPAGO();
                                mp.Ticket_ID = IDCabezal;
                                mp.MedioPago_ID = (int)cmbFormaPago5.SelectedValue;
                                mp.Importe = Convert.ToDecimal(txtFormaPago5.Text);

                                hb.TICKETMEDIOPAGO.Add(mp);
                            }                         

                            //if (ConsultaMedioPago.Codigo == "EFE")
                            //{
                                
                            //    if (DineroEntregado == 0)
                            //        N.Entregado = Convert.ToDecimal(txtImporteTotal.Text);
                            //    else
                            //        N.Entregado = Convert.ToDecimal(txtEntregado.Text);
                            //}
                            //if (ConsultaMedioPago.Codigo == "DEB" || ConsultaMedioPago.Codigo == "TRANS")
                            //{
                            //   // N.MedioPago = 2;
                            //    if (DineroEntregado == 0)
                            //        N.Entregado = Convert.ToDecimal(txtImporteTotal.Text);
                            //    else
                            //        N.Entregado = Convert.ToDecimal(txtEntregado.Text);
                            //}
                            //if (ConsultaMedioPago.Codigo == "CRE")
                            //{
                            //   // N.MedioPago = 3;
                            //    if (DineroEntregado == 0)
                            //        N.Entregado = Convert.ToDecimal(txtImporteTotal.Text);
                            //    else
                            //        N.Entregado = Convert.ToDecimal(txtEntregado.Text);
                            //}
                            //if (ConsultaMedioPago.Codigo == "CC")
                            //{
                            //   N.Entregado = 0; 
                            //  // N.MedioPago = 4;                              
                            //}

                            //N.MedioPago = (int)cmbFormaPago.SelectedValue;

                            try
                            {
                                if (txtLetraComprobante.Text == "A"
                                     || txtLetraComprobante.Text == "B"
                                     || txtLetraComprobante.Text == "M"
                                     || txtLetraComprobante.Text == "")

                                    N.Letra = txtLetraComprobante.Text;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Letra de comprobante incorrecta", "Atencion");
                                Error = true;
                            }
                            try
                            {
                                Convert.ToInt16(txtPuntoVenta.Text);
                                NumeroComprobante = txtPuntoVenta.Text;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Punto de venta incorrecto", "Atencion");
                                Error = true;
                            }
                            try
                            {
                                Convert.ToInt32(txtNumeroComprobante.Text);
                                NumeroComprobante = NumeroComprobante + txtNumeroComprobante.Text;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Numero de comprobante incorrecto", "Atencion");
                                Error = true;
                            }
                            try
                            {
                                var ConsultaCabezal = (from CC in hb.TICKET
                                                       where CC.NumeroTicket == txtPuntoVenta.Text + txtNumeroComprobante.Text
                                                       select CC).FirstOrDefault();

                                if (ConsultaCabezal != null)
                                {
                                    MessageBox.Show("Ya hay ingreso cargado con la siguiente numeraciòn " + txtPuntoVenta.Text + " - " + txtNumeroComprobante.Text, "Atencion");
                                    Error = true;
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Ya hay ingreso cargado con la siguiente numeraciòn " + txtPuntoVenta.Text + " - " + txtNumeroComprobante.Text, "Atencion");
                                Error = true;
                            }
                            if (Error == true)
                                return;

                            N.MedioPago = 1;
                            N.NumeroTicket = NumeroComprobante;
                            N.ImporteTotal = Convert.ToDecimal(txtFormaPagoTotal.Text);
                            //N.Entregado = Convert.ToDecimal(txtEntregado.Text);
                            N.ImporteAfectado = 0;
                            N.Observacion = txtObservacion.Text;
                            N.CajaUsuario_ID = CajaUsuarioID;

                            hb.TICKET.Add(N);

                            //CUERPO
                            long IDinicial = 0;

                            var ConsultaCuerpoID = (from ID in hb.TICKETCUERPO
                                                    orderby ID.ID descending
                                                    select ID).FirstOrDefault();

                            if (ConsultaCuerpoID == null)
                                IDinicial = 1;
                            else
                                IDinicial = ConsultaCuerpoID.ID + 1;

                            for (var i = 0; i < dgvTicket.RowCount; i++)
                            {
                                var NC = new TICKETCUERPO();

                                if (i == 0)
                                    NC.ID = IDinicial;
                                else
                                    NC.ID = IDinicial + i;

                                NC.Ticket_ID = IDCabezal;
                                NC.Insumo_ID = dgvTicket.Rows[i].Cells["colCodigo"].Value.ToString();
                                NC.Cantidad = Convert.ToDecimal(dgvTicket.Rows[i].Cells["colCantidad"].Value);
                                NC.Precio = Convert.ToDecimal(dgvTicket.Rows[i].Cells["colPrecio"].Value);
                                NC.ImporteTotal = Convert.ToDecimal(dgvTicket.Rows[i].Cells["colTotal"].Value);
                                //NC.Cantidad = Convert.ToDecimal(dgvTicket.Rows[i].Cells["colCantidad"].Value);
                                // NC.Precio = Convert.ToDecimal(dgvTicket.Rows[i].Cells["colPrecio"].Value);

                                hb.TICKETCUERPO.Add(NC);
                            }
                            hb.SaveChanges();
                            MessageBox.Show("Datos cargados correctamente", "Atencion");
                            C.ImprimirTicket(IDCabezal, dgvTicket, chkImprimir);
                            this.Hide();
                        }
                    }
                }
                else
                {
                    if(cmbMovimiento.SelectedIndex == -1)
                    {
                        MessageBox.Show("No selecciono Movimiento. Por favor seleccione uno para continuar", "Atención");
                    }
                    if (cmbCliente.SelectedIndex == -1)
                    {
                        MessageBox.Show("No selecciono Cliente. Por favor seleccione uno para continuar", "Atención");
                    }
                    //if ((!rdbEfectivo.Checked
                    //   && !rdbDebito.Checked
                    //   && !rdbCredito.Checked
                    //   && !rdbCC.Checked))
                    //{
                    //    MessageBox.Show("No selecciono forma de pago. Por favor seleccione uno para continuar", "Atención");
                    //}
                    if ((!chkMedioPago1.Checked && cmbFormaPago1.SelectedIndex < 1)
                      && (!chkMedioPago2.Checked && cmbFormaPago2.SelectedIndex < 1)
                      && (!chkMedioPago3.Checked && cmbFormaPago3.SelectedIndex < 1)
                      && (!chkMedioPago4.Checked && cmbFormaPago4.SelectedIndex < 1)
                      && (!chkMedioPago5.Checked && cmbFormaPago5.SelectedIndex < 1))
                    {
                        MessageBox.Show("No selecciono ninguna forma de pago. Por favor determine al menos un1 para continuar", "Atención");
                    }
                    if (Convert.ToDecimal(txtFormaPago1.Text) +
                      Convert.ToDecimal(txtFormaPago2.Text) +
                      Convert.ToDecimal(txtFormaPago3.Text) +
                      Convert.ToDecimal(txtFormaPago4.Text) +
                      Convert.ToDecimal(txtFormaPago5.Text) != Convert.ToDecimal(txtFormaPagoTotal.Text))
                    {
                        MessageBox.Show("El valor de todos los medios de pagos no coincide con el Importe total del ticket", "Atención");
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Error");
            }
        }
        private void ActivarLectorCodigoBarra()
        {
            txtCodigoBarra.Focus();          
            lblEstadoLector.Text = "Leyendo";
            lblEstadoLector.ForeColor = Color.ForestGreen;          
        }
        private void btnlector_Click(object sender, EventArgs e)
        {
            ActivarLectorCodigoBarra();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txtCodigoBarra.Focused)
            {
                lblEstadoLector.Text = "Leyendo";
                lblEstadoLector.ForeColor = Color.ForestGreen;
            }
            else
            {
                lblEstadoLector.Text = "Sin lectura";
                lblEstadoLector.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }

        private void txtLetraComprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.A)
                || e.KeyChar == Convert.ToChar(Keys.B)
                || e.KeyChar == Convert.ToChar(Keys.M)
                || e.KeyChar == Convert.ToChar(Keys.E))
                txtLetraComprobante.Text.ToUpper();
            else
                txtLetraComprobante.Text = "";

        }

        private void txtLetraComprobante_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtLetraComprobante.Text.ToUpper() == "A" ||
                   txtLetraComprobante.Text.ToUpper() == "B" ||
                   txtLetraComprobante.Text.ToUpper() == "C" ||
                   txtLetraComprobante.Text.ToUpper() == "E" ||
                   txtLetraComprobante.Text.ToUpper() == "M")
                {
                    txtLetraComprobante.Text = txtLetraComprobante.Text.ToUpper();
                }
                else
                {
                    txtLetraComprobante.Text = "";
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Caracter no permitido como letra de comprobante", "Atención");
            }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTicket_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (this.dgvTicket.Columns[e.ColumnIndex].Name == "colCantidad")
            //{
            //    if (e.Value != null)
            //    {
            //        e.Value = Convert.ToDecimal(e.Value);
            //        e.FormattingApplied = false; // 👈 deja que use el Format del DGV
            //    }
            //}
            //if (this.dgvTicket.Columns[e.ColumnIndex].Name == "colPrecio")
            //{
            //    try
            //    {
            //        if (!e.Value.ToString().Contains(",") && e.Value.ToString().Contains("."))
            //            e.Value = e.Value.ToString().Replace(".", ",");
            //        else
            //            e.Value = Convert.ToDecimal(e.Value).ToString("N2");

            //    }
            //    catch (Exception)
            //    {
            //        e.Value = "0,00";
            //    }
            //}
        }
        private void LeerCodigoBarra(KeyPressEventArgs e)
        {
            EsPesable = false;

            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    string CodigoBarra = txtCodigoBarra.Text;
                    SoundPlayer SonidoError = new SoundPlayer(@"C:\Program Files (x86)\Pack-Codin\Sound\Error.wav");
                    if (txtCodigoBarra.TextLength > 0)
                    {
                        // txtCodigoBarra.Text = txtCodigoBarra.Text.Replace(" ","");

                        using (var hb = new DBdatos())
                        {
                            dgvTicket.Columns[3].ValueType = typeof(decimal);

                            var ConsultaPLU = (from PLU in hb.Productos_Insumos
                                               where PLU.PLU == txtCodigoBarra.Text.Substring(0, 4)
                                               select PLU).FirstOrDefault();

                            var ConsultaCodigoBarra = (from C in hb.CODIGOBARRA
                                                       where C.CodigoBarra1 == txtCodigoBarra.Text                                                     
                                                       select C).FirstOrDefault();

                            var ConsultaCodigo = (from C in hb.Productos_Insumos
                                                       where C.Codigo == txtCodigoBarra.Text
                                                       select C).FirstOrDefault();

                            if (ConsultaCodigoBarra != null || ConsultaCodigo != null || ConsultaPLU != null)
                            {
                                string CodigoProducto = string.Empty;

                                if (ConsultaPLU != null)
                                {
                                    EsPesable = true;
                                    CodigoProducto = ConsultaPLU.Codigo;
                                }                                 
                                if (ConsultaCodigoBarra != null && ConsultaPLU == null)
                                    CodigoProducto = ConsultaCodigoBarra.Producto_ID;
                                if (ConsultaCodigo != null && ConsultaPLU == null)
                                    CodigoProducto = ConsultaCodigo.Codigo;

                                    var ConsultaArticulo = (from A in hb.Productos_Insumos
                                                            where A.Codigo == CodigoProducto
                                                            select A).FirstOrDefault();

                                if (ConsultaArticulo == null)
                                    MessageBox.Show("No existe articulo con el codigo de barras ingresado");
                                else
                                {
                                    var ConsultaListaPrecio = (from LP in hb.LISTAPRECIOCUERPO
                                                               where LP.ListaPrecio_ID == (int)cmbListaPrecio.SelectedValue
                                                                   && LP.Articulo_ID == ConsultaArticulo.Codigo
                                                               select LP).FirstOrDefault();

                                    if (ConsultaListaPrecio != null && ConsultaListaPrecio.Precio > 0)
                                    {
                                        //SI ES PESABLE
                                        if (ConsultaPLU != null)
                                        {
                                           decimal Peso;
                                           decimal Importe;

                                           string SPeso;
                                           string SImporte;

                                             SImporte = txtCodigoBarra.Text.Substring(4,  8).TrimStart('0');
                                            // Importe = decimal.Parse(SImporte);
                                            Importe = decimal.Parse(SImporte);
                                            //Importe = Math.Round(Importe, 2, MidpointRounding.AwayFromZero);

                                            Peso = Importe / (decimal)ConsultaListaPrecio.Precio;
                                            Peso = Math.Round(Peso, 3);
                                           // Importe = Math.Round(Importe, 2);

                                            dgvTicket.Rows.Add("", ConsultaArticulo.Codigo, ConsultaArticulo.Descripcion, Peso, ConsultaListaPrecio.Precio,Importe);
                                           

                                        }
                                        else
                                        {
                                            dgvTicket.Rows.Add("", ConsultaArticulo.Codigo, ConsultaArticulo.Descripcion, 1m , ConsultaListaPrecio.Precio);
                                        }
                                        SeleccionarUltimaFila();
                                        //else
                                        //{
                                        //    SonidoError.Play();
                                        //    MessageBox.Show("El artículo " + ConsultaArticulo.Descripcion + " - " + ConsultaArticulo.Codigo + " no tiene precio definido. Favor de definir el mismo en la lista de precio " + ConsultaListaPrecio.LISTAPRECIO.Descripcion, "Atención");

                                        //}
                                    }
                                    else
                                    {
                                        SonidoError.Play();
                                        //MessageBox.Show("El articulo " + ConsultaArticulo.Descripcion + " - " + ConsultaArticulo.Codigo + " no esta registrado en ninguna lista de precio. Favor de agregarlo a una lista para poder continuar.", "Atención");
                                        DialogResult R = MessageBox.Show("El articulo " + ConsultaArticulo.Descripcion + " - " + ConsultaArticulo.Codigo + " no esta registrado en ninguna lista de precio.¿Desea agregarlo?", "Atención", MessageBoxButtons.YesNo);

                                        if (R == DialogResult.Yes)
                                        {
                                            var f = new frmQuickAgregarProductoListaPrecio();
                                            f.ProductoID = ConsultaArticulo.Codigo;
                                            f.Producto = ConsultaArticulo.Descripcion;
                                            f.ListaPrecioID = (int)cmbListaPrecio.SelectedValue;
                                            f.ListaPrecio = cmbListaPrecio.Text;
                                            f.ShowDialog();
                                        }

                                    }
                                }
                            }
                            else
                            {
                                SonidoError.Play();

                                if (ConsultaCodigoBarra == null)
                                {
                                    DialogResult R = MessageBox.Show("El articulo con código " + CodigoBarra + " no exite en la base de datos. ¿Desea crearlo?", "Atención", MessageBoxButtons.YesNo);
                                    {
                                        if (R == DialogResult.Yes)
                                        {
                                            var f = new frmQuickCrearArticulo();
                                            f.StartPosition = FormStartPosition.CenterScreen;
                                            f.CodigoBarra = CodigoBarra;
                                            f.DGV = this.dgvTicket;
                                            f.Modulo = "TICKET";
                                            f.ShowDialog();
                                        }                                     
                                    }
                                }                                                      
                            }
                        }
                    }
                   
                    CalcularTotal();
                   

                    txtCodigoBarra.Clear();
                    txtCodigoBarra.Focus();
                    e.Handled = true;
                }
                catch (Exception error)
                {

                    MessageBox.Show(error.Message);
                }
                
            }
        }
        private void SeleccionarUltimaFila()
        {
            int ultimaFila = dgvTicket.Rows.Count - 1;

            dgvTicket.ClearSelection();
            dgvTicket.Rows[ultimaFila].Selected = true;
            dgvTicket.CurrentCell = dgvTicket.Rows[ultimaFila].Cells[1];
        }
        private void txtCodigoBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            LeerCodigoBarra(e);
        }
        private void PD_BeginPrint(object sender, PrintEventArgs e)
        {
            //PageSettings pagesetup = new PageSettings();
            //pagesetup.PaperSize = new PaperSize("Custom", 270, longpaper);
            //PD.DefaultPageSettings = pagesetup;
        }
        private void PD_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font f7 = new Font("Calibri", 7, FontStyle.Regular);
            Font f8 = new Font("Calibri", 8, FontStyle.Regular);
            Font f10 = new Font("Calibri", 10, FontStyle.Regular);
            Font f10b = new Font("Calibri", 10, FontStyle.Bold);
            Font f12N = new Font("Calibri", 12, FontStyle.Bold);
            Font f14 = new Font("Calibri", 14, FontStyle.Bold);
            

            //int leftmargin = PD.DefaultPageSettings.Margins.Left;              //DESCOMENTAR
            //int centermargin = PD.DefaultPageSettings.PaperSize.Width / 2;
            //int rightmargin = PD.DefaultPageSettings.PaperSize.Width;

            StringFormat right = new StringFormat();
            StringFormat center = new StringFormat();
            right.Alignment = StringAlignment.Far;
            center.Alignment = StringAlignment.Center;

            string line = "****************************************************************";
            //string line = "________________________________________________________________";

            //Image logoImage = Properties.Resources.logo;
            //e.Graphics.DrawImage(logoImage, (e.PageBounds.Width - 50) / 2, 5, 50, 35);

            using (var hb = new DBdatos())
            {
                string Empresa;
                string CUIT;
                string Direccion;
                string Ciudad;
                string CondicionIVA;
                string Comprobante;
                string NumeroComprobante;
                string Fecha;
                string Hora;
                string Cliente;
                decimal CantidadArticulo = 0;
                decimal ImporteTotal = 0;
                int LargoPapel = 0;
                long ID;

                var ConsultaCliente = (from CLI in hb.Clientes
                                       where CLI.Cliente_Usuario == true
                                       select CLI).FirstOrDefault();

                //CLIENTE
                if (ConsultaCliente != null)
                    Empresa = ConsultaCliente.Descripcion;
                else
                    Empresa = "";

                CUIT = "30-25648971-8";
                Direccion = "Bv España 775";
                Ciudad = "Colazo - Cordoba";
                CondicionIVA = "RESPONSABLE INSCRIPTO";

                if (Accion != "2")
                    ID = IDCabezal;
                else
                    ID = IDRecibido;

                //CABEZAL
                var ConsultaCabezal = (from CAB in hb.TICKET
                                where CAB.ID == ID
                                select CAB).FirstOrDefault();

                Comprobante = ConsultaCabezal.MOVIMIENTOS.Descripcion + " - " + ConsultaCabezal.Letra;
                NumeroComprobante = ConsultaCabezal.NumeroTicket.Substring(0, 4) + " - " + ConsultaCabezal.NumeroTicket.Substring(4, 8);
                Fecha = ConsultaCabezal.Fecha.ToShortDateString();
                Hora = ConsultaCabezal.Fecha.ToShortTimeString();
                Cliente = ConsultaCabezal.Clientes.Descripcion;
                
                var ConsultaCuerpo = (from CU in hb.TICKETCUERPO
                                      where CU.Ticket_ID == ID
                                      select CU).ToList();


                //e.Graphics.DrawString(Empresa, f12N, Brushes.Black, centermargin, 10, center);
                //e.Graphics.DrawString(CUIT, f10, Brushes.Black, centermargin, 35, center);
                //e.Graphics.DrawString(Direccion, f10, Brushes.Black, centermargin, 50, center);
                //e.Graphics.DrawString(Ciudad, f10, Brushes.Black, centermargin, 65, center);
                //e.Graphics.DrawString(Comprobante, f12N, Brushes.Black, centermargin, 90, center);

                e.Graphics.DrawString("Factura N", f8, Brushes.Black, 0, 120); // SEPARA 20
                e.Graphics.DrawString(":", f8, Brushes.Black, 50, 120);
                e.Graphics.DrawString(NumeroComprobante, f8, Brushes.Black, 70, 120);

                e.Graphics.DrawString("Fecha: " + DateTime.Now.ToShortDateString() + " - Hora: " + DateTime.Now.ToShortTimeString(), f8, Brushes.Black, 0, 130);

                e.Graphics.DrawString(line, f8, Brushes.Black, 0, 140);
                
                int height = 0;
                decimal i;
                //DataGridView1.AllowUserToAddRows = false;

                foreach(var item in ConsultaCuerpo)
                {
                    string Articulo1 = item.Productos_Insumos.Descripcion;

                    if (Articulo1.Length > 36)
                    {
                        string Articulo2 = Articulo1.Remove(0,33); // SALTO LINEA NOMBRE MUY LARGO

                        height += 15;
                        Articulo1 = Articulo1.Substring(0, 33);
                        e.Graphics.DrawString(Articulo1, f8, Brushes.Black, 0, 140 + height);
                        e.Graphics.DrawString(item.Cantidad.ToString(), f8, Brushes.Black, 150, 140 + height);
                        e.Graphics.DrawString(item.Precio.ToString("N2"), f8, Brushes.Black, 210, 140 + height);
                        height = height + 15;
                        //Articulo = item.Productos_Insumos.Descripcion.Substring(39, item.Productos_Insumos.Descripcion.Length - 1);
                        e.Graphics.DrawString(Articulo2, f8, Brushes.Black, 0, 140 + height);
                        e.Graphics.DrawString("", f8, Brushes.Black, 210, 140 + height);
                    }
                    else
                    {
                        height = height + 15; //Espacio entre lineas
                        e.Graphics.DrawString(Articulo1, f8, Brushes.Black, 0, 140 + height);
                        e.Graphics.DrawString(item.Cantidad.ToString(), f8, Brushes.Black, 150, 140 + height);
                        e.Graphics.DrawString(item.Precio.ToString("N2"), f8, Brushes.Black, 210, 140 + height);
                    }
                    //height += 15; //Espacio entre lineas
                    //e.Graphics.DrawString(Articulo, f7, Brushes.Black, 0, 140 + height);
                    //e.Graphics.DrawString(item.Precio.ToString("N2"), f7, Brushes.Black, rightmargin, 140 + height);
                   
                    
                    //i = Convert.ToDecimal(DataGridView1.Rows[row].Cells[2].Value);
                    //DataGridView1.Rows[row].Cells[2].Value = i.ToString("##,##0");

                    //e.Graphics.DrawString(DataGridView1.Rows[row].Cells[2].Value.ToString(), f8, Brushes.Black, 180, 115 + height, right);
                    CantidadArticulo = (decimal)(CantidadArticulo + item.Cantidad);
                    ImporteTotal = ImporteTotal + Convert.ToDecimal(item.Precio);
                    //e.Graphics.DrawString(totalprice.ToString("##,##0"), f8, Brushes.Black, rightmargin, 115 + height, right);
                }

                int height2 = 175 + height;

                //sumprice();
                e.Graphics.DrawString(line, f8, Brushes.Black, 0, height2);
               // e.Graphics.DrawString("Total: " + ImporteTotal.ToString("N2"), f10b, Brushes.Black, rightmargin, 20 + height2, right);
                e.Graphics.DrawString("Articulos: " + CantidadArticulo.ToString(), f10, Brushes.Black, 0, 20 + height2);

              //  e.Graphics.DrawString("~ GRACIAS POR SU COMPRA ~", f10, Brushes.Black, centermargin, 50 + height2, center);
               
                //e.Graphics.DrawString("~ Documento generado por: Nombre del software ~", f8, Brushes.Black, centermargin, 85 + height2, center);

               // longpaper = ConsultaCuerpo.Count * 15 + 240;

                
            }
        }
        private void LargoPapel()
        {
            int CantidadArticulos = 0;
            for (int row = 0; row < dgvTicket.RowCount; row++)
            {
                CantidadArticulos++;
                if (dgvTicket.Rows[row].Cells["colArticulo"].Value.ToString().Length > 36)
                    CantidadArticulos++;
            }
            C.LargoPapel = CantidadArticulos * 15 + 240;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //MostrarPantallaEspera();
            //clsQueryPlantillas.PlaTicket(IDRecibido, VisorReporte);
            //LargoPapel();
            //PPD.Document = PD;
            //PPD.ShowDialog();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (Accion != "2")
                IDImprimir = IDCabezal;
            else
                IDImprimir = IDRecibido;
         
            C.ImprimirTicket(IDImprimir,dgvTicket,chkImprimir);




            //LargoPapel();
            //C.LargoPapel = longpaper;
           // C.PPD.Document = C.PD;
            //if (chkImprimir.Checked)
            //    PD.Print();
            //else
            //    PPD.ShowDialog();

            //clsImprimirPlantilla clsImprimirPlantilla = new clsImprimirPlantilla();
           
            //C.PPD.ShowDialog();
            //clsImprimirPlantilla.PD_PrintPage(sender,PrintPageEventArgs p);
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {

        }

        private void txtEntregado_Leave(object sender, EventArgs e)
        {
            //Reutilizables.ValidarSoloNumeros(txtEntregado);
        }

        private void cmbMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivarLectorCodigoBarra();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            ActivarLectorCodigoBarra();
        }

        private void rdbContado_CheckedChanged(object sender, EventArgs e)
        {
            ActivarLectorCodigoBarra();
        }

        private void rdbEnProceso_CheckedChanged(object sender, EventArgs e)
        {
            ActivarLectorCodigoBarra();
            clsCargarCombos.MostrarComboClientes(cmbCliente,txtBuscarCliente,false,"CLI",0);
            if (Accion != "2")
                cmbCliente.SelectedIndex = -1;
           
        }

        private void chkImprimir_CheckedChanged(object sender, EventArgs e)
        {
            ActivarLectorCodigoBarra();
        }

        private void dgvTicket_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvTicket.CurrentCell = dgvTicket.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvTicket.BeginEdit(true);
            }
            catch (Exception)
            {


            }
        }

        private void txtBuscarCliente_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtObservacion_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void btnImprimirPresupuesto_Click(object sender, EventArgs e)
        {
            if(cmbCliente.SelectedValue != null)
            {
                clsQueryPlantillas.PlaPresupuesto001(dgvTicket, VisorReporte,(int)cmbCliente.SelectedValue,txtImporteTotal.Text,txtDescuentoPorcentaje.Text,txtDescuentoAplicado.Text);
            }
            
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            txtBuscarCliente.Visible = true;
            txtBuscarCliente.Select();
        }

        private void txtBuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarCliente.Visible = false;
                clsCargarCombos.MostrarComboClientes(cmbCliente, txtBuscarCliente,true,"CLI", 0);
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

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescuentoPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CalcularTotal();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActivarLectorCodigoBarra();
        }

        private void rdbCredito_CheckedChanged(object sender, EventArgs e)
        {
            ActivarLectorCodigoBarra();
        }

        private void rdbDebito_CheckedChanged(object sender, EventArgs e)
        {
            ActivarLectorCodigoBarra();
        }

        private void cmbListaPrecio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivarLectorCodigoBarra();
        }

        private void cmbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var hb = new DBdatos())
                {
                    // var c = hb.LISTAPRECIOCUERPO.FirstOrDefault(x => x.ID == ID);
                    if (cmbFormaPago.SelectedValue != null)
                    {
                        if((int)cmbFormaPago.SelectedValue != 0)
                        {
                            var c = hb.MEDIOPAGO.FirstOrDefault(x => x.ID == (int)cmbFormaPago.SelectedValue);
                            if (c.Codigo == "CC")
                            {
                                clsCargarCombos.MostrarComboClientes(cmbCliente, txtBuscarCliente, false, "CLI", 0);
                                if (Accion != "2")
                                    cmbCliente.SelectedIndex = -1;
                            }
                            CalcularTotal();
                            ActivarLectorCodigoBarra();
                        }
                        


                    }
                }
                    
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
                return;
            }
        }
        private void CalcularImporteFormaPago(CheckBox chk ,TextBox txt , ComboBox cmb , int MedioPagoID , Label lbl)
        {
            try
            {
                if (chk.Checked)
                {
                    decimal TotalAfectado = 0;
                    decimal Resultado = 0;
                    decimal TotalGeneral = Convert.ToDecimal(txtImporteTotal.Text);

                    foreach (var i in pnlMedioPagoCentral.Controls.OfType<TextBox>())
                    {
                        if (!i.Name.Contains("Total") && i.Enabled == true) 
                        {
                            TotalAfectado = TotalAfectado + Convert.ToDecimal(i.Text);
                            Resultado = TotalGeneral - TotalAfectado;
                            //TotalAfectado = TotalGeneral - (TotalAfectado + Convert.ToDecimal(i.Text));                            
                        }
                    }
                    if(Resultado <= 0)
                    {
                        chk.Checked = false;
                        MessageBox.Show("Ya afecto todo el total", "Atencion");
                        txt.Text = "0,00";
                        cmb.SelectedValue = 0;
                        return;
                    }
                    using (var hb = new DBdatos())
                    {

                        txt.Text = Resultado.ToString("N2");
                        //if (cmb.SelectedValue != null && cmb.SelectedIndex != -1)
                        //{
                        //    var c = hb.MEDIOPAGO.FirstOrDefault(x => x.ID == (int)cmbFormaPago.SelectedValue);

                        //    if(c != null)
                        //    {
                        //        Resultado = Resultado + (Resultado * ((decimal)c.Porcentaje / 100));
                        //        txt.Text = Resultado.ToString("N2");
                        //    }
                        //}
                    }


                        
                }
                else
                {
                    

                    using (var hb = new DBdatos())
                    {
                        if (MedioPagoID != 0)
                        {
                            decimal TotalFormaPago = Convert.ToDecimal(txtImporteTotal.Text);

                            var c = hb.MEDIOPAGO.FirstOrDefault(x => x.ID == MedioPagoID);
                            if (c.Porcentaje != null && c.Porcentaje > 0)
                            {
                                DescRecFormaPago = Convert.ToDecimal(txtFormaPagoDescRec.Text) - ((Convert.ToDecimal(txt.Text) / (1 + ((decimal)c.Porcentaje / 100))* ((decimal)c.Porcentaje / 100)));
                                TotalFormaPago = TotalFormaPago - DescRecFormaPago;

                                txtFormaPagoDescRec.Text = DescRecFormaPago.ToString("N2");
                                txtFormaPagoTotal.Text = TotalFormaPago.ToString("N2");
                                MedioPagoID = 0;
                                //Resultado = Resultado + (Resultado * ((decimal)c.Porcentaje / 100));
                                //txt.Text = Resultado.ToString("N2");
                            }
                        }
                    }
                    txt.Text = "0,00";
                    cmb.SelectedValue = 0;
                    lbl.Text = "";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
            
        }
        private void DefinirDescRecFormaPago(ComboBox cmb , TextBox txt , CheckBox chk , Label lbl)
        {
            try
            {
                using (var hb = new DBdatos())
                {
                    // var c = hb.LISTAPRECIOCUERPO.FirstOrDefault(x => x.ID == ID);
                    if (cmb.SelectedValue != null)
                    {
                        decimal Resultado = 0;
                        decimal TotalAfectado = 0;
                        decimal TotalGeneral = 0;
                        decimal DescRecFormaPago = 0;

                        if ((int)cmb.SelectedValue != 0)
                        {
                            var c = hb.MEDIOPAGO.FirstOrDefault(x => x.ID == (int)cmb.SelectedValue);
                            if (c.Codigo == "CC")
                            {
                                clsCargarCombos.MostrarComboClientes(cmbCliente, txtBuscarCliente, false, "CLI", 0);
                                if (Accion != "2")
                                    cmbCliente.SelectedIndex = -1;

                            }
                            if (c.Porcentaje != null)
                            {
                                //LINEA
                                DescRecFormaPago = (Convert.ToDecimal(txt.Text) * ((decimal)c.Porcentaje / 100));
                                //TotalGeneral = Convert.ToDecimal(txtFormaPagoTotal.Text) + DescRecFormaPago;
                                Resultado = Convert.ToDecimal(txt.Text) + DescRecFormaPago;

                                if (c.Porcentaje > 0)
                                {
                                    lbl.Text = "Aplica " + c.Porcentaje + " % " + " de recargo";
                                    lbl.ForeColor = Color.Red;
                                }
                                if (c.Porcentaje < 0)
                                {
                                    lbl.Text = "Aplica " + c.Porcentaje + " % " + " de descuento";
                                    lbl.ForeColor = Color.ForestGreen;
                                }

                                //CAMBIA EL VALOR DEL TOTAL
                                DescRecFormaPago = 0;

                                foreach (var i in pnlMedioPagoCentral.Controls.OfType<TextBox>())
                                {
                                    if (!i.Name.Contains("Total") && i.Enabled == true)
                                    {
                                        string comboRef = i.Name.Replace("txt", "cmb");
                                        Control[] controles = this.Controls.Find(comboRef, true);
                                        ComboBox ComboSeleccionado = (ComboBox)controles[0];

                                        if (ComboSeleccionado.SelectedValue != null)
                                        {
                                            var X = hb.MEDIOPAGO.FirstOrDefault(x => x.ID == (int)ComboSeleccionado.SelectedValue);

                                            if (X.Porcentaje != null)
                                            {
                                                if (chk.Checked)
                                                {
                                                    DescRecFormaPago = DescRecFormaPago + (Convert.ToDecimal(txt.Text) * ((decimal)X.Porcentaje / 100));
                                                    TotalGeneral = Convert.ToDecimal(txtFormaPagoTotal.Text) + DescRecFormaPago;
                                                }
                                                else
                                                {
                                                    DescRecFormaPago = DescRecFormaPago - (Convert.ToDecimal(txt.Text) * ((decimal)X.Porcentaje / 100));
                                                    TotalGeneral = Convert.ToDecimal(txtFormaPagoTotal.Text) - DescRecFormaPago;
                                                    cmb.SelectedValue = 0;
                                                }
                                                //TotalGeneral = Convert.ToDecimal(txtFormaPagoTotal.Text) + DescRecFormaPago;
                                                //Resultado = Convert.ToDecimal(txt.Text) + (Convert.ToDecimal(txt.Text) * ((decimal)c.Porcentaje / 100));
                                            }
                                            else
                                            {
                                                DescRecFormaPago = DescRecFormaPago + (Convert.ToDecimal(txt.Text) * 0 / 100);
                                                TotalGeneral = Convert.ToDecimal(txtFormaPagoTotal.Text) + DescRecFormaPago;
                                                //Resultado = Convert.ToDecimal(txt.Text) + (Convert.ToDecimal(txt.Text) * 0 / 100);
                                            }
                                        }

                                    }
                                }


                                txt.Text = Resultado.ToString("N2");
                                txtFormaPagoDescRec.Text = DescRecFormaPago.ToString("N2");
                                txtFormaPagoTotal.Text = (TotalGeneral).ToString("N2");

                                //txt.Text = Resultado.ToString("N2");
                                //TotalGeneral = Convert.ToDecimal(txtFormaPagoTotal.Text) + (Convert.ToDecimal(txt.Text) * ((decimal)c.Porcentaje / 100));
                            }

                        }
                        else
                        {
                            Resultado = Convert.ToDecimal(txt.Text);
                            txt.Text = Resultado.ToString("N2");
                            lbl.Text = "";
                            
                        }
                        ////CAMBIA EL VALOR DEL TOTAL
                        //foreach (var i in pnlMedioPagoCentral.Controls.OfType<TextBox>())
                        //{
                        //    if (!i.Name.Contains("Total") && i.Enabled == true)
                        //    {
                        //        var X = hb.MEDIOPAGO.FirstOrDefault(x => x.ID == (int)cmb.SelectedValue);

                        //        if (X != null)
                        //        {
                        //            TotalGeneral = TotalGeneral + Convert.ToDecimal(txtFormaPagoTotal.Text) + (Convert.ToDecimal(txt.Text) * ((decimal)c.Porcentaje / 100));
                        //        }
                        //        else
                        //        {
                        //            TotalGeneral = TotalGeneral + Convert.ToDecimal(txt.Text);
                        //        }

                        //        txtFormaPagoTotal.Text = TotalGeneral.ToString("N2");
                        //    }
                        //}
                        //ActivarLectorCodigoBarra();




                    }
                    else
                    {
                        lbl.Text = "";
                        cmb.SelectedValue = 0;
                    }
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
                return;
            }
        }
        private void cmbFormaPago_MouseEnter(object sender, EventArgs e)
        {
            ActivarLectorCodigoBarra();
        }

        private void cmbFormaPago_MouseDown(object sender, MouseEventArgs e)
        {
            //if(cmbFormaPago.DroppedDown != true)
            //{
            //    ActivarLectorCodigoBarra();
            //}
           // ActivarLectorCodigoBarra();
        }

        private void cmbFormaPago_Leave(object sender, EventArgs e)
        {
            ActivarLectorCodigoBarra();
        }

        private void cmbFormaPago_MouseClick(object sender, MouseEventArgs e)
        {
            ActivarLectorCodigoBarra();
            cmbFormaPago.DroppedDown = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //Reutilizables.ActivarFiltroMedioPago2(cmb)
        }

        private void chkMedioPago1_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroMedioPago2(chkMedioPago1, cmbFormaPago1, txtFormaPago1,ref MedioPagoSeleccionado1);
            CalcularImporteFormaPago(chkMedioPago1, txtFormaPago1, cmbFormaPago1 ,MedioPagoSeleccionado1, lblDesRec2);
            
            
        }

        private void chkMedioPago2_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroMedioPago2(chkMedioPago2, cmbFormaPago2, txtFormaPago2, ref MedioPagoSeleccionado2);
            CalcularImporteFormaPago(chkMedioPago2, txtFormaPago2, cmbFormaPago2 , MedioPagoSeleccionado2,lblDesRec2);
            

        }

        private void chkMedioPago3_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroMedioPago2(chkMedioPago3, cmbFormaPago3, txtFormaPago3, ref MedioPagoSeleccionado3);
            CalcularImporteFormaPago(chkMedioPago3, txtFormaPago3, cmbFormaPago3, MedioPagoSeleccionado3, lblDesRec4);
            
        }

        private void chkMedioPago4_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroMedioPago2(chkMedioPago4, cmbFormaPago4, txtFormaPago4, ref MedioPagoSeleccionado4);
            CalcularImporteFormaPago(chkMedioPago4, txtFormaPago4, cmbFormaPago4, MedioPagoSeleccionado4, lblDesRec4);
            
        }

        private void chkMedioPago5_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroMedioPago2(chkMedioPago5, cmbFormaPago5, txtFormaPago5, ref MedioPagoSeleccionado5);
            CalcularImporteFormaPago(chkMedioPago5, txtFormaPago5, cmbFormaPago5, MedioPagoSeleccionado5, lblDesRec5);
            
            
        }

        private void btnCerrarPanelFormaPago_Click(object sender, EventArgs e)
        {
            pnlMedioPago.Visible = false;
        }

        private void btnMostrarFormaPago_Click(object sender, EventArgs e)
        {
            pnlMedioPago.Visible = true;
            txtFormaPagoTotal.Text = txtImporteTotal.Text;
        }

        private void txtFormaPago1_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtFormaPago1);
        }

        private void txtFormaPago2_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtFormaPago2);
        }

        private void txtFormaPago3_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtFormaPago3);
        }

        private void txtFormaPago4_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtFormaPago4);
        }

        private void txtFormaPago5_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtFormaPago5);
        }

        private void cmbFormaPago1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DefinirDescRecFormaPago(cmbFormaPago1,txtFormaPago1,chkMedioPago1,lblDesRec1);
        }

        private void cmbFormaPago2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DefinirDescRecFormaPago(cmbFormaPago2, txtFormaPago2, chkMedioPago2, lblDesRec2);
        }

        private void cmbFormaPago3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DefinirDescRecFormaPago(cmbFormaPago3, txtFormaPago3, chkMedioPago3, lblDesRec3);
        }

        private void cmbFormaPago4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DefinirDescRecFormaPago(cmbFormaPago4, txtFormaPago4, chkMedioPago4, lblDesRec4);
        }

        private void cmbFormaPago5_SelectedIndexChanged(object sender, EventArgs e)
        {
            DefinirDescRecFormaPago(cmbFormaPago5, txtFormaPago5, chkMedioPago5, lblDesRec5);
        }

        private void pnlMedioPagoCentral_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
