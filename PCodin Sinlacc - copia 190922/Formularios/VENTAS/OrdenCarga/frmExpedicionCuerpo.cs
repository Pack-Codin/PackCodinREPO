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
using System.Data.Entity.ModelConfiguration.Configuration;
using PCodin_Sinlacc.Clases.UsuarioTema;

namespace PCodin_Sinlacc.Formularios.VENTAS.OrdenCarga
{
    public partial class frmExpedicionCuerpo : Form
    {
        public frmExpedicionCuerpo()
        {
            InitializeComponent();
        }
        public frmExpedicion frmExpedicion;
        public string Accion;
        public DataGridView DGV;
        public DataGridView DGVPEDIDOS;
        public int RowIndice;
        public Label Resultados;
        string CodigoPalletProducto;
        long PedidoCuerpoID;
        decimal CantidadLote = 0; //CANTIDAD DEL SERIELOTE
        private void frmExpedicionCuerpo_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            try
            {
                clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
                clsCargarCombos.MostrarComboClientes(cmbCliente, txtBuscarCliente, false, "CLI", 0);
                clsCargarCombos.MostrarComboInsProConMedida(cmbProducto, cmbMedida, txtBuscarProducto, "PRO", false);
                cmbCliente.SelectedIndex = -1;
                cmbProducto.SelectedIndex = -1;

                if (Accion == "2")
                {
                    cmbCliente.SelectedValue = Convert.ToInt32(DGV.CurrentRow.Cells["colClienteID"].Value);
                    cmbCliente.Text = DGV.CurrentRow.Cells["colCliente"].Value.ToString();
                    txtBuscarProducto.Text = DGV.CurrentRow.Cells["colCodigoProducto"].Value.ToString();
                    clsCargarCombos.MostrarComboInsProConMedida(cmbProducto, cmbMedida, txtBuscarProducto, "PRO", true);
                    txtBuscarProducto.Text = "";
                    txtCantidad.Text = DGV.CurrentRow.Cells["colCantidad"].Value.ToString();

                    if (DGV.CurrentRow.Cells["colLote"].Value.ToString() != "")
                    {
                        string Lote = DGV.CurrentRow.Cells["colLote"].Value.ToString();
                        Lote = Lote.Insert(2, "/");
                        Lote = Lote.Insert(5, "/");

                        dtpLote.Value = Convert.ToDateTime(Lote);
                        txtLote.Text = DGV.CurrentRow.Cells["colLote"].Value.ToString();
                    }
                    else
                    {
                        dtpLote.Text = "01/01/1990";
                        txtLote.Text = "";
                    }

                    if (DGV.Rows[RowIndice].Cells["colTipoPallet"].Value.ToString() == "Suelto")
                        rdbSuelto.Checked = true;
                    if (DGV.Rows[RowIndice].Cells["colTipoPallet"].Value.ToString() == "Pallet")
                        rdbPallet.Checked = true;
                    if (DGV.Rows[RowIndice].Cells["colTipoPallet"].Value.ToString() == "Mixto")
                        rdbPalletMixto.Checked = true;

                    txtPallets.Text = DGV.Rows[RowIndice].Cells["colPallets"].Value.ToString();
                    txtHumedad.Text = DGV.CurrentRow.Cells["colHumedad"].Value.ToString();
                    txtAcidez.Text = DGV.CurrentRow.Cells["colAcidez"].Value.ToString();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }

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

        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarProducto.Visible = false;
                clsCargarCombos.MostrarComboInsProSinCheck(cmbProducto, txtBuscarProducto, "PRO", true, "NO");
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
                clsCargarCombos.MostrarComboInsProSinCheck(cmbProducto, txtBuscarProducto, "PRO", false, "NO");
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedIndex != -1 && cmbProducto.SelectedIndex != -1 && txtCantidad.Text != "0,00" && txtLote.Text != "" && txtHumedad.Text != "0,00" && txtAcidez.Text != "0,00" && (rdbPallet.Checked || rdbPalletMixto.Checked || rdbSuelto.Checked))
            {
                bool CerrarPantalla = true;

                if (Accion == "1")
                {
                    decimal CantidadPendientePedido = 0;
                    decimal CantidadOrdenCarga = 0;
                    

                    //CUANDO SE HACE POR PEDIDO SINO 0 ES SIN PEDIDO
                    if (txtNumPedido.Text != "")
                    {
                        CantidadPendientePedido = Convert.ToDecimal(dgvPedidos.CurrentRow.Cells["colCantidadPend"].Value);
                        CantidadOrdenCarga = Convert.ToDecimal(txtCantidad.Text);
                    }
                    
                   

                    if (CantidadOrdenCarga <= CantidadPendientePedido
                         && Convert.ToDecimal(txtCantidad.Text) <= CantidadLote)
                       
                    {
                        string Pallets = "";
                        string TipoPallet = "";
                        bool Suelto;
                        if (rdbSuelto.Checked)
                        {
                            Pallets = "0,00";
                            TipoPallet = "Suelto";
                            // Suelto = true;
                        }
                        if (rdbPallet.Checked)
                        {
                            Pallets = txtPallets.Text;
                            TipoPallet = "Pallet";
                            // Suelto = false;
                        }
                        if (rdbPalletMixto.Checked)
                        {
                            Pallets = txtPallets.Text;
                            TipoPallet = "Mixto";
                        }
                        CalcularCantidadPallet();
                        DGV.Rows.Add(cmbProducto.SelectedValue,
                                     cmbProducto.Text,
                                     txtCantidad.Text,
                                     Pallets,
                                     CodigoPalletProducto,
                                     txtLote.Text,
                                     txtNumPedido.Text,
                                     txtHumedad.Text,
                                     txtAcidez.Text,
                                     cmbCliente.SelectedValue,
                                     cmbCliente.Text,
                                     TipoPallet,
                                     0,
                                     PedidoCuerpoID);
                    }
                    else
                    {
                        if (CantidadOrdenCarga > CantidadPendientePedido)
                            MessageBox.Show("La cantidad de la orden de carga no puede ser mayor a la del pedido", "Atención");
                        if (Convert.ToDecimal(txtCantidad.Text) > CantidadLote)
                            MessageBox.Show("La cantidad de la orden de carga no puede ser mayor a la del lote producido", "Atención");

                        CerrarPantalla = false;
                    }                
                }
                if (Accion == "2")
                {
                    DGV.CurrentRow.Cells["colCodigoProducto"].Value = cmbProducto.SelectedValue;
                    DGV.CurrentRow.Cells["colProducto"].Value = cmbProducto.Text;
                    DGV.CurrentRow.Cells["colCantidad"].Value = txtCantidad.Text;
                    DGV.CurrentRow.Cells["colLote"].Value = txtLote.Text;
                    DGV.CurrentRow.Cells["colClienteID"].Value = cmbCliente.SelectedValue;
                    DGV.CurrentRow.Cells["colCliente"].Value = cmbCliente.Text;
                    DGV.CurrentRow.Cells["colPallets"].Value = txtPallets.Text;

                    string Tipo = DGV.CurrentRow.Cells["colTipoPallet"].Value.ToString();

                    if (Tipo == "Pallet")
                        rdbPallet.Checked = true;
                    if (Tipo == "Mixto")
                        rdbPalletMixto.Checked = true;
                    if (Tipo == "Suelto")
                        rdbSuelto.Checked = true;

                    if (rdbSuelto.Checked == true)
                    {
                        DGV.CurrentRow.Cells["colTipoPallet"].Value = "Suelto";
                        DGV.CurrentRow.Cells["colPalletProducto"].Value = "";
                    }
                    if (rdbPallet.Checked)
                    {
                        DGV.CurrentRow.Cells["colTipoPallet"].Value = "Pallet";
                        DGV.CurrentRow.Cells["colPalletProducto"].Value = CodigoPalletProducto;
                    }
                    if (rdbPalletMixto.Checked)
                    {
                        DGV.CurrentRow.Cells["colTipoPallet"].Value = "Mixto";
                        DGV.CurrentRow.Cells["colPalletProducto"].Value = CodigoPalletProducto;
                    }

                    //CALIDAD
                    DGV.CurrentRow.Cells["colHumedad"].Value = txtHumedad.Text;
                    DGV.CurrentRow.Cells["colAcidez"].Value = txtAcidez.Text;
                }
                CalcularCantidadPallet();

                if (CerrarPantalla == true)
                    this.Close();
               
                Resultados.Text = DGV.RowCount.ToString();
            }
            else
            {
                if (cmbCliente.SelectedIndex == -1)
                    MessageBox.Show("No seleccionó cliente", "Atención");
                if (cmbProducto.SelectedIndex == -1)
                    MessageBox.Show("No seleccionó producto", "Atención");
                if (txtCantidad.Text == "0,00")
                    MessageBox.Show("No ingresó cantidad", "Atención");
                if (txtLote.Text == "")
                    MessageBox.Show("No ingresó lote", "Atención");
                if (txtHumedad.Text == "0,00")
                    MessageBox.Show("No ingresó Humedad", "Atención");
                if (txtAcidez.Text == "0,00")
                    MessageBox.Show("No ingresó Acidez", "Atención");
                if (!rdbPallet.Checked && !rdbPalletMixto.Checked && !rdbSuelto.Checked)
                    MessageBox.Show("No selecciono tipo de pallet", "Atención");
            }
        }
        private void CalcularCantidadPallet()
        {
            using (var hb = new DBdatos())
            {
                try
                {
                    if (cmbProducto.SelectedIndex != -1)
                    {
                        var Consulta = (from P in hb.Productos_Insumos
                                        where P.Pallet == "SI"
                                            && P.ProductoPallet == cmbProducto.SelectedValue.ToString()
                                        select P).FirstOrDefault();

                        if (Consulta != null)
                        {
                            decimal Cantidad = Convert.ToDecimal(txtCantidad.Text);
                            decimal CantidadEquivalente = (decimal)Consulta.ProductoPalletCantidad;

                            decimal CantidadPallets = Cantidad / CantidadEquivalente;
                            CodigoPalletProducto = Consulta.Codigo;
                            txtPallets.Text = CantidadPallets.ToString("N2");
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }

            }
        }
        private void MostrarPedidosPendientes()
        {
            using (var hb = new DBdatos())
            {
                try
                {
                    btnVerificarPedidos.BackColor = Color.Orange;
                    btnVerificarStock.BackColor = Color.Transparent;

                    dgvPedidos.Rows.Clear();

                    decimal Cantidad = 0;                  
                    dgvPedidos.Visible = true;
                    dgvStock.Visible = false;
                                                              
                    var Consulta = (from VP in hb.VistaPedidos
                                    where VP.EstadoPedido == "AU"
                                    select new
                                    {
                                        PedidoCuerpoID = VP.PedidoCuerpoID,
                                        NumeroPedido = VP.NumeroPedido,
                                        VP.ClienteID,
                                        Cliente = VP.Cliente,
                                        ProductoID = VP.ProductoID,
                                        Producto = VP.Producto,
                                        CantidadOri = VP.CantidadOriginal,
                                        CantidadPendiente = VP.CantidadPendiente,
                                        VP.Zona_ID,
                                        VP.Zona,
                                        VP.VendedorID,
                                        VP.PedidoID,
                                        VP.FechaPedido
                                        
                                        
                                    }).Take(1000);

                    if (chkFiltraCliente.Checked)
                        Consulta = (from C in Consulta
                                    where C.ClienteID == (int)cmbFiltraCliente.SelectedValue
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

                    //var Resultados = Consulta.ToList();

                    foreach(var item in Consulta.ToList())
                    {
                        decimal CantidadPendiente = Convert.ToDecimal(item.CantidadPendiente);
                        decimal CantidadOrdenCarga = 0;

                        if (DGV.RowCount > 0)
                        {
                            for (int i = 0; i < DGV.RowCount; i++)
                            {
                                if (DGV.Rows[i].Cells["colPedidoCuerpoID"].Value.ToString() == item.PedidoCuerpoID.ToString())
                                {                                    
                                    CantidadOrdenCarga = CantidadOrdenCarga +Convert.ToDecimal(DGV.Rows[i].Cells["colCantidad"].Value);                                   
                                }                                  
                            }

                        }
                        if(CantidadPendiente >= CantidadOrdenCarga)
                        {
                            string Lote = "";
                            decimal Humedad = 0;
                            decimal Acidez = 0;

                            if((CantidadPendiente - CantidadOrdenCarga) > 0)
                            {
                                var ConsultaParteID = (from C in hb.OrdenProduccionParteCuerpo
                                                       where C.Orden_Produccion_Parte.OrdenProduccion_Cuerpo.Pedido_ID == item.PedidoID
                                                        && C.Orden_Produccion_Parte.OrdenProduccion_Cuerpo.Producto_ID == item.ProductoID
                                                       select C).FirstOrDefault();

                                if(ConsultaParteID != null)
                                {
                                    var ConsultaDatosExistencia = (from EPT in hb.Existencia_ProductoTerminado
                                                                   where EPT.OrdenProduccionParteCuerpo_ID == ConsultaParteID.ID
                                                                   select EPT).FirstOrDefault();

                                    Lote = ConsultaDatosExistencia.Lote;
                                    Humedad = (decimal)ConsultaDatosExistencia.Humedad;
                                    Acidez = (decimal)ConsultaDatosExistencia.Acidez;
                                }

                                dgvPedidos.Rows.Add(
                                                item.PedidoCuerpoID,
                                                item.NumeroPedido,
                                                item.PedidoID,
                                                item.ClienteID,
                                                item.Cliente,
                                                item.ProductoID,
                                                item.Producto,
                                                item.CantidadOri,
                                                item.CantidadPendiente - CantidadOrdenCarga,                                        
                                                Lote,
                                                Humedad,
                                                Acidez,
                                                item.Zona);
                            }
                           
                        }
                        
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error");
                }
              
            }
        }
        private void MostrarExistenciaProductos()
        {
            using (var hb = new DBdatos())
            {
                string Lote;
                string CodigoProducto = cmbProducto.SelectedValue.ToString();
               
                decimal CantidadEnORden = 0;
          
                DateTime Fecha = Convert.ToDateTime("01/01/2001");
               
                var Consulta = (from VS in hb.ftStockProductoFinaLPorLote_01(Fecha, 0, "")
                                join PRO in hb.Productos_Insumos on VS.ProductoID equals PRO.Codigo
                                where PRO.Codigo == CodigoProducto
                                    && VS.Lote != ""
                                orderby VS.ProductoID
                                select new
                                {
                                    VS.Lote,
                                    VS.ProductoID,
                                    VS.Producto,
                                    Existencia = VS.Existencia,

                                }).Take(1000);            

                if(chkFiltroPedido.Checked)
                {
                    long PedidoID = Convert.ToInt64(dgvPedidos.CurrentRow.Cells["colPedidoID"].Value);
                    List<long> ListasIDOPC = new List<long>();
                    List<string> ListaLotesPedido = new List<string>();

                    var ConsultaOPC = (from PED in hb.OrdenProduccionParteCuerpo
                                           where PED.Orden_Produccion_Parte.OrdenProduccion_Cuerpo.Pedido_ID == PedidoID
                                           select PED).ToList();

                    foreach(var item in ConsultaOPC)
                    {
                        ListasIDOPC.Add(item.ID);
                    }

                    var ConsultaEPT = (from EPT in hb.Existencia_ProductoTerminado
                                       where ListasIDOPC.Contains((long)EPT.OrdenProduccionParteCuerpo_ID)
                                       select EPT).ToList();

                    foreach (var item2 in ConsultaEPT)
                    {
                        ListaLotesPedido.Add(item2.Lote);
                    }

                    Consulta = (from C in Consulta
                                where ListaLotesPedido.Contains(C.Lote)
                                select C);
                }
                var Resultados = Consulta.ToList();

                foreach(var item in Consulta)
                {
                    if (DGV.RowCount > 0)
                    {
                        CantidadEnORden = 0;

                        for (int i = 0; i < DGV.RowCount; i++)
                        {
                            if (DGV.Rows[i].Cells["colCodigoProducto"].Value.ToString() == item.ProductoID && DGV.Rows[i].Cells["colLote"].Value.ToString() == item.Lote)
                            {                  
                                CantidadEnORden = CantidadEnORden + Convert.ToDecimal(DGV.Rows[i].Cells["colCantidad"].Value);

                               
                            }
                        }
                    }
                    if(item.Existencia - CantidadEnORden > 0)
                    {
                        decimal Humedad = 0;
                        decimal Acidez = 0;

                        var ConsultaCalidad = (from CA in hb.LOTEPRODUCCION
                                               where CA.Lote == item.Lote
                                                && CA.Producto_ID == item.ProductoID
                                               select CA).FirstOrDefault();

                        if (ConsultaCalidad != null)
                        {
                            Humedad = Convert.ToDecimal(ConsultaCalidad.Humedad);
                            Acidez = Convert.ToDecimal(ConsultaCalidad.Acidez);
                        }

                        dgvStock.Rows.Add(
                                           item.Lote,
                                           item.ProductoID,
                                           item.Producto,
                                           item.Existencia - CantidadEnORden,
                                           Humedad,
                                           Acidez);
                    }
                }

                //colLote.DataPropertyName = "Lote";
                //colInsProdID.DataPropertyName = "ProductoID";
                //colInsPro.DataPropertyName = "Producto";
                //colExistencia.DataPropertyName = "Existencia";
               
                //dgvStock.AutoGenerateColumns = false;
                //dgvStock.DataSource = Resultados;
            }
        }
        private void VerificarStock(string MostrarDGVStock)
        {
            if(MostrarDGVStock == "SI")
            {
                btnVerificarPedidos.BackColor = Color.Transparent;
                btnVerificarStock.BackColor = Color.Orange;
            }
            else
            {
                btnVerificarPedidos.BackColor = Color.Orange;
                btnVerificarStock.BackColor = Color.Transparent;
            }

            using (var hb = new DBdatos())
            {
                try
                {
                    dgvStock.Rows.Clear();

                    if(MostrarDGVStock == "SI")
                    {
                        dgvStock.Visible = true;
                        dgvPedidos.Visible = false;
                    }
                    

                    if(cmbProducto.SelectedIndex != -1)
                      // && txtLote.Text != "")
                    {
                        MostrarExistenciaProductos();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Atención");
                }
            }
        }
        private void SeleccionarPedido()
        {
            if(dgvPedidos.RowCount > 0)
            {
                PedidoCuerpoID = Convert.ToInt64(dgvPedidos.CurrentRow.Cells["colID"].Value);
                string NumeroPedido = dgvPedidos.CurrentRow.Cells["colNumeroPedido"].Value.ToString();
                int Cliente_ID = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["colClienteID"].Value);
                string Cliente = dgvPedidos.CurrentRow.Cells["colCliente"].Value.ToString();
                string Producto_ID = dgvPedidos.CurrentRow.Cells["colProductoID"].Value.ToString();
                string Producto = dgvPedidos.CurrentRow.Cells["colProducto"].Value.ToString();
                decimal Cantidad = Convert.ToDecimal(dgvPedidos.CurrentRow.Cells["colCantidadPend"].Value);
                string Lote = dgvPedidos.CurrentRow.Cells["colLotePedido"].Value.ToString();
                decimal Humedad = Convert.ToDecimal(dgvPedidos.CurrentRow.Cells["colHumedadPedido"].Value);
                decimal Acidez = Convert.ToDecimal(dgvPedidos.CurrentRow.Cells["colAcidezPedido"].Value);

                cmbCliente.SelectedValue = Cliente_ID;
                cmbCliente.Text = Cliente;
                cmbProducto.SelectedValue = Producto_ID;
                cmbProducto.Text = Producto;
                txtCantidad.Text = Cantidad.ToString("N2");
                txtNumPedido.Text = NumeroPedido.ToString();

                txtLote.Text = Lote;
                txtHumedad.Text =Humedad.ToString("N2");
                txtAcidez.Text = Acidez.ToString("N2");

                cmbCliente.Enabled  = false;              
                cmbProducto.Enabled = false;
                txtCantidad.Text = Cantidad.ToString("N2");
                txtNumPedido.Text = NumeroPedido.ToString();

                rdbPallet.Checked = false;
                rdbPalletMixto.Checked = false;
                rdbSuelto.Checked = false;

                txtPallets.Text = "0,00";
            }
        }
        private void SeleccionarLote(string TomaDatoDe)
        {
            if(dgvStock.RowCount > 0)
            {
                if(TomaDatoDe == "Pedido")
                {
                    for (int i = 0; i < dgvStock.RowCount; i++)
                    {
                        if (dgvStock.Rows[i].Cells["colInsProdID"].Value.ToString() == cmbProducto.SelectedValue.ToString() && dgvStock.Rows[i].Cells["colLote"].Value.ToString() == txtLote.Text)
                        {
                            CantidadLote = Convert.ToDecimal(dgvStock.Rows[i].Cells["colExistencia"].Value);
                        }
                    }                                        
                }
                if (TomaDatoDe == "Stock")
                {
                    CantidadLote = Convert.ToDecimal(dgvStock.CurrentRow.Cells["colExistencia"].Value);
                    txtLote.Text = dgvStock.CurrentRow.Cells["colLote"].Value.ToString();
                    txtHumedad.Text = dgvStock.CurrentRow.Cells["colHumedad"].Value.ToString();
                    txtAcidez.Text = dgvStock.CurrentRow.Cells["colAcidez"].Value.ToString();
                }
                
            }
        }
        private void FormatearCeldas(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPedidos.RowCount > 0)
            {
                if (this.dgvPedidos.Columns[e.ColumnIndex].Name == "colCantidad")
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.Font = new System.Drawing.Font("Roboto Condensed", 9, FontStyle.Bold);
                }
                if (this.dgvPedidos.Columns[e.ColumnIndex].Name == "colCantidadPend")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.SelectionForeColor = Color.Red;
                    e.CellStyle.Font = new System.Drawing.Font("Roboto Condensed", 9, FontStyle.Bold);
                }
            }
        }
        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCantidad);            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCantidad_Click(object sender, EventArgs e)
        {
            txtCantidad.SelectAll();
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void btnBuscarIProducto_Click(object sender, EventArgs e)
        {
            txtBuscarProducto.Visible = true;
            txtBuscarProducto.Select();
        }

        private void chkSuelto_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSuelto.Checked)
                pnlPallets.Visible = false;
            else
                pnlPallets.Visible = true;
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCantidad.Text = "0,00";
            txtPallets.Text = "0,00";
        }
        private void FormatearLote()
        {
            try
            {
                txtLote.Text = dtpLote.Value.ToShortDateString().Replace("/", "");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }
        private void dtpLote_ValueChanged(object sender, EventArgs e)
        {
            FormatearLote();
        }

        private void txtHumedad_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtHumedad);
        }

        private void txtAcidez_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtAcidez);
        }

        private void rdpSuelto_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSuelto.Checked)
                pnlPallets.Visible = false;
            else
                pnlPallets.Visible = true;
        }

        private void btnVerificarStock_Click(object sender, EventArgs e)
        {
            VerificarStock("SI");
        }

        private void btnVerificarPedidos_Click(object sender, EventArgs e)
        {
            MostrarPedidosPendientes();
        }

        private void dgvPedidos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void rdbPallet_CheckedChanged(object sender, EventArgs e)
        {
            CalcularCantidadPallet();
        }

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarPedido();
            VerificarStock("NO");
            SeleccionarLote("Pedido");
        }

        private void dgvPedidos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatearCeldas(e);
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarLote("Stock");
        }

        private void txtPallets_Click(object sender, EventArgs e)
        {
            txtPallets.SelectAll();
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtPallets_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtPallets);
        }

        private void rdbPallet_Click(object sender, EventArgs e)
        {
            CalcularCantidadPallet();
        }

        private void rdbPalletMixto_CheckedChanged(object sender, EventArgs e)
        {
            txtPallets.Text = "0,00";
        }

        private void pnlFiltroGeneral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkFiltraNroPedido_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraNroPedido, chkFiltraNroPedido);
        }

        private void chkFiltraCliente_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboCliente(chkFiltraCliente, cmbCliente, txtFiltraCliente, btnBuscarCliente);
        }

        private void txtFiltraCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtFiltraCliente.Visible = false;
                clsCargarCombos.MostrarComboClientes(cmbFiltraCliente, txtFiltraCliente, true, "CLI", 0);
                txtBuscarCliente.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtFiltraCliente.Visible = false;
                txtFiltraCliente.Focus();
                e.Handled = true;
            }
        }

        private void cmbFiltraCliente_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            txtFiltraCliente.Visible = true;
            txtFiltraCliente.Select();
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

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarPedidosPendientes();
        }

        private void dgvPedidos_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            VerificarStock("SI");
        }

        private void txtBuscarCliente_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscarProducto_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtNumPedido_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtHumedad_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtAcidez_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtFiltraCliente_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscarCiudad_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtFiltraNroPedido_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtFiltraVendedor_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
