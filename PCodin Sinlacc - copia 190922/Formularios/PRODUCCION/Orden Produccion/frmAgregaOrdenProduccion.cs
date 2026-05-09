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
using System.Media;
using System.Windows.Input;
using PCodin_Sinlacc.Formularios.Orden_Produccion;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmAgregaOrdenProduccion : Form
    {
        public string CrearEditar;
        public long IDRecibido;
        public long IDRecibidoParaAgregar; // ESTE SE CREA PARA AYUDAR A QUE CUANDO ABRIMOS EL ASISTENTE DE AGREGAR NO MUESTRE LOS AFECTADOS EN EL METODO InsertarTablaTemporalPedidoCuerpoEditar
        private string AfectarAfectados;
        private int Indice = 0;
        private int CatidadFilasDGV;
        public long OrdenID; // variable para autocalcular el número de orden
        bool  Valida;
        string AsociarOrdenProduccion = "NO";
        public frmMostrarOrdenProduccion FormularioMostrarOrdenProd;
        frmFormMovimientoFinalizado FormFinalizado = new frmFormMovimientoFinalizado();
        private bool AgrandarGrilla = false; 
        public frmAgregaOrdenProduccion()
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
        private void LlenarComboOrdenar()
        {
            cmbOrdenar.Items.Clear();

            if(AfectarAfectados == "1")
            {
                cmbOrdenar.Items.Add("");
                cmbOrdenar.Items.Add("Nro pedido");
                cmbOrdenar.Items.Add("Producto");
                cmbOrdenar.Items.Add("Medida");
                cmbOrdenar.Items.Add("Cant. pendiente");
                cmbOrdenar.Items.Add("Cant. afectada");
                cmbOrdenar.Items.Add("Estado");
            }
            if (AfectarAfectados == "2")
            {
                cmbOrdenar.Items.Add("");
                cmbOrdenar.Items.Add("Nro pedido");
                cmbOrdenar.Items.Add("Producto");
                cmbOrdenar.Items.Add("Medida");               
                cmbOrdenar.Items.Add("Cant. afectada");               
            }
        }
        private void btnAfectar_Click(object sender, EventArgs e)
        {
            //DeleteTablaTemporarPedidoCuerpo();
            //DeleteTablaTemporarOrdenCargacuerpo();// Elimina los valores en la tabla temporal

            // InicializarForm();
            //InsertarTablaTemporalPedidoCuerpo(); // Inserta los valores en la tabla temporal
            //  InsertarTablaTemporalPedidoCuerpoEditar();
           

            if (AfectarAfectados == "1")
                MostrarPedidoCuerpo("1", 999999999);
            else
                MostrarPedidoCuerpo("2", 0);

            if (CrearEditar == "2")
                MostrarAfectados();

     

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

            LlenarComboOrdenar();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteTablaTemporarPedidoCuerpo();
            DeleteTablaTemporarOrdenCargacuerpo();
            DeleteTablaTemporalTTAFEC();
            DeleteTablaTemporalTTRPT();
            this.Close();
        }

        private void frmAgregarOrdenCarga_Load(object sender, EventArgs e)
        {
            DeleteTablaTemporarPedidoCuerpo();
            DeleteTablaTemporarOrdenCargacuerpo();// Elimina los valores en la tabla temporal
            InsertarTablaTemporalPedidoCuerpo(); // Inserta los valores en la tabla temporal
            InsertarTablaTemporalPedidoCuerpoEditar();
            InicializarForm();
            //DeleteTablaTemporalTTAFEC();
            //DeleteTablaTemporalTTRPT();
            txtObservaciones.Parent = this.pnlCentral1;
            pictureBox2.Parent = this.pnlCentral1;



           // InsertarDatosEnTablaTemporalTTRPT();


            //DeleteTablaTemporarPedidoCuerpo();
            //DeleteTablaTemporarOrdenCargacuerpo();// Elimina los valores en la tabla temporal

            //InicializarForm();



            if (AfectarAfectados == "1")
                MostrarPedidoCuerpo("1", 999999999);
            else
                MostrarPedidoCuerpo("2", 0);

            if (CrearEditar != "1" && CrearEditar != "4")
                MostrarAfectados();
        }
        private void InicializarForm()
        {
            dtpFechaHasta.Value = DateTime.Now.Date;
            dtpFechaDesde.Value = DateTime.Now.Date;
            clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, false);
            

            if (CrearEditar == "1")
            {
                CalcularNumeroOrdenProduccion();
                CalculaIdOrdenProduccion();
                btnCargar.Text = "Confirmar";
                cmbResponsable.SelectedIndex = -1;
                CalculaIdOrdenProduccion();
            }
            if (CrearEditar == "2" || CrearEditar == "4") // SOLO PARA VER O ANULAR
            {
                if (CrearEditar == "2")
                    AfectarAfectados = "2";
                else
                    AfectarAfectados = "1";

                using (var hb = new DBdatos())
                {

                    txtNumeroOrden.Text = IDRecibido.ToString();

                    btnCargar.Enabled = false;
                    btnInvalidar.Enabled = true;
                    btnAfectar.Enabled = false;
                    cmsAfectarProducto.Enabled = false;
                    btnAfectar.BackColor = Color.White;
                    btnAfectados.BackColor = Color.Orange;
                    btnCargar.Text = "Editar";

                    var ConsultaOrdenProduccion = (from P in hb.Orden_Produccion1
                                                   where P.ID == IDRecibido
                                                   select P);

                    var ResultadoOrdenProduccion = ConsultaOrdenProduccion.FirstOrDefault();

                    if (ResultadoOrdenProduccion != null)
                    {
                        txtNumeroOrden.Text = ResultadoOrdenProduccion.NumeroOrden;
                        dtpFecha.Value = ResultadoOrdenProduccion.Fecha;
                        dtpFechaLimite.Value = (DateTime)ResultadoOrdenProduccion.Fecha_Limite;
                        cmbResponsable.SelectedValue = ResultadoOrdenProduccion.Responsable_ID;
                        cmbResponsable.Text = ResultadoOrdenProduccion.Empleados.Nombre;
                        txtEstado.Text = ResultadoOrdenProduccion.Estado_Ord_Carga.Descripcion;

                        if (ResultadoOrdenProduccion.Estado_ID == "AU")
                            rdbAutorizado.Checked = true;
                        if (ResultadoOrdenProduccion.Estado_ID == "PRO")
                            rdbEnProceso.Checked = true;

                        if (ResultadoOrdenProduccion.Estado_ID == "AN")
                        {
                            txtEstado.ForeColor = Color.Red;
                            btnInvalidar.Enabled = false;
                        }
                        if (ResultadoOrdenProduccion.Estado_ID == "AU")
                        {
                            txtEstado.ForeColor = Color.Black;
                            btnInvalidar.Enabled = true;
                        }
                        if (ResultadoOrdenProduccion.Estado_ID == "PRO")
                        {
                            txtEstado.ForeColor = Color.DarkBlue;
                            btnInvalidar.Enabled = true;
                        }
                        if (ResultadoOrdenProduccion.Estado_ID == "FI")
                        {
                            txtEstado.ForeColor = Color.Green;
                            btnInvalidar.Enabled = true;
                        }
                        //MostrarTTOrdenCargaCuerpo();
                    }

                    if (CrearEditar == "4")
                    {
                        btnCargar.Enabled = true;
                        btnCargar.Enabled = false;
                        btnAfectar.Enabled = true;
                        btnAfectar.BackColor = Color.Orange;
                        btnAfectados.BackColor = Color.White;
                        cmsAfectarProducto.Enabled = true;
                        btnCargar.Text = "Agregar";
                        txtNumeroOrden.Enabled = false;
                    }
                }
            }
            if (CrearEditar == "3") // COPIAR
            {
                using (var hb = new DBdatos())
                {
                    var ConsultaOPC = (from OPC in hb.OrdenProduccion_Cuerpo
                                       where OPC.OrdenProd_ID == IDRecibido
                                       select OPC);

                    var ResultadosOPCLista = ConsultaOPC.ToList();
                    var ResultadoOPUnico = ConsultaOPC.FirstOrDefault();

                    txtNumeroOrden.Text = ResultadoOPUnico.Orden_Produccion.NumeroOrden;
                    CalculaIdOrdenProduccion();
                    btnCargar.Text = "Confirmar";
                    btnInvalidar.Enabled = false;
                    btnAfectar.BackColor = Color.White;
                    btnAfectados.BackColor = Color.Orange;
                    btnAfec.Visible = false;
                    txtEstado.Text = "";
                    //MostrarTTOrdenCargaCuerpo();
                    cmbResponsable.Enabled = true;
                    //AfectarAfectados = "2";
                    //btnAfectados.BackColor = Color.DarkOrange;
                   



                    foreach (var item in ConsultaOPC)
                    {
                        //var ConsultaTTOPC = (from TTOPC in hb.TT_OrdenProduccion_Cuerpo
                        //                     where TTOPC.IDaEditar == OrdenID
                        //                        && TTOPC.Producto_ID == item.Producto_ID
                        //                     select TTOPC).FirstOrDefault();

                      

                        var ConsultaTTPC = (from TTPC in hb.TT_Pedido_Cuerpo
                                            where TTPC.Producto_ID == item.Producto_ID
                                                && TTPC.Pedido_ID == item.Registro_Pedidos.ID
                                                && TTPC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                                && TTPC.Sesion_ID == clsVariablesGenerales.SesionID
                                            select TTPC).FirstOrDefault();



                       // ConsultaTTOPC.Cantidad = item.Cantidad;

                        ConsultaTTPC.Cantidad = ConsultaTTPC.Cantidad - item.Cantidad;
                        ConsultaTTPC.Cantidad_Afectada = item.Cantidad;

                        if (ConsultaTTPC.Cantidad == 0)
                            ConsultaTTPC.Estado_ID = "COM";
                        else
                            ConsultaTTPC.Estado_ID = "PEN";

                        var i = new TT_OrdenProduccion_Cuerpo();

                        i.IDaEditar = OrdenID;
                        i.Pedido_ID = item.Registro_Pedidos.ID;
                        i.Producto_ID = item.Producto_ID;
                        i.Cantidad = item.Cantidad;
                        i.Usuario_ID = clsVariablesGenerales.UsuarioID;
                        i.Sesion_ID = clsVariablesGenerales.SesionID;
                    }
                    hb.SaveChanges();
                    MostrarAfectados();
                }
            }
        }
        private void AgrandarDGV()
        {
            pictureBox2.Visible = false;
            txtEstado.Visible = false;

            pnlCentral1.Visible = false;
            panel3.Location = new Point(876, 32);

            btnAfectar.Location = new Point(1, 123);
            btnAfectados.Location = new Point (126, 123);
            btnExcel.Location = new Point(279, 123);
            btnModificarGrilla.Location = new Point(447, 123);
            //btnModificarGrilla.Text = "Contraer";

            dgvPedidoProductos.Location = new Point(1, 156);
            dgvPedidoProductos.Size = new Size(1161, 480);
        }
        private void AchicarDGV()
        {
            pictureBox2.Visible = true;
            txtEstado.Visible = true;

            pnlCentral1.Visible = true;
            panel3.Location = new Point(873, 136);

            btnAfectar.Location = new Point(1, 226);
            btnAfectados.Location = new Point(126, 226);
            btnExcel.Location = new Point(279, 226);
            btnModificarGrilla.Location = new Point(447, 226);
            //btnModificarGrilla.Text = "Expandir";

            dgvPedidoProductos.Location = new Point(5, 260);
            dgvPedidoProductos.Size = new Size(1161, 376);
        }
        private void MostrarAfectados()
        {
            Indice = 0;
            AfectarAfectados = "2";
            OnOffbtnEditarCantidad();
            CambiarColorbtnSeleccionado("2", btnAfectados, btnAfectar, btnAfec);
            MostrarTTOrdenCargaCuerpo();
            //OnOffBtnConfirnarordenPedido();
            dgvPedidoProductos.Focus();

            if (CrearEditar == "2")
            {
                btnEditar.Enabled = false;
            }

            if (CrearEditar == "2")
            {
                btnEditar.Enabled = false;
            }
            LlenarComboOrdenar();
        }
        private void MostrarPedidoCuerpo(string AfectarAfectado, decimal Valor)
        {
            //if (cmbCliente.SelectedIndex != -1)
            //{
            using (var hb = new DBdatos()) 
            {

                var Consulta = (from OP in hb.Registro_Pedidos
                                join PC in hb.TT_Pedido_Cuerpo on OP.ID equals PC.Pedido_ID
                                join PRO in hb.Productos_Insumos on PC.Producto_ID equals PRO.Codigo
                                where OP.Estado_ID == "AU"
                                      && PC.Cantidad_Afectada != Valor
                                      && PC.Sesion_ID == clsVariablesGenerales.SesionID
                                      && PC.Usuario_ID == clsVariablesGenerales.UsuarioID

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
                                   
                                }).Take(1000);

                if (AfectarAfectado == "1")  // Pestaña Afectar // SI SE ROMPIO ES ACA // 5/11/21
                {
                    Consulta = (from C in Consulta
                                where C.EstadoID_OC == "PEN"
                                    && C.Cantidad > 0
                                select C);

                    colCantidad.Visible = true;
                    colEstado.Visible = true;

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
                }
                if (AfectarAfectado == "2") // Pestaña Afectados
                {
                    Consulta = (from C in Consulta
                                where C.Afectada == true
                                select C);

                    colCantidad.Visible = false;
                    colEstado.Visible = false;                  
                }

                if (chkFiltraCliente.Checked)
                    Consulta = (from C in Consulta
                                where C.Cliente_ID == (int)cmbFiltraCliente.SelectedValue
                                select C);
             
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

                colEstado.Visible = false;

                colPedidoID.DataPropertyName = "ID";
                colNumeroPedido.DataPropertyName = "Numero_Pedido";
                colPCID.DataPropertyName = "PedCuerpID";
                colProductoID.DataPropertyName = "Producto_ID";
                colProductoDescrip.DataPropertyName = "Descripcion";
                colMedida.DataPropertyName = "Medida";
                colCantidad.DataPropertyName = "Cantidad";
                colMedida_ID.DataPropertyName = "Medida_ID";
                colCantidadAfec.DataPropertyName = "Cantidad_Afectada";
                colCliente.DataPropertyName = "Cliente";
                //colEstado.DataPropertyName = "EstadoPC";

                dgvPedidoProductos.AutoGenerateColumns = false;
                dgvPedidoProductos.DataSource = Resultados;

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
        private void CalcularNumeroOrdenProduccion()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from OP in hb.Orden_Produccion1
                                orderby OP.ID descending
                                select OP).FirstOrDefault();

                if(Consulta == null)
                {
                    txtNumeroOrden.Text = "OP1";
                }    
                else
                {
                    txtNumeroOrden.Text = "OP" + (Consulta.ID + 1).ToString();
                }
            }
        }
        private void MostrarTTOrdenCargaCuerpo()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from OCC in hb.TT_OrdenProduccion_Cuerpo
                                join PED in hb.Registro_Pedidos on OCC.Pedido_ID equals PED.ID
                                orderby OCC.Pedido_ID, OCC.Productos_Insumos.Descripcion
                                where OCC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                    && OCC.Sesion_ID == clsVariablesGenerales.SesionID
                                select new
                                {
                                    OCC.ID,
                                    OCC.Registro_Pedidos.Numero_Pedido,
                                    OCC.Pedido_ID,
                                    OCC.Producto_ID,
                                    OCC.Productos_Insumos.Descripcion,
                                    OCC.Estado_ID,
                                    Estado = OCC.Estado_Pedido_Cuerpo.Descripcion,                                    //OCC.Medida_ID,
                                    Medida = OCC.Productos_Insumos.Medidas_Producto.Descripcion,
                                    MedidaID = OCC.Productos_Insumos.Medida,
                                    OCC.Cantidad,
                                    Cliente = PED.Clientes.Descripcion
                                    //Completo = "Completo",
                                    //Pendiente = "Pendiente"

                                }).Take(1000);

                colCantidad.Visible = false;
                colEstado.Visible = false;

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

                //var Consulta = (from VOOC in hb.VistaOCC_CantidadesAfectas
                //                orderby VOOC.Pedido_ID, VOOC.ProductoDescrip
                //                select new
                //                {
                //                    VOOC.Orden_ID,
                //                    VOOC.Pedido_ID,
                //                    VOOC.Codigo,
                //                    VOOC.ProductoDescrip,
                //                    Medida_ID = VOOC.ID,
                //                    VOOC.MedidaDescrip,
                //                    VOOC.CantOCC,
                //                    VOOC.Estado,
                //                    Completo = "Completo"
                //                }).Take(1000);

                //colCantidad.Visible = false;
                //colEstado.Visible = true;

                //if (chkFiltraNroPedido.Checked)
                //{
                //    long NroPedido = Convert.ToInt64(txtFiltraNroPedido.Text);

                //    Consulta = (from C in Consulta
                //                where C.ID == NroPedido
                //                select C);
                //}

                var Resultados = Consulta.ToList();

                colPedidoID.DataPropertyName = "Pedido_ID";
                colNumeroPedido.DataPropertyName = "Numero_Pedido";
                colProductoID.DataPropertyName = "Producto_ID";
                colProductoDescrip.DataPropertyName = "Descripcion";
                colMedida.DataPropertyName = "Medida";
                colCantidad.DataPropertyName = "Cantidad";
                colMedida_ID.DataPropertyName = "MedidaID";
                colCantidadAfec.DataPropertyName = "Cantidad";               
                colEstado.DataPropertyName = "Estado";
                colCliente.DataPropertyName = "Cliente";

                dgvPedidoProductos.AutoGenerateColumns = false;
                dgvPedidoProductos.DataSource = Resultados;

                //for (var i = 1; i <= dgvPedidoProductos.RowCount; i++)
                //{
                   
                //    decimal Cantidad = (decimal)dgvPedidoProductos.Rows[i - 1].Cells[5].Value;
                //    //decimal CantidadAfec = (decimal)dgvPedidoProductos.Rows[i - 1].Cells[6].Value;
                //    long PedidoID = (long)dgvPedidoProductos.Rows[i - 1].Cells[0].Value;

                //    var ConsultaTTAFEC = (from TTAFEC in hb.TT_Prodocuto_Afec_OrdenCarga
                //                          where TTAFEC.Cantidad > 0
                //                              && TTAFEC.Pedido_ID == PedidoID
                //                          group TTAFEC by new { TTAFEC.Pedido_ID } into Grupo
                //                          select new
                //                          {
                //                              CantidadAfec = Grupo.Sum(x => x.Cantidad)
                //                          });

                //    var ResultadosTTAFEC = ConsultaTTAFEC.FirstOrDefault();

                //    if (ResultadosTTAFEC != null)
                //    {
                //        if (Cantidad == ResultadosTTAFEC.CantidadAfec)
                //        {
                //            colAfecCompleto.DataPropertyName = "Completo";
                //        }
                //        else
                //        {
                //            colAfecCompleto.DataPropertyName = "Pendiente";
                //        }
                //    }
                //    else
                //    {
                //        colAfecCompleto.DataPropertyName = "Pendiente";
                //    }

                //}

                //dgvPedidoProductos.DataSource = Resultados;


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

                colPedidoID.DataPropertyName = "Pedido_ID";
                //colPCID.DataPropertyName = "PedCuerpID";
                colProductoID.DataPropertyName = "Producto_ID";
                colProductoDescrip.DataPropertyName = "Descripcion";
                colMedida.DataPropertyName = "Medida";
                colCantidad.DataPropertyName = "Cantidad";
                colMedida_ID.DataPropertyName = "Medida_ID";
                colCantidadAfec.DataPropertyName = "Cantidad";





                dgvPedidoProductos.AutoGenerateColumns = false;
                dgvPedidoProductos.DataSource = Resultados;
            }
        }
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbCliente.SelectedIndex != -1)
            //{
            //    OnOffBtnConfirnarordenPedido();
            //    //  if (CrearEditar == "1")
            //    //{
            //    DeleteTablaTemporarPedidoCuerpo();
            //    DeleteTablaTemporarOrdenCargacuerpo();// Elimina los valores en la tabla temporal
            //                                          //  InsertarTablaTemporalPedidoCuerpo(); // Inserta los valores en la tabla temporal
            //    InsertarTablaTemporalPedidoCuerpoEditar();
            //    //}

            //    if (AfectarAfectados == "1")
            //        MostrarPedidoCuerpo("1", 999999999);
            //    else
            //        MostrarPedidoCuerpo("2", 0);

            //    Reutilizables.MostrarCiudadAutomaticamente(cmbCliente, cmbResponsable);
            //}
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
            Reutilizables.ReubicarFiltros(gbxFiltros, pnlInferior, btnMostrarfiltros);
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
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
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
                using (var hb = new DBdatos())
                {
                    long Pedido_ID = (long)dgvPedidoProductos.CurrentRow.Cells[columnName: "colPedidoID"].Value;
                    string Producto_ID = dgvPedidoProductos.CurrentRow.Cells[columnName: "colProductoID"].Value.ToString();
                    string Producto = dgvPedidoProductos.CurrentRow.Cells[columnName: "colProductoDescrip"].Value.ToString();

                    var ConsultaPedido = (from PC in hb.TT_Pedido_Cuerpo
                                          where PC.Pedido_ID == Pedido_ID
                                              && PC.Producto_ID == Producto_ID
                                              && PC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                              && PC.Sesion_ID == clsVariablesGenerales.SesionID
                                          select PC);

                    var ConsultaCircuito = (from CI in hb.Seccion_Circuito
                                            where CI.Producto_ID == Producto_ID
                                            select CI).FirstOrDefault();

                    var ResultadoPedido = ConsultaPedido.FirstOrDefault();


                    //hb.SaveChanges();
                    if (ConsultaCircuito != null)
                    {


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

                                    var i = new TT_OrdenProduccion_Cuerpo();

                                    //i.OrdenProduc_ID = OrdenID;
                                    i.Pedido_ID = Pedido_ID;
                                    i.Producto_ID = Producto_ID;
                                    //i.Medida_ID = ResultadoPedido.Medida_ID;
                                    i.Cantidad = ResultadoPedido.Cantidad_Afectada;
                                    i.IDaEditar = OrdenID;
                                    i.Usuario_ID = clsVariablesGenerales.UsuarioID;
                                    i.Sesion_ID = clsVariablesGenerales.SesionID;

                                    hb.TT_OrdenProduccion_Cuerpo.Add(i);
                                }
                                // SI TIENE CANTIDAD AFECTADA
                                else
                                {
                                    ResultadoPedido.Cantidad_Afectada = ResultadoPedido.Cantidad_Afectada + ResultadoPedido.Cantidad;
                                    ResultadoPedido.Cantidad = 0; // Cantidad pendiente
                                    ResultadoPedido.Estado_ID = "COM";

                                    var ConsultaOCC = (from PC in hb.TT_OrdenProduccion_Cuerpo
                                                       where PC.Pedido_ID == Pedido_ID
                                                           && PC.Producto_ID == Producto_ID
                                                           && PC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                                           && PC.Sesion_ID == clsVariablesGenerales.SesionID
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
                                var ConsultaOCC = (from PC in hb.TT_OrdenProduccion_Cuerpo
                                                   where PC.Pedido_ID == Pedido_ID
                                                       && PC.Producto_ID == Producto_ID
                                                       && PC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                                       && PC.Sesion_ID == clsVariablesGenerales.SesionID
                                                   select PC);

                                var ResultadoOOC = ConsultaOCC.FirstOrDefault();

                                if (ResultadoOOC == null)
                                {
                                    var i = new TT_OrdenProduccion_Cuerpo();

                                    // i.ID = OrdenID;
                                    i.Pedido_ID = Pedido_ID;
                                    i.Producto_ID = Producto_ID;
                                    // i.Medida_ID = ResultadoPedido.Medida_ID;
                                    i.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                                    i.IDaEditar = OrdenID;
                                    i.Usuario_ID = clsVariablesGenerales.UsuarioID;
                                    i.Sesion_ID = clsVariablesGenerales.SesionID;

                                    hb.TT_OrdenProduccion_Cuerpo.Add(i);
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

                                //if (ResultadoPedido.Cantidad == 0)
                                //{
                                //    ResultadoPedido.Estado_ID = "COM";
                                //}
                                //if (ResultadoPedido.Cantidad > 0)
                                //{
                                //    ResultadoPedido.Estado_ID = "PEN";
                                //}

                                if (CantidadTotal < ResultadoPedido.Cantidad_Afectada) // Validacion para que la cantidad no sea negativa.
                                {
                                    MessageBox.Show("La cantidad pendiente no puede ser negativa", "Atención");
                                    return;
                                }
                            }
                            // SI DESAFECTAMOS
                            if (CompletoParcial == "3") // boton desafectar
                            {
                                var ConsultaOCC = (from PC in hb.TT_OrdenProduccion_Cuerpo
                                                   where PC.Pedido_ID == Pedido_ID
                                                       && PC.Producto_ID == Producto_ID
                                                       && PC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                                       && PC.Sesion_ID == clsVariablesGenerales.SesionID
                                                   select PC);

                                var ResultadoOOC = ConsultaOCC.FirstOrDefault();

                                ResultadoPedido.Cantidad = ResultadoPedido.Cantidad_Afectada + ResultadoPedido.Cantidad;
                                ResultadoPedido.Cantidad_Afectada = 0;
                                ResultadoPedido.Estado_ID = "PEN";

                                hb.TT_OrdenProduccion_Cuerpo.Remove(ResultadoOOC);
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
                    }
                    else
                    {
                        MessageBox.Show("El producto " + Producto + " - " + Producto_ID + " no tiene circuito defenido. Para poder afectarlo debe definirle un circuito productivo", "Atención");
                        return;
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
                    LlenarComboOrdenar();
                }
            }
        }
        private void InsertarDatosEnTablaTemporalTTRPT()
        {
            //using (var hb = new DBdatos())
            //{
            //    var Consulta = (from EPT in hb.Existencia_ProductoTerminado
            //                    where EPT.Cantidad_Utiliz != EPT.Cantidad
            //                            //&& EPT.Produto_ID == ProductoID
            //                            && EPT.Movimiento_ID != "AJUNE"
            //                            //&& EPT.Movimiento_ID != "AJUPO"
            //                            && EPT.Estado_ID != "AN"
            //                    select EPT);

            //    var Resultados = Consulta.ToList();

            //    foreach (var item in Resultados)
            //    {
            //        var ConsultaTT = (from TTEPT in hb.TT_Existencia_ProductoTerminado
            //                          where TTEPT.Movimiento_ID != "AJUNE"
            //                                && TTEPT.IDaModificar == item.ID
            //                          select TTEPT);

            //        var ResultadosTT = ConsultaTT.FirstOrDefault();

            //        var i = new TT_Existencia_ProductoTerminado();

            //        i.IDaModificar = item.ID;
            //        i.Producto_ID = item.Produto_ID;
            //        i.Movimiento_ID = item.Movimiento_ID;
            //        i.Medida_ID = item.Medida_ID;
            //        i.Retencion = item.Retencion;
            //        i.Ficha = item.Ficha;
            //        i.Fecha = item.Fecha;
            //        i.Observaciones = item.Observaciones;
            //        i.Empleado_ID = item.Empleado_ID;
            //        i.Cantidad = (decimal)(item.Cantidad - item.Cantidad_Utiliz);
            //        i.Cantidad_Afec = 0;
            //        i.Deposito = item.Deposito;
            //        i.IDaModificar = item.ID;

            //        hb.TT_Existencia_ProductoTerminado.Add(i);
            //    }
            //    hb.SaveChanges();
            //}
        }
        private void DeleteTablaTemporalTTRPT()
        {
            //using (var hb = new DBdatos())
            //{
            //    var Consulta = (from TTEPT in hb.TT_Existencia_ProductoTerminado
            //                    select TTEPT).ToList();

            //    hb.TT_Existencia_ProductoTerminado.RemoveRange(Consulta);
            //    hb.SaveChanges();
            //}
        }
        private void DeleteTablaTemporalTTAFEC()
        {
            //using (var hb = new DBdatos())
            //{
            //    var Consulta = (from TTEPT in hb.TT_Prodocuto_Afec_OrdenCarga
            //                    select TTEPT).ToList();

            //    hb.TT_Prodocuto_Afec_OrdenCarga.RemoveRange(Consulta);
            //    hb.SaveChanges();
            //}
        }
        private void InsertarTablaTemporalPedidoCuerpo()
        {
            using (var hb = new DBdatos())
            {
                var ConsultaPedido = (from PC in hb.Pedido_Cuerpo
                                      where PC.Estado_ID == "PEN"
                                     // && PC.Cantidad_Afec_Producir !=
                                     && PC.Cantidad_Pend_Producir > 0
                                      select PC);

                var ResultadoPedido = ConsultaPedido.ToList();

                if (ResultadoPedido.Count > 0)
                {
                    foreach (var item in ResultadoPedido)
                    {
                        var i = new TT_Pedido_Cuerpo();

                        i.Ped_Cuerp_ID = item.ID;
                        i.Cantidad = item.Cantidad - item.Cantidad_Afec_Producir; // NUEVO PENDIENTE DE AFECTAR
                        i.Cantidad_Afectada = item.Cantidad_Producida;
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
                }
            }
        }
        private void InsertarTablaTemporalPedidoCuerpoEditar()
        {
            using (var hb = new DBdatos())
            {
                long OrdenProd_ID;

                if (CrearEditar == "4") 
                {
                    OrdenProd_ID = -1;
                }
                else
                {
                    OrdenProd_ID = IDRecibido;
                }
                //CONSULTA LOS PEDIDOS PENDIENTES
                var ConsultaPedido = (from PC in hb.Pedido_Cuerpo
                                      where /*PC.Registro_Pedidos.Cliente_ID == (int)cmbCliente.SelectedValue*/
                                         PC.Registro_Pedidos.Estado_ID != "AN"
                                        && PC.Registro_Pedidos.Estado_ID != "INF"
                                      select PC);

                
                  
                // CONSULTA LAS ORDENES CARGA CON TAL NUMERO DE ORDEN Y CLIENTE QUE ESTAMOS COPIANDO
                var ConsultaOrdenCargaCuerpo = (from OCC in hb.OrdenProduccion_Cuerpo
                                                where OCC.OrdenProd_ID == IDRecibido
                                                select OCC);

                var ResultadoPedido = ConsultaPedido.ToList();
                var ResultadoOrdenCargaCuerpo = ConsultaOrdenCargaCuerpo.ToList();

                // SI HAY ORDENES DE PRODUCCION SE REGISTRAN EN LA TTOCC
                if (ResultadoOrdenCargaCuerpo.Count > 0)
                {
                    foreach (var item2 in ResultadoOrdenCargaCuerpo)
                    {

                        var z = new TT_OrdenProduccion_Cuerpo();

                        //z.Orden_ID = OrdenID;
                        z.Pedido_ID = item2.Pedido_ID;
                        z.IDaEditar = item2.ID;
                        z.Producto_ID = item2.Producto_ID;
                        z.Cantidad = item2.Cantidad;
                        z.Usuario_ID = clsVariablesGenerales.UsuarioID;
                        z.Sesion_ID = clsVariablesGenerales.SesionID;

                       // z.Medida_ID = item2.Medida_ID;

                        //if (CrearEditar == "3")
                        //{
                        //    CalculaIdOrdenProduccion();
                        //    z.OrdenProduc_ID = OrdenID;
                        //}

                        hb.TT_OrdenProduccion_Cuerpo.Add(z);
                        hb.SaveChanges();
                    }
                }
                // SI HAY PEDIDOS
                //if (ResultadoPedido.Count > 0)
                //{
                //    foreach (var item in ResultadoPedido)
                //    {
                //        //  if (CrearEditar == "3")
                //        // {
                //        var ConusltaTTOCC = (from TTOCC in hb.TT_OrdenProduccion_Cuerpo
                //                             where TTOCC.Pedido_ID == item.Pedido_ID
                //                                 && TTOCC.Producto_ID == item.Producto_ID
                //                             select TTOCC);

                //        var ResultadosTTOCC = ConusltaTTOCC.FirstOrDefault();
                //        //   }
                //        if (ResultadosTTOCC == null)
                //        {

                //            var i = new TT_Pedido_Cuerpo();

                //            i.Ped_Cuerp_ID = item.ID;
                //            i.Cantidad = item.Cantidad_Pend_Producir;
                //            i.Cantidad_Afectada = item.Cantidad_Producida;
                //            i.Estado_ID = item.Estado_ID;
                //            i.Producto_ID = item.Producto_ID;
                //            i.Medida_ID = item.Medida_ID;
                //            i.Pedido_ID = item.Pedido_ID;
                //            i.Afectada = false;

                //            hb.TT_Pedido_Cuerpo.Add(i);
                //            hb.SaveChanges();
                //        }
                //        else
                //        {
                //            var i = new TT_Pedido_Cuerpo();

                //            i.Ped_Cuerp_ID = item.ID;
                //            i.Cantidad = item.Cantidad_Pend_Producir - ResultadosTTOCC.Cantidad;
                //            i.Cantidad_Afectada = ResultadosTTOCC.Cantidad;
                //            if (ResultadosTTOCC.Cantidad == item.Cantidad_Pend_Producir)
                //            {
                //                i.Estado_ID = "COM";
                //            }
                //            else
                //            {
                //                i.Estado_ID = "PEN";
                //            }
                //            //i.Estado_ID = item.Estado_ID;
                //            i.Producto_ID = item.Producto_ID;
                //            i.Medida_ID = item.Medida_ID;
                //            i.Pedido_ID = item.Pedido_ID;
                //            i.Afectada = false;

                //            hb.TT_Pedido_Cuerpo.Add(i);
                //            hb.SaveChanges();
                //        }
                //    }

                //    //{
                //    //    //foreach (var item2 in ResultadoOrdenCargaCuerpo)
                //    //    //{

                //    //    //    var z = new TT_Pedido_Cuerpo();

                //    //    //    // z.Orden_ID = item2.Orden_ID;
                //    //    //    z.Pedido_ID = item2.Pedido_ID;
                //    //    //    //  z.IDaEditar = item2.ID;
                //    //    //    z.Producto_ID = item2.Producto_ID;
                //    //    //    z.Cantidad = item2.Cantidad;
                //    //    //    z.Medida_ID = item2.Medida_ID;

                //    //    //    hb.TT_Pedido_Cuerpo.Add(z);
                //    //    //    hb.SaveChanges();
                //    //    //}
                //    //}
                //}

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

                if (ConsultaPedido.Count > 0)
                {
                    hb.TT_Pedido_Cuerpo.RemoveRange(ConsultaPedido);
                    hb.SaveChanges();
                }
            }
        }
        private void DeleteTablaTemporarOrdenCargacuerpo()
        {
            using (var hb = new DBdatos())
            {
                var ConsultaOCC = (from PC in hb.TT_OrdenProduccion_Cuerpo
                                   where PC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                        && PC.Sesion_ID == clsVariablesGenerales.SesionID
                                   //where PC.Registro_Pedidos.Cliente_ID == (int)cmbCliente.SelectedValue
                                   //  && PC.Estado_ID == "PEN"
                                   select PC).ToList();

                hb.TT_OrdenProduccion_Cuerpo.RemoveRange(ConsultaOCC);
                hb.SaveChanges();
            }
        }
        private void Agregar()
        {
            //var i = new Orden_Produccion1();

            //i.Fecha = DateTime.Now.Date;
            //i.Fecha_Limite = DateTime.Now.Date;
            //i.Responsable_ID = 5;
            //i.
        }
        private void CargarOrdenProduccion()
        {
            ValidacionAlCargarDatos();

            if (Valida == true)
            {
                if (AsociarOrdenProduccion == "NO")
                {
                    int ID;

                    using (var hb = new DBdatos())
                    {
                        var ConsultaNumeroOrden = (from OR in hb.Orden_Produccion1
                                                   where OR.NumeroOrden == txtNumeroOrden.Text
                                                        && OR.Estado_ID != "AN"
                                                   select OR).FirstOrDefault();

                        if (ConsultaNumeroOrden == null)
                        {
                            var i = new Orden_Produccion1();

                            i.ID = OrdenID;
                            i.NumeroOrden = txtNumeroOrden.Text;
                            i.Fecha = dtpFecha.Value.Date;
                            i.Fecha_Limite = dtpFechaLimite.Value.Date;
                            i.Responsable_ID = (int)cmbResponsable.SelectedValue;

                            if (rdbAutorizado.Checked)
                                i.Estado_ID = "AU";
                            //if (rdbInform.Checked)
                            //    i.Estado_ID = "INF";

                            hb.Orden_Produccion1.Add(i);

                            var ConsultaTTpedido = (from PC in hb.TT_Pedido_Cuerpo
                                                    where PC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                                        && PC.Sesion_ID == clsVariablesGenerales.SesionID
                                                    select PC); // CONSULTA A LA TT PEDIDO CUERPO

                            var ResultadoTTPedido = ConsultaTTpedido.ToList();

                            List<long?> ListaPedidos_ID = new List<long?>(); // LISTA CREADA PARA GUARDAR LOS ID DE LA TABLA PEDIDO CUERPO PARA EN EL FINAL VER QUE SI FINALIZA UN PEDIDO O QUEDA PENDIENTE

                            long IDFicticio = 0; // Variable que sirvve para calcular el ID del la tabla OrdenProduccion_Cuerpo

                            foreach (var item in ResultadoTTPedido) // RECORRIDO DE LA TABLA TEMPORAL PEDIDO
                            {
                                var ConsultaPedCuerpo = (from PC in hb.Pedido_Cuerpo
                                                         where PC.ID == item.Ped_Cuerp_ID
                                                         select PC); // CONSULTA PARA VER QUE PEDIDOS DEBEMOS MODIFICAR LA CANTIDAD EN LA TABLA PEDIDO_CUERPO                  

                                var ResultaodosPedCuerpo = ConsultaPedCuerpo.FirstOrDefault();

                                // SI AFECTE CANTIDADES
                                if (ResultaodosPedCuerpo != null)
                                {

                                    if (item.Cantidad_Afectada > 0) // SI TIENE CANTIDAD AFECTADA SE MODIFICAN LAS CANTIDADES DEL PEDIDO
                                    {

                                        // AJUSTA EL PEDIDO CUERPO
                                        ListaPedidos_ID.Add(item.Pedido_ID);
                                        // ResultaodosPedCuerpo.Cantidad_Pend_Producir = ResultaodosPedCuerpo.Cantidad_Pend_Producir - (decimal)item.Cantidad_Afectada; // Cantidad Pend de afectar
                                        // ResultaodosPedCuerpo.Cantidad_Pend_Producir = ResultaodosPedCuerpo.Cantidad;
                                        ResultaodosPedCuerpo.Cantidad_Afec_Producir = ResultaodosPedCuerpo.Cantidad_Afec_Producir + item.Cantidad_Afectada;
                                        ResultaodosPedCuerpo.Cantidad_Total_Producida = 0;

                                        //if (item.Cantidad == 0) // SI LA CANTIDAD PENDIENTE ES = 0 ENTONCES ESA FILA DEL PEDIDOCUERPO ESTA COMPLETA
                                        //    ResultaodosPedCuerpo.Estado_ID = "COM";
                                        //else
                                        //    ResultaodosPedCuerpo.Estado_ID = "PEN";

                                        // SE CARGA DATOS EN ORDEN CARGA CUERPO
                                        var z = new OrdenProduccion_Cuerpo();

                                        var ConsultaID = (from OPC in hb.OrdenProduccion_Cuerpo
                                                          orderby OPC.ID descending
                                                          select OPC).FirstOrDefault();

                                        if (ConsultaID == null)
                                        {
                                            IDFicticio = IDFicticio + 1;
                                            z.ID = IDFicticio;
                                        }
                                        else
                                        {
                                            IDFicticio = IDFicticio + 1;
                                            z.ID = ConsultaID.ID + IDFicticio;
                                           
                                        }

                                        z.OrdenProd_ID = OrdenID;
                                        z.Pedido_ID = (long)item.Pedido_ID;
                                        z.Producto_ID = item.Producto_ID;
                                        z.Cantidad = (decimal)item.Cantidad_Afectada;
                                        z.Avance = 0;
                                        z.Estado_ID = "PEN";

                                        hb.OrdenProduccion_Cuerpo.Add(z);
                                    }
                                }
                            }
                            hb.SaveChanges();
                            Reutilizables.AbriFormFinalizado("C:/Program Files (x86)/Pack-Codin/Images/FinalizarPedido.png", "O. Producción agregada correctamente");
                            //MessageBox.Show("Datos cargados correctamente", "Atención");
                            
                            DeleteTablaTemporarPedidoCuerpo();
                            this.Hide();
                            FormularioMostrarOrdenProd.MostrarDatos();
                        }
                        else
                        {
                            MessageBox.Show("El número de orden " + " " + txtNumeroOrden.Text + " " + "ya existe en la base de datos", "Atención");
                        }
                    }
                }
            }
            if(AsociarOrdenProduccion == "SI") // SI SE LE AGREGA CANTIDAD
            {
                CalculaIdOrdenProduccion();

                long OrdenProducionCuerpoID;
                string NumeroOrden = txtNumeroOrden.Text;
                string ProductoID;
                decimal Cantidad;
                long PedidoID;

                
                //VER
                using (var hb = new DBdatos())
                {
                    // CONSULTA PARA SABER EL ESTADO DE LA ORDEN DE PRODUCCION
                    var ConsultaOP = (from OP in hb.Orden_Produccion1
                                      where OP.ID == IDRecibido
                                      select OP).FirstOrDefault();
                    // RECORRE EL DGV
                    for (var i = 1; i <= dgvPedidoProductos.RowCount; i++)
                    {
                        PedidoID = (long)dgvPedidoProductos.Rows[i - 1].Cells[columnName: "colPedidoID"].Value;
                        ProductoID = dgvPedidoProductos.Rows[i - 1].Cells[columnName: "colProductoID"].Value.ToString();
                        Cantidad = Convert.ToDecimal(dgvPedidoProductos.Rows[i - 1].Cells[columnName: "colCantidadAfec"].Value);

                        // CONSULTA SI HAY ALGUN OPC CREADO CON LAS MISMAS CARACTERISTICAS
                        var ConsultaOPC = (from OPC in hb.OrdenProduccion_Cuerpo
                                           where OPC.OrdenProd_ID == IDRecibido
                                                && OPC.Pedido_ID == PedidoID
                                                && OPC.Producto_ID == ProductoID
                                           select OPC).FirstOrDefault();

                        // CONSULTA PARA MODIFICAR LAS CANTIDADES DEL PEDIDO CUERPO
                        var ConsultaPedidoCuerpo = (from C in hb.Pedido_Cuerpo
                                                    where C.Pedido_ID == PedidoID
                                                        && C.Producto_ID == ProductoID
                                                    select C).FirstOrDefault();

                        // SI NO LO HAY LO CREA
                        if (ConsultaOPC == null)
                        {
                            long IDFicticio = 1;

                            //MODIFICAR PEDIDO CUERPO
                           
                            var ConsultaID = (from OPC in hb.OrdenProduccion_Cuerpo
                                              orderby OPC.ID descending
                                              select OPC).FirstOrDefault();

                            var P = new OrdenProduccion_Cuerpo();

                            if (ConsultaID == null)
                            {
                                P.ID = 1;
                                OrdenProducionCuerpoID = 1;
                            }
                            else
                            {
                                IDFicticio = ConsultaID.ID + IDFicticio;
                                P.ID = IDFicticio;
                                OrdenProducionCuerpoID = IDFicticio;
                            }

                            P.OrdenProd_ID = IDRecibido;
                            P.Pedido_ID = PedidoID;
                            P.Producto_ID = ProductoID;
                            P.Cantidad = Cantidad;
                            P.Avance = 0;
                            P.Estado_ID = "PEN";

                            hb.OrdenProduccion_Cuerpo.Add(P);

                            //var ConsultaPedidoCuerpo = (from C in hb.Pedido_Cuerpo
                            //                            where C.Pedido_ID == PedidoID
                            //                                && C.Producto_ID == ProductoID
                            //                            select C).FirstOrDefault();

                            //if(ConsultaPedidoCuerpo != null)
                            //{
                            //    ConsultaPedidoCuerpo.Cantidad_Afec_Producir = Cantidad;
                            //    ConsultaPedidoCuerpo.Estado_ID = "PEN";
                            //}
                        }
                        else
                        {
                            OrdenProducionCuerpoID = ConsultaOPC.ID;
                            ConsultaOPC.Cantidad = ConsultaOPC.Cantidad + Cantidad;
                            ConsultaOPC.Estado_ID = "PEN";
                        }

                        ConsultaPedidoCuerpo.Cantidad_Afec_Producir = ConsultaPedidoCuerpo.Cantidad_Afec_Producir + Cantidad;
                        ConsultaPedidoCuerpo.Estado_ID = "PEN";
                        
                        var ConsultaCantInsAsociados = (from FP in hb.Formula_Producto
                                                            where FP.Producto_ID == ProductoID
                                                                && FP.Productos_Insumos.Subproducto == "NO"
                                                            select FP).ToList();

                        var ConsultaConfig = (from Conf in hb.PcnConfiguraciones
                                              where Conf.Modulo_ID == 1
                                              select Conf).FirstOrDefault();

                        if (ConsultaOP.Estado_ID == "PRO" || ConsultaOP.Estado_ID == "FI")
                        {
                            if (ConsultaConfig.TrabajaConStockNegativo == "NO")
                            {
                                foreach (var item2 in ConsultaCantInsAsociados)
                                {
                                    var ConsultaExistenciIns = (from EI in hb.Existencia_Insumos
                                                                where EI.Insumo_ID == item2.Insumo_ID
                                                                //&& EI.Productos_Insumos.Subproducto == "NO" // QUE SOLO VALORE PARA DESCONTAR STOCKS DE INSUMO LOS QUE NO SON SUBPRODUCTOS
                                                                group EI by new { EI.Insumo_ID } into Grupo
                                                                select new
                                                                {
                                                                    Grupo.Key.Insumo_ID,
                                                                    CantidadDisponible = Grupo.Sum(x => x.Cantidad) - Grupo.Sum(x => x.Cantidad_Utilizada)
                                                                });

                                    var ResultadosExistenciIns = ConsultaExistenciIns.FirstOrDefault();

                                    if (ResultadosExistenciIns != null)
                                    {
                                        decimal CantidadRequerida = Cantidad * item2.Cantidad; // CANTIDAD DE LA ORDEN DE PRODUCCION X LA CANTIDAD DE LA FORMULA
                                        decimal CantidadDisponible = ResultadosExistenciIns.CantidadDisponible;

                                        if (CantidadDisponible < CantidadRequerida) // CORROBORAR LAS CANTIDADES DE INSUMOS
                                        {
                                            string Mensaje = "La cantidad del insumo " + item2.Productos_Insumos.Descripcion + " - " + item2.Productos_Insumos.Codigo + " no abastece la cantidad requerida"
                                                + "\r\n"
                                                + "\r\n"
                                                + "Cantidad Requerida  = " + CantidadRequerida.ToString("N2") + "  " + item2.Productos_Insumos.Medidas_Producto.Descripcion
                                                + "\r\n"
                                                + "Cantidad Disponible = " + CantidadDisponible.ToString("N2") + "  " + item2.Productos_Insumos.Medidas_Producto.Descripcion
                                                + "\r\n"
                                                + "                                 ____________________"
                                                + "\r\n"
                                                + "Faltantes                        " + (CantidadRequerida - CantidadDisponible).ToString("N2") + "  " + item2.Productos_Insumos.Medidas_Producto.Descripcion;

                                            MessageBox.Show(Mensaje, "Atención");
                                            return;
                                        }
                                        else
                                        {
                                            decimal CantidadAcumulada = 0;
                                            decimal CantidadParcial = CantidadRequerida; // Esta es la cantidad requerida , la diferencia que se le va restando las cantidades
                                            List<long?> ListaID = new List<long?>();

                                            while (CantidadRequerida != CantidadAcumulada)
                                            {
                                                decimal CantidadDisponiblePorRegistro = 0;

                                                var ConsultaExistenciaIns2 = (from EI in hb.Existencia_Insumos
                                                                              where EI.Insumo_ID == item2.Insumo_ID
                                                                                && EI.Cantidad != EI.Cantidad_Utilizada
                                                                                && !ListaID.Contains(EI.ID)
                                                                              select EI);

                                                var ResultadoConsultaExistenciaIns2 = ConsultaExistenciaIns2.FirstOrDefault();


                                                CantidadDisponiblePorRegistro = ResultadoConsultaExistenciaIns2.Cantidad - ResultadoConsultaExistenciaIns2.Cantidad_Utilizada;

                                                if (CantidadDisponiblePorRegistro >= CantidadParcial)
                                                {
                                                    ResultadoConsultaExistenciaIns2.Cantidad_Utilizada = ResultadoConsultaExistenciaIns2.Cantidad_Utilizada + CantidadParcial;
                                                    CantidadAcumulada = CantidadAcumulada + CantidadParcial;

                                                    if (ResultadoConsultaExistenciaIns2.Cantidad == ResultadoConsultaExistenciaIns2.Cantidad_Utilizada)
                                                        ResultadoConsultaExistenciaIns2.Estado_ID = "COM";
                                                    if (ResultadoConsultaExistenciaIns2.Cantidad > ResultadoConsultaExistenciaIns2.Cantidad_Utilizada)
                                                        ResultadoConsultaExistenciaIns2.Estado_ID = "PEN";
                                                }
                                                else
                                                {
                                                    ResultadoConsultaExistenciaIns2.Cantidad_Utilizada = ResultadoConsultaExistenciaIns2.Cantidad; // usa todo
                                                    CantidadAcumulada = CantidadAcumulada + CantidadDisponiblePorRegistro;
                                                    ResultadoConsultaExistenciaIns2.Estado_ID = "COM";

                                                    CantidadParcial = CantidadRequerida - CantidadDisponiblePorRegistro;
                                                    ListaID.Add(ResultadoConsultaExistenciaIns2.ID);
                                                }
                                                // AQUI CARGA LOS DATOS EN LA TABLA EXISTENCIAINSUMOS_EXISTENCIA PRODUCTOS PARA HACER TRAZABILIDAD
                                                var I = new ExistenciaProducto_ExistenciaInsumo();

                                                I.ExistenciaInsumo_ID = ResultadoConsultaExistenciaIns2.ID;
                                                I.ExitenciaProducto_ID = null;
                                                I.OrdenProduccion_ID = IDRecibido;
                                                I.Cantidad = CantidadRequerida;

                                                hb.ExistenciaProducto_ExistenciaInsumo.Add(I);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No hay ningun registro del insumo " + item2.Productos_Insumos.Descripcion + " en el sistema. Para poder cargar un producto final deberá primero cargar este insumo", "Atención");
                                        return;
                                    }
                                }
                            }
                            // VER ACA QUE NO CREE UN NUEVO ORDEN PRODUCCION PARTE SINO QUE LO EDITE O CREE SEGUN SEA CONVENIENTE
                            var ConsultaCircuito = (from CIR in hb.Seccion_Circuito
                                                    where CIR.Producto_ID == ProductoID
                                                        && (CIR.Productos_Insumos.Subproducto == "SI" || CIR.Insumo_ID == null)
                                                    select CIR).ToList();

                            foreach (var item3 in ConsultaCircuito)
                            {
                                // CONSULTA REALIZADA PARA SABER SI HAY UNA OPP YA CREADA
                                var ConsultaOPP = (from OPP in hb.Orden_Produccion_Parte
                                                   where OPP.OrdenProducCuerpo_ID == OrdenProducionCuerpoID                                  
                                                   select OPP).FirstOrDefault();


                                var ConsultaFormula = (from FP in hb.Formula_Producto
                                                       where FP.Producto_ID == ProductoID
                                                            && FP.Insumo_ID == item3.Insumo_ID
                                                       select FP).FirstOrDefault();

                                // SI NO HAY NINGUNA OPP CREADA, PROCEDE A CREARLA
                                if (ConsultaOPP == null)
                                {
                                    if (ConsultaFormula != null)
                                    {
                                        var q = new Orden_Produccion_Parte();

                                        q.OrdenProducCuerpo_ID = OrdenProducionCuerpoID;
                                        q.Insumo_ID = item3.Insumo_ID;
                                        q.Seccion_ID = item3.Seccion_ID;
                                        q.Cantidad = Cantidad * ConsultaFormula.Cantidad; // CANTIDAD A PRODUCIR X CANTIDAD DE LA FORMULA
                                        q.Cantidad_Producida = 0;
                                        q.Avance = 0;
                                        q.Estado_ID = "PEN";

                                        hb.Orden_Produccion_Parte.Add(q);
                                    }
                                    // SI ENTRA AQUI ES PORQUE ES LA SECCION FINAL
                                    else
                                    { 
                                        var q = new Orden_Produccion_Parte();

                                        q.OrdenProducCuerpo_ID = OrdenProducionCuerpoID;
                                        q.Insumo_ID = null;
                                        q.Seccion_ID = item3.Seccion_ID;
                                        q.Cantidad = Cantidad; // CANTIDAD A PRODUCIR X CANTIDAD DE LA FORMULA
                                        q.Cantidad_Producida = 0;
                                        q.Avance = 0;
                                        q.Estado_ID = "PEN";

                                        hb.Orden_Produccion_Parte.Add(q);
                                    }
                                }
                                // SI YA EXISTE UNA OPP CREADA IGUAL
                                else
                                {
                                    // SOLO MODIFICA SU CANTIDAD
                                    ConsultaOPP.Cantidad = ConsultaOPP.Cantidad + Cantidad;
                                    ConsultaOPP.Estado_ID = "PEN";
                                }
                            }
                        }

                        // SI ESTA EN ESTADO "FI" PASA A ESTADO "PRO"
                        if (ConsultaOP.Estado_ID == "FI")
                            ConsultaOP.Estado_ID = "PRO";

                        hb.SaveChanges();
                        Reutilizables.AbriFormFinalizado("C:/Program Files (x86)/Pack-Codin/Images/FinalizarPedido.png", "Pedidos agregados correctamente");

                        // MessageBox.Show("Pedidos agregados correctamente a la orden de producción", "Atención");                       
                    }
                }
            }
        }
        private void CargarOrden()
        {
            using (var hb = new DBdatos())
            {
                var ConsultaVOOC = (from VOOC in hb.VistaOCC_CantidadesAfectas
                                    where VOOC.Estado == "Pendiente"
                                    select VOOC);

                var ResultadosVOOC = ConsultaVOOC.FirstOrDefault();

                if (ResultadosVOOC == null)
                {
                    var i = new Orden_Carga();

                    i.ID = OrdenID;
                    i.Fecha = dtpFecha.Value.Date;
                    //i.Cliente_ID = (int)cmbCliente.SelectedValue;
                    i.Ciudad_ID = (int)cmbResponsable.SelectedValue;
                    i.Observaciones = txtObservaciones.Text;
                    i.Estado_ID = "FI";

                    hb.Orden_Carga.Add(i);

                    // AJUSTA EL PEDIDO
                    var ConsultaTTpedido = (from PC in hb.TT_Pedido_Cuerpo
                                            where PC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                                && PC.Sesion_ID == clsVariablesGenerales.SesionID
                                            select PC); // CONSULTA A LA TT PEDIDO

                    var ResultadoTTPedido = ConsultaTTpedido.ToList();

                    List<long?> ListaPedidos_ID = new List<long?>(); // LISTA CREADA PARA GUARDAR LOS ID DE LA TABLA PEDIDO CUERPO PARA EN EL FINAL VER QUE SI FINALIZA UN PEDIDO O QUEDA PENDIENTE

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
                                                      select TTAFEC);

                                var ResultadpsTTAFEC = ConsultaTTAFEC.ToList();

                                foreach (var item2 in ResultadpsTTAFEC)
                                {
                                    var ConsultaEPT = (from EPT in hb.Existencia_ProductoTerminado
                                                       where EPT.ID == item2.ExitenciaProTer_ID
                                                       select EPT);

                                    var ResultadosEPT = ConsultaEPT.FirstOrDefault();

                                    if (ResultadosEPT != null)
                                    {
                                        ResultadosEPT.Cantidad_Utiliz = ResultadosEPT.Cantidad_Utiliz + item2.Cantidad;

                                        if(ResultadosEPT.Cantidad_Utiliz == ResultadosEPT.Cantidad)
                                        {
                                            ResultadosEPT.Estado_ID = "ENT";
                                        }
                                    }

                                    var w = new Producto_Afec_OrdenCarga();

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

                        // CLICLO PARA VER DESCONTAR LOS PRODUCTOS DE LAS TABLA EXISTENCIA PRODUCTO
                        for (int l = 1; l <= item.Cantidad_Afectada; l++)
                        {
                            var ConsultaExistencia = (from EP in hb.Existencia_ProductoTerminado
                                                      where EP.Produto_ID == item.Producto_ID
                                                            // && EP.Estado_ID == "PEN"
                                                            && !ProductosExluidos.Contains(EP.ID)
                                                      orderby EP.Fecha
                                                      select EP);

                            var ResultadoExistencia = ConsultaExistencia.FirstOrDefault();
                            decimal CantidadDeProductos = ConsultaExistencia.Count();

                            if (ResultadoExistencia != null)
                            {
                                //  ResultadoExistencia.Estado_ID = "COM";
                                ProductosExluidos.Add(ResultadoExistencia.ID);
                            }
                        }
                    }
                    hb.SaveChanges();
                    MessageBox.Show("Datos cargados correctamente", "Atención");
                    DeleteTablaTemporarPedidoCuerpo();

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
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("No se puede finalizar la Orden de carga porque aún tiene pedidos pendientes de asignarle productos", "Atención");
                    return;
                }
            }
        }
       
        private void CalculaIdOrdenProduccion()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from OC in hb.Orden_Produccion1
                                orderby OC.ID descending
                                select OC);

                var Resultados = Consulta.FirstOrDefault();

                if(Resultados == null)
                {
                    OrdenID = 1;
                   // txtNumeroOrden.Text = "1";
                }
                else
                {
                    OrdenID = Resultados.ID + 1;
                    //txtNumeroOrden.Text = (Resultados.ID + 1).ToString();
                }
            }
        }
        private void AnularOrden() // QUEDA PENDIENTE ESTO
        {
            DialogResult R = MessageBox.Show("¿Esta seguro que desea anular esta orden de producción", "Atención", MessageBoxButtons.YesNo);
            if (R == DialogResult.Yes)
            {
                using (var hb = new DBdatos())
                {
                    // TRAE LA ORDEN A ANULAR
                    var ConsultaOP = (from OC in hb.Orden_Produccion1
                                      where OC.ID == IDRecibido
                                      select OC).FirstOrDefault();

                    // SI EL ESTADO DE LA ORDEN ES INFORMATIVA O AUTORIZADA
                    if (ConsultaOP.Estado_ID == "INF" || ConsultaOP.Estado_ID == "AU")
                    {
                        ConsultaOP.Estado_ID = "AN";

                        // TRAE LOS REGISTROS DE LA OPC CON ESE ORDENPROD_ID
                        var ConsultaOPC = (from OPC in hb.OrdenProduccion_Cuerpo
                                           where OPC.OrdenProd_ID == IDRecibido
                                           select OPC).ToList();

                        // REALIZA EL CICLO
                        foreach(var itemOPC in ConsultaOPC)
                        {
                            // PASA EL PRODUCTO DE LA ORDENPRODUCCIONCUERPO A ESTADO ANULADO
                            itemOPC.Estado_ID = "AN";

                            // TRAE LOS PRODUCTOS DE LA TABLA PEDIDOCUERPO PARA ANULARLOS TAMBIEN
                            var ConsultaPEDC = (from PEDC in hb.Pedido_Cuerpo
                                               where PEDC.Pedido_ID == itemOPC.Pedido_ID
                                                    && PEDC.Producto_ID == itemOPC.Producto_ID
                                               select PEDC).ToList();

                            foreach(var itemPEDC in ConsultaPEDC)
                            {
                                //// DEVUELVE LA CANTIDAD PENDIENTE DE PRODUCIR A LA TABLA PEDIDOCUERPO
                                //itemPEDC.Cantidad_Pend_Producir = itemPEDC.Cantidad_Pend_Producir + itemOPC.Cantidad;
                                //// DESCUENTA LA CANTIDAD POR PRODUCIR A LA TABLA PEDIDOCUERPO
                                //itemPEDC.Cantidad_Total_Producida = itemPEDC.Cantidad_Total_Producida - itemOPC.Cantidad;
                                //itemPEDC.Cantidad_Afec_Producir = itemPEDC.Cantidad_Afec_Producir - itemOPC.Cantidad;

                               // itemPEDC.Cantidad_Pend_Producir = itemPEDC.Cantidad_Pend_Producir + itemPEDC.Cantidad_Total_Producida;

                               // itemPEDC.Cantidad_Total_Producida = 0;
                                
                                itemPEDC.Cantidad_Afec_Producir = itemPEDC.Cantidad_Afec_Producir - itemOPC.Cantidad;
                            }
                           
                        }
                    }
                    // SI ESTA EN PROCESO O FINALIZADA
                    else
                    {
                        // CONSULTA TODOS LAS OPC CON ESE NUMERO DE ORDEN DE PROD
                        var ConsultaOPC = (from OPC in hb.OrdenProduccion_Cuerpo
                                           where OPC.OrdenProd_ID == IDRecibido
                                           select OPC).ToList();

                        // RECORRE UNO POR UNO
                        foreach (var itemOPC in ConsultaOPC)
                        {
                            // CONSULTA EL EL PEDIDO CUERPO DE CADA ORDEN DE PRODUCCION
                            var ConsultaPEDC = (from PEDC in hb.Pedido_Cuerpo
                                                where PEDC.Pedido_ID == itemOPC.Pedido_ID
                                                     && PEDC.Producto_ID == itemOPC.Producto_ID
                                                select PEDC).ToList();

                            // CONSULTA EL NUMERO DE ORD PROD PARTE
                            var ConsultaOPP = (from OPP in hb.Orden_Produccion_Parte
                                               where OPP.OrdenProducCuerpo_ID == itemOPC.ID
                                               select OPP).ToList();

                            // VARIABLE CREADA PARA SABER CUANTA CANTIDAD HAY PRODUCIDA EN CADA OPPC
                            decimal CantidadProducida = 0;

                            //RECORRE TODOS LOS OPP RELACIONADOS CON EL OPC
                            foreach (var itemOPP in ConsultaOPP)
                            {
                                var ConsultaOPPC1 = (from OPPC in hb.OrdenProduccionParteCuerpo
                                                     where OPPC.OrdenProdParte_ID == itemOPP.ID
                                                     select OPPC).ToList();

                                foreach(var itemOPPC in ConsultaOPPC1)
                                {
                                    // CALCULA LA CANTIDAD PRODUCIDA
                                    CantidadProducida = CantidadProducida + itemOPPC.Cantidad;
                                }
                            }


                            foreach (var itemPEDC in ConsultaPEDC)
                            {
                                //// DEVUELVE LA CANTIDAD PENDIENTE DE PRODUCIR A LA TABLA PEDIDOCUERPO
                                //itemPEDC.Cantidad_Pend_Producir = itemPEDC.Cantidad_Pend_Producir + itemOPC.Cantidad;
                                //// DESCUENTA LA CANTIDAD POR PRODUCIR A LA TABLA PEDIDOCUERPO
                                //itemPEDC.Cantidad_Total_Producida = itemPEDC.Cantidad_Total_Producida - itemOPC.Cantidad;
                                //itemPEDC.Cantidad_Afec_Producir = itemPEDC.Cantidad_Afec_Producir - itemOPC.Cantidad;

                                //// DEVUELVE LA CANTIDAD PENDIENTE DE PRODUCIR A LA TABLA PEDIDOCUERPO

                                // DEVUELVE LA CANTIDAD PENDIENTE DE PRODUCIR A LA TABLA PEDIDOCUERPO
                                itemPEDC.Cantidad_Pend_Producir = itemPEDC.Cantidad_Pend_Producir + CantidadProducida;

                                // RECUPERA LA CANTIDAD TOTAL PRODUCIDA A LA TABLA PEDIDOCUERPO
                                itemPEDC.Cantidad_Total_Producida = itemPEDC.Cantidad_Total_Producida - CantidadProducida;
                                // RECUPERA LA CANTIDAD AFECTADA A LA ORDEN A LA TABLA PEDIDOCUERPO
                                itemPEDC.Cantidad_Afec_Producir = itemPEDC.Cantidad_Afec_Producir - itemOPC.Cantidad;

                            }
                        }


                        var ConsultaOPPC = (from OPPC in hb.OrdenProduccionParteCuerpo
                                                where OPPC.Orden_Produccion_Parte.OrdenProduccion_Cuerpo.OrdenProd_ID == IDRecibido
                                                    && OPPC.Orden_Produccion_Parte.Seccion.Seccion_Final == "SI"
                                                select OPPC).ToList();

                        //REVISA QUE NO HAYA PRODUCTOS PRODUCIDOS
                        if (ConsultaOPPC.Count > 0)
                        {
                            foreach (var itemOPPC in ConsultaOPPC)
                            {
                                var ConsultaEPT = (from EPT in hb.Existencia_ProductoTerminado
                                                   where EPT.OrdenProduccionParteCuerpo_ID == itemOPPC.ID
                                                   select EPT).FirstOrDefault();

                                if (ConsultaEPT.Cantidad_Utiliz > 0)
                                {
                                    MessageBox.Show("No se puede anular la orden de producción ya que 1 o mas de sus productos están afectados a Ordenes de carga", "Atención");
                                    return;
                                }
                                else
                                {
                                    ConsultaEPT.Estado_ID = "AN";
                                    itemOPPC.Orden_Produccion_Parte.OrdenProduccion_Cuerpo.Orden_Produccion.Estado_ID = "AN";
                                }


                            }
                        }
                        else
                        {
                            ConsultaOP.Estado_ID = "AN";
                        }

                        // CONSULTA LOS INSUMOS AFECTADOS
                        var ConsultaEPI = (from EPI in hb.ExistenciaProducto_ExistenciaInsumo
                                           where EPI.OrdenProduccion_ID == IDRecibido
                                           select EPI).ToList();

                        // AQUI DEVUELVE LAS CANTIDADES AFECTADAS
                        foreach (var itemEPI in ConsultaEPI)
                        {
                            var ConsultaEI = (from EI in hb.Existencia_Insumos
                                              where EI.ID == itemEPI.ExistenciaInsumo_ID
                                              select EI).FirstOrDefault();

                            ConsultaEI.Cantidad_Utilizada = ConsultaEI.Cantidad_Utilizada - itemEPI.Cantidad;
                        }


                    }
                    hb.SaveChanges();
                    MessageBox.Show("Orden de producción anulada correctamente", "Atención");
                    DeleteTablaTemporarPedidoCuerpo();
                    DeleteTablaTemporarOrdenCargacuerpo();
                    DeleteTablaTemporalTTAFEC();
                    DeleteTablaTemporalTTRPT();
                    this.Hide();
                    FormularioMostrarOrdenProd.MostrarDatos();
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
                btnEditar.Enabled = true;
            else
                btnEditar.Enabled = false;
        }
        private void MostrarCantidadEntxt()
        {
            if (dgvPedidoProductos.RowCount > 0)
            {
                decimal Cantidad = (decimal)dgvPedidoProductos.CurrentRow.Cells[columnName: "colCantidad"].Value;
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
        private void ValidacionAlCargarDatos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from TTOPC in hb.TT_OrdenProduccion_Cuerpo
                                where TTOPC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                    && TTOPC.Sesion_ID == clsVariablesGenerales.SesionID
                                select TTOPC).ToList();

                if(Consulta.Count<=0 || cmbResponsable.SelectedIndex == -1 || !rdbAutorizado.Checked  || txtNumeroOrden.TextLength == 0)
                {
                    if (Consulta.Count <= 0)
                    {
                        MessageBox.Show("No hay productos afectados", "Atención");
                        Valida = false;
                        return;
                    }
                    if(cmbResponsable.SelectedIndex < 0)
                    {
                        MessageBox.Show("No selecciono responsable", "Atención");
                        Valida = false;
                        return;
                    }
                    if (!rdbAutorizado.Checked)
                    {
                        MessageBox.Show("No selecciono ningun estado", "Atención");
                        Valida = false;
                        return;
                    }
                    if(txtNumeroOrden.TextLength == 0)
                    {
                        MessageBox.Show("No ingresó el número de orden de producción", "Atención");
                        Valida = false;
                        return;
                    }
                    
                }
                else
                {
                    Valida = true;
                }
            }
        }
        private void OnOffBtnConfirnarordenPedido()
        {


            //if (cmbCliente.SelectedIndex != -1)
            //{

            //    using (var hb = new DBdatos())
            //    {
            //        //for (var i = 1; i <= dgvPedidoProductos.RowCount; i++)
            //        //{
            //        //    if ((decimal)dgvPedidoProductos.Rows[i - 1].Cells[6].Value != 0)
            //        //    {

            //        //    }
            //        //}

            //        //var Consulta = (from OP in hb.Registro_Pedidos
            //        //                join PC in hb.Pedido_Cuerpo on OP.ID equals PC.Pedido_ID
            //        //                join PRO in hb.Productos_Insumos on PC.Producto_ID equals PRO.Codigo
            //        //                where OP.Cliente_ID == (int)cmbCliente.SelectedValue
            //        //                     && PC.Cantidad_Afectada != 0
            //        //                select PC);

            //        if (dgvPedidoProductos.RowCount > 0)
            //        {
            //            var Consulta = (from TT in hb.TT_Pedido_Cuerpo
            //                            where TT.Cantidad_Afectada > 0
            //                            select TT);

            //            var Resultados = Consulta.FirstOrDefault();

            //            if (Resultados != null)
            //            {
            //                if (cmbCliente.SelectedIndex != -1 && cmbResponsable.SelectedIndex != -1)
            //                {
            //                    btnCargar.Enabled = true;
            //                }
            //            }
            //            else
            //            {
            //                btnCargar.Enabled = false;
            //            }
            //        }
            //    }
            //}
        }
        private void dgvPedidoProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            MostrarEstadosEnColores(e);
        }
        private void AbrirFormAfectarProducto()
        {
            //string ProductoID;
            //ProductoID = dgvPedidoProductos.CurrentRow.Cells[columnName:].Value.ToString();

            //var f = new frmSeleccionarProducto();
            //f.ProductoID = ProductoID;
            //f.CantidadParaAfectar = Convert.ToDecimal(txtCantidad.Text);
            //f.ShowDialog();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
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
            txtCantidad.SelectAll();
            OnOffbtnEditarCantidad();
        }

        private void btnAfectados_Click(object sender, EventArgs e)
        {         
            MostrarAfectados();
            
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
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraProducto, cmbProducto, txtBuscarProducto, btnBuscarIProducto,"PRO","NO");
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
        }

        private void btnAfec_Click(object sender, EventArgs e)
        {
            AfectarPedido("1"); // Desafecta la fila seleccionada de los afectados
            OnOffBtnConfirnarordenPedido();
        }

        private void txtBuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == Convert.ToChar(Keys.Enter))
            //{
            //    txtBuscarCliente.Visible = false;
            //    clsCargarCombos.MostrarComboClientes(cmbCliente, txtBuscarCliente, true, "CLI");
            //    txtBuscarCliente.Focus();
            //    e.Handled = true;
            //}
            //if (e.KeyChar == Convert.ToChar(Keys.Escape))
            //{
            //    txtBuscarCliente.Visible = false;
            //    txtBuscarCliente.Focus();
            //    e.Handled = true;
            //}
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            //txtBuscarCliente.Visible = true;
            //txtBuscarCliente.Select();
        }

        private void txtBuscarCiudad_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, false);
                e.Handled = true;
            }
        }

        private void btnBuscarCiudad_Click(object sender, EventArgs e)
        {
            txtBuscarResponsable.Visible = true;
            txtBuscarResponsable.Select();
        }

        private void cmbCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == Convert.ToChar(Keys.Escape))
            //{
            //    clsCargarCombos.MostrarComboClientes(cmbCliente, txtBuscarCliente, false, "CLI");
            //}
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {           
            CargarOrdenProduccion();
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
            //using (var hb = new DBdatos())
            //{
            //    var Consulta = (from OP in hb.Orden_Produccion1
            //                    where OP.ID == IDRecibido
            //                    select OP).FirstOrDefault();

            //    if(Consulta.Estado_ID <> "AN")
                    
            //    if (AfectarAfectados == "2")
            //    {
            //        string ProductoID;
            //        string ProductoDescripcion;
            //        decimal Cantidad;
            //        long PedidoID;
            //        string Estado;

            //        ProductoID = dgvPedidoProductos.CurrentRow.Cells[1].Value.ToString();
            //        ProductoDescripcion = dgvPedidoProductos.CurrentRow.Cells[3].Value.ToString();
            //        Cantidad = (decimal)dgvPedidoProductos.CurrentRow.Cells[6].Value;
            //        PedidoID = (long)dgvPedidoProductos.CurrentRow.Cells[0].Value;
            //        Estado = txtEstado.Text;

            //        var f = new frmSeleccionarProducto();
            //        f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmSeleccionarProducto_FormClosed);
            //        f.ProductoID = ProductoID;
            //        f.CantidadParaAfectar = Cantidad;
            //        f.PedidoID = PedidoID;
            //        f.CrearEditar = CrearEditar;

            //        if (CrearEditar == "1" || CrearEditar == "3")
            //            f.OrdenID = OrdenID;
            //        if (CrearEditar == "2")
            //            f.OrdenID = Convert.ToInt64(txtNumeroOrden.Text);

            //        f.ProductoDescripcion = ProductoDescripcion;
            //        f.Estado = Estado;
            //        f.ShowDialog();
            //    }
            //}
        }
        private void frmSeleccionarProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(AfectarAfectados == "2")
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

        private void txtCantidad_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCantidad);
        }

        private void btnProducirOrden_Click(object sender, EventArgs e)
        {

        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (AfectarAfectados == "1")
                MostrarPedidoCuerpo("1", 999999999);
            else
                MostrarTTOrdenCargaCuerpo();
            //else
            //    MostrarPedidoCuerpo("2", 0);
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
        private void AfectarOrdenProduccion()
        {
            if (txtNumeroOrden.TextLength > 0)
            {
                lblEstadoOrden.Visible = true;

                using (var hb = new DBdatos())
                {
                    var Consulta = (from OP in hb.Orden_Produccion1
                                    where OP.NumeroOrden == txtNumeroOrden.Text
                                        && OP.Estado_ID != "AN"
                                    select OP).FirstOrDefault();

                    if (Consulta != null)
                    {
                        AsociarOrdenProduccion = "SI";
                        IDRecibido = Consulta.ID;
                        txtNumeroOrden.Text = Consulta.NumeroOrden;
                        lblEstadoOrden.Text = "Orden encontrada";
                        lblEstadoOrden.ForeColor = Color.DarkGreen;
                        txtNumeroOrden.ReadOnly = true;

                        dtpFecha.Value = Consulta.Fecha.Date;
                        dtpFechaLimite.Value = Consulta.Fecha_Limite.Value;

                        if (Consulta.Estado_ID == "AU")
                        {
                            rdbAutorizado.Checked = true;
                            txtEstado.Text = Consulta.Estado_Ord_Carga.Descripcion;
                            txtEstado.ForeColor = Color.Black;
                        }
                        if (Consulta.Estado_ID == "PRO")
                        {
                            rdbEnProceso.Checked = true;
                            txtEstado.Text = Consulta.Estado_Ord_Carga.Descripcion;
                            txtEstado.ForeColor = Color.DarkBlue;
                        }

                        cmbResponsable.SelectedValue = Consulta.Responsable_ID;
                        cmbResponsable.Text = Consulta.Empleados.Nombre;

                        SoundPlayer SonidoAfectacion = new SoundPlayer(@"C:\Program Files (x86)\Pack-Codin\Sound\Afectar.wav");
                        SonidoAfectacion.Play();

                        // QUEDA PENDINENTE LAS OBSERVACIONES

                        dtpFecha.Enabled = false;
                        dtpFechaLimite.Enabled = false;
                        gbxEstadoPedido.Enabled = false;
                        cmbResponsable.Enabled = false;
                        btnBuscarResponsable.Enabled = false;
                    }
                    else
                    {
                        AsociarOrdenProduccion = "NO";
                        txtNumeroOrden.Text = txtNumeroOrden.Text;
                        lblEstadoOrden.Text = "Orden no encontrada";
                        lblEstadoOrden.ForeColor = Color.Red;
                        txtNumeroOrden.ReadOnly = false;

                        dtpFecha.Enabled = true;
                        dtpFechaLimite.Enabled = true;
                        gbxEstadoPedido.Enabled = true;
                        cmbResponsable.Enabled = true;
                        btnBuscarResponsable.Enabled = true;
                    }
                }
            }
        }
        private void btnBuscarOrdenProd_Click(object sender, EventArgs e)
        {
            AfectarOrdenProduccion();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtNumeroOrden.Text = "";
            lblEstadoOrden.Visible = false;
            AsociarOrdenProduccion = "NO";
            txtNumeroOrden.ReadOnly = false;

            dtpFecha.Value = DateTime.Now.Date;
            dtpFechaLimite.Value = DateTime.Now.Date;
            rdbAutorizado.Checked = true;
            cmbResponsable.SelectedIndex = -1;
            txtObservaciones.Text = "";
            txtEstado.Text = "Autorizado";

            dtpFecha.Enabled = true;
            dtpFechaLimite.Enabled = true;
            gbxEstadoPedido.Enabled = true;
            cmbResponsable.Enabled = true;
            btnBuscarResponsable.Enabled = true;

            CalcularNumeroOrdenProduccion();
            CalculaIdOrdenProduccion();


        }

        private void txtNumeroOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AfectarOrdenProduccion();
            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCantidad);
        }

        private void txtCantidad_TextChanged_1(object sender, EventArgs e)
        {
            OnOffbtnEditarCantidad();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnModificarGrilla_Click(object sender, EventArgs e)
        {
            if(AgrandarGrilla == false)
            {
                AgrandarGrilla = true;
                AgrandarDGV();
            }
            else
            {
                AgrandarGrilla = false;
                AchicarDGV();
            }         
        }

        private void gbxFiltros_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscarCliente_Click_1(object sender, EventArgs e)
        {
            txtBuscarCliente.Visible = true;
            txtBuscarCliente.Visible = true;
        }

        private void txtBuscarCliente_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarCliente.Visible = false;
                clsCargarCombos.MostrarComboClientes(cmbFiltraCliente, txtBuscarCliente, true, "CLI", 0);
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

        private void cmbFiltraCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboClientes(cmbFiltraCliente, txtBuscarCliente, false, "CLI",0);
                txtBuscarCliente.Focus();
                e.Handled = true;
            }
        }

        private void btnCargar_Click_1(object sender, EventArgs e)
        {
            CargarOrdenProduccion();
        }

        private void btnInvalidar_Click(object sender, EventArgs e)
        {
            AnularOrden();
        }

        private void txtBuscarResponsable_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscarProducto_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscarCliente_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
