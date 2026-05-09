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
using PCodin_Sinlacc.Clases.UsuarioTema;
using PCodin_Sinlacc.Datos;
using PCodin_Sinlacc.Formularios;
using PCodin_Sinlacc.Formularios.Notificación;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmAgregarNuevoPedidoMOBILE : Form
    {
        public string PulsoAgregarEditar;
        public long IdRecibido;
        public string EstadoOrden = ""; // creada exclusivamente para que cuando carga productos al cuerpo no valide stcok cuando es INF
        long ID;
        long PedidoCuerpoID = 0;
        long IDFicticio = 0;
        public int UsuarioID;
        public frmMenu FormMenu;
        frmFormMovimientoFinalizado FrmMovFinalizado = new frmFormMovimientoFinalizado();

        //  decimal NuevoStockPendiente = 0;
        string NuevoProducto_ID;
        public frmAgregarNuevoPedidoMOBILE()
        {
            InitializeComponent();
        }

        private void frmAgregarNuevoPedido_Load(object sender, EventArgs e)
        {
            Reutilizables.RenderizarForm(this);
            InicializarForm();
        }
        public void ExportarExcel(DataGridView DGV)
        {
            Reutilizables.ExportarExcel(dgvPedidoProductos);
        }
        private void InicializarForm()
        {
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
            clsCargarCombos.MostrarComboClientes(cmbCliente, txtBuscarCliente, false, "CLI", 0);
            clsCargarCombos.MostrarComboCiudades(cmbCiudad, txtBuscarCiudad, false);
            clsCargarCombos.MostrarComboZona(cmbZona);
            clsCargarCombos.MostrarComboInsProConMedida(cmbProducto, cmbMedida, txtBuscarProducto, "PRO", false);
            clsCargarCombos.MostrarComboVendores(cmbResponsable, txtBuscarResponsable, false);

            if (PulsoAgregarEditar == "1")
            {
                CalcularNumeroPedido();
                btnCargar.Text = "Cargar Pedido";
                btnInvalidar.Enabled = false;
                OnoffbtnAgregarEditarCantidad();
                cmbCliente.SelectedIndex = -1;
                cmbCiudad.SelectedIndex = -1;
                cmbZona.SelectedIndex = -1;
                cmbResponsable.SelectedIndex = -1;
            }
            if (PulsoAgregarEditar == "2")
            {

                cmbCliente.Enabled = false;
                cmbCiudad.Enabled = false;

                using (var hb = new DBdatos())
                {
                    btnCargar.Text = "Editar Pedido";
                    gbxEstadoPedido.Enabled = false;

                    var ConsultaPedido = (from P in hb.Registro_Pedidos
                                          where P.ID == IdRecibido
                                          select P);

                    var ResultadoPedido = ConsultaPedido.FirstOrDefault();

                    if (ResultadoPedido != null)
                    {
                        dtpFecha.Value = ResultadoPedido.Fecha;
                        cmbCliente.SelectedValue = ResultadoPedido.Cliente_ID;
                        cmbCliente.Text = ResultadoPedido.Clientes.Descripcion;
                        cmbCiudad.SelectedValue = ResultadoPedido.Ciudad_ID;
                        cmbCiudad.Text = ResultadoPedido.Ciudades.Descripcion;

                        if (ResultadoPedido.Zona_ID != null)
                        {
                            cmbZona.SelectedValue = ResultadoPedido.Zona_ID;
                            cmbZona.Text = ResultadoPedido.ZONA.Descripcion;
                        }
                        else
                            cmbZona.SelectedIndex = -1;
                       
                        cmbResponsable.SelectedValue = ResultadoPedido.Empleado_ID;
                        cmbResponsable.Text = ResultadoPedido.Empleados.Nombre;

                        if (ResultadoPedido.Estado_ID == "INF")
                            rdbInform.Checked = true;
                        if (ResultadoPedido.Estado_ID == "AU")
                            rdbAutorizado.Checked = true;
                        if (ResultadoPedido.Estado_ID == "FI")
                            rdbFinalizado.Checked = true;

                        txtNumeroPedido.Text = ResultadoPedido.Numero_Pedido.ToString();
                        txtEstado.Text = ResultadoPedido.Estado_Ord_Carga.Descripcion;

                        if (ResultadoPedido.Estado_ID == "AU")
                            txtEstado.ForeColor = Color.Black;
                        if (ResultadoPedido.Estado_ID == "FI")
                            txtEstado.ForeColor = Color.Green;
                        if (ResultadoPedido.Estado_ID == "AN")
                            txtEstado.ForeColor = Color.Red;
                        if (ResultadoPedido.Estado_ID == "INF")
                            txtEstado.ForeColor = Color.Blue;


                        var ConsultaCuerpoPedido = (from PC in hb.Pedido_Cuerpo
                                                    where PC.Pedido_ID == IdRecibido
                                                    select PC);

                        var ResultadosCuerpoPedido = ConsultaCuerpoPedido.ToList();
                        lblResultados.Text = ResultadosCuerpoPedido.Count.ToString();

                        if (ResultadosCuerpoPedido.Count > 0)
                        {
                            foreach (var item in ResultadosCuerpoPedido)
                            {
                                var ConsultaStock = (from VS in hb.Vista_Stock
                                                     where VS.Codigo == item.Producto_ID
                                                     select VS);

                                var ResultadosStock = ConsultaStock.FirstOrDefault();

                                //dgvPedidoProductos.Rows.Add("", cmbProducto.SelectedValue, cmbProducto.Text, cmbMedida.Text, txtCantidad.Text, txtPrecio.Text, CantidadPallet.ToString("N2"), txtCantidad.Text, 0, "Pendiente", cmbMedida.SelectedValue, "PEN", "", "", txtCantidad.Text, 0);
                                dgvPedidoProductos.Rows.Add(item.ID, item.Producto_ID, item.Productos_Insumos.Descripcion, item.Productos_Insumos.Medidas_Producto.Descripcion, item.Cantidad, item.Precio, item.Pallets, 0, 0, "", item.Medida_ID, "", "", "", 0, 0);


                                //DataGridViewRow Fila = new DataGridViewRow();

                                //Fila.CreateCells(dgvPedidoProductos);
                                //Fila.Cells[0].Value = item.ID;
                                //Fila.Cells[1].Value = item.Producto_ID;
                                //Fila.Cells[2].Value = item.Productos_Insumos.Descripcion;
                                //Fila.Cells[3].Value = item.Productos_Insumos.Medidas_Producto.Descripcion;
                                //Fila.Cells[4].Value = item.Cantidad + item.Cantidad_Total_Entregada; // Cantidad entregada original
                                //Fila.Cells[5].Value = item.Cantidad; // pendiente
                                //Fila.Cells[6].Value = item.Cantidad_Total_Entregada; // Total afectada
                                //Fila.Cells[7].Value = item.Estado_Pedido_Cuerpo.Descripcion;
                                //Fila.Cells[8].Value = item.Medida_ID;
                                //Fila.Cells[9].Value = item.Estado_ID;
                                ////  Fila.Cells[10].Value = item.ID;
                                //Fila.Cells[11].Value = ResultadosStock.Pendiente; // SE HACE PARA AGREGAR EL STOCK PENDIENTE DE LA VS PARA AYUDAR A MODIFICAR LAS CANTIDADES DEL PEDIDO
                                //Fila.Cells[12].Value = (item.Cantidad + item.Cantidad_Total_Entregada) - item.Cantidad_Total_Producida; // Se hace así porque la columna cantidad no es la Cantidad original sino que la pendiente
                                //Fila.Cells[13].Value = item.Cantidad_Total_Producida;

                                //dgvPedidoProductos.Rows.Add(Fila);
                            }
                        }
                    }
                    if (ResultadoPedido.Estado_ID != "AN")
                    {
                        btnInvalidar.Enabled = true;
                        gbxEstadoPedido.Enabled = true;

                        if (ResultadoPedido.Estado_ID == "AU")
                        {
                            gbxEstadoPedido.Enabled = true;
                           // rdbInform.Enabled = false;
                        }
                        if (ResultadoPedido.Estado_ID == "INF")
                        {
                            gbxEstadoPedido.Enabled = true;
                            rdbAutorizado.Enabled = true;
                        }
                        if (ResultadoPedido.Estado_ID == "FI")
                        {
                            gbxEstadoPedido.Enabled = false;
                            rdbInform.Enabled = false;
                            btnCargar.Visible = false;
                        }
                    }
                    else
                    {
                        btnInvalidar.Enabled = false;
                        btnCargar.Visible = false;
                        btnEliminarProducto.Visible = false;
                        btnConfirmarProducto.Enabled = false;
                        btnEditarCantidad.Enabled = false;
                        gbxEstadoPedido.Enabled = false;
                    }
                }
            }
            if (PulsoAgregarEditar == "3")
            {
                using (var hb = new DBdatos())
                {
                    CalcularNumeroPedido();

                    btnCargar.Text = "Cargar Pedido";
                    gbxEstadoPedido.Enabled = true;
                    rdbAutorizado.Checked = true;

                    var ConsultaPedido = (from P in hb.Registro_Pedidos
                                          where P.ID == IdRecibido
                                          select P);

                    var ResultadoPedido = ConsultaPedido.FirstOrDefault();

                    if (ResultadoPedido != null)
                    {
                        dtpFecha.Value = ResultadoPedido.Fecha;
                        cmbCliente.SelectedValue = ResultadoPedido.Cliente_ID;
                        cmbCliente.Text = ResultadoPedido.Clientes.Descripcion;
                        cmbCiudad.SelectedValue = ResultadoPedido.Ciudad_ID;
                        cmbCiudad.Text = ResultadoPedido.Ciudades.Descripcion;
                        cmbResponsable.SelectedValue = ResultadoPedido.Empleado_ID;
                        cmbResponsable.Text = ResultadoPedido.Empleados.Nombre;
                        //txtNumeroPedido.Text = PEDID
                        // txtEstado.Text = ResultadoPedido.Estado_Ord_Carga.Descripcion;

                        if (ResultadoPedido.Estado_ID == "AU")
                            txtEstado.ForeColor = Color.Black;
                        if (ResultadoPedido.Estado_ID == "FI")
                            txtEstado.ForeColor = Color.Green;
                        if (ResultadoPedido.Estado_ID == "AN")
                            txtEstado.ForeColor = Color.Red;
                        if (ResultadoPedido.Estado_ID == "INF")
                            txtEstado.ForeColor = Color.Blue;

                        var ConsultaCuerpoPedido = (from PC in hb.Pedido_Cuerpo
                                                    where PC.Pedido_ID == IdRecibido
                                                    select PC);

                        var ResultadosCuerpoPedido = ConsultaCuerpoPedido.ToList();

                        if (ResultadosCuerpoPedido.Count > 0)
                        {
                            foreach (var item in ResultadosCuerpoPedido)
                            {
                                var ConsultaStock = (from VS in hb.Vista_Stock
                                                     where VS.Codigo == item.Producto_ID
                                                     select VS);

                                var ResultadosStock = ConsultaStock.FirstOrDefault();

                                DataGridViewRow Fila = new DataGridViewRow();

                                Fila.CreateCells(dgvPedidoProductos);

                                Fila.Cells[0].Value = item.ID;
                                Fila.Cells[1].Value = item.Producto_ID;
                                Fila.Cells[2].Value = item.Productos_Insumos.Descripcion;
                                Fila.Cells[3].Value = item.Productos_Insumos.Medidas_Producto.Descripcion;
                                Fila.Cells[4].Value = item.Cantidad + item.Cantidad_Total_Entregada; // Cantidad original
                                Fila.Cells[5].Value = item.Cantidad + item.Cantidad_Total_Entregada; // pendiente
                                Fila.Cells[6].Value = 0; // Total afectada
                                Fila.Cells[7].Value = "Pendiente";
                                Fila.Cells[8].Value = item.Medida_ID;
                                Fila.Cells[9].Value = item.Estado_ID;
                                //  Fila.Cells[10].Value = item.ID;
                                Fila.Cells[11].Value = ResultadosStock.Pendiente; // SE HACE PARA AGREGAR EL STOCK PENDIENTE DE LA VS PARA AYUDAR A MODIFICAR LAS CANTIDADES DEL PEDIDO
                                Fila.Cells[12].Value = item.Cantidad + item.Cantidad_Total_Entregada;
                                Fila.Cells[13].Value = 0;

                                dgvPedidoProductos.Rows.Add(Fila);
                            }
                        }
                    }
                    btnInvalidar.Visible = false;
                    btnCargar.Visible = true;
                }
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
                    string EstadoID = dgvPedidoProductos.Rows[i - 1].Cells[columnName: "colEstado"].Value.ToString();

                    if (ProductoID != cmbFiltraProducto.SelectedValue.ToString())
                    {
                        if (chkFiltraEstado.Checked)
                        {
                            if (ProductoID != cmbFiltraProducto.SelectedValue.ToString() && EstadoID != cmbFiltraEstado.Text)
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
                else if (chkFiltraEstado.Checked)
                {
                    string ProductoID = dgvPedidoProductos.Rows[i - 1].Cells[columnName: "colProductoID"].Value.ToString();
                    string EstadoID = dgvPedidoProductos.Rows[i - 1].Cells[columnName: "colEstado"].Value.ToString();

                    if (EstadoID != cmbFiltraEstado.Text)
                    {
                        if (chkFiltraProducto.Checked)
                        {
                            if (ProductoID != cmbFiltraProducto.SelectedValue.ToString() && EstadoID != cmbFiltraEstado.Text)
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
        private void OnoffbtnAgregarEditarCantidad()
        {
            if (!rdbInform.Checked && !rdbAutorizado.Checked && !rdbFinalizado.Checked)
            {
                btnConfirmarProducto.Enabled = false;
                btnEditarCantidad.Enabled = false;
            }
            else
            {
                btnConfirmarProducto.Enabled = true;
                btnEditarCantidad.Enabled = true;
            }
        }
        private void EliminarRegstroAlCambiarEstado()
        {
            //SI ESTADO ORDEN QUE SALE DE CADA RDB ES DIFERENTE A VACIO Y SE ESTÁ CREANDO NUEVA ORDEN
            if (dgvPedidoProductos.RowCount > 0 && EstadoOrden != "" && PulsoAgregarEditar == "1")
            {
                DialogResult R = MessageBox.Show("Si cambia de estado se eliminaran todos los productos de la lista de pedido, ¿Continua?", "Atención", MessageBoxButtons.YesNo);
                if (R == DialogResult.Yes)
                {
                    dgvPedidoProductos.Rows.Clear();
                }
            }
        }
        private void NodejarModificarCantidadACompletos() // AQUI QUEDE
        {
            if (dgvPedidoProductos.RowCount > 0)
            {
                using (var hb = new DBdatos())
                {
                    if (txtCantidad.Text != "0")
                    {
                        string Producto_ID = dgvPedidoProductos.CurrentRow.Cells[columnName: "colProductoID"].Value.ToString();
                        decimal Cantidad = (decimal)dgvPedidoProductos.CurrentRow.Cells[columnName: "colCantidadOriginal"].Value;
                        decimal CantidadPend = (decimal)dgvPedidoProductos.CurrentRow.Cells[columnName: "colCantidadPend"].Value;
                        decimal CantidadAfect = Convert.ToDecimal(dgvPedidoProductos.CurrentRow.Cells[columnName: "colCantidadAfec"].Value);
                        decimal NuevaCantidad = Convert.ToDecimal(txtCantidad.Text);
                        decimal CantidadProducida = Convert.ToDecimal(dgvPedidoProductos.CurrentRow.Cells[columnName: "colCantidadProducida"].Value);
                        //  decimal NuevoStockPendiente = (decimal)dgvPedidoProductos.CurrentRow.Cells[11].Value; SE QUITO EL 21/02/2022

                        var ConsultaStock = (from VS in hb.Vista_Stock
                                             where VS.Codigo == Producto_ID
                                             select VS);

                        var ResultadosStock = ConsultaStock.FirstOrDefault();

                        if (ResultadosStock != null)
                        {
                            if (NuevaCantidad >= CantidadAfect && NuevaCantidad >= CantidadProducida)
                            {
                                // SI EL PEDIDO ESTA AUTORIZADO
                                if (rdbAutorizado.Checked)
                                {
                                    // SI PRODUCTO ESTA EN LA LISTA
                                    //if (dgvPedidoProductos.CurrentRow.Cells[0].Value == null)

                                    if (CantidadAfect == 0)
                                    {
                                        //if (ResultadosStock.Existencia + ((ResultadosStock.Pendiente + CantidadPend) - NuevaCantidad) < 0)
                                        //if(ResultadosStock.Existencia + (NuevoStockPendiente + CantidadPend - NuevaCantidad) < 0)
                                        //{                                           
                                        //    string Mensaje = "La cantidad del producto " + ResultadosStock.DescripcionProducto + " " + "es insuficiente para completar este pedido" + "\r\n" + "\r\n"
                                        //                    + "Cantidad requerida: " + NuevaCantidad.ToString("N2") + "\r\n"
                                        //                    + "Stock real: " + ResultadosStock.StockReal.ToString() + "\r\n" + "\r\n"
                                        //                    + "Necesita para completar pedido: " + ((NuevoStockPendiente * -1 - CantidadPend + NuevaCantidad) - ResultadosStock.Existencia).ToString();

                                        //    MessageBox.Show(Mensaje, "Atención");
                                        //    return;
                                        //}
                                        //else
                                        //{
                                        //    //if (ResultadosStock.Pendiente != 0)
                                        //    //{
                                        //    //    NuevoStockPendiente = NuevoStockPendiente + CantidadPend - NuevaCantidad;
                                        //    //}
                                        //    //else
                                        //    //{
                                        //    //    NuevoStockPendiente = -NuevaCantidad;
                                        //    //}




                                        //    //string Mensaje = "Stock suficiente para el producto " + ResultadosStock.DescripcionProducto + "\r\n" + "\r\n"
                                        //    //             + "Stock disponible: " + (ResultadosStock.Existencia + NuevoStockPendiente).ToString();

                                        //    ////  (ResultadosStock.Existencia + ((ResultadosStock.Pendiente + CantidadPend) - NuevaCantidad)).ToString();

                                        //    //MessageBox.Show(Mensaje, "Atención");
                                        //    //dgvPedidoProductos.CurrentRow.Cells[11].Value = NuevoStockPendiente;
                                        //}
                                    }
                                    // SI PRODUCTO NO ESTA EN LA LISTA
                                    else
                                    {
                                        ////if (ResultadosStock.Existencia - (ResultadosStock.Pendiente + (NuevaCantidad + CantidadAfect)) < 0)
                                        //if(ResultadosStock.Existencia  < (NuevaCantidad - CantidadAfect))
                                        //{
                                        //    string Mensaje = "La cantidad del producto " + ResultadosStock.DescripcionProducto + " " + "es insuficiente para completar este pedido" + "\r\n" + "\r\n"
                                        //                + "Cantidad requerida: " + NuevaCantidad.ToString("N2") + "\r\n"
                                        //                + "Stock real: " + ResultadosStock.StockReal.ToString() + "\r\n" + "\r\n"
                                        //                + "Necesita para completar pedido: " + (((NuevoStockPendiente *-1 - CantidadPend) + (NuevaCantidad - CantidadAfect)) - ResultadosStock.Existencia).ToString(); // EL *-1 ES UNA FORMA PARA QUE EL STOCK FALTANTE NO DE NEGATIVO

                                        //    MessageBox.Show(Mensaje, "Atención");
                                        //    return;
                                        //}
                                        //else
                                        //{
                                        //   // if (ResultadosStock.Pendiente != 0)
                                        //   // {
                                        //   //     NuevoStockPendiente = NuevoStockPendiente + CantidadPend - (NuevaCantidad - CantidadAfect);
                                        //   // }
                                        //   // else
                                        //   // {
                                        //   //     NuevoStockPendiente = -NuevaCantidad;
                                        //   // }

                                        //   // string Mensaje = "Stock suficiente para el producto " + ResultadosStock.DescripcionProducto + "\r\n" + "\r\n"
                                        //   //                + "Stock disponible: " + (ResultadosStock.Existencia + NuevoStockPendiente).ToString();

                                        //   //// (ResultadosStock.Existencia - (ResultadosStock.Pendiente + (NuevaCantidad + CantidadAfect))).ToString();
                                        //   // MessageBox.Show(Mensaje, "Atención");
                                        //   // dgvPedidoProductos.CurrentRow.Cells[11].Value = NuevoStockPendiente;
                                        //}
                                    }
                                }
                                if (rdbInform.Checked == false)
                                {
                                    dgvPedidoProductos.CurrentRow.Cells[columnName: "colCantidadOriginal"].Value = NuevaCantidad;
                                    dgvPedidoProductos.CurrentRow.Cells[columnName: "colCantidadPend"].Value = NuevaCantidad - CantidadAfect;

                                    dgvPedidoProductos.CurrentRow.Cells[columnName: "colPendienteProducir"].Value = NuevaCantidad - CantidadProducida;
                                }
                                if (NuevaCantidad == CantidadAfect)
                                {
                                    dgvPedidoProductos.CurrentRow.Cells[columnName: "colEstado"].Value = "Completo";
                                    dgvPedidoProductos.CurrentRow.Cells[columnName: "colEstado_ID"].Value = "COM";
                                }
                                else
                                {
                                    dgvPedidoProductos.CurrentRow.Cells[columnName: "colEstado"].Value = "Pendiente";
                                    dgvPedidoProductos.CurrentRow.Cells[columnName: "colEstado_ID"].Value = "PEN";
                                }
                            }
                            else
                            {
                                MessageBox.Show("La cantidad total nunca puede ser menor a la cantidad entregada o a la cantidad producida");
                            }
                        }
                    }
                }
            }
        }
        private void CalcularNumeroPedido()
        {
            if (PulsoAgregarEditar == "1" || PulsoAgregarEditar == "3")
            {
                using (var hb = new DBdatos())
                {
                    var Consulta = (from P in hb.Registro_Pedidos
                                    orderby P.ID descending
                                    select P).FirstOrDefault();

                    if (Consulta == null)
                    {
                        txtNumeroPedido.Text = "P" + 1;
                    }
                    else
                    {
                        txtNumeroPedido.Text = "P" + (Consulta.ID + 1).ToString();
                    }
                }
            }
        }
        private void OnOffbtnCargarEditar()
        {
            if (PulsoAgregarEditar == "1")
            {
                if (cmbCliente.SelectedIndex != -1
                    && cmbCiudad.SelectedIndex != -1
                    && (rdbInform.Checked || rdbAutorizado.Checked)
                    && dgvPedidoProductos.RowCount > 0)
                {
                    btnCargar.Enabled = true;
                }
                else
                {
                    btnInvalidar.Enabled = false;
                }
            }
            else
            {
                if (cmbCliente.SelectedIndex != -1
                   && cmbCiudad.SelectedIndex != -1
                   && dgvPedidoProductos.RowCount > 0)
                {
                    btnCargar.Enabled = true;
                }
                else
                {
                    btnCargar.Enabled = false;
                }
            }
        }
        private void CalcularID()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from PED in hb.Registro_Pedidos
                                orderby PED.ID descending
                                select PED).FirstOrDefault();

                if (Consulta == null)
                {
                    ID = 1;
                }
                else
                {
                    ID = Consulta.ID + 1;
                }
            }
        }
        private void CargarPedido()
        {
            try
            {
                using (var hb = new DBdatos())
                {
                    CalcularID();

                    var ConsultaNumPedido = (from P in hb.Registro_Pedidos
                                             where P.Numero_Pedido == txtNumeroPedido.Text
                                             select P).FirstOrDefault();

                    if (ConsultaNumPedido != null)
                    {
                        MessageBox.Show("Ya existe un pedido con el número " + txtNumeroPedido.Text + " por favor ingrese otro diferente", "Atención");
                        return;
                    }
                    if (dgvPedidoProductos.RowCount == 0)
                    {
                        MessageBox.Show("No hay productos en lista", "Atención");
                        return;
                    }

                    var i = new Registro_Pedidos();

                    i.ID = ID;
                    i.Numero_Pedido = txtNumeroPedido.Text;
                    i.Fecha = dtpFecha.Value.Date;
                    i.Cliente_ID = (int)cmbCliente.SelectedValue;
                    i.Ciudad_ID = (int)cmbCiudad.SelectedValue;
                    i.Empleado_ID = (int)cmbResponsable.SelectedValue;
                    i.Zona_ID = (int)cmbZona.SelectedValue;
                    
                    if (rdbInform.Checked)
                        i.Estado_ID = "INF";
                    else
                        i.Estado_ID = "AU";

                    i.Observaciones = txtObservaciones.Text;

                    List<string> ListaID = new List<string>();

                    for (int c = 1; c <= dgvPedidoProductos.Rows.Count; c++)
                    {
                        CalcularPedidoCuerpoID();

                        string ProductoID = dgvPedidoProductos.Rows[c - 1].Cells["colProductoID"].Value.ToString();
                        string Producto_Descrip = dgvPedidoProductos.Rows[c - 1].Cells["colProductoDescrip"].Value.ToString();
                        decimal Cantidad = Convert.ToDecimal(dgvPedidoProductos.Rows[c - 1].Cells["colCantidadOriginal"].Value);
                        decimal Precio = Convert.ToDecimal(dgvPedidoProductos.Rows[c - 1].Cells["colPrecio"].Value);
                        decimal Pallets = Convert.ToDecimal(dgvPedidoProductos.Rows[c - 1].Cells["colPallets"].Value);

                        var ConsultaStock1 = (from EP in hb.Existencia_Productos
                                              where EP.Producto_ID == ProductoID
                                              select EP);

                        var ResultadosStock = ConsultaStock1.FirstOrDefault();

                        if (rdbInform.Checked || rdbAutorizado.Checked)
                        {
                            var z = new Pedido_Cuerpo();

                            z.ID = PedidoCuerpoID;
                            z.Producto_ID = ProductoID;
                            z.Cantidad = Cantidad; // Cantidad Pend
                            z.Pallets = Pallets;
                            z.Precio = Precio;
                            z.Cantidad_Total_Entregada = 0;
                            z.Cantidad_Entregada = 0;
                            z.Medida_ID = (int)cmbMedida.SelectedValue;
                            z.Estado_ID = "PEN";
                            z.Cantidad_Pend_Producir = Cantidad;
                            z.Cantidad_Producida = 0;
                            z.Cantidad_Afec_Producir = 0;
                            z.Cantidad_Total_Producida = 0;
                            z.Pedido_ID = ID;

                            hb.Pedido_Cuerpo.Add(z);
                            ListaID.Add(ProductoID);
                        }
                    }
                    hb.Registro_Pedidos.Add(i);
                    hb.SaveChanges();
                    // FrmMovFinalizado.ShowDialog();
                    MessageBox.Show("Pedido cargado correctamente", "Atencion");


                    //TODO LO DE ABAJO DESCOMENTAR SE COMENTO A PROPOSITO POR NOTIFICACIONES

                    // CONSULTA NUEVAMENTE EL STOCK PARA VER SI TIENE QUE NOTIFICAR
                    //var ConsultaStock2 = (from VS in hb.Vista_Stock
                    //                      where ListaID.Contains(VS.Codigo)
                    //                      select VS).ToList();

                    // ESTE RESTO ES PARA LAS NOTIFICACIONES
                    //bool Notificacion = false;
                    //foreach (var item in ConsultaStock2)
                    //{


                    //    var ConsultaIP = (from PI in hb.Productos_Insumos
                    //                      where PI.Codigo == item.Codigo
                    //                      select PI).FirstOrDefault();

                    //    if (item.StockReal <= item.StockMin && ConsultaIP.NotificaPuntoPedido == "SI") // SI EL STOK REAL ES MENOR AL MINIMO Y EL PRODUCTO ESTÁ CONFIG PARA NOTIFICAR
                    //    {
                    //        var Z = new Notificaciones();

                    //        Z.Descripcion = "El Producto " + item.DescripcionProducto + " - " + item.Codigo + " alcanzó su STOCK MINIMO";
                    //        Z.Leida = "NO";
                    //        Z.Tipo_ID = 1;
                    //        Z.Fecha = DateTime.Now.Date;
                    //        Z.Hora = DateTime.Now.TimeOfDay;

                    //        hb.Notificaciones.Add(Z);
                    //        MessageBox.Show("El Producto " + item.DescripcionProducto + " - " + item.Codigo + " alcanzó su STOCK MINIMO", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //        Notificacion = true;
                    //        hb.Notificaciones.Add(Z);
                    //    }
                    //}
                    //if (Notificacion == true)
                    //{
                    //    var f = new frmAlertas();
                    //    f.ShowDialog();
                    //}
                    //hb.SaveChanges();
                    this.Hide();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void ConsultarStock()
        {
            if (dgvPedidoProductos.RowCount > 0)
            {
                using (var hb = new DBdatos())
                {
                    for (int c = 1; c <= dgvPedidoProductos.Rows.Count; c++)
                    {
                        if (dgvPedidoProductos.Rows[c - 1].Cells[9].Value.ToString() == "PEN")
                        {
                            string ProductoID = dgvPedidoProductos.Rows[c - 1].Cells[1].Value.ToString();
                            string Producto_Descrip = dgvPedidoProductos.Rows[c - 1].Cells[2].Value.ToString();
                            decimal Cantidad = Convert.ToDecimal(dgvPedidoProductos.Rows[c - 1].Cells[4].Value);

                            var ConsultaStock = (from VS in hb.Vista_Stock
                                                 where VS.Codigo == ProductoID
                                                 select VS);

                            var ResultadosStock = ConsultaStock.FirstOrDefault();

                            if (ResultadosStock.StockReal < Cantidad)
                            {
                                string Mensaje = "La cantidad del producto " + Producto_Descrip + " " + "es insuficiente para completar este pedido" + "\r\n" + "\r\n"
                                                + "Cantidad requerida: " + Cantidad.ToString("N2") + "\r\n"
                                                + "Stock real: " + ResultadosStock.StockReal.ToString() + "\r\n" + "\r\n"
                                                + "Necesita para completar pedido: " + (Cantidad - ResultadosStock.StockReal).ToString();

                                MessageBox.Show(Mensaje, "Atención");
                                dgvPedidoProductos.Rows.Remove(dgvPedidoProductos.Rows[c - 1]);
                            }
                            else
                            {
                                string Mensaje = "Stock suficiente para el producto " + Producto_Descrip + "\r\n" + "\r\n"
                                                + "Stock disponible: " + (ResultadosStock.StockReal - Cantidad).ToString();

                                MessageBox.Show(Mensaje, "Atención");
                            }
                        }
                    }
                }
            }
        }
        private void EditarPedido()
        {
            using (var hb = new DBdatos())
            {
                try
                {
                    var Consulta = (from R in hb.Registro_Pedidos
                                    where R.ID == IdRecibido
                                    select R).FirstOrDefault();

                    Consulta.Fecha = dtpFecha.Value.Date;
                    Consulta.Empleado_ID = (int)cmbResponsable.SelectedValue;
                    Consulta.Zona_ID = (int)cmbZona.SelectedValue;
                    Consulta.Zona_ID = (int)cmbZona.SelectedValue;

                    if (rdbFinalizado.Checked == false)
                    {
                        if (Consulta.Estado_ID == "INF" || Consulta.Estado_ID == "AU" && rdbFinalizado.Checked == false)
                        {
                            if (rdbInform.Checked)
                                Consulta.Estado_ID = "INF";
                            if (rdbAutorizado.Checked)
                                Consulta.Estado_ID = "AU";
                        }
                        else
                        {
                            MessageBox.Show("No se puede finalizar un pedido de forma manual", "Error");
                        }
                    }
                    else
                        pnlEstadoPedido.Enabled = false;

                    hb.SaveChanges();
                    MessageBox.Show("Datos modificados correctamente", "Atención");
                   
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error");
                }
            }
            //using (var hb = new DBdatos())
            //{
            //    int CantidadDePendientes = 0; // CANTIDAD DE REGISTROS CON CANTIDAD PENDIENTE

            //    for (int c = 1; c <= dgvPedidoProductos.Rows.Count; c++)
            //    {
            //        if (dgvPedidoProductos.Rows[c - 1].Cells[columnName: "colID"].Value != null && dgvPedidoProductos.Rows[c - 1].Cells[columnName: "colID"].Value.ToString() != "")
            //        {
            //            PedidoCuerpoID = (long)dgvPedidoProductos.Rows[c - 1].Cells["colID"].Value;
            //        }
            //        else
            //        {
            //            PedidoCuerpoID = 0;
            //            CalcularPedidoCuerpoID();
            //        }

            //        string Producto_ID = dgvPedidoProductos.Rows[c - 1].Cells[1].Value.ToString();
            //        string Medida = dgvPedidoProductos.Rows[c - 1].Cells[3].Value.ToString();
            //        int Medida_ID = (int)dgvPedidoProductos.Rows[c - 1].Cells[8].Value;
            //        decimal Cantidad = Convert.ToDecimal(dgvPedidoProductos.Rows[c - 1].Cells[4].Value);

            //        //CONSULTA LA TABLA PEDIDO CUERPO SEG
            //        var Consulta = (from FP in hb.Pedido_Cuerpo
            //                        where FP.ID == PedidoCuerpoID
            //                        select FP);


            //        var Validacion = Consulta.FirstOrDefault(); // Validación para no cargar renglon con mismo formula

            //        // SI EN LA BD NO HAY NINGUN PRODUCTO CON ESTAS CARCATERISTICAS , CREA UNO
            //        if (Validacion == null)
            //        {
            //            var z = new Pedido_Cuerpo();

            //            z.ID = PedidoCuerpoID;
            //            z.Pedido_ID = IdRecibido;
            //            z.Producto_ID = Producto_ID;
            //            z.Cantidad = Cantidad;
            //            z.Medida_ID = Medida_ID;
            //            z.Estado_ID = "PEN";
            //            z.Cantidad_Pend_Producir = Cantidad;
            //            z.Cantidad_Total_Producida = 0;
            //            z.Cantidad_Producida = 0;
            //            z.Cantidad_Afec_Producir = 0;

            //            hb.Pedido_Cuerpo.Add(z);
            //        }
            //        else
            //        {
            //            //AJUSTA LAS CANTIDADES DEL PEDIDO CUERPO
            //            Validacion.Cantidad = (Cantidad - Validacion.Cantidad_Total_Entregada);

            //            //AJUSTA EL PENDIENTE DE PRODUCIR
            //            if (Validacion.Cantidad_Afec_Producir == 0)
            //                Validacion.Cantidad_Pend_Producir = Cantidad;
            //            else
            //            {
            //                decimal CantidadAnterior = (decimal)Validacion.Cantidad;
            //                decimal NuevaCantidad = Cantidad - CantidadAnterior;

            //                if (NuevaCantidad > CantidadAnterior)
            //                    Validacion.Cantidad_Pend_Producir = Validacion.Cantidad_Pend_Producir + NuevaCantidad;
            //                else
            //                    Validacion.Cantidad_Pend_Producir = Validacion.Cantidad_Pend_Producir - (NuevaCantidad * -1);

            //            }
            //        }
            //        // SE COMPRUEBA QUE NO HAYA NINGUN RESGISTRO CON CANTIDAD PENDIENTE , SI ES ASI ACTIVA EL ACUMULADOR Y SI EL ACU ES MAYOR A 0 QUIERE DECIR QUE EL PEDIDO NO SE FINALIZARA PORQUE TIENE PENDIENTE
            //        if (Convert.ToDecimal(dgvPedidoProductos.Rows[c - 1].Cells["colCantidadPend"].Value) > 0)
            //        {
            //            CantidadDePendientes = CantidadDePendientes + 1;
            //        }
            //        else
            //        {
            //            Validacion.Estado_ID = "COM";
            //        }
            //    }
            //    // CONSULTA EL PEDIDO PARA EDITAR EL ESTADO EN CASO DE QUE SE EDITE
            //    var ConsultaPedido = (from RP in hb.Registro_Pedidos
            //                          where RP.ID == IdRecibido
            //                          select RP).FirstOrDefault();

            //    var ConsultaNumPedido = (from RP in hb.Registro_Pedidos
            //                             where RP.Numero_Pedido == txtNumeroPedido.Text
            //                             select RP).FirstOrDefault();

            //    ConsultaPedido.Fecha = dtpFecha.Value.Date;
            //    ConsultaPedido.Empleado_ID = (int)cmbResponsable.SelectedValue;


            //    if (ConsultaPedido.Numero_Pedido != txtNumeroPedido.Text)
            //    {
            //        if (ConsultaNumPedido != null)
            //        {
            //            MessageBox.Show("Ya existe un pedido con el número " + txtNumeroPedido.Text + " por favor ingrese otro diferente", "Atención");
            //            return;
            //        }
            //    }

            //    // SI ESTA FINALIZADO
            //    if (rdbFinalizado.Checked == true)
            //    {
            //        // SI LA CANTIDAD PENDIENTE ES MAYOR A 0
            //        if (CantidadDePendientes > 0 && rdbFinalizado.Checked)
            //        {
            //            MessageBox.Show("El pedido pasara a estado AUTORIZADO ya que hay cantidades pendientes", "Atención");
            //            ConsultaPedido.Estado_ID = "AU";
            //        }
            //        // SI LA CANTIDAD PENDIENTE ES = A 0
            //        if (CantidadDePendientes == 0)
            //        {
            //            MessageBox.Show("El pedido pasara a estado FINALIZADO ya que hay cantidades pendientes", "Atención");
            //            ConsultaPedido.Estado_ID = "FI";

            //        }
            //    }
            //    // SINO ESTA FINALIZADO
            //    if (rdbAutorizado.Checked)
            //    {
            //        // SI ESTA AUTORIZADO Y CON PENDIENTES
            //        if (rdbAutorizado.Checked && CantidadDePendientes > 0)
            //            ConsultaPedido.Estado_ID = "AU";

            //        // SI ESTA AUTORIZADO Y SIN PENDIENTES - FINALIZA
            //        if (rdbAutorizado.Checked && CantidadDePendientes == 0)
            //            ConsultaPedido.Estado_ID = "FI";

            //    }
            //    hb.SaveChanges();
            //    MessageBox.Show("Datos modificados correctamente", "Atención");
            //}
            //this.Hide();
        }
        private void EliminarProductoPedido(string CrearEditar)
        {
            if (dgvPedidoProductos.RowCount > 0)
            {
                DialogResult R = MessageBox.Show("¿Seguro que desea eliminar este item de la fórmula?", "Atención", MessageBoxButtons.YesNo);
                if (R == DialogResult.Yes)
                {
                    using (var hb = new DBdatos())
                    {
                        if (CrearEditar == "1")
                        {
                            dgvPedidoProductos.Rows.Remove(dgvPedidoProductos.CurrentRow);
                        }
                        if (CrearEditar == "2")
                        {
                            decimal CantidadAfect = Convert.ToDecimal(dgvPedidoProductos.CurrentRow.Cells[6].Value);
                            /*long ID = (long)dgvPedidoProductos.CurrentRow.Cells[0].Value;*/ // Id de la lista de pedido a eliminar
                            if (CantidadAfect == 0)
                                dgvPedidoProductos.Rows.Remove(dgvPedidoProductos.CurrentRow);
                            else
                                MessageBox.Show("No se puede eliminar un producto que ya tiene cantidad afectada", "Atención");


                            //var Consulta = (from IP in hb.Pedido_Cuerpo
                            //                where IP.ID == ID
                            //                select IP);

                            //var Resultado = Consulta.FirstOrDefault();

                            //if (Resultado != null && Resultado.Cantidad_Total_Afec == 0)
                            //{
                            //    hb.Pedido_Cuerpo.Remove(Resultado);
                            //    dgvPedidoProductos.Rows.Remove(dgvPedidoProductos.CurrentRow);
                            //    hb.SaveChanges();
                            //    MessageBox.Show("El item fue eliminado correctamente", "Atención");
                            //}
                            //else
                            //{
                            //    MessageBox.Show("No se puede eliminar producto que ya tiene cantidad afectada", "Atención");
                            //    return;
                            //}
                        }
                    }

                }
            }

        }
        private void CalcularCantidadPallet(ref decimal VarCantidadPallet)
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
                            VarCantidadPallet = CantidadPallets;
                        }
                        else
                        {
                            VarCantidadPallet = 0;
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }

            }
        }
        private void AgregarProducto()
        {
            decimal CantidadPallet = 0; //VARIABLE PARA SABER LA CANTIDAD EQUIVALENTE A PALLETS

            CalcularCantidadPallet(ref CantidadPallet);
            dgvPedidoProductos.Rows.Add("", cmbProducto.SelectedValue, cmbProducto.Text, cmbMedida.Text, txtCantidad.Text, txtPrecio.Text, CantidadPallet.ToString("N2"), txtCantidad.Text, 0, "Pendiente", cmbMedida.SelectedValue, "PEN", "", "", txtCantidad.Text, 0);
            txtPrecio.Text = "0,00";
        }
        private void AnularPedido()
        {
            DialogResult R = MessageBox.Show("¿Esta seguro que desea anular este pedido", "Atención", MessageBoxButtons.YesNo);
            if (R == DialogResult.Yes)
            {
                using (var hb = new DBdatos())
                {
                    var ConsultaPedido = (from RP in hb.Registro_Pedidos
                                          where RP.ID == IdRecibido
                                          select RP).FirstOrDefault();

                    var ConsultaPC = (from PC in hb.Pedido_Cuerpo
                                      where PC.Pedido_ID == IdRecibido
                                      select new
                                      {
                                          PC.ID

                                      }).ToList();

                    List<long> ListPedidoCuerpoID = new List<long>();

                    foreach(var item in ConsultaPC)
                    {
                        ListPedidoCuerpoID.Add(item.ID);
                    }

                    var ConsultaOCC = (from OCC in hb.OrdenCarga_Cuerpo
                                       where ListPedidoCuerpoID.Contains((long)OCC.PedidoCuerpoID)
                                            && OCC.Orden_Carga.Estado_ID != "AN"                                     
                                       select OCC);

                    //var ConsultaOCC = (from OCC in hb.OrdenCarga_Cuerpo
                    //                   where OCC.Pedido_ID == IdRecibido
                    //                        && OCC.Orden_Carga.Estado_ID != "AN"
                    //                   //&& OCC.Orden_Carga.Estado_ID == "FI"
                    //                   select OCC);



                    var ConsultaOPC = (from OPP in hb.OrdenProduccion_Cuerpo
                                       where OPP.Pedido_ID == IdRecibido
                                            && OPP.Orden_Produccion.Estado_ID != "AN"
                                       select OPP).FirstOrDefault();

                   // var ResultadosPedido = ConsultaPedido.FirstOrDefault();
                    var ResultadosOOC = ConsultaOCC.ToList();

                    if (ResultadosOOC.Count > 0)
                    {
                        MessageBox.Show("El pedido " + ConsultaPedido.Numero_Pedido + " está afectado a una o varias ordenes de carga", "Atención");
                        return;
                    }
                    if (ConsultaOPC != null)
                    {
                        MessageBox.Show("El pedido " + ConsultaPedido.Numero_Pedido + " está afectado a una o varias ordenes de producción", "Atención");
                        return;
                    }

                    ConsultaPedido.Estado_ID = "AN";

                    hb.SaveChanges();
                    MessageBox.Show("Pedido anulado corretamente", "Atención");
                    this.Hide();




                    //if (ResultadosPedido != null && ResultadosOOC.Count == 0)
                    //{
                    //    ResultadosPedido.Estado_ID = "AN";
                    //}
                    //else
                    //{
                    //    MessageBox.Show("El pedido " + IdRecibido + " está afectado a una o varias ordenes de carga", "Atención");
                    //    return;
                    //}
                    //hb.SaveChanges();
                    //MessageBox.Show("Pedido anulado corretamente", "Atención");
                    //this.Hide();
                }
            }
        }
        private void ActivarbtnModificarCantidad()
        {
            if (txtCantidad.TextLength > 0)
                btnEditarCantidad.Enabled = true;
            else
                btnEditarCantidad.Enabled = false;
        }
        private void frmAgregarNuevoPedido_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnConfirmarProducto_Click(object sender, EventArgs e)
        {
            decimal Cantidad = 0;

            if (txtCantidad.TextLength > 0)
                Cantidad = Convert.ToDecimal(txtCantidad.Text);

            if (Cantidad > 0)
            {
                AgregarProducto();
                //frmCrearInsumoProducto.AgregarRecetaALista(dgvPedidoProductos, cmbProducto, cmbMedida, txtCantidad, "2", EstadoOrden);
                OnOffbtnCargarEditar();
            }
            else
            {
                MessageBox.Show("La cantidad tiene que ser mayor a 0", "Atención");
            }
        }
        public static void ControlarStock(ComboBox ComboProducto, TextBox txtCantidad)
        {

        }
        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarProducto.Visible = false;
                clsCargarCombos.MostrarComboInsProConMedida(cmbProducto, cmbMedida, txtBuscarProducto, "PRO", true);
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
                clsCargarCombos.MostrarComboInsProConMedida(cmbProducto, cmbMedida, txtBuscarProducto, "PRO", false);
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            txtBuscarProducto.Visible = true;
            txtBuscarProducto.Select();
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
            }
        }
        private void CambiarColorEstado()
        {
            if (rdbInform.Checked)
            {
                rdbInform.Checked = true;
                rdbAutorizado.Checked = false;
                rdbFinalizado.Checked = false;

                pnlEstadoInf.BackColor = Color.Teal;
                rdbInform.ForeColor = Color.White;

                rdbAutorizado.ForeColor = Color.Black;
                rdbFinalizado.ForeColor = Color.Black;


                pnlEstadoAu.BackColor = Color.White;
                pnlEstadoFi.BackColor = Color.White;
            }
            if (rdbAutorizado.Checked)
            {
                rdbAutorizado.Checked = true;
                rdbInform.Checked = false;
                rdbFinalizado.Checked = false;

                pnlEstadoAu.BackColor = Color.Teal;
                rdbAutorizado.ForeColor = Color.White;

                rdbInform.ForeColor = Color.Black;
                rdbFinalizado.ForeColor = Color.Black; ;

                pnlEstadoInf.BackColor = Color.White;
                pnlEstadoFi.BackColor = Color.White;
            }
            if (rdbFinalizado.Checked)
            {
                rdbFinalizado.Checked = true;
                rdbInform.Checked = false;
                rdbAutorizado.Checked = false;

                pnlEstadoFi.BackColor = Color.Teal;
                rdbFinalizado.ForeColor = Color.White;

                rdbInform.ForeColor = Color.Black;
                rdbAutorizado.ForeColor = Color.Black;

                pnlEstadoInf.BackColor = Color.White;
                pnlEstadoAu.BackColor = Color.White;
            }
        }
        private void AutoSeleccionarZona()
        {
            using (var hb = new DBdatos())
            {
                if(cmbCliente.SelectedValue != null)
                {
                    var consulta = (from C in hb.Clientes
                                    where C.ID == (int)cmbCliente.SelectedValue
                                    select C).FirstOrDefault();

                    if(consulta!= null && consulta.Zona_ID != null)
                    {
                        cmbZona.SelectedValue = consulta.Zona_ID;
                        cmbZona.Text = consulta.ZONA.Descripcion;
                    }
                    else
                    {
                        cmbZona.SelectedIndex = -1;
                    }
                }
            }
        }
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffbtnCargarEditar();
            AutoSeleccionarZona();
            Reutilizables.MostrarCiudadAutomaticamente(cmbCliente, cmbCiudad);
        }
        private void cmbCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffbtnCargarEditar();
        }

        private void rdbInform_CheckedChanged(object sender, EventArgs e)
        {

            OnOffbtnCargarEditar();
            EstadoOrden = "INF";
            OnoffbtnAgregarEditarCantidad();
           
        }

        private void rdbAutorizado_CheckedChanged(object sender, EventArgs e)
        {        
            OnOffbtnCargarEditar();
            EstadoOrden = "AU";
            EliminarRegstroAlCambiarEstado();
            OnoffbtnAgregarEditarCantidad();
            
        }

        private void dgvPedidoProductos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            OnOffbtnCargarEditar();
        }
        private void OnOffbtnCargar()
        {
            if (!chkFiltraProducto.Checked &&
               !chkFiltraEstado.Checked)
               
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
        private void CalcularPedidoCuerpoID()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from PC in hb.Pedido_Cuerpo
                                orderby PC.ID descending
                                select PC).FirstOrDefault();

                if (Consulta == null)
                {
                    IDFicticio = IDFicticio + 1;
                    PedidoCuerpoID = IDFicticio;
                }
                else
                {
                    IDFicticio = IDFicticio + 1;
                    PedidoCuerpoID = Consulta.ID + IDFicticio;

                }
            }
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultarStock_Click(object sender, EventArgs e)
        {
            NodejarModificarCantidadACompletos();
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            EliminarProductoPedido(PulsoAgregarEditar);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormatearCeldas(DataGridViewCellFormattingEventArgs e)
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
                if (this.dgvPedidoProductos.Columns[e.ColumnIndex].Name == "colCantidadPend")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font("Roboto Condensed", 10, FontStyle.Bold);
                }
                if (this.dgvPedidoProductos.Columns[e.ColumnIndex].Name == "colCantidadOriginal")
                {
                    e.CellStyle.Font = new Font("Roboto Condensed", 10, FontStyle.Bold);
                }
                if (this.dgvPedidoProductos.Columns[e.ColumnIndex].Name == "colPendienteProducir")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.SelectionForeColor = Color.Red;
                    e.CellStyle.Font = new Font("Roboto Condensed", 10, FontStyle.Bold);
                }
                if (this.dgvPedidoProductos.Columns[e.ColumnIndex].Name == "colCantidadProducida")
                {
                    e.CellStyle.Font = new Font("Roboto Condensed", 10, FontStyle.Bold);
                }
            }
        }
        private void AbrirFormRelaciones()
        {
            if (dgvPedidoProductos.RowCount > 0)
            {
                var f = new frmRelacionesPedido();
                f.PedidoID_Recibido = IdRecibido;
                f.ProductoID_Recibido = dgvPedidoProductos.CurrentRow.Cells[1].Value.ToString();
                f.ShowDialog();
            }
        }
        private void dgvPedidoProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatearCeldas(e);
        }

        private void dgvPedidoProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            NodejarModificarCantidadACompletos();
        }

        private void dgvPedidoProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPedidoProductos.RowCount > 0)
            {
                txtCantidad.Text = Convert.ToDecimal(dgvPedidoProductos.CurrentRow.Cells[4].Value).ToString("N2");
                //  _ = dgvPedidoProductos.SelectedCells;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            NodejarModificarCantidadACompletos();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            ActivarbtnModificarCantidad();
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCantidad.Text = "0,00";
        }

        private void cmbProducto_Click(object sender, EventArgs e)
        {
            txtCantidad.Text = "0,00";
        }

        private void btnEditarCantidad_Click(object sender, EventArgs e)
        {
            NodejarModificarCantidadACompletos();
        }

        private void btnRelacion_Click(object sender, EventArgs e)
        {
            AbrirFormRelaciones();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            AnularPedido();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Reutilizables.ExportarExcel(dgvPedidoProductos);
        }

        private void rdbFinalizado_CheckedChanged(object sender, EventArgs e)
        {
            OnoffbtnAgregarEditarCantidad();
            
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_Click(object sender, EventArgs e)
        {
            txtCantidad.SelectAll();
        }

        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCantidad);
        }

        private void chkFiltraProducto_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraProducto, cmbFiltraProducto, txtFiltraBuscaProducto, btnFiltraBuscarIProducto, "PRO","NO");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarDatosFiltrados();
            OnOffbtnCargar();
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros,btnMostrarfiltros,lblfiltros);
        }

        private void txtFiltraBuscaProducto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbFiltraProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProSinCheck(cmbProducto, txtBuscarProducto, "PRO", false, "NO");
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void btnFiltraBuscarIProducto_Click(object sender, EventArgs e)
        {
            txtBuscarProducto.Visible = true;
            txtBuscarProducto.Select();
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCantidad);
        }

        private void chkFiltraEstado_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraEstado,cmbFiltraEstado);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void cmbResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, false);
                e.Handled = true;
            }
        }

        private void txtBuscarResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarResponsable.Visible = false;
                clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, true);
                txtBuscarResponsable.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarResponsable.Visible = false;
            }
        }

        private void btnBuscarResponsable_Click(object sender, EventArgs e)
        {
            txtBuscarResponsable.Visible = true;
            txtBuscarResponsable.Select();
        }

        private void btnCargar_Click_1(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue != null
               && cmbResponsable.SelectedValue != null
               && dgvPedidoProductos.RowCount > 0) //VALIDACIONES 
            {

                if (PulsoAgregarEditar == "1" || PulsoAgregarEditar == "3")
                    CargarPedido();
                else
                    EditarPedido();
            }
            else
            {
                if (cmbCliente.SelectedValue == null)
                    MessageBox.Show("No seleccionó cliente", "Atención");
                if (cmbResponsable.SelectedValue == null)
                    MessageBox.Show("No seleccionó responsable", "Atención");
                if (dgvPedidoProductos.RowCount < 0)
                    MessageBox.Show("No hay productos en la lista", "Atención");
            }
            //clsNotificacion.NotificarStockMinimoProducto(UsuarioID);
            //clsNotificacion.MostrarCantidadNotificacionesNoLeidas(FormMenu.lblCantidadNotificaciones);
        }

        private void btnInvalidar_Click(object sender, EventArgs e)
        {
            AnularPedido();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdbInform_Click(object sender, EventArgs e)
        {
            rdbInform.Checked = true;
            rdbAutorizado.Checked = false;
            rdbFinalizado.Checked = false;

            rdbInform.ForeColor = Color.White;
            rdbInform.BackColor = Color.Teal;

            rdbAutorizado.BackColor = Color.White;
            rdbAutorizado.ForeColor = Color.Black;

            rdbFinalizado.BackColor = Color.White;
            rdbFinalizado.ForeColor = Color.Black;

        }

        private void rdbAutorizado_Click(object sender, EventArgs e)
        {
            rdbAutorizado.Checked = true;
            rdbInform.Checked = false;
            rdbFinalizado.Checked = false;

            rdbAutorizado.ForeColor = Color.White;
            rdbAutorizado.BackColor = Color.Teal;

            rdbInform.BackColor = Color.White;
            rdbInform.ForeColor = Color.Black;

            rdbFinalizado.BackColor = Color.White;
            rdbFinalizado.ForeColor = Color.Black;
        }

        private void rdbFinalizado_Click(object sender, EventArgs e)
        {
            rdbFinalizado.Checked = true;
            rdbInform.Checked = false;
            rdbAutorizado.Checked = false;

            rdbFinalizado.ForeColor = Color.White;
            rdbFinalizado.BackColor = Color.Teal;

            rdbInform.BackColor = Color.White;
            rdbInform.ForeColor = Color.Black;

            rdbAutorizado.BackColor = Color.White;
            rdbAutorizado.ForeColor = Color.Black;
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtPrecio);
        }

        private void txtPrecio_Click(object sender, EventArgs e)
        {
            txtPrecio.SelectAll();
        }
    }
}
