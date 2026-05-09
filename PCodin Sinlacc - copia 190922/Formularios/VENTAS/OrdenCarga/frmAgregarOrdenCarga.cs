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
using PCodin_Sinlacc.Clases.Notificaciones_Ejecutables.Produccion;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmAgregarOrdenCarga : Form
    {
        public string CrearEditar;
        public long IDRecibido;
        private string AfectarAfectados;
        private int Indice = 0;
        private int CatidadFilasDGV;
        public long OrdenID = -1; // variable para autocalcular el número de orden
        private frmPantallaEspera PantallaEspera = new frmPantallaEspera();
        private frmReporte VisorReporte = new frmReporte();

        public frmAgregarOrdenCarga()
        {
            InitializeComponent();
        }
        private void AfectarPedido()
        {
            //var f = new frmAfectarPedido();
            ////  f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmAgregarOrdenCarga_FormClosed);
            ////f.PulsoAgregarEditar = AgregarEditar;
            //f.IDRecibido = (int)cmbCliente.SelectedValue;
            //AddOwnedForm(f);
            //f.TopLevel = false;
            //f.Dock = DockStyle.Fill;
            //this.Controls.Add(f);
            //this.Tag = f;
            //f.BringToFront();
            //f.Show();
        }
        private void btnAfectar_Click(object sender, EventArgs e)
        {
            Indice = 0;
            AfectarAfectados = "1";
            OnOffbtnEditarCantidad();
            //DeleteTablaTemporarPedidoCuerpo();   // Elimina los valores en la tabla temporal
            //InsertarTablaTemporalPedidoCuerpo(); // Inserta los valores en la tabla temporal
            CambiarColorbtnSeleccionado("1", btnAfectar, btnAfectados, btnAfec);
            MostrarPedidoCuerpo("1", 999999999);
            OnOffBtnConfirnarordenPedido();
            dgvPedidoProductos.Focus();

            if (CrearEditar == "2")
            {
                btnEditar.Enabled = false;
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            LimpiarTablasTemporales();
            //DeleteTablaTemporarPedidoCuerpo();
            //DeleteTablaTemporarOrdenCargacuerpo();
            //DeleteTablaTemporalTTAFEC();
            //DeleteTablaTemporalTTRPT();
            this.Close();
        }

        private void frmAgregarOrdenCarga_Load(object sender, EventArgs e)
        {
            InicializarForm();


            //LIMPIEAZA DE TABLAS TEMPORALES

            LimpiarTablasTemporales();
            //DeleteTablaTemporarPedidoCuerpo();
            //DeleteTablaTemporalTTAFEC();
            //DeleteTablaTemporalTTRPT();
            //DeleteTablaTemporarOrdenCargacuerpo();
            //DeleteTablaTemporarPedidoCuerpo();

            InsertarDatosEnTablaTemporalTTRPT();


           
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
        private void InicializarForm()
        {
            dtpFechaHasta.Value = DateTime.Now.Date;
            dtpFechaDesde.Value = DateTime.Now.Date.AddDays(-30);
            clsCargarCombos.MostrarComboClientes(cmbCliente, txtBuscarCliente, false, "CLI",0);
            clsCargarCombos.MostrarComboCiudades(cmbCiudad, txtBuscarCiudad, false);

            if (CrearEditar == "1")
            {
                CalculaIDOrdenCarga();
                CalcularNumeroOrdenCarga();
                btnCargar.Text = "Confirmar orden";
                cmbCliente.SelectedIndex = -1;
                cmbCiudad.SelectedIndex = -1;
            }
            if (CrearEditar == "2") // SOLO PARA VER O ANULAR
            {
                AfectarAfectados = "2";

                using (var hb = new DBdatos())
                {
                    btnCargar.Enabled = false;
                    btnAnular.Enabled = true;
                    btnAfectar.Enabled = false;
                    cmsAfectarProducto.Enabled = false;
                    btnAfectar.BackColor = Color.White;
                    btnAfectados.BackColor = Color.Orange;


                    var ConsultaOrdenCarga = (from P in hb.Orden_Carga
                                              where P.ID == IDRecibido
                                              select P);

                    var ResultadoPedido = ConsultaOrdenCarga.FirstOrDefault();

                    if (ResultadoPedido != null)
                    {
                        txtNumeroOrden.Text = ResultadoPedido.Numero_Orden;
                        dtpFecha.Value = ResultadoPedido.Fecha;
                        cmbCliente.SelectedValue = ResultadoPedido.Cliente_ID;
                        cmbCliente.Text = ResultadoPedido.Clientes.Descripcion;
                        cmbCiudad.SelectedValue = ResultadoPedido.Ciudad_ID;
                        cmbCiudad.Text = ResultadoPedido.Ciudades.Descripcion;
                        txtEstado.Text = ResultadoPedido.Estado_Ord_Carga.Descripcion;

                        if (ResultadoPedido.Estado_ID == "AN")
                        {
                            txtEstado.ForeColor = Color.Red;
                            btnAnular.Enabled = false;
                        }
                        if (ResultadoPedido.Estado_ID == "FI")
                        {
                            txtEstado.ForeColor = Color.Green;
                            btnAnular.Enabled = true;
                        }

                        MostrarTTOrdenCargaCuerpo();
                    }
                }
            }
            if (CrearEditar == "3") // COPIAR
            {
                using (var hb = new DBdatos())
                {
                    CalculaIDOrdenCarga();
                    CalcularNumeroOrdenCarga();
                    btnCargar.Text = "Confirmar orden";
                    btnAnular.Enabled = false;
                    btnAfectar.BackColor = Color.White;
                    btnAfectados.BackColor = Color.Orange;
                    btnAfec.Visible = false;
                    txtEstado.Text = "";
                    MostrarTTOrdenCargaCuerpo();
                    cmbCliente.Enabled = false;
                    cmbCiudad.Enabled = false;

                    var ConsultaOrdenCarga = (from P in hb.Orden_Carga
                                              where P.ID == IDRecibido
                                              select P);



                    var ResultadoPedido = ConsultaOrdenCarga.FirstOrDefault();

                    //var ConsultaOCC = (from OCC in hb.TT_Orden_Carga_Cuerpo
                    //                   where OCC.Pedido_ID == ResultadoPedido.Producto_Afec_OrdenCarga.
                    //                        && OCC.Producto_ID == 
                    //                   select OCC).FirstOrDefault();

                    if (ResultadoPedido != null)
                    {
                        dtpFecha.Value = ResultadoPedido.Fecha;
                        cmbCliente.SelectedValue = ResultadoPedido.Cliente_ID;
                        cmbCliente.Text = ResultadoPedido.Clientes.Descripcion;
                        cmbCiudad.SelectedValue = ResultadoPedido.Ciudad_ID;
                        cmbCiudad.Text = ResultadoPedido.Ciudades.Descripcion;
                    }

                    //long Pedido_ID = (long)dgvPedidoProductos.CurrentRow.Cells[0].Value;
                    //string Produto_ID = dgvPedidoProductos.CurrentRow.Cells[1].Value.ToString();

                    //var ConsultaPedido = (from PC in hb.TT_Pedido_Cuerpo
                    //                      where PC.Pedido_ID == Pedido_ID
                    //                          && PC.Producto_ID == Produto_ID
                    //                      select PC).FirstOrDefault();

                    //if (ConsultaOCC != null)
                    //{

                    //ConsultaOCC.Orden_IDref = OrdenID;

                    //hb.SaveChanges();
                    //}
                }
            }
        }
        private void OnOffbtnCargar()
        {
            if (!chkFiltraProducto.Checked &&
               !chkFiltraNroPedido.Checked)

            {
                btnCargar.Visible = true;
                picFiltroActivo.Visible = false;
                picFiltroInactivo.Visible = true;
            }
            else
            {
                btnCargar.Visible = false;
                picFiltroActivo.Visible = true;
                picFiltroInactivo.Visible = false;
            }
        }
        private void MostrarDatosFiltrados()
        {
            int CantidadDeRegistros = 0;

            for (var i = 1; i <= dgvPedidoProductos.RowCount; i++)
            {
                if (chkFiltraProducto.Checked)
                {
                    string ProductoID = dgvPedidoProductos.Rows[i - 1].Cells[columnName: "colProductoID"].Value.ToString();
                    string NumeroPedido = dgvPedidoProductos.Rows[i - 1].Cells[columnName: "colNumeroPedido"].Value.ToString();

                    if (ProductoID != cmbProducto.SelectedValue.ToString() && NumeroPedido != txtFiltraNroPedido.Text)
                    {
                        if (chkFiltraProducto.Checked)
                        {
                            if (ProductoID != cmbProducto.SelectedValue.ToString())
                                dgvPedidoProductos.Rows[i - 1].Visible = false;
                        }
                        else
                        {
                            dgvPedidoProductos.Rows[i - 1].Visible = false;
                        }
                    }
                    else
                    {
                        dgvPedidoProductos.Rows[i - 1].Visible = true;
                        CantidadDeRegistros = CantidadDeRegistros + 1;
                    }
                }
                else if (chkFiltraNroPedido.Checked)
                {
                    string ProductoID = dgvPedidoProductos.Rows[i - 1].Cells[columnName: "colProductoID"].Value.ToString();
                    string NumeroPedido = dgvPedidoProductos.Rows[i - 1].Cells[columnName: "colNumeroPedido"].Value.ToString();

                    if (NumeroPedido != txtFiltraNroPedido.Text)
                    {
                        if (chkFiltraProducto.Checked)
                        {
                            if (ProductoID != cmbProducto.SelectedValue.ToString() && NumeroPedido != txtFiltraNroPedido.Text)
                                dgvPedidoProductos.Rows[i - 1].Visible = false;
                        }
                        else
                        {
                            dgvPedidoProductos.Rows[i - 1].Visible = false;
                        }
                    }
                    else
                    {
                        dgvPedidoProductos.Rows[i - 1].Visible = true;
                        CantidadDeRegistros = CantidadDeRegistros + 1;
                    }
                }
                else
                {
                    dgvPedidoProductos.Rows[i - 1].Visible = true;
                    CantidadDeRegistros = CantidadDeRegistros + 1;
                }
            }
            lblResultados.Text = CantidadDeRegistros.ToString();
        }
        private void MostrarPedidoCuerpo(string AfectarAfectado, decimal Valor)
        {
            if (cmbCliente.SelectedIndex != -1)
            {
                using (var hb = new DBdatos())
                {

                    var Consulta = (from OP in hb.Registro_Pedidos
                                    join PC in hb.TT_Pedido_Cuerpo on OP.ID equals PC.Pedido_ID
                                    join PRO in hb.Productos_Insumos on PC.Producto_ID equals PRO.Codigo
                                    where OP.Cliente_ID == (int)cmbCliente.SelectedValue
                                          // && PC.Estado_ID == "PEN"
                                          && PC.Cantidad_Afectada != Valor
                                          && OP.Estado_ID == "AU"
                                          && PC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                          && PC.Sesion_ID == clsVariablesGenerales.SesionID
                                    orderby OP.ID, PC.Productos_Insumos.Descripcion
                                    select new
                                    {
                                        OP.ID,
                                        OP.Numero_Pedido,
                                        OP.Fecha,
                                        OP.Cliente_ID,
                                        Cliente = OP.Clientes.Descripcion,
                                        OP.Ciudad_ID,
                                        Ciudad = OP.Ciudades.Descripcion,
                                        OP.Estado_ID,
                                        PedCuerpID = PC.ID,
                                        PC.Cantidad,
                                        PC.Producto_ID,
                                        PC.Cantidad_Afectada,
                                        EstadoID_OC = PC.Estado_ID,
                                        PC.Medida_ID,
                                        EstadoPC = PC.Estado_Pedido_Cuerpo.Descripcion, // Completo - Pendiente
                                        OP.Observaciones,
                                        PRO.Codigo,
                                        PRO.Descripcion,
                                        Medida = PRO.Medidas_Producto.Descripcion,
                                        PC.Afectada,
                                        PC.Ped_Cuerp_ID

                                    }).Take(1000);

                    if (cmbOrdenar.SelectedIndex == 1)
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
                    if (cmbOrdenar.SelectedIndex == 2)
                    {
                        if (btnBuscarAsc.Visible == true)
                            Consulta = (from C in Consulta
                                        orderby C.Descripcion ascending
                                        select C);
                        else
                            Consulta = (from C in Consulta
                                        orderby C.Descripcion descending
                                        select C);
                    }
                    if (cmbOrdenar.SelectedIndex == 3)
                    {
                        if (btnBuscarAsc.Visible == true)
                            Consulta = (from C in Consulta
                                        orderby C.Medida ascending
                                        select C);
                        else
                            Consulta = (from C in Consulta
                                        orderby C.Medida descending
                                        select C);

                    }
                    if (cmbOrdenar.SelectedIndex == 4)
                    {
                        if (btnBuscarAsc.Visible == true)
                            Consulta = (from C in Consulta
                                        orderby C.Cantidad ascending
                                        select C);
                        else
                            Consulta = (from C in Consulta
                                        orderby C.Cantidad descending
                                        select C);
                    }
                    if (cmbOrdenar.SelectedIndex == 5)
                    {
                        if (btnBuscarAsc.Visible == true)
                            Consulta = (from C in Consulta
                                        orderby C.Cantidad_Afectada ascending
                                        select C);
                        else
                            Consulta = (from C in Consulta
                                        orderby C.Cantidad_Afectada descending
                                        select C);
                    }
                    if (cmbOrdenar.SelectedIndex == 6)
                    {
                        if (btnBuscarAsc.Visible == true)
                            Consulta = (from C in Consulta
                                        orderby C.EstadoPC ascending
                                        select C);
                        else
                            Consulta = (from C in Consulta
                                        orderby C.EstadoPC descending
                                        select C);
                    }
                    if (cmbOrdenar.SelectedIndex == 7)
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

                    if (AfectarAfectado == "1") // Pestaña Afectar // SI SE ROMPIO ES ACA // 5/11/21
                    {
                        Consulta = (from C in Consulta
                                    where C.EstadoID_OC == "PEN"
                                    select C);

                        colCantidad.Visible = true;
                        colEstado.Visible = true;
                    }
                    if (AfectarAfectado == "2") // Pestaña Afectados
                    {
                        Consulta = (from C in Consulta
                                    where C.Afectada == true
                                    select C);

                        colCantidad.Visible = false;
                        colEstado.Visible = false;
                    }

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
                        string NroPedido = txtFiltraNroPedido.Text;

                        Consulta = (from C in Consulta
                                    where C.Numero_Pedido == NroPedido
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

                    //if (chkFechaDesde.Checked && chkFechaHasta.Checked == false)
                    //{
                    //    Consulta = (from C in Consulta
                    //                where C.Fecha >= dtpFechaDesde.Value.Date
                    //                select C);
                    //}
                    //else if (chkFechaDesde.Checked == false && chkFechaHasta.Checked)
                    //{
                    //    Consulta = (from C in Consulta
                    //                where C.Fecha <= dtpFechaHasta.Value.Date
                    //                select C);
                    //}
                    //else if (chkFechaDesde.Checked && chkFechaHasta.Checked)
                    //{
                    //    Consulta = (from C in Consulta
                    //                where C.Fecha >= dtpFechaDesde.Value.Date && C.Fecha <= dtpFechaHasta.Value.Date
                    //                select C);
                    //}

                    var Resultados = Consulta.ToList();

                    colEstado.Visible = false;

                    colID.DataPropertyName = "ID";
                    colNumeroPedido.DataPropertyName = "Numero_Pedido";
                    colPCID.DataPropertyName = "Ped_Cuerp_ID";
                    colProductoID.DataPropertyName = "Producto_ID";
                    colProductoDescrip.DataPropertyName = "Descripcion";
                    colMedida.DataPropertyName = "Medida";
                    colCantidad.DataPropertyName = "Cantidad";
                    //colMedida_ID.DataPropertyName = "Medida_ID";
                    colCantidadAfec.DataPropertyName = "Cantidad_Afectada";
                    //colCliente.DataPropertyName = "Cliente";
                    //colEstado.DataPropertyName = "EstadoPC";

                    dgvPedidoProductos.AutoGenerateColumns = false;
                    dgvPedidoProductos.DataSource = Resultados;

                    lblResultados.Text = Resultados.Count.ToString();
                    //CatidadFilasDGV = Resultados.Count();

                    if (Resultados.Count > 0)
                    {
                        if (dgvPedidoProductos.RowCount == CatidadFilasDGV)
                        {
                            dgvPedidoProductos.FirstDisplayedScrollingRowIndex = Indice;
                            //dgvPedidoProductos.Refresh();
                            // txtCantidad.Text = dgvPedidoProductos.Rows[Indice].Cells[6].Value.ToString();
                            // dgvPedidoProductos.Rows[Indice].Selected = true; // CODIGO PRA DEJAR SELECCIONADA LA FILA
                            dgvPedidoProductos.Rows[Indice].Cells[columnName: "colCantidadAfec"].Selected = true;
                            //dgvPedidoProductos.Refresh();
                            dgvPedidoProductos.Focus();
                        }
                    }
                }
            }
        }
        private void MostrarTTOrdenCargaCuerpo()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from VOOC in hb.VistaOCC_CantidadesAfectas
                                join PED in hb.Registro_Pedidos on VOOC.Pedido_ID equals PED.ID
                                orderby VOOC.Pedido_ID, VOOC.ProductoDescrip
                                where VOOC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                    && VOOC.Sesion_ID == clsVariablesGenerales.SesionID
                                select new
                                {
                                    VOOC.Orden_ID,
                                    VOOC.Pedido_ID,
                                    VOOC.Numero_Pedido,
                                    VOOC.Codigo,
                                    VOOC.ProductoDescrip,
                                    Medida_ID = VOOC.ID,
                                    VOOC.MedidaDescrip,
                                    VOOC.CantOCC,
                                    VOOC.Estado,
                                    Completo = "Completo",
                                    Cliente = PED.Clientes.Descripcion

                                }).Take(1000);

                colCantidad.Visible = false;
                colEstado.Visible = true;

                var Resultados = Consulta.ToList();

                colID.DataPropertyName = "Pedido_ID";
                colNumeroPedido.DataPropertyName = "Numero_Pedido";
                colProductoID.DataPropertyName = "Codigo";
                colProductoDescrip.DataPropertyName = "ProductoDescrip";
                colMedida.DataPropertyName = "MedidaDescrip";
                colCantidad.DataPropertyName = "CantOCC";
                //colMedida_ID.DataPropertyName = "Medida_ID";
                colCantidadAfec.DataPropertyName = "CantOCC";
                //colCliente.DataPropertyName = "Cliente";

                if (CrearEditar == "1" || CrearEditar == "3")
                    colEstado.DataPropertyName = "Estado";
                else
                    colEstado.DataPropertyName = "Completo";

                dgvPedidoProductos.AutoGenerateColumns = false;
                dgvPedidoProductos.DataSource = Resultados;
                lblResultados.Text = Resultados.Count.ToString();
            }
        }
        private void MostrarDatosEditar()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from OCC in hb.TT_Orden_Carga_Cuerpo
                                orderby OCC.Pedido_ID, OCC.Productos_Insumos.Descripcion
                                select new
                                {
                                    OCC.ID,
                                    OCC.Orden_ID,
                                    OCC.Pedido_ID,
                                    OCC.Producto_ID,
                                    OCC.Productos_Insumos.Descripcion,
                                    OCC.Medida_ID,
                                    Medida = OCC.Medidas_Producto.Descripcion,
                                    OCC.Cantidad

                                }).Take(1000);

                colCantidad.Visible = false;
                colEstado.Visible = false;

                if (chkFiltraNroPedido.Checked)
                {
                    long NroPedido = Convert.ToInt64(txtFiltraNroPedido.Text);

                    Consulta = (from C in Consulta
                                where C.ID == NroPedido
                                select C);
                }

                var Resultados = Consulta.ToList();

                colID.DataPropertyName = "Pedido_ID";
                //colPCID.DataPropertyName = "PedCuerpID";
                colProductoID.DataPropertyName = "Producto_ID";
                colProductoDescrip.DataPropertyName = "Descripcion";
                colMedida.DataPropertyName = "Medida";
                colCantidad.DataPropertyName = "Cantidad";
                //colMedida_ID.DataPropertyName = "Medida_ID";
                colCantidadAfec.DataPropertyName = "Cantidad";





                dgvPedidoProductos.AutoGenerateColumns = false;
                dgvPedidoProductos.DataSource = Resultados;
            }
        }
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedIndex != -1)
            {
                OnOffBtnConfirnarordenPedido();
                //  if (CrearEditar == "1")
                //{
                DeleteTablaTemporarPedidoCuerpo();
                DeleteTablaTemporarOrdenCargacuerpo();// Elimina los valores en la tabla temporal
                                                      //  InsertarTablaTemporalPedidoCuerpo(); // Inserta los valores en la tabla temporal
                InsertarTablaTemporalPedidoCuerpoEditar();
                //}

                if (AfectarAfectados == "1")
                    MostrarPedidoCuerpo("1", 999999999);
                else
                    MostrarPedidoCuerpo("2", 0);

                Reutilizables.MostrarCiudadAutomaticamente(cmbCliente, cmbCiudad);
            }
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }
        private void MostrarEstadosEnColores(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPedidoProductos.RowCount > 0)
            {
                if (this.dgvPedidoProductos.Columns[e.ColumnIndex].Name == "colEstado")
                {
                    if (e.Value.ToString() == "Completo")
                    {
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        e.CellStyle.SelectionForeColor = Color.Green;
                        e.CellStyle.Font = new Font("Roboto Condensed", 10, FontStyle.Bold);
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                        e.CellStyle.Font = new Font("Roboto Condensed", 10, FontStyle.Bold);
                    }
                }
                if (this.dgvPedidoProductos.Columns[e.ColumnIndex].Name == "colCantidad")
                {
                    e.CellStyle.Font = new Font("Roboto Condensed", 10, FontStyle.Bold);
                }
                if (this.dgvPedidoProductos.Columns[e.ColumnIndex].Name == "colCantidadAfec")
                {
                    e.CellStyle.Font = new Font("Roboto Condensed", 10, FontStyle.Bold);
                }
            }
        }
        private void AfectarPedido(string CompletoParcial) // Afecta pedidos si , tiene funcionalidad para completo o parcial
        {
            if (dgvPedidoProductos.RowCount > 0)
            {
                try
                {
                    using (var hb = new DBdatos())
                    {
                        long Pedido_ID = (long)dgvPedidoProductos.CurrentRow.Cells[columnName: "colID"].Value;
                        long PedidoCuerpo_ID = (long)dgvPedidoProductos.CurrentRow.Cells[columnName: "colPCID"].Value;
                        string Produto_ID = dgvPedidoProductos.CurrentRow.Cells[columnName: "colProductoID"].Value.ToString();

                        var ConsultaPedido = (from PC in hb.TT_Pedido_Cuerpo
                                              where PC.Ped_Cuerp_ID == PedidoCuerpo_ID
                                                  //&& PC.Producto_ID == Produto_ID
                                                  && PC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                                  && PC.Sesion_ID == clsVariablesGenerales.SesionID
                                              select PC);

                        //var ConsultaPedido = (from PC in hb.TT_Pedido_Cuerpo
                        //                      where PC.Pedido_ID == Pedido_ID
                        //                          && PC.Producto_ID == Produto_ID
                        //                          && PC.Usuario_ID == clsVariablesGenerales.UsuarioID
                        //                          && PC.Sesion_ID == clsVariablesGenerales.SesionID
                        //                      select PC);

                        var ResultadoPedido = ConsultaPedido.FirstOrDefault();


                        //hb.SaveChanges();

                        if (ResultadoPedido != null)
                        {
                            // SI SE AFECTA REGISTRO DE PEDIDO COMPLETO
                            if (CompletoParcial == "1") // Lo que hace esto es acomodar las cantidades pendientes y afectadas
                            {
                                // SI NO TIENE CANTIDAD AFECTADA
                                if (ResultadoPedido.Cantidad_Afectada == 0)
                                {
                                    ResultadoPedido.Cantidad_Afectada = ResultadoPedido.Cantidad_Afectada + ResultadoPedido.Cantidad;
                                    ResultadoPedido.Cantidad = 0; // Cantidad pendiente
                                    ResultadoPedido.Estado_ID = "COM";

                                    var i = new TT_Orden_Carga_Cuerpo();

                                   // i.Orden_ID = consulta;
                                    i.Pedido_ID = Pedido_ID;
                                    i.Producto_ID = Produto_ID;
                                    i.Medida_ID = ResultadoPedido.Medida_ID;
                                    i.Cantidad = ResultadoPedido.Cantidad_Afectada;
                                    i.Orden_IDref = OrdenID; //ORDEN CARGA AFECTADA
                                    i.Numero_Pedido = ResultadoPedido.Registro_Pedidos.Numero_Pedido;
                                    i.Usuario_ID = clsVariablesGenerales.UsuarioID;
                                    i.Sesion_ID = clsVariablesGenerales.SesionID;

                                    hb.TT_Orden_Carga_Cuerpo.Add(i);
                                }
                                // SI TIENE CANTIDAD AFECTADA
                                else
                                {
                                    ResultadoPedido.Cantidad_Afectada = ResultadoPedido.Cantidad_Afectada + ResultadoPedido.Cantidad;
                                    ResultadoPedido.Cantidad = 0; // Cantidad pendiente
                                    ResultadoPedido.Estado_ID = "COM";

                                    var ConsultaOCC = (from PC in hb.TT_Orden_Carga_Cuerpo
                                                       where PC.Pedido_ID == Pedido_ID
                                                            && PC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                                            && PC.Sesion_ID == clsVariablesGenerales.SesionID
                                                            && PC.Producto_ID == Produto_ID
                                                       select PC);

                                    var ResultadoOOC = ConsultaOCC.FirstOrDefault();

                                    if (ResultadoOOC != null)
                                    {
                                        ResultadoOOC.Cantidad = ResultadoPedido.Cantidad_Afectada + ResultadoPedido.Cantidad;
                                    }
                                }


                            }
                            // SI SE AFECTA REGISTRO DE PEDIDO PARCIAL
                            if (CompletoParcial == "2") // Lo que hace esto es acomodar las cantidades pendientes y afectadas
                            {
                                if (Convert.ToDecimal(txtCantidad.Text) > 0)
                                {
                                    var ConsultaOCC = (from PC in hb.TT_Orden_Carga_Cuerpo
                                                       where PC.Pedido_ID == Pedido_ID
                                                           && PC.Producto_ID == Produto_ID
                                                           && PC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                                           && PC.Sesion_ID == clsVariablesGenerales.SesionID
                                                       select PC);

                                    var ResultadoOOC = ConsultaOCC.FirstOrDefault();

                                    if (ResultadoOOC == null)
                                    {
                                        var i = new TT_Orden_Carga_Cuerpo();

                                        //i.Orden_ID = OrdenID;
                                        i.Pedido_ID = Pedido_ID;
                                        i.Producto_ID = Produto_ID;
                                        i.Medida_ID = ResultadoPedido.Medida_ID;
                                        i.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                                        i.Orden_IDref = OrdenID;
                                        i.Numero_Pedido = ResultadoPedido.Registro_Pedidos.Numero_Pedido;
                                        i.Usuario_ID = clsVariablesGenerales.UsuarioID;
                                        i.Sesion_ID = clsVariablesGenerales.SesionID;

                                        hb.TT_Orden_Carga_Cuerpo.Add(i);
                                        hb.SaveChanges();

                                    }
                                    // ACTUALIZA LA CONSULTA DEL LA TT ORDEN DE CARGA
                                    ConsultaOCC = (from C in ConsultaOCC
                                                   select C);

                                    ResultadoOOC = ConsultaOCC.FirstOrDefault();

                                    decimal CantidadTotal = (decimal)(ResultadoPedido.Cantidad + ResultadoPedido.Cantidad_Afectada);

                                    // MODIFICA LA CANTIDAD AFECTADA
                                    if (txtCantidad.TextLength > 0)
                                    {
                                        ResultadoPedido.Cantidad_Afectada = Convert.ToDecimal(txtCantidad.Text);
                                        ResultadoOOC.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                                    }
                                    else
                                    {
                                        ResultadoPedido.Cantidad_Afectada = 0;
                                        ResultadoOOC.Cantidad = 0;
                                    }

                                    // MODIFICA LA CANTIDAD PENDIENTE
                                    ResultadoPedido.Cantidad = CantidadTotal - ResultadoPedido.Cantidad_Afectada;  // pendiente

                                    if (ResultadoPedido.Cantidad < 0)
                                        ResultadoPedido.Cantidad = ResultadoPedido.Cantidad * -1; // Para que no sea negativo

                                    // MODIFICA LOS ESTADOS

                                    ResultadoPedido.Afectada = true;

                                    if (ResultadoPedido.Cantidad == 0)
                                    {
                                        ResultadoPedido.Estado_ID = "COM";
                                    }
                                    if (ResultadoPedido.Cantidad > 0)
                                    {
                                        ResultadoPedido.Estado_ID = "PEN";
                                    }

                                    if (CantidadTotal < ResultadoPedido.Cantidad_Afectada) // Validacion para que la cantidad no sea negativa.
                                    {
                                        MessageBox.Show("La cantidad pendiente no puede ser negativa", "Atención");
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("La cantidad a Afectar debe ser mayor a 0", "Atención");
                                }
                            }
                            // SI DESAFECTAMOS
                            if (CompletoParcial == "3") // boton desafectar
                            {
                                var ConsultaOCC = (from PC in hb.TT_Orden_Carga_Cuerpo
                                                   where PC.Pedido_ID == Pedido_ID
                                                       && PC.Producto_ID == Produto_ID
                                                       && PC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                                       && PC.Sesion_ID == clsVariablesGenerales.SesionID
                                                   select PC);

                                var ResultadoOOC = ConsultaOCC.FirstOrDefault();

                                ResultadoPedido.Cantidad = ResultadoPedido.Cantidad_Afectada + ResultadoPedido.Cantidad;
                                ResultadoPedido.Cantidad_Afectada = 0;
                                ResultadoPedido.Estado_ID = "PEN";

                                hb.TT_Orden_Carga_Cuerpo.Remove(ResultadoOOC);
                            }
                            hb.SaveChanges();
                            // if (AfectarAfectados == "1")

                        }
                        else
                        {
                            //if (CompletoParcial == "3" && CrearEditar == "3") // boton desafectar
                            //{
                            //    Pedido_ID = (long)dgvPedidoProductos.CurrentRow.Cells[0].Value;
                            //    Produto_ID = dgvPedidoProductos.CurrentRow.Cells[1].Value.ToString();
                            //    decimal Cantidad = (decimal)dgvPedidoProductos.CurrentRow.Cells[6].Value;

                            //    var ConsultaPC = (from PC in hb.Pedido_Cuerpo
                            //                          where PC.Pedido_ID == Pedido_ID
                            //                              && PC.Producto_ID == Produto_ID
                            //                          select PC);

                            //    var ResultadoPC = ConsultaPC.FirstOrDefault();

                            //    if(ResultadoPC != null)
                            //    {
                            //        ResultadoPedido.Cantidad_Afectada = ResultadoPedido.Cantidad_Afectada - 
                            //    }

                            //}
                        }
                        CatidadFilasDGV = dgvPedidoProductos.RowCount;
                        Indice = dgvPedidoProductos.CurrentRow.Index;
                        // MostrarPedidoCuerpo();

                        // if (AfectarAfectados == "1")
                        MostrarPedidoCuerpo("1", 999999999);
                        MostrarTTOrdenCargaCuerpo();
                        ////////////////////////////////// ESTOS 4 SE HACEN PARA QUE MUETRE LA TABLA DE AFECTADOS Y DESABILITE EL
                        AfectarAfectados = "2";          // EL BOTON EDITAR
                                                         //btnAfectados.BackColor = Color.Orange;
                                                         //btnAfectar.BackColor = Color.White;
                        CambiarColorbtnSeleccionado("2", btnAfectados, btnAfectar, btnAfec);
                        OnOffbtnEditarCantidad();
                        //else
                        //MostrarPedidoCuerpo("2", 0);


                    }




                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                    throw;
                }
               
            }
        }
        private void InsertarDatosEnTablaTemporalTTRPT()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from EPT in hb.Existencia_ProductoTerminado
                                where EPT.Cantidad_Utiliz != EPT.Cantidad
                                        //&& EPT.Produto_ID == ProductoID
                                        && EPT.Movimiento_ID != "AJUNE"
                                        //&& EPT.Movimiento_ID != "AJUPO"
                                        && EPT.Estado_ID != "AN"
                                select EPT);

                var Resultados = Consulta.ToList();

                foreach (var item in Resultados)
                {                  
                    var i = new TT_Existencia_ProductoTerminado();

                    //i.ID = 1;
                    //i.IDaModificar = item.ID;
                    i.Producto_ID = item.Produto_ID;
                    i.Cantidad = Convert.ToDecimal(item.Cantidad - item.Cantidad_Utiliz);
                    i.Cantidad_Afec = 0;
                    i.IDaModificar = item.ID;
                    i.Fecha = item.Fecha;
                    i.Ficha = item.Ficha;
                    i.Retencion = item.Retencion;
                    i.Movimiento_ID = item.Movimiento_ID;
                    i.Medida_ID = (int)item.Medida_ID;
                    i.Deposito = item.Deposito;
                    i.Empleado_ID = (int)item.Empleado_ID;
                    i.Observaciones = item.Observaciones;                    
                    i.Pedido_ID = 10252;
                    i.Usuario_ID = clsVariablesGenerales.UsuarioID;
                    i.Sesion_ID = clsVariablesGenerales.SesionID;
                    i.Lote = item.Lote;

                    hb.TT_Existencia_ProductoTerminado.Add(i);
                    hb.SaveChanges();
                }

            }
        }
        private void DeleteTablaTemporalTTRPT()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from TTEPT in hb.TT_Existencia_ProductoTerminado
                                where TTEPT.Usuario_ID == clsVariablesGenerales.UsuarioID
                                    && TTEPT.Sesion_ID == clsVariablesGenerales.SesionID
                                select TTEPT).ToList();

                hb.TT_Existencia_ProductoTerminado.RemoveRange(Consulta);
                hb.SaveChanges();
            }
        }
        private void DeleteTablaTemporalTTAFEC()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from TTEPT in hb.TT_Prodocuto_Afec_OrdenCarga
                                where TTEPT.Usuario_ID == clsVariablesGenerales.UsuarioID
                                    && TTEPT.Sesion_ID == clsVariablesGenerales.SesionID
                                select TTEPT).ToList();

                hb.TT_Prodocuto_Afec_OrdenCarga.RemoveRange(Consulta);
                hb.SaveChanges();
            }
        }
        private void InsertarTablaTemporalPedidoCuerpo()
        {
            using (var hb = new DBdatos())
            {
                var ConsultaPedido = (from PC in hb.Pedido_Cuerpo
                                      where PC.Registro_Pedidos.Cliente_ID == (int)cmbCliente.SelectedValue
                                        && PC.Estado_ID == "PEN"
                                      select PC);

                var ResultadoPedido = ConsultaPedido.ToList();

                if (ResultadoPedido.Count > 0)
                {
                    foreach (var item in ResultadoPedido)
                    {
                        var i = new TT_Pedido_Cuerpo();

                        i.Ped_Cuerp_ID = item.ID;
                        i.Cantidad = item.Cantidad;
                        i.Cantidad_Afectada = item.Cantidad_Entregada;
                        i.Estado_ID = item.Estado_ID;
                        i.Producto_ID = item.Producto_ID;
                        i.Medida_ID = item.Medida_ID;
                        i.Pedido_ID = item.Pedido_ID;
                        i.Afectada = false;

                        hb.TT_Pedido_Cuerpo.Add(i);
                        hb.SaveChanges();
                    }
                }
            }
        }
        private void InsertarTablaTemporalPedidoCuerpoEditar()
        {
            using (var hb = new DBdatos())
            {
                //CONSULTA LOS PEDIDOS CON EL CLIENTE SELECCIONADO
                var ConsultaPedido = (from PC in hb.Pedido_Cuerpo
                                      where PC.Registro_Pedidos.Cliente_ID == (int)cmbCliente.SelectedValue
                                        && PC.Registro_Pedidos.Estado_ID != "AN"
                                        && PC.Registro_Pedidos.Estado_ID != "INF"
                                      select PC);

                // CONSULTA LAS ORDENES CARGA CON TAL NUMERO DE ORDEN Y CLIENTE QUE ESTAMOS COPIANDO
                var ConsultaOrdenCargaCuerpo = (from OCC in hb.OrdenCarga_Cuerpo
                                                where OCC.Orden_ID == IDRecibido
                                                && OCC.Orden_Carga.Cliente_ID == (int)cmbCliente.SelectedValue
                                                select OCC);

                var ResultadoPedido = ConsultaPedido.ToList();
                var ResultadoOrdenCargaCuerpo = ConsultaOrdenCargaCuerpo.ToList();

                // SI HAY ORDENES DE CARGAGAS SE REGISTRAN EN LA TTOCC
                if (ResultadoOrdenCargaCuerpo.Count > 0)
                {
                    foreach (var item2 in ResultadoOrdenCargaCuerpo)
                    {

                        var z = new TT_Orden_Carga_Cuerpo();

                        //z.Orden_ID = OrdenID;
                        z.Pedido_ID = item2.Pedido_ID;
                        z.IDaEditar = item2.ID;
                        z.Producto_ID = item2.Producto_ID;
                        z.Cantidad = item2.Cantidad;
                        z.Medida_ID = item2.Medida_ID;
                        z.Usuario_ID = clsVariablesGenerales.UsuarioID;
                        z.Sesion_ID = clsVariablesGenerales.SesionID;

                        if (CrearEditar == "3")
                        {
                            CalculaIDOrdenCarga();
                            CalcularNumeroOrdenCarga();
                            z.Orden_IDref = OrdenID;
                        }

                        hb.TT_Orden_Carga_Cuerpo.Add(z);
                        hb.SaveChanges();
                    }
                }
                // SI HAY PEDIDOS
                if (ResultadoPedido.Count > 0)
                {
                    foreach (var item in ResultadoPedido)
                    {
                        //  if (CrearEditar == "3")
                        // {
                        var ConusltaTTOCC = (from TTOCC in hb.TT_Orden_Carga_Cuerpo
                                             where TTOCC.Pedido_ID == item.Pedido_ID
                                                 && TTOCC.Producto_ID == item.Producto_ID
                                                 && TTOCC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                                 && TTOCC.Sesion_ID == clsVariablesGenerales.SesionID
                                             select TTOCC);

                        var ResultadosTTOCC = ConusltaTTOCC.FirstOrDefault();
                        
                        if (ResultadosTTOCC == null)
                        {

                            var i = new TT_Pedido_Cuerpo();

                            i.Ped_Cuerp_ID = item.ID;
                            i.Cantidad = item.Cantidad;
                            i.Cantidad_Afectada = item.Cantidad_Entregada;
                            i.Estado_ID = item.Estado_ID;
                            i.Producto_ID = item.Producto_ID;
                            i.Medida_ID = item.Medida_ID;
                            i.Pedido_ID = item.Pedido_ID;
                            i.Afectada = false;
                            i.Usuario_ID = clsVariablesGenerales.UsuarioID;
                            i.Sesion_ID = clsVariablesGenerales.SesionID;

                            hb.TT_Pedido_Cuerpo.Add(i);
                            hb.SaveChanges();
                        }
                        else
                        {
                            var i = new TT_Pedido_Cuerpo();

                            i.Ped_Cuerp_ID = item.ID;
                            i.Cantidad = item.Cantidad - ResultadosTTOCC.Cantidad;
                            i.Cantidad_Afectada = ResultadosTTOCC.Cantidad;
                            if (ResultadosTTOCC.Cantidad == item.Cantidad)
                            {
                                i.Estado_ID = "COM";
                            }
                            else
                            {
                                i.Estado_ID = "PEN";
                            }
                            //i.Estado_ID = item.Estado_ID;
                            i.Producto_ID = item.Producto_ID;
                            i.Medida_ID = item.Medida_ID;
                            i.Pedido_ID = item.Pedido_ID;
                            i.Afectada = false;
                            i.Usuario_ID = clsVariablesGenerales.UsuarioID;
                            i.Sesion_ID = clsVariablesGenerales.SesionID;

                            hb.TT_Pedido_Cuerpo.Add(i);
                            hb.SaveChanges();
                        }
                    }

                    //{
                    //    //foreach (var item2 in ResultadoOrdenCargaCuerpo)
                    //    //{

                    //    //    var z = new TT_Pedido_Cuerpo();

                    //    //    // z.Orden_ID = item2.Orden_ID;
                    //    //    z.Pedido_ID = item2.Pedido_ID;
                    //    //    //  z.IDaEditar = item2.ID;
                    //    //    z.Producto_ID = item2.Producto_ID;
                    //    //    z.Cantidad = item2.Cantidad;
                    //    //    z.Medida_ID = item2.Medida_ID;

                    //    //    hb.TT_Pedido_Cuerpo.Add(z);
                    //    //    hb.SaveChanges();
                    //    //}
                    //}
                }

            }
        }
        private void LimpiarTablasTemporales()
        {
            using (var hb = new DBdatos())
            {
                //var ConsultaPedidoCuerpo = (from PC in hb.TT_Pedido_Cuerpo
                //                      where PC.Usuario_ID == clsVariablesGenerales.UsuarioID
                //                        && PC.Sesion_ID == clsVariablesGenerales.SesionID
                //                      //where PC.Registro_Pedidos.Cliente_ID == (int)cmbCliente.SelectedValue
                //                      //  && PC.Estado_ID == "PEN"
                //                      select PC).ToList();

                var ConsultaProductoAfecOrdenCarga = (from TTEPT in hb.TT_Prodocuto_Afec_OrdenCarga
                                                      where TTEPT.Usuario_ID == clsVariablesGenerales.UsuarioID
                                                          && TTEPT.Sesion_ID == clsVariablesGenerales.SesionID
                                                      select TTEPT).ToList();

                var ConsultaExintencia = (from TTEPT in hb.TT_Existencia_ProductoTerminado
                                          where TTEPT.Usuario_ID == clsVariablesGenerales.UsuarioID
                                              && TTEPT.Sesion_ID == clsVariablesGenerales.SesionID
                                          select TTEPT).ToList();

                var ConsultaOCC = (from PC in hb.TT_Orden_Carga_Cuerpo
                                   where PC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                       && PC.Sesion_ID == clsVariablesGenerales.SesionID
                                   //where PC.Registro_Pedidos.Cliente_ID == (int)cmbCliente.SelectedValue
                                   //  && PC.Estado_ID == "PEN"
                                   select PC).ToList();

                var ConsultaPedido = (from PC in hb.TT_Pedido_Cuerpo
                                      where PC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                        && PC.Sesion_ID == clsVariablesGenerales.SesionID
                                      //where PC.Registro_Pedidos.Cliente_ID == (int)cmbCliente.SelectedValue
                                      //  && PC.Estado_ID == "PEN"
                                      select PC).ToList();

                hb.TT_Pedido_Cuerpo.RemoveRange(ConsultaPedido);

                hb.TT_Orden_Carga_Cuerpo.RemoveRange(ConsultaOCC);

                hb.TT_Existencia_ProductoTerminado.RemoveRange(ConsultaExintencia);

                hb.TT_Prodocuto_Afec_OrdenCarga.RemoveRange(ConsultaProductoAfecOrdenCarga);

                hb.TT_Pedido_Cuerpo.RemoveRange(ConsultaPedido);

                hb.SaveChanges();
            }
        }
        private void DeleteTablaTemporarPedidoCuerpo()
        {
            using (var hb = new DBdatos())
            {
                //  hb.Database.ExecuteSqlCommand("TRUNCATE TABLE TT_Pedido_Cuerpo");
                var ConsultaPedido = (from PC in hb.TT_Pedido_Cuerpo
                                      where PC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                        && PC.Sesion_ID == clsVariablesGenerales.SesionID
                                      //where PC.Registro_Pedidos.Cliente_ID == (int)cmbCliente.SelectedValue
                                      //  && PC.Estado_ID == "PEN"
                                      select PC).ToList();

                hb.TT_Pedido_Cuerpo.RemoveRange(ConsultaPedido);
                hb.SaveChanges();
            }
        }
        private void DeleteTablaTemporarOrdenCargacuerpo()
        {
            using (var hb = new DBdatos())
            {
                var ConsultaOCC = (from PC in hb.TT_Orden_Carga_Cuerpo
                                   where PC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                       && PC.Sesion_ID == clsVariablesGenerales.SesionID
                                   //where PC.Registro_Pedidos.Cliente_ID == (int)cmbCliente.SelectedValue
                                   //  && PC.Estado_ID == "PEN"
                                   select PC).ToList();

                hb.TT_Orden_Carga_Cuerpo.RemoveRange(ConsultaOCC);
                hb.SaveChanges();
            }
        }
        private void CargarOrden()
        {
            using (var hb = new DBdatos())
            {
                var ConsultaVOOC = (from VOOC in hb.VistaOCC_CantidadesAfectas
                                    where VOOC.Estado == "Pendiente"
                                        && VOOC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                        && VOOC.Sesion_ID == clsVariablesGenerales.SesionID
                                    select VOOC);

                var ResultadosVOOC = ConsultaVOOC.FirstOrDefault();

                //ESTA CONSULTA CALCULA QUE TODOS LOS ITEMS DE LAS ORDEN DE CARGA HAYAN SELECCIONADO MERCADERIA
                if (ResultadosVOOC == null)
                {
                    var i = new Orden_Carga();

                    i.ID = OrdenID;
                    i.Numero_Orden = txtNumeroOrden.Text;
                    i.Fecha = dtpFecha.Value.Date;
                    i.Cliente_ID = (int)cmbCliente.SelectedValue;
                    i.Ciudad_ID = (int)cmbCiudad.SelectedValue;
                    i.Observaciones = txtObservaciones.Text;
                    i.Estado_ID = "FI";
                    i.Modo = true;

                    hb.Orden_Carga.Add(i);

                    // AJUSTA EL PEDIDO
                    var ConsultaTTpedido = (from PC in hb.TT_Pedido_Cuerpo
                                            where PC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                                && PC.Sesion_ID == clsVariablesGenerales.SesionID
                                            select PC); // CONSULTA A LA TT PEDIDO

                    var ResultadoTTPedido = ConsultaTTpedido.ToList();

                    List<long?> ListaPedidos_ID = new List<long?>(); // LISTA CREADA PARA GUARDAR LOS ID DE LA TABLA PEDIDO CUERPO PARA EN EL FINAL VER QUE SI FINALIZA UN PEDIDO O QUEDA PENDIENTE

                    long Produto_Afec_OrdenCarga_ID = 0; // PARA CALCULAR EL ID DE LA TABLA PRODUCTO_AFEC_ORDENCARGA
                    long Contador = 0;

                    foreach (var item in ResultadoTTPedido) // RECORRIDO DE LA TABLA TEMPORAL
                    {
                        var ConsultaPedCuerpo = (from PC in hb.Pedido_Cuerpo
                                                 where PC.ID == item.Ped_Cuerp_ID                                                
                                                 select PC); // CONSULTA PARA VER QUE PEDIDOS DEBEMOS MODIFICAR LA CANTIDAD EN LA TABLA PEDIDO_CUERPO                  

                        var ResultaodosPedCuerpo = ConsultaPedCuerpo.FirstOrDefault();

                        if (ResultaodosPedCuerpo != null)
                        {
                            if (item.Cantidad_Afectada > 0) // SI TIENE CANTIDAD AFECTADA SE MODIFICAN LAS CANTIDADES DEL PEDIDO
                            {
                                // AJUSTA EL PEDIDO CUERPO
                                ListaPedidos_ID.Add(item.Pedido_ID);
                                ResultaodosPedCuerpo.Cantidad = (decimal)item.Cantidad;
                                ResultaodosPedCuerpo.Cantidad_Entregada = 0;
                                ResultaodosPedCuerpo.Cantidad_Total_Entregada = (decimal)(ResultaodosPedCuerpo.Cantidad_Total_Entregada + item.Cantidad_Afectada);

                                if (item.Cantidad == 0) // SI LA CANTIDAD PENDIENTE ES = 0 ENTONCES ESA FILA DEL PEDIDOCUERPO ESTA COMPLETA
                                    ResultaodosPedCuerpo.Estado_ID = "COM";
                                else
                                    ResultaodosPedCuerpo.Estado_ID = "PEN";

                                // SE CARGA DATOS EN ORDEN CARGA CUERPO
                                var z = new OrdenCarga_Cuerpo();

                                z.Orden_ID = OrdenID;
                                z.Pedido_ID = (long)item.Pedido_ID;
                                z.Producto_ID = item.Producto_ID;
                                z.Medida_ID = (int)item.Medida_ID;
                                z.Cantidad = (decimal)item.Cantidad_Afectada;
                                //z.Afectada = TRUE

                                hb.OrdenCarga_Cuerpo.Add(z);

                                var ConsultaTTAFEC = (from TTAFEC in hb.TT_Prodocuto_Afec_OrdenCarga
                                                      where TTAFEC.Pedido_ID == item.Pedido_ID
                                                        && TTAFEC.Producto_ID == item.Producto_ID
                                                        && TTAFEC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                                        && TTAFEC.Sesion_ID == clsVariablesGenerales.SesionID
                                                      select TTAFEC);

                                var ResultadpsTTAFEC = ConsultaTTAFEC.ToList();

                               

                                foreach (var item2 in ResultadpsTTAFEC)
                                {
                                    var ConsultaEPT = (from EPT in hb.Existencia_ProductoTerminado
                                                       where EPT.ID == item2.ExitenciaProTer_ID
                                                       select EPT);

                                    var ConsultaIDAfec = (from AFEC in hb.Producto_Afec_OrdenCarga
                                                          orderby AFEC.ID descending
                                                          select AFEC).Take(1).FirstOrDefault();

                                    

                                    if (ConsultaIDAfec != null)
                                    {
                                        Contador = Contador + 1;
                                        Produto_Afec_OrdenCarga_ID = ConsultaIDAfec.ID + Contador;

                                        //if (ConsultaIDAfec == null)
                                        //{
                                        //    Produto_Afec_OrdenCarga_ID = Produto_Afec_OrdenCarga_ID + 1;
                                        //}
                                        //else
                                        //{
                                        //    Produto_Afec_OrdenCarga_ID = ConsultaIDAfec.ID + Contador;
                                        //}                                      
                                    }
                                    else
                                    {
                                        Produto_Afec_OrdenCarga_ID = Produto_Afec_OrdenCarga_ID + 1;
                                    }
                                        


                                    var ResultadosEPT = ConsultaEPT.FirstOrDefault();

                                    if (ResultadosEPT != null)
                                    {
                                        ResultadosEPT.Cantidad_Utiliz = ResultadosEPT.Cantidad_Utiliz + item2.Cantidad;

                                        if (ResultadosEPT.Cantidad_Utiliz == ResultadosEPT.Cantidad)
                                        {
                                            ResultadosEPT.Estado_ID = "ENT";
                                        }
                                    }

                                    var w = new Producto_Afec_OrdenCarga();

                                    w.ID = Produto_Afec_OrdenCarga_ID;
                                    w.ExitenciaProTer_ID = (long)item2.ExitenciaProTer_ID;
                                    w.Pedido_ID = (long)item2.Pedido_ID;
                                    w.Cantidad = (decimal)item2.Cantidad;
                                    w.Producto_ID = item2.Producto_ID;
                                    w.Orden_ID = OrdenID;
                                    w.Estado = "FI";
                              
                                    hb.Producto_Afec_OrdenCarga.Add(w);
                                }
                            }
                        }
                        // LISTA CREADA PARA IR GUARDANDO LOS ID DE LOS PRODUCTOS YA USUADOS EN LA TABLA EXISTENCIA
                        List<long?> ProductosExluidos = new List<long?>();



                        //// CLICLO PARA VER DESCONTAR LOS PRODUCTOS DE LAS TABLA EXISTENCIA PRODUCTO
                        //for (int l = 1; l <= item.Cantidad_Afectada; l++)
                        //{
                        //    var ConsultaExistencia = (from EP in hb.Existencia_ProductoTerminado
                        //                              where EP.Produto_ID == item.Producto_ID
                        //                                    // && EP.Estado_ID == "PEN"
                        //                                    && !ProductosExluidos.Contains(EP.ID)
                        //                              orderby EP.Fecha
                        //                              select EP);

                        //    var ResultadoExistencia = ConsultaExistencia.FirstOrDefault();
                        //    decimal CantidadDeProductos = ConsultaExistencia.Count();

                        //    if (ResultadoExistencia != null)
                        //    {
                        //        //  ResultadoExistencia.Estado_ID = "COM";
                        //        ProductosExluidos.Add(ResultadoExistencia.ID);
                        //    }
                        //}
                    }
                    hb.SaveChanges();
                    MessageBox.Show("Datos cargados correctamente", "Atención");
                    //Reutilizables.AbriFormFinalizado("C:/Program Files (x86)/Pack-Codin/Images/OrdenCarga.png", "O. carga agregada correctamente");


                    //DeleteTablaTemporarPedidoCuerpo();
                    //DeleteTablaTemporalTTAFEC();
                    //DeleteTablaTemporalTTRPT();
                    //DeleteTablaTemporarOrdenCargacuerpo();
                    //DeleteTablaTemporarPedidoCuerpo();

                    var ConsultaRegistroPedido = (from PCC in hb.Pedido_Cuerpo  // ESTE CODIGO ES PARA VER SI FINALIZAMOS AUTOMATICAMENTE UN PEDIDO OSEA PASA A ESTA FI
                                                  where ListaPedidos_ID.Contains(PCC.Pedido_ID)
                                                  group PCC by new { PCC.Pedido_ID } into Grupo
                                                  select new
                                                  {
                                                      Grupo.Key.Pedido_ID,
                                                      CantidadPendiente = Grupo.Sum(x => x.Cantidad)
                                                  }); // AGRUPAMOS TODOS LOS PEDIDOS Y EL QUE TENGA CANTIDAD 0 SE FINALIZA

                    var ResultaodosPedCuerpo2 = ConsultaRegistroPedido.ToList();

                    foreach (var item in ResultaodosPedCuerpo2)
                    {
                        if (item.CantidadPendiente == 0)
                        {
                            var Consulta = (from RP in hb.Registro_Pedidos
                                            where RP.ID == item.Pedido_ID
                                            select RP);

                            var Resultados = Consulta.FirstOrDefault();

                            if (Resultados != null)
                            {
                                Resultados.Estado_ID = "FI";
                            }
                            hb.SaveChanges();



                        }
                    }

                    //DeleteTablaTemporarPedidoCuerpo();
                    //DeleteTablaTemporarOrdenCargacuerpo();
                    //DeleteTablaTemporalTTAFEC();
                    //DeleteTablaTemporalTTRPT();

                    LimpiarTablasTemporales();

                    MostrarPantallaEspera();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se puede finalizar la Orden de carga porque aún tiene pedidos pendientes de asignarle productos", "Atención");
                    return;
                }
            }
        }
        private void MostrarPantallaEspera()
        {
            PantallaEspera = new frmPantallaEspera();
            VisorReporte = new frmReporte();

            PantallaEspera.Shown += new System.EventHandler(frmPantallaEspera_Shown);
            PantallaEspera.ShowDialog();
        }

        private void frmPantallaEspera_Shown(object sender, EventArgs e)
        {
            //SE CREA PARA DIFERENCIAR CUANDO ES IMPRESION DE PLANTILLA AL FINALIZAR O SOLO IMPRIMIR
            long ID;

            //SI ES SOLO IMPREESION
            if (OrdenID > 0)
                ID = OrdenID;
            else // SI ES CUANDO FINALIZA EL COMPROBANTE
                ID = IDRecibido;

            clsQueryPlantillas.PlaOrdenCarga(ID, VisorReporte); //LISTA LA ORDEN
            PantallaEspera.Close();
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
                    OrdenID = 1;
                }
                else
                {
                    OrdenID = Resultados.ID + 1;
                }
            }
        }
        private void AnularOrden()
        {
            DialogResult R = MessageBox.Show("¿Esta seguro que desea anular esta orden de carga", "Atención", MessageBoxButtons.YesNo);
            if (R == DialogResult.Yes)
            {
                //int ValidarSTieneCantPendiente = 0; // Esta variable es para ver si el pedido que estamos anulando tiene productos pendientes
                //                                    // si Tiene combierte la or
                using (var hb = new DBdatos())
                {
                    // TRAE LA ORDEN A ANULAR
                    var ConsultaOC = (from OC in hb.Orden_Carga
                                      where OC.ID == IDRecibido
                                      select OC);

                    var ResultadosOC = ConsultaOC.FirstOrDefault();

                    if (ResultadosOC != null)
                    {
                        // TRAE LOS PRODUCTOS A RESTAURAR
                        var ConsultaOCC = (from OCC in hb.OrdenCarga_Cuerpo
                                           where OCC.Orden_ID == IDRecibido
                                           select OCC);

                        var ResultadosOCC = ConsultaOCC.ToList();

                        if (ResultadosOCC != null)
                        {
                            // RECORRE LA TABLA OCC 
                            foreach (var item in ResultadosOCC)
                            {
                                // CONSULTA PARA TRAER LOS PRODUCTOS DEL PEDIDO_CUERPO
                                var ConsultaPC = (from PC in hb.Pedido_Cuerpo
                                                  where PC.Pedido_ID == item.Pedido_ID
                                                      && PC.Producto_ID == item.Producto_ID
                                                  select PC);

                                //CONSULTA PARA SABER LAS CANTIDADDES DE PRODUCTOS QUE TIENE AFECTADO
                                var ConsultaAfec = (from AFEC in hb.Producto_Afec_OrdenCarga
                                                    where AFEC.Orden_ID == item.Orden_ID
                                                        && AFEC.Producto_ID == item.Producto_ID
                                                        && AFEC.Estado == "FI"
                                                    select AFEC);

                                var ResultadosPC = ConsultaPC.FirstOrDefault();
                                var ResultadosAfec = ConsultaAfec.ToList();

                                if (ResultadosPC != null)
                                {
                                    // AJUSTA LAS CANTIDADES DEL PEDIDO_CUERPO
                                    ResultadosPC.Cantidad = ResultadosPC.Cantidad + item.Cantidad;
                                    /// ResultadosPC.Cantidad_Afectada = ResultadosPC.Cantidad_Afectada - item.Cantidad;
                                    ResultadosPC.Cantidad_Total_Entregada = ResultadosPC.Cantidad_Total_Entregada - item.Cantidad;
                                    ResultadosPC.Estado_ID = "PEN";
                                    // PASA AL PEDIDO EN ESTADO 'AU' 
                                    ResultadosPC.Registro_Pedidos.Estado_ID = "AU";
                                }
                                if (ResultadosAfec != null)
                                {
                                    foreach (var item2 in ResultadosAfec)
                                    {
                                        // CONSULTA PARA AJUSTAR LAS CANTIDADES EN LA TABLA EPT
                                        var ConssultaEPT = (from EPT in hb.Existencia_ProductoTerminado
                                                            where EPT.ID == item2.ExitenciaProTer_ID
                                                            select EPT);

                                        var ResultadosEPT = ConssultaEPT.FirstOrDefault();

                                        if (ResultadosEPT != null)
                                        {
                                            // AJUSTA LAS CANTIDADES EN LA TABLA EPT
                                            ResultadosEPT.Cantidad_Utiliz = ResultadosEPT.Cantidad_Utiliz - item2.Cantidad;
                                            ResultadosEPT.Estado_ID = "PEN";

                                            // SE REALIZA ESTA CONSULTA CON EL OBJETIVO DE SI EL DEPOSITO SIGUE VACIO O OCUPADO PERO CON EL MISMO PRODUCTO, ESA MERCADERIA VUELVA , DE LO CONTRARIO QUEDE SIN ASIGNAR
                                            var ConsultaDeposito = (from EPT in hb.Existencia_ProductoTerminado
                                                                    where EPT.Deposito == ResultadosEPT.Deposito
                                                                        && EPT.Estado_ID == "PEN"
                                                                    select EPT).FirstOrDefault();

                                            // SI ESTA OCUPADO
                                            if (ConsultaDeposito != null)
                                            {
                                                // Y EL PRODUCTO ES DIFERENTE
                                                if (ConsultaDeposito.Produto_ID != ResultadosEPT.Produto_ID)
                                                {
                                                    MessageBox.Show("El movimiento " + ResultadosEPT.ID + " , no puede volver a su deposito original " + ResultadosEPT.Deposito + " porque el mismo está ocupado por otro movimeinto con diferente producto", "Atención");
                                                    ResultadosEPT.Deposito = "";
                                                }
                                            }
                                        }
                                        item2.Estado = "AN";
                                    }
                                }
                            }
                        }

                        ResultadosOC.Estado_ID = "AN";
                    }
                    hb.SaveChanges();
                    MessageBox.Show("Orden anulada correctamente", "Atención");
                    MessageBox.Show("");
                    this.Hide();
                }
            }
        }
        private void EditarOrden()
        {
            using (var hb = new DBdatos())
            {


                var ConsultaTTORdenCarga = (from TTOOC in hb.TT_Orden_Carga_Cuerpo
                                            select TTOOC);


                var ResultadosTTOrdenCargaCuerpo = ConsultaTTORdenCarga.ToList();

                if (ResultadosTTOrdenCargaCuerpo != null)
                {
                    foreach (var item in ResultadosTTOrdenCargaCuerpo)
                    {
                        var ConsultaOrdenCargaCuerpo = (from OCC in hb.OrdenCarga_Cuerpo
                                                        where OCC.Producto_ID == item.Producto_ID
                                                            && OCC.Pedido_ID == item.Pedido_ID
                                                        select OCC);

                        var ResultadosOrdenCargaCuerpo = ConsultaOrdenCargaCuerpo.FirstOrDefault();

                        if (item.Producto_ID != ResultadosOrdenCargaCuerpo.Producto_ID || item.Pedido_ID != ResultadosOrdenCargaCuerpo.Pedido_ID)
                        {
                            ResultadosOrdenCargaCuerpo.Orden_ID = (long)item.Orden_ID;
                            ResultadosOrdenCargaCuerpo.Pedido_ID = (long)item.Pedido_ID;
                            ResultadosOrdenCargaCuerpo.Producto_ID = item.Producto_ID;
                            ResultadosOrdenCargaCuerpo.Medida_ID = (int)item.Medida_ID;
                            ResultadosOrdenCargaCuerpo.Cantidad = (decimal)item.Cantidad;

                            var ConsultaPedidoCuerpo = (from OCC in hb.Pedido_Cuerpo
                                                        where OCC.Producto_ID == item.Producto_ID
                                                            && OCC.Pedido_ID == item.Pedido_ID
                                                        select OCC);

                            var ResultaodosPedCuerpo = ConsultaPedidoCuerpo.FirstOrDefault();

                            List<long?> ListaPedidos_ID = new List<long?>();

                            ListaPedidos_ID.Add(item.Pedido_ID);
                            ResultaodosPedCuerpo.Cantidad = (decimal)item.Cantidad;
                            ResultaodosPedCuerpo.Cantidad_Entregada = 0;
                            ResultaodosPedCuerpo.Cantidad_Total_Entregada = (decimal)(ResultaodosPedCuerpo.Cantidad_Total_Entregada + item.Cantidad);

                            if (item.Cantidad == 0) // SI LA CANTIDAD PENDIENTE ES = 0 ENTONCES ESA FILA DEL PEDIDOCUERPO ESTA COMPLETA
                                ResultaodosPedCuerpo.Estado_ID = "COM";
                            else
                                ResultaodosPedCuerpo.Estado_ID = "PEN";
                        }
                    }
                }
            }
        }
        private void OnOffbtnEditarCantidad()
        {
            if (txtCantidad.TextLength > 0 && AfectarAfectados == "1")
            {
                if (txtCantidad.Text != "0" && txtCantidad.Text != "0,00")
                    btnEditar.Enabled = true;
                else
                    btnEditar.Enabled = false;
            }
            else
                btnEditar.Enabled = false;
        }
        private void MostrarCantidadEntxt()
        {
            if (dgvPedidoProductos.RowCount > 0)
            {
                decimal Cantidad = (decimal)dgvPedidoProductos.CurrentRow.Cells[columnName: "colCantidadAfec"].Value;
                txtCantidad.Text = Cantidad.ToString("N2");
                //  _ = dgvPedidoProductos.SelectedCells;
            }
        }
        private void CambiarColorbtnSeleccionado(string Pulso, Button btnActivo, Button btnInactivo, ToolStripMenuItem btnAfeAfectados)
        {
            AfectarAfectados = Pulso;
            btnActivo.BackColor = Color.DarkOrange;
            btnInactivo.BackColor = Color.White;

            if (Pulso == "1")
            {
                btnAfec.Visible = true;
                btnDesafectar.Visible = false;
            }
            if (Pulso == "2")
            {
                btnAfec.Visible = false;
                btnDesafectar.Visible = true;
            }
        }
        private void OnOffBtnConfirnarordenPedido()
        {
            if (cmbCliente.SelectedIndex != -1)
            {

                using (var hb = new DBdatos())
                {
                    //for (var i = 1; i <= dgvPedidoProductos.RowCount; i++)
                    //{
                    //    if ((decimal)dgvPedidoProductos.Rows[i - 1].Cells[6].Value != 0)
                    //    {

                    //    }
                    //}

                    //var Consulta = (from OP in hb.Registro_Pedidos
                    //                join PC in hb.Pedido_Cuerpo on OP.ID equals PC.Pedido_ID
                    //                join PRO in hb.Productos_Insumos on PC.Producto_ID equals PRO.Codigo
                    //                where OP.Cliente_ID == (int)cmbCliente.SelectedValue
                    //                     && PC.Cantidad_Afectada != 0
                    //                select PC);

                    if (dgvPedidoProductos.RowCount > 0)
                    {
                        var Consulta = (from TT in hb.TT_Pedido_Cuerpo
                                        where TT.Cantidad_Afectada > 0 
                                        && TT.Usuario_ID == clsVariablesGenerales.UsuarioID 
                                        && TT.Sesion_ID == clsVariablesGenerales.SesionID
                                        select TT);

                        var Resultados = Consulta.FirstOrDefault();

                        if (Resultados != null)
                        {
                            if (cmbCliente.SelectedIndex != -1 && cmbCiudad.SelectedIndex != -1)
                            {
                                btnCargar.Enabled = true;
                            }
                        }
                        else
                        {
                            btnCargar.Enabled = false;
                        }
                    }
                }
            }
        }
        private void dgvPedidoProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            MostrarEstadosEnColores(e);
        }
        private void AbrirFormAfectarProducto()
        {
            string ProductoID;
            ProductoID = dgvPedidoProductos.CurrentRow.Cells[columnName: "colProductoID"].Value.ToString();

            var f = new frmSeleccionarProducto();
            f.ProductoID = ProductoID;
            f.CantidadParaAfectar = Convert.ToDecimal(txtCantidad.Text);
            f.ShowDialog();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Reutilizables.ValidarSoloNumeros2(txtCantidad);
            //AbrirFormAfectarProducto();
            AfectarPedido("2");
            OnOffBtnConfirnarordenPedido();
            // MostrarCantidadEntxt();         
        }

        private void dgvPedidoProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MostrarCantidadEntxt();
        }

        private void dgvPedidoProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MostrarCantidadEntxt();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            OnOffbtnEditarCantidad();
        }

        private void btnAfectados_Click(object sender, EventArgs e)
        {
            Indice = 0;
            AfectarAfectados = "2";
            OnOffbtnEditarCantidad();
            CambiarColorbtnSeleccionado("2", btnAfectados, btnAfectar, btnAfec);
            MostrarTTOrdenCargaCuerpo();
            OnOffBtnConfirnarordenPedido();
            dgvPedidoProductos.Focus();

            if (CrearEditar == "2")
            {
                btnEditar.Enabled = false;
            }
        }
        //private void Mostrargb
        private void chkFiltraNroPedido_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraNroPedido, chkFiltraNroPedido);
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

        private void chkFiltraProducto_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraProducto, cmbProducto, txtBuscarProducto, btnBuscarIProducto, "PRO", "NO");
        }

        private void btnBuscarIProducto_Click(object sender, EventArgs e)
        {
            txtBuscarProducto.Visible = true;
            txtBuscarProducto.Select();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (AfectarAfectados == "1")
                MostrarPedidoCuerpo("1", 999999999); // Se hace para que muestre todos los valores con cantidad igual o mayor a 0
            else
                MostrarPedidoCuerpo("2", 0); // Se hace para que muestre todos los registros diferentes a 0.

            OnOffbtnCargar();
        }

        private void btnAfec_Click(object sender, EventArgs e)
        {
            AfectarPedido("1"); // Desafecta la fila seleccionada de los afectados
            OnOffBtnConfirnarordenPedido();
        }

        private void txtBuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarCliente.Visible = false;
                clsCargarCombos.MostrarComboClientes(cmbCliente, txtBuscarCliente, true, "CLI",0);
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
            }
        }

        private void cmbCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboCiudades(cmbCiudad, txtBuscarCiudad, false);
            }
        }

        private void btnBuscarCiudad_Click(object sender, EventArgs e)
        {
            txtBuscarCiudad.Visible = true;
            txtBuscarCiudad.Select();
        }

        private void cmbCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboClientes(cmbCliente, txtBuscarCliente, false, "CLI", 0);
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarOrden();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnOffBtnConfirnarordenPedido();
        }

        private void cmbCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffBtnConfirnarordenPedido();
        }

        private void cmbCiudad_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            OnOffBtnConfirnarordenPedido();
        }

        private void btnDesafectar_Click(object sender, EventArgs e)
        {
            AfectarPedido("3"); // Desafecta el registro afectado
            OnOffBtnConfirnarordenPedido();
        }

        private void frmAgregarOrdenCarga_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void dgvPedidoProductos_SelectionChanged(object sender, EventArgs e)
        {
            //MostrarCantidadEntxt();
        }

        private void dgvPedidoProductos_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //MostrarCantidadEntxt();
        }

        private void dgvPedidoProductos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //MostrarCantidadEntxt();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            AnularOrden();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Reutilizables.ExportarExcel(dgvPedidoProductos);
        }
        private void AbrirFormSeleccionarProducto()
        {
            if (AfectarAfectados == "2")
            {
                string ProductoID;
                string ProductoDescripcion;
                decimal Cantidad;
                long PedidoID;
                string Estado;

                ProductoID = dgvPedidoProductos.CurrentRow.Cells[columnName: "colProductoID"].Value.ToString();
                ProductoDescripcion = dgvPedidoProductos.CurrentRow.Cells[columnName: "colProductoDescrip"].Value.ToString();
                Cantidad = (decimal)dgvPedidoProductos.CurrentRow.Cells[columnName: "colCantidadAfec"].Value;
                PedidoID = (long)dgvPedidoProductos.CurrentRow.Cells[columnName: "colID"].Value;
                Estado = txtEstado.Text;

                var f = new frmSeleccionarProducto();
                f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmSeleccionarProducto_FormClosed);
                f.ProductoID = ProductoID;
                f.CantidadParaAfectar = Cantidad;
                f.PedidoID = PedidoID;
                f.CrearEditar = CrearEditar;

                if (CrearEditar == "1" || CrearEditar == "3")
                    f.OrdenID = OrdenID;
                if (CrearEditar == "2")
                    f.OrdenID = Convert.ToInt64(txtNumeroOrden.Text.Remove(0,2));

                f.ProductoDescripcion = ProductoDescripcion;
                f.Estado = Estado;
                f.ShowDialog();
            }
        }
        private void frmSeleccionarProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (AfectarAfectados == "2")
            {
                MostrarTTOrdenCargaCuerpo();
            }
        }
        private void dgvPedidoProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirFormSeleccionarProducto();
        }

        private void txtCantidad_Click(object sender, EventArgs e)
        {
            txtCantidad.SelectAll();
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCantidad);
        }

        private void btnBuscarDesc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            if (AfectarAfectados == "1")
                MostrarPedidoCuerpo("1", 999999999);
            else
                MostrarTTOrdenCargaCuerpo();
        }

        private void btnBuscarAsc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            if (AfectarAfectados == "1")
                MostrarPedidoCuerpo("1", 999999999);
            else
                MostrarTTOrdenCargaCuerpo();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            MostrarPantallaEspera();
            clsQueryPlantillas.PlaOrdenCarga(IDRecibido, VisorReporte);
        }

        private void btnCargar_Click_1(object sender, EventArgs e)
        {
            CargarOrden();
        }

        private void btnAnular_Click_1(object sender, EventArgs e)
        {
            AnularOrden();
        }

        private void txtCantidad_TextChanged_1(object sender, EventArgs e)
        {
            OnOffbtnEditarCantidad();
        }

        private void txtFiltraNroPedido_Click(object sender, EventArgs e)
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
