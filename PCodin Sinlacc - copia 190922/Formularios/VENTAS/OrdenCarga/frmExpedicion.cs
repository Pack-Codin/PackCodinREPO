using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Clases.UsuarioTema;
using PCodin_Sinlacc.Datos;
using TextBox = System.Windows.Forms.TextBox;

namespace PCodin_Sinlacc.Formularios.VENTAS.OrdenCarga
{
    public partial class frmExpedicion : Form
    {
        public frmExpedicion()
        {
            InitializeComponent();
        }
        public string Accion;
        public long IDRecibido;
        long OrdenCargaID; //ID DE LA ORDEN DE CARGA
        long OrdenCargaCuerpoID = 0; //ID DE LA ORDEN DE CARGA CUERPO
        long ExitenciaProductoID;
        private frmPantallaEspera PantallaEspera = new frmPantallaEspera();
        private frmReporte VisorReporte = new frmReporte();
        private void frmExpedicion_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
            Reutilizables.RenderizarForm(this);

            clsCargarCombos.MostrarComboEmpleadosPorPuesto(cmbChofer, txtBuscaChofer, false, 7);
            MostrarImpresoras();

            cmbChofer.SelectedIndex = -1;

            if (Accion == "1")
            {
                btnAnular.Enabled = false;
                lblEstado.Text = "Pendiente";
            }
            if (Accion == "2" || Accion == "3")
            {
                if (Accion == "2")
                    btnImprimirEtiqueta.Enabled = true;
                else
                    btnImprimirEtiqueta.Enabled = false;

                using (var hb = new DBdatos())
                {
                    var ConsultaOC = (from OC in hb.Orden_Carga
                                      where OC.ID == IDRecibido
                                      select OC).FirstOrDefault();

                    var ConusltaOCC = (from OCC in hb.OrdenCarga_Cuerpo
                                       where OCC.Orden_ID == IDRecibido
                                       select OCC).ToList();

                    
                    txtNumeroOrden.Text = ConsultaOC.Numero_Orden;

                    if (Accion == "2")
                        lblEstado.Text = ConsultaOC.Estado_Ord_Carga.Descripcion;
                    else
                        lblEstado.Text = "Pendiente";

                   

                    dtpFecha.Value = ConsultaOC.Fecha.Date;
                    cmbChofer.SelectedValue = ConsultaOC.Chofer_ID;
                    cmbChofer.Text = ConsultaOC.Clientes.Descripcion;
                    txtObservaciones.Text = ConsultaOC.Observaciones;

                    foreach (var item in ConusltaOCC)
                    {
                        string PalletProducto = "";

                        //CALCULA NUMERO PEIDDO
                        string NumeroPedido = "";

                        var ConsultaPedido = (from PC in hb.Pedido_Cuerpo
                                              where PC.ID == item.PedidoCuerpoID
                                              select PC).FirstOrDefault();

                        if (ConsultaPedido != null)
                            NumeroPedido = ConsultaPedido.Registro_Pedidos.Numero_Pedido;

                        if (Accion == "3")
                        {
                            var ConsultaPallet = (from PRO in hb.Productos_Insumos
                                                  where PRO.ProductoPallet == item.Producto_ID
                                                    && PRO.Pallet == "SI"
                                                  select PRO).FirstOrDefault();

                            if (ConsultaPallet != null)
                                PalletProducto = ConsultaPallet.Codigo;
                        }
                        
                        dgvOrdenCarga.Rows.Add(
                                                item.Producto_ID,
                                                item.Productos_Insumos.Descripcion,
                                                item.Cantidad,
                                                item.Pallets,
                                                PalletProducto,
                                                item.Lote,
                                                NumeroPedido,
                                                item.Humedad,
                                                item.Acidez,
                                                item.Cliente_ID,
                                                item.Clientes.Descripcion,
                                                item.TipoPallet,
                                                item.ID,
                                                item.PedidoCuerpoID
                                                );
                    }

                    lblResultados.Text = ConusltaOCC.Count.ToString();
                }
            }
            FormatearEstado();
        }
        private void CalculaIDOrdenCarga()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from OC in hb.Orden_Carga
                                orderby OC.ID descending
                                select OC).Take(1);

                var Resultados = Consulta.FirstOrDefault();

                if (Resultados == null)
                {
                    OrdenCargaID = 1;
                }
                else
                {
                    OrdenCargaID = Resultados.ID + 1;
                }
            }
        }
        private void CalcularIDOrdenCargaCUerpo()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from OC in hb.OrdenCarga_Cuerpo
                                orderby OC.ID descending
                                select OC).FirstOrDefault();

                if (Consulta == null)
                {
                    OrdenCargaCuerpoID = 1;
                }
                else
                {
                    OrdenCargaCuerpoID = Consulta.ID + 1;
                }
            }
        }
        private void CalculaIDExistenciaProducto()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from EP in hb.Existencia_ProductoTerminado
                                orderby EP.ID descending
                                select EP).FirstOrDefault();

                if (Consulta == null)
                {
                    ExitenciaProductoID = 1;
                }
                else
                {
                    ExitenciaProductoID = Consulta.ID + 1;
                }
            }
        }
        private void CalcularNumeroOrdenCarga()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from OC in hb.Orden_Carga
                                orderby OC.ID descending
                                select OC).FirstOrDefault();

                if (Consulta == null)
                {
                    txtNumeroOrden.Text = "OC1";
                }
                else
                {
                    txtNumeroOrden.Text = "OC" + (Consulta.ID + 1);
                }
            }
        }
        private void FormatearEstado()
        {
            if (lblEstado.Text == "Finalizado")
                lblEstado.ForeColor = Color.LimeGreen;
            if (lblEstado.Text == "Anulado")
                lblEstado.ForeColor = Color.Red;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirFormAgregar("1");
        }
        private void MostrarImpresoras()
        {
            String pkInstalledPrinters;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                cmbImpresoras.Items.Add(pkInstalledPrinters);
            }
        }

        private void txtBuscaChofer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaChofer.Visible = false;
                clsCargarCombos.MostrarComboEmpleadosPorPuesto(cmbChofer, txtBuscaChofer, true, 0);
                txtBuscaChofer.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaChofer.Visible = false;
                txtBuscaChofer.Focus();
                e.Handled = true;
            }
        }

        private void cmbChofer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboEmpleadosPorPuesto(cmbChofer, txtBuscaChofer, false, 0);
                txtBuscaChofer.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscaChofer_Click(object sender, EventArgs e)
        {
            txtBuscaChofer.Visible = true;
            txtBuscaChofer.Select();
        }
        private void MostrarPantallaEspera()
        {
            PantallaEspera = new frmPantallaEspera();
            VisorReporte = new frmReporte();

            PantallaEspera.Shown += new System.EventHandler(frmPantallaEspera_Shown);
            PantallaEspera.ShowDialog();
        }



        private void btnCargar_Click(object sender, EventArgs e)
        {
            using (var hb = new DBdatos())
            {
                if (dgvOrdenCarga.RowCount > 0 && Accion != "2" && cmbChofer.SelectedIndex != -1)
                {
                    try
                    {
                        CalculaIDOrdenCarga();
                        CalcularNumeroOrdenCarga();
                        CalcularIDOrdenCargaCUerpo();
                        CalculaIDExistenciaProducto();

                        var Cabezal = new Orden_Carga();

                        var ConsultaClienteVarios = (from C in hb.Clientes
                                                     where C.Descripcion == "VARIOS"
                                                     select C).FirstOrDefault();

                        //CABEZAL
                        Cabezal.ID = OrdenCargaID;
                        Cabezal.Numero_Orden = txtNumeroOrden.Text;
                        Cabezal.Cliente_ID = ConsultaClienteVarios.ID;
                        Cabezal.Chofer_ID = (int)cmbChofer.SelectedValue;
                        Cabezal.Fecha = dtpFecha.Value.Date;
                        Cabezal.Estado_ID = "FI";
                        Cabezal.Observaciones = txtObservaciones.Text;
                        Cabezal.Modo = true; // TRUE CUANDO ES CARGADA POR EXPEDICION - FALSE POR ORDEN DE CARGA TRADICIONAL

                        hb.Orden_Carga.Add(Cabezal);

                        //CUERPO                                          
                        for (var i = 0; i < dgvOrdenCarga.RowCount; i++)
                        {
                            var Cuerpo = new OrdenCarga_Cuerpo();

                            Cuerpo.ID = OrdenCargaCuerpoID;
                            Cuerpo.Orden_ID = OrdenCargaID;
                            Cuerpo.Producto_ID = dgvOrdenCarga.Rows[i].Cells["colCodigoProducto"].Value.ToString();
                            Cuerpo.Cantidad = Convert.ToDecimal(dgvOrdenCarga.Rows[i].Cells["colCantidad"].Value);
                            Cuerpo.Cliente_ID = Convert.ToInt32(dgvOrdenCarga.Rows[i].Cells["colClienteID"].Value);
                            Cuerpo.Lote = dgvOrdenCarga.Rows[i].Cells["colLote"].Value.ToString();
                            Cuerpo.Pallets = Convert.ToDecimal(dgvOrdenCarga.Rows[i].Cells["colPallets"].Value);
                            Cuerpo.Humedad = Convert.ToDecimal(dgvOrdenCarga.Rows[i].Cells["colHumedad"].Value);
                            Cuerpo.Acidez = Convert.ToDecimal(dgvOrdenCarga.Rows[i].Cells["colAcidez"].Value);
                            Cuerpo.TipoPallet = dgvOrdenCarga.Rows[i].Cells["colTipoPallet"].Value.ToString();
                            Cuerpo.PedidoCuerpoID = Convert.ToInt64(dgvOrdenCarga.Rows[i].Cells["colPedidoCuerpoID"].Value);
                            Cuerpo.NumeroPedido = dgvOrdenCarga.Rows[i].Cells["colPedido"].Value.ToString();

                            hb.OrdenCarga_Cuerpo.Add(Cuerpo);   
                            
                           

                            //EXISTENCIA PRODUCTO TERMINADO (AQUI SE CARGAR LOS PALLETS PARA DESCONTAR TARIMAS E INSUMOS EN SU FORMULA)
                            if (dgvOrdenCarga.Rows[i].Cells["colTipoPallet"].Value.ToString() != "Suelto")
                            {
                                var ExistenciaProducto = new Existencia_ProductoTerminado();

                                ExistenciaProducto.ID = ExitenciaProductoID;
                                ExistenciaProducto.Fecha = dtpFecha.Value.Date;
                                ExistenciaProducto.Produto_ID = dgvOrdenCarga.Rows[i].Cells["colPalletProducto"].Value.ToString();
                                ExistenciaProducto.Cantidad = Convert.ToDecimal(dgvOrdenCarga.Rows[i].Cells["colPallets"].Value);
                                ExistenciaProducto.Cantidad_Utiliz = Convert.ToDecimal(dgvOrdenCarga.Rows[i].Cells["colPallets"].Value);
                                ExistenciaProducto.Movimiento_ID = "EPT";
                                ExistenciaProducto.Estado_ID = "ENT";
                                ExistenciaProducto.Lote = dgvOrdenCarga.Rows[i].Cells["colLote"].Value.ToString();
                                ExistenciaProducto.Numero_Produccion = "MP" + ExitenciaProductoID.ToString();
                                ExistenciaProducto.OrdenCargaID = OrdenCargaID;
                                ExistenciaProducto.Humedad = Convert.ToDecimal(dgvOrdenCarga.Rows[i].Cells["colHumedad"].Value);
                                ExistenciaProducto.Acidez = Convert.ToDecimal(dgvOrdenCarga.Rows[i].Cells["colAcidez"].Value);
                                ExistenciaProducto.OrdenCargaCuerpo_ID = OrdenCargaCuerpoID;

                                hb.Existencia_ProductoTerminado.Add(ExistenciaProducto);
                                ExitenciaProductoID = ExitenciaProductoID + 1; //AUTOINCREMENTA EL ID
                            }
                            OrdenCargaCuerpoID = OrdenCargaCuerpoID + 1; //AUTOINCREMENTA EL ID
                        }
                        hb.SaveChanges();
                        MessageBox.Show("Datos cargados correctamente", "Atención");



                        //IMPRIMIR
                        if (chkImprimir.Checked)
                            clsQueryPlantillas.EtiquetaCarga001(OrdenCargaID, VisorReporte, "Multiple", 0, 0, cmbImpresoras.Text, 0);

                        MostrarPantallaEspera();

                        this.Hide();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }
                }
                else
                {
                    if (dgvOrdenCarga.RowCount < 1)
                        MessageBox.Show("No ingreso ningun producto", "Atención");
                    if (Accion == "2")
                        MessageBox.Show("No se puede modificar un movimiento finalizado", "Atención");
                    if (cmbChofer.SelectedIndex < 0)
                        MessageBox.Show("No selecciono chofer", "Atención");
                }
            }
        }
        private void Imprimir()
        {
            try
            {
                //IMPRIMIR Etiqueta
                if (chkImprimir.Checked)
                    clsQueryPlantillas.EtiquetaCarga001(OrdenCargaID, VisorReporte, "Multiple", 0, 0, cmbImpresoras.Text, 0);

                //IMPRIMIR PLANILLA
                MostrarPantallaEspera();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
           
        }
     

        private void frmPantallaEspera_Shown(object sender, EventArgs e)
        {
            // SE CREA PARA DIFERENCIAR CUANDO ES IMPRESION DE PLANTILLA AL FINALIZAR O SOLO IMPRIMIR
            long ID;

            //SI ES SOLO IMPREESION
            if (OrdenCargaID > 0)
                ID = OrdenCargaID;
            else // SI ES CUANDO FINALIZA EL COMPROBANTE
                ID = IDRecibido;

            clsQueryPlantillas.PlaOrdenCargaPlanilla(ID, VisorReporte); //LISTA LA ORDEN
            PantallaEspera.Close();
        }

        private void AbrirFormAgregar(string Accion)
        {
            var f = new frmExpedicionCuerpo();

            if (Accion == "2" && dgvOrdenCarga.RowCount > 0)
            {
                f.RowIndice = dgvOrdenCarga.CurrentRow.Index;
                f.btnCargar.Visible = false;
            }
                

            f.frmExpedicion = this;            
            f.DGV = dgvOrdenCarga;
            f.Accion = Accion;
            f.Resultados = lblResultados;          
            f.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AbrirFormAgregar("2");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenCarga.RowCount > 0)
            {
                try
                {
                    dgvOrdenCarga.Rows.Remove(dgvOrdenCarga.CurrentRow);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }

            }
        }
        private void MostrarOpcionesImpresion()
        {
            if (dgvOrdenCarga.RowCount > 0)
            {
                if (pnlImpresionEtiqueta.Visible == false)
                {
                    String pkInstalledPrinters;
                    for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
                    {
                        pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                        cmbImpresoras.Items.Add(pkInstalledPrinters);
                    }

                    decimal Cantidad = 0;
                    if (Convert.ToDecimal(dgvOrdenCarga.CurrentRow.Cells["colPallets"].Value) < 1)
                        Cantidad = 1;
                    else
                        Cantidad = Convert.ToDecimal(dgvOrdenCarga.CurrentRow.Cells["colPallets"].Value);

                    int CantidadCopias = Convert.ToInt32(Cantidad);

                    pnlImpresionEtiqueta.Visible = true;
                    txtNumCopias.Value = CantidadCopias;


                    pnlImpresionEtiqueta.Location = new System.Drawing.Point(btnImprimirEtiqueta.Location.X, dgvOrdenCarga.Location.Y);
                }
                else
                    pnlImpresionEtiqueta.Visible = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //MostrarPantallaEspera();
            long ID = Convert.ToInt64(textBox1.Text);
            clsQueryPlantillas.EtiquetaCarga001(ID, VisorReporte, "Multiple", 0, 0, "", 0);
        }

        private void btnImprimirEtiqueta_Click(object sender, EventArgs e)
        {

            if (Accion == "2" && dgvOrdenCarga.RowCount > 0)
            {
                try
                {
                    long OCC_ID = Convert.ToInt64(dgvOrdenCarga.CurrentRow.Cells["colOrdenCargaCuerpoID"].Value);

                    MostrarOpcionesImpresion();

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }


            }



        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult R = MessageBox.Show("¿Esta seguro que desea anular esta orden de carga", "Atención", MessageBoxButtons.YesNo);
                if (R == DialogResult.Yes)
                {
                    using (var hb = new DBdatos())
                    {
                        // PASA A ESTADO AN LA ORDEN DE CARGA
                        var ConsultaOC = (from OC in hb.Orden_Carga
                                          where OC.ID == IDRecibido
                                          select OC).FirstOrDefault();

                        ConsultaOC.Estado_ID = "AN";

                        var ConsultaPallets = (from P in hb.Existencia_ProductoTerminado
                                               where P.OrdenCargaID == IDRecibido
                                               select P).ToList();

                        foreach (var item in ConsultaPallets)
                        {
                            item.Estado_ID = "AN";
                        }

                        hb.SaveChanges();
                        MessageBox.Show("Orden de carga invalidada correctamente", "Atenciòn");
                        this.Close();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }


        }

        private void btnImprimirEtiquetaIndidual_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbCompleta.Checked == true || rdbIndividual.Checked == true)
                {
                    string ModoImpresion = "";

                    if (rdbCompleta.Checked)
                        ModoImpresion = "Multiple";
                    if (rdbIndividual.Checked)
                        ModoImpresion = "Individual";

                    long OCC_ID = Convert.ToInt64(dgvOrdenCarga.CurrentRow.Cells["colOrdenCargaCuerpoID"].Value);
                    clsQueryPlantillas.EtiquetaCarga001(IDRecibido, VisorReporte, ModoImpresion, 0, Convert.ToInt32(txtNumCopias.Value), cmbImpresoras.Text, OCC_ID);
                }
                else
                {
                    MessageBox.Show("No selecciono tipo de impresión", "Atención");
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlImpresionEtiqueta.Visible = false;
        }

        private void dgvOrdenCarga_Click(object sender, EventArgs e)
        {
           pnlImpresionEtiqueta.Visible = false;
        }

        private void dgvOrdenCarga_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           pnlImpresionEtiqueta.Visible = false;
        }
        private void FormatearCeldas(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvOrdenCarga.RowCount > 0)
            {
                if (this.dgvOrdenCarga.Columns[e.ColumnIndex].Name == "colTipoPallet")
                {
                    if (e.Value.ToString() == "Mixto")
                    {
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.SelectionForeColor = Color.Black;
                        e.CellStyle.BackColor = Color.Khaki;
                        e.CellStyle.Font = new System.Drawing.Font("Roboto Condensed", 9, FontStyle.Bold);
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.SelectionForeColor = Color.Black;
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.Font = new System.Drawing.Font("Roboto Condensed", 9, FontStyle.Bold);
                    }
                }
            }
        } 

        private void dgvOrdenCarga_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatearCeldas(e);
        }

        private void rdbCompleta_CheckedChanged(object sender, EventArgs e)
        {
            pnlCopias.Visible = false;
        }

        private void rdbIndividual_CheckedChanged(object sender, EventArgs e)
        {
            pnlCopias.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void dgvOrdenCarga_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirFormAgregar("2");
        }

        private void dgvOrdenCarga_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscaChofer_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
