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

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmSeleccionarProducto : Form
    {
        public string ProductoID;
        public string ProductoDescripcion;
        public decimal CantidadParaAfectar;
        decimal CantidadAfectadaAcumulada = 0;
        public long OrdenID;
        public long PedidoID;
        public string CrearEditar;
        string AfectarAfectados = "1";
        public string Estado;
        public string DepositoSeleccionado;
        public frmAgregarOrdenCarga FormOrdenCarga;
        public DataGridView DGV;
        
        public frmSeleccionarProducto()
        {
            InitializeComponent();
        }

        private void frmSeleccionarProducto_Load(object sender, EventArgs e)
        {

            lblCantAfectar.Text = CantidadParaAfectar.ToString();
            lblCantAfectada.Text = CantidadAfectadaAcumulada.ToString("N2");
            lblNumPedido.Text = "P" + PedidoID.ToString();
            lblProducto.Text = ProductoDescripcion + " - " + ProductoID.ToString();
            CalcularCantidadAfecta("1");
            lblDiferencia.Text = (Convert.ToDecimal(lblCantAfectar.Text) - Convert.ToDecimal(lblCantAfectada.Text)).ToString("N2");

            InicializarForm();
        }
        private void InicializarForm() //descomentar
        {
            lblCantAfectar.Text = CantidadParaAfectar.ToString("N2");
            lblCantAfectada.Text = CantidadAfectadaAcumulada.ToString("N2");
            lblNumPedido.Text = "P" + PedidoID.ToString();
            lblNumOrdenCarga.Text = "OC" + OrdenID.ToString();
            lblProducto.Text = ProductoDescripcion + " - " + ProductoID.ToString();

            if (CrearEditar == "1" || CrearEditar == "3")
            {
                using (var hb = new DBdatos())
                {
                    var Consulta = (from VS in hb.Vista_Stock
                                    where VS.Codigo == ProductoID
                                    select VS).FirstOrDefault();

                    if (Consulta.Existencia >= CantidadParaAfectar)
                        CalcularCantidadAfecta("1");
                    else
                    {
                        MessageBox.Show("La existencia del producto " + Consulta.DescripcionProducto + " - " + Consulta.Codigo + " es menor a la cantidad solicitada", "Atención");
                        this.Close();
                    }
                }
            }
            if (CrearEditar == "2")
            {
                btnAfectar.Enabled = false;
                CalcularCantidadAfecta("2");
                btnDesafectar.Enabled = false;
            }
        }
        private void InsertarDatosEnTablaTemporal()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from EPT in hb.Existencia_ProductoTerminado
                                where EPT.Cantidad_Utiliz != EPT.Cantidad
                                        && EPT.Produto_ID == ProductoID
                                        && EPT.Movimiento_ID != "AJUNE"
                                select EPT);

                var Resultados = Consulta.ToList();

                foreach (var item in Resultados)
                {
                    var ConsultaTT = (from TTEPT in hb.TT_Existencia_ProductoTerminado
                                      where TTEPT.Movimiento_ID != "AJUNE"
                                            //&& TTEPT.Movimiento_ID != "AJUPO"
                                            && TTEPT.IDaModificar == item.ID
                                      select TTEPT);

                    var ResultadosTT = ConsultaTT.FirstOrDefault();

                    if (ResultadosTT == null)
                    {
                        var i = new TT_Existencia_ProductoTerminado();

                        i.IDaModificar = item.ID;
                        i.Producto_ID = item.Produto_ID;
                        i.Movimiento_ID = item.Movimiento_ID;
                        i.Medida_ID = (int)item.Medida_ID;
                        i.Retencion = item.Retencion;
                        i.Ficha = item.Ficha;
                        i.Fecha = item.Fecha;
                        i.Deposito = item.Deposito;
                        i.Observaciones = item.Observaciones;
                        i.Empleado_ID = (int)item.Empleado_ID;
                        i.Cantidad = (decimal)(item.Cantidad - item.Cantidad_Utiliz);
                        i.Cantidad_Afec = 0;
                        i.IDaModificar = item.ID;

                        hb.TT_Existencia_ProductoTerminado.Add(i);
                        hb.SaveChanges();
                    }
                }
            }
        }
        private void DeleteTablaTemporal()
        {
            //using (var hb = new DBdatos())
            //{
            //    var Consulta = (from TTEPT in hb.TT_Existencia_ProductoTerminado
            //                    where TTEPT.Pedido_ID == PedidoID
            //                        && TTEPT.Producto_ID == ProductoID
            //                    select TTEPT).ToList();

            //    hb.TT_Existencia_ProductoTerminado.RemoveRange(Consulta);
            //    hb.SaveChanges();
            //}
        }
        private void MostrarDatos(string AfectaAfectados)
        {
            using (var hb = new DBdatos())
            {
                if (CrearEditar == "1" || CrearEditar == "3")
                {
                    //var Consulta = (from TTEPT in hb.TT_Existencia_ProductoTerminado
                    //                where TTEPT.Deposito == DepositoSeleccionado
                    //                && TTEPT.Cantidad > 0
                    //                && TTEPT.Producto_ID == ProductoID
                    //                orderby TTEPT.Fecha, TTEPT.IDaModificar
                    //                select new
                    //                {
                    //                    TTEPT.ID,
                    //                    TTEPT.Producto_ID,
                    //                    TTEPT.Movimiento_ID,
                    //                    Movimiento = TTEPT.Movimientos_Produccion.Descripcion,
                    //                    Producto = TTEPT.Productos_Insumos.Descripcion,
                    //                    TTEPT.Fecha,
                    //                    TTEPT.Medida_ID,
                    //                    Medida = TTEPT.Medidas_Producto.Descripcion,
                    //                    TTEPT.Empleado_ID,
                    //                    Empleado = TTEPT.Empleados.Nombre,
                    //                    Cantidad = TTEPT.Cantidad,
                    //                    TTEPT.Ficha,
                    //                    TTEPT.Retencion,
                    //                    TTEPT.IDaModificar,
                    //                    TTEPT.Cantidad_Afec,
                    //                    TTEPT.Productos_Insumos.Categoria_ID,
                    //                    TTEPT.Pedido_ID,
                    //                    TTEPT.Deposito,
                    //                    TTEPT.Observaciones
                    //                });




                    //CONSULTA ORIGINAL
                    var Consulta = (from TTEPT in hb.TT_Existencia_ProductoTerminado
                                    where TTEPT.Producto_ID == ProductoID
                                        && TTEPT.Usuario_ID == clsVariablesGenerales.UsuarioID
                                        && TTEPT.Sesion_ID == clsVariablesGenerales.SesionID
                                        && TTEPT.Cantidad > 0
                                    orderby TTEPT.Deposito, TTEPT.Fecha, TTEPT.IDaModificar
                                    select new
                                    {
                                        TTEPT.ID,
                                        TTEPT.Producto_ID,
                                        TTEPT.Movimiento_ID,
                                        Movimiento = TTEPT.Movimientos_Produccion.Descripcion,
                                        Producto = TTEPT.Productos_Insumos.Descripcion,
                                        TTEPT.Fecha,
                                        TTEPT.Medida_ID,
                                        Medida = TTEPT.Medidas_Producto.Descripcion,
                                        TTEPT.Empleado_ID,
                                        Empleado = TTEPT.Empleados.Nombre,
                                        Cantidad = TTEPT.Cantidad,
                                        TTEPT.Ficha,
                                        TTEPT.Retencion,
                                        TTEPT.IDaModificar,
                                        TTEPT.Cantidad_Afec,
                                        TTEPT.Productos_Insumos.Categoria_ID,
                                        TTEPT.Pedido_ID,
                                        TTEPT.Deposito,
                                        TTEPT.Observaciones
                                    });

                    var Resultados = Consulta.ToList();

                    if (AfectaAfectados == "1")
                    {
                        Consulta = (from C in Consulta
                                    where C.Cantidad > 0
                                    orderby C.Fecha, C.IDaModificar
                                    select C);

                        

                        colID.DataPropertyName = "ID";
                        colProductoDescrip.DataPropertyName = "Producto";
                        colFecha.DataPropertyName = "Fecha";
                        colMovimiento.DataPropertyName = "Movimiento";
                        colProductoDescrip.DataPropertyName = "Producto";
                        colCantidad.DataPropertyName = "Cantidad";                    
                        colMedida.DataPropertyName = "Medida";
                        colDeposito.DataPropertyName = "Deposito";
                        colRetencion.DataPropertyName = "Retencion";
                        colFicha.DataPropertyName = "Ficha";
                        colIDModificar.DataPropertyName = "IDaModificar";
                        colEmpleado.DataPropertyName = "Empleado";
                        colObservaciones.DataPropertyName = "Observaciones";
                        colDeposito.DataPropertyName = "Deposito";

                        lblResultados.Text = Resultados.Count.ToString();

                        dgvPedidoProductos.AutoGenerateColumns = false;
                        dgvPedidoProductos.DataSource = Resultados;
                    }
                    if (AfectaAfectados == "2")
                    {
                        var ConsultaTTAFEC = (from TTEPT in hb.TT_Existencia_ProductoTerminado
                                              join TTAFEC in hb.TT_Prodocuto_Afec_OrdenCarga on TTEPT.IDaModificar equals TTAFEC.ExitenciaProTer_ID
                                              where TTAFEC.Pedido_ID == PedidoID
                                                    && TTEPT.Producto_ID == ProductoID
                                                    && TTEPT.Cantidad_Afec > 0
                                                    && TTEPT.Usuario_ID == clsVariablesGenerales.UsuarioID
                                                    && TTEPT.Sesion_ID == clsVariablesGenerales.SesionID
                                                    && TTAFEC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                                    && TTAFEC.Sesion_ID == clsVariablesGenerales.SesionID
                                              select new
                                              {
                                                  TTEPT.ID,
                                                  TTEPT.Producto_ID,
                                                  TTEPT.Movimiento_ID,
                                                  Movimiento = TTEPT.Movimientos_Produccion.Descripcion,
                                                  Producto = TTEPT.Productos_Insumos.Descripcion,
                                                  TTEPT.Fecha,
                                                  TTEPT.Medida_ID,
                                                  Medida = TTEPT.Medidas_Producto.Descripcion,
                                                  TTEPT.Empleado_ID,
                                                  Empleado = TTEPT.Empleados.Nombre,
                                                  Cantidad = TTAFEC.Cantidad,
                                                  TTEPT.Ficha,
                                                  TTEPT.Retencion,
                                                  TTEPT.IDaModificar,
                                                  TTEPT.Cantidad_Afec,
                                                  TTEPT.Productos_Insumos.Categoria_ID,
                                                  TTEPT.Pedido_ID,
                                                  TTEPT.Observaciones,
                                                  TTEPT.Deposito,
                                                  TTEPT.Lote
                                              });

                        var ResultadosTTAFEC = ConsultaTTAFEC.ToList();

                        colID.DataPropertyName = "ID";
                        colProductoDescrip.DataPropertyName = "Producto";                     
                        colFecha.DataPropertyName = "Fecha";
                        colMovimiento.DataPropertyName = "Movimiento";
                        colProductoDescrip.DataPropertyName = "Producto";                      
                        colCantidad.DataPropertyName = "Cantidad";                  
                        colMedida.DataPropertyName = "Medida";
                        colRetencion.DataPropertyName = "Retencion";
                        colFicha.DataPropertyName = "Ficha";
                        colIDModificar.DataPropertyName = "IDaModificar";                      
                        colEmpleado.DataPropertyName = "Empleado";
                        colObservaciones.DataPropertyName = "Observaciones";
                        colDeposito.DataPropertyName = "Deposito";
                        colLote.DataPropertyName = "Lote";

                        lblResultados.Text = ResultadosTTAFEC.Count.ToString();

                        dgvPedidoProductos.AutoGenerateColumns = false;
                        dgvPedidoProductos.DataSource = ResultadosTTAFEC;
                        //Consulta = (from C in Consulta
                        //            join TTAFEC in hb.TT_Prodocuto_Afec_OrdenCarga on C.IDaModificar equals TTAFEC.ExitenciaProTer_ID
                        //            where C.Cantidad_Afec > 0
                        //                && TTAFEC.Pedido_ID == PedidoID
                        //            orderby C.Fecha, C.IDaModificar
                        //            select new
                        //            {


                        //            });
                    }

                    if(chkFiltraProduccion.Checked && txtFiltraProduccion.TextLength > 0)
                    {
                        long Produccion = Convert.ToInt64(txtFiltraProduccion.Text);

                        Consulta = (from C in Consulta
                                         where C.IDaModificar == Produccion
                                         select C);
                    }
                    if(chkFiltraMovimiento.Checked)
                    {
                        Consulta = (from C in Consulta
                                    where C.Movimiento_ID == cmbFiltraMovimiento.SelectedValue.ToString()
                                    select C);
                    }
                    if (chkFiltraFicha.Checked)
                    {
                        Consulta = (from C in Consulta
                                    where C.Ficha == cmbFiltraFicha.Text
                                    select C);
                    }
                    if (chkFiltraRetencion.Checked)
                    {
                        Consulta = (from C in Consulta
                                    where C.Ficha == cmbFiltraRetencion.Text
                                    select C);
                    }

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
                   // var Resultados = Consulta.ToList();

                    //colID.DataPropertyName = "ID";
                    //colProductoDescrip.DataPropertyName = "Producto";

                    
                    //colFecha.DataPropertyName = "Fecha";
                    //colMovimiento.DataPropertyName = "Movimiento";
                    //colProductoDescrip.DataPropertyName = "Producto";
                  
                    //    colCantidad.DataPropertyName = "Cantidad";
                 
                    //colMedida.DataPropertyName = "Medida";
                    //colRetencion.DataPropertyName = "Retencion";
                    //colFicha.DataPropertyName = "Ficha";
                    //colIDModificar.DataPropertyName = "IDaModificar";
                    
                    //colEmpleado.DataPropertyName = "Empleado";
                    //colObservaciones.DataPropertyName = "Observaciones";

                    //txtCantidadResultados.Text = Resultados.Count.ToString();

                    //dgvPedidoProductos.AutoGenerateColumns = false;
                    //dgvPedidoProductos.DataSource = Resultados;
                }
                else
                {
                    var Consulta = (from EPT in hb.Existencia_ProductoTerminado
                                    join AFEC in hb.Producto_Afec_OrdenCarga on EPT.ID equals AFEC.ExitenciaProTer_ID
                                    where AFEC.Pedido_ID == PedidoID
                                        && AFEC.Orden_ID == OrdenID 
                                        && AFEC.Producto_ID == ProductoID
                                    orderby EPT.Fecha, EPT.ID
                                    select new
                                    {
                                        EPT.ID,
                                        EPT.Produto_ID,
                                        EPT.Movimiento_ID,
                                        Movimiento = EPT.Movimientos_Produccion.Descripcion,
                                        Producto = EPT.Productos_Insumos.Descripcion,
                                        EPT.Fecha,
                                        EPT.Medida_ID,
                                        Medida = EPT.Medidas_Producto.Descripcion,
                                        EPT.Empleado_ID,
                                        Empleado = EPT.Empleados.Nombre,
                                        Cantidad = EPT.Cantidad,
                                        EPT.Cantidad_Utiliz,
                                        EPT.Ficha,
                                        EPT.Retencion,
                                        CantidadAfectada = AFEC.Cantidad,
                                        // TTEPT.IDaModificar,
                                        //EMP.Cantidad_Disp,
                                        //EPT.Cantidad_Utiliz,
                                        EPT.Productos_Insumos.Categoria_ID,
                                        //TTEPT.Pedido_ID,
                                        EPT.Observaciones
                                    });

                    //if (AfectaAfectados == "1")
                    //{
                    //    Consulta = (from C in Consulta
                    //                where C.Cantidad > 0
                    //                orderby C.Fecha, C.ID
                    //                select C);
                    //}
                    //if (AfectaAfectados == "2")
                    //{
                    //    Consulta = (from C in Consulta
                    //                join AFEC in hb.Producto_Afec_OrdenCarga on C.ID equals AFEC.ExitenciaProTer_ID
                    //                where C.Cantidad_Utiliz > 0
                    //                    && AFEC.Pedido_ID == PedidoID
                    //                    && AFEC.Orden_ID == OrdenID
                    //                orderby C.Fecha, C.ID
                    //                select C);
                    //}
                    if (chkFiltraProduccion.Checked)
                    {
                        long Produccion = Convert.ToInt64(txtFiltraProduccion.Text);

                        Consulta = (from C in Consulta
                                    where C.ID == Produccion
                                    select C);
                    }
                    if (chkFiltraMovimiento.Checked)
                    {
                        Consulta = (from C in Consulta
                                    where C.Movimiento_ID == cmbFiltraMovimiento.SelectedValue.ToString()
                                    select C);
                    }
                    if (chkFiltraFicha.Checked)
                    {
                        Consulta = (from C in Consulta
                                    where C.Ficha == cmbFiltraFicha.Text
                                    select C);
                    }
                    if (chkFiltraRetencion.Checked)
                    {
                        Consulta = (from C in Consulta
                                    where C.Ficha == cmbFiltraRetencion.Text
                                    select C);
                    }

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
                    colProductoDescrip.DataPropertyName = "Producto";

                    colIDModificar.DataPropertyName = "ID";
                    colFecha.DataPropertyName = "Fecha";
                    colMovimiento.DataPropertyName = "Movimiento";
                    colProductoDescrip.DataPropertyName = "Producto";
                    colCantidad.DataPropertyName = "CantidadAfectada";
                    colMedida.DataPropertyName = "Medida";
                    colRetencion.DataPropertyName = "Retencion";
                    colFicha.DataPropertyName = "Ficha";
                    //colEstado.DataPropertyName = "Estado";
                    colEmpleado.DataPropertyName = "Empleado";
                    colObservaciones.DataPropertyName = "Observaciones";

                    lblResultados.Text = Resultados.Count.ToString();

                    dgvPedidoProductos.AutoGenerateColumns = false;
                    dgvPedidoProductos.DataSource = Resultados;
                }
            }
        }
        private void CalcularCantidadAfecta(string CrearEditar)
        {
            using (var hb = new DBdatos())
            {
                if (CrearEditar == "1" || CrearEditar == "3") 
                {
                    var Consulta = (from TTAFEC in hb.TT_Prodocuto_Afec_OrdenCarga
                                    where TTAFEC.Pedido_ID == PedidoID
                                        && TTAFEC.Orden_ID == OrdenID
                                        && TTAFEC.Producto_ID == ProductoID
                                        && TTAFEC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                        && TTAFEC.Sesion_ID == clsVariablesGenerales.SesionID
                                    group TTAFEC by new { TTAFEC.Pedido_ID } into Grupo
                                    select new
                                    {
                                        Cantidad = Grupo.Sum(x => x.Cantidad)
                                    });

                    var Resultados = Consulta.FirstOrDefault();

                    if (Resultados == null)
                    {
                        lblCantAfectada.Text = "0";
                    }
                    else
                    {
                        lblCantAfectada.Text = Resultados.Cantidad.ToString();
                    }
                }
                else
                {
                    var Consulta = (from AFEC in hb.Producto_Afec_OrdenCarga
                                    where AFEC.Pedido_ID == PedidoID
                                        && AFEC.Orden_ID  == OrdenID
                                        && AFEC.Producto_ID == ProductoID
                                    group AFEC by new { AFEC.Pedido_ID , AFEC.Orden_ID , AFEC.Producto_ID} into Grupo
                                    select new
                                    {
                                        Cantidad = Grupo.Sum(x => x.Cantidad)
                                    });

                    var Resultados = Consulta.FirstOrDefault();

                    if (Resultados == null)
                    {
                        lblCantAfectada.Text = "0";
                    }
                    else
                    {
                        lblCantAfectada.Text = Resultados.Cantidad.ToString();
                    }
                }
            }
        }
        private void MostrarCantidades()
        {
            if(dgvPedidoProductos.RowCount > 0)
            {
                decimal Cantidad = (decimal)dgvPedidoProductos.CurrentRow.Cells["colCantidad"].Value;

                txtCantidad.Text = Cantidad.ToString();
            }
        }
        private void Afectar()
        {
            using (var hb = new DBdatos())
            {
                CantidadAfectadaAcumulada = Convert.ToDecimal(lblCantAfectada.Text);
                // Extrae el codigo ID de la tabla TT_EPT
                long Exitencia_ID = (long)dgvPedidoProductos.CurrentRow.Cells[0].Value;

                var Consulta = (from TTEPT in hb.TT_Existencia_ProductoTerminado
                                where TTEPT.ID == Exitencia_ID
                                && TTEPT.Usuario_ID == clsVariablesGenerales.UsuarioID
                                && TTEPT.Sesion_ID == clsVariablesGenerales.SesionID
                                select TTEPT);

                var Resultados = Consulta.FirstOrDefault();

                if(Resultados != null)
                {                    
                    if (Convert.ToDecimal(txtCantidad.Text) <= Convert.ToDecimal(lblCantAfectar.Text) && (CantidadAfectadaAcumulada + Convert.ToDecimal(txtCantidad.Text) <= Convert.ToDecimal(lblCantAfectar.Text)))
                    {
                        Resultados.Cantidad = Resultados.Cantidad - Convert.ToDecimal(txtCantidad.Text);
                        Resultados.Cantidad_Afec = Resultados.Cantidad_Afec + Convert.ToDecimal(txtCantidad.Text);
                        //Resultados.Pedido_ID = PedidoID;                       
                        CantidadAfectadaAcumulada = CantidadAfectadaAcumulada + Convert.ToDecimal(txtCantidad.Text); // subir arriba

                        // Este ahora es el ID de la tabla original RPT
                        Exitencia_ID = (long)dgvPedidoProductos.CurrentRow.Cells[1].Value;
                        //Ajustamos las cantidades provisorias en la TT_Producto_afec_OrdenCarga
                        var ConsultaTTAFEC = (from TTAFEC in hb.TT_Prodocuto_Afec_OrdenCarga
                                              where TTAFEC.Pedido_ID == PedidoID
                                                && TTAFEC.Orden_ID == OrdenID
                                                && TTAFEC.Producto_ID == ProductoID
                                                && TTAFEC.ExitenciaProTer_ID == Exitencia_ID
                                                && TTAFEC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                                && TTAFEC.Sesion_ID == clsVariablesGenerales.SesionID
                                              select TTAFEC);

                        var ResultadosTTAFEC = ConsultaTTAFEC.FirstOrDefault();

                        if (ResultadosTTAFEC == null)
                        {
                            var i = new TT_Prodocuto_Afec_OrdenCarga();

                            i.ExitenciaProTer_ID = (long?)dgvPedidoProductos.CurrentRow.Cells[1].Value;
                            i.Pedido_ID = PedidoID;
                            i.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                            i.Producto_ID = ProductoID;
                            i.Orden_ID = OrdenID;
                            i.Usuario_ID = clsVariablesGenerales.UsuarioID;
                            i.Sesion_ID = clsVariablesGenerales.SesionID;

                            hb.TT_Prodocuto_Afec_OrdenCarga.Add(i);

                            CambiarColorbtnSeleccionado(btnAfectados, btnAfectar);
                        }
                        else
                        {
                            ResultadosTTAFEC.ExitenciaProTer_ID = (long?)dgvPedidoProductos.CurrentRow.Cells[1].Value;
                            ResultadosTTAFEC.Pedido_ID = PedidoID;
                            ResultadosTTAFEC.Cantidad = ResultadosTTAFEC.Cantidad + Convert.ToDecimal(txtCantidad.Text);
                            ResultadosTTAFEC.Producto_ID = ProductoID;
                            ResultadosTTAFEC.Orden_ID = OrdenID;
                            CambiarColorbtnSeleccionado(btnAfectados, btnAfectar);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La cantidad afectada debe ser " + lblCantAfectar.Text);
                        return;
                    }
                }
                lblCantAfectada.Text = CantidadAfectadaAcumulada.ToString("N2");
                hb.SaveChanges();
                MostrarDatos("2");
                AfectarAfectados = "2";
                btnEditar.Visible = false;
                lblDiferencia.Text = (Convert.ToDecimal(lblCantAfectar.Text) - Convert.ToDecimal(lblCantAfectada.Text)).ToString("N2");
                MostrarOpciones();
            }
        }
        private void Desafectar()
        {
            CantidadAfectadaAcumulada = Convert.ToDecimal(lblCantAfectada.Text);

            using (var hb = new DBdatos())
            {
                long ID = (long)dgvPedidoProductos.CurrentRow.Cells[0].Value;

                var Consulta = (from TTEPT in hb.TT_Existencia_ProductoTerminado
                                where TTEPT.ID == ID
                                    && TTEPT.Usuario_ID == clsVariablesGenerales.UsuarioID
                                    && TTEPT.Sesion_ID == clsVariablesGenerales.SesionID
                                select TTEPT);

                var Resultados = Consulta.FirstOrDefault();

                if (Resultados != null)
                {
                    long Exitencia_ID = (long)dgvPedidoProductos.CurrentRow.Cells[1].Value;
                    //decimal Cantidad = Resultados.Cantidad;
                    decimal CantidadAfec = Resultados.Cantidad_Afec; // guarda el valor de la cantidad afec antes que se modifique abajo, ya que al modif cambia el valor y rompe calculos

                    Resultados.Cantidad = Resultados.Cantidad + Resultados.Cantidad_Afec;

                    CantidadAfectadaAcumulada = CantidadAfectadaAcumulada - Resultados.Cantidad_Afec;
                    if (CantidadAfectadaAcumulada < 0)
                        CantidadAfectadaAcumulada = 0;
                    Resultados.Cantidad_Afec = Resultados.Cantidad_Afec - CantidadAfec;
                   
                    var ConsultaTTAFEC = (from TTAFEC in hb.TT_Prodocuto_Afec_OrdenCarga
                                          where TTAFEC.Pedido_ID == PedidoID
                                            && TTAFEC.Orden_ID == OrdenID
                                            && TTAFEC.Producto_ID == ProductoID
                                            && TTAFEC.ExitenciaProTer_ID == Exitencia_ID
                                            && TTAFEC.Usuario_ID == clsVariablesGenerales.UsuarioID
                                            && TTAFEC.Sesion_ID == clsVariablesGenerales.SesionID
                                          select TTAFEC).FirstOrDefault();

                    hb.TT_Prodocuto_Afec_OrdenCarga.Remove(ConsultaTTAFEC);
                    hb.SaveChanges();
                    lblCantAfectada.Text = CantidadAfectadaAcumulada.ToString("N2");
                    MostrarDatos("2");
                    lblDiferencia.Text = (Convert.ToDecimal(lblCantAfectar.Text) - Convert.ToDecimal(lblCantAfectada.Text)).ToString("N2");
                }
            }
        }
        private void MostrarOpciones()
        {
            if(AfectarAfectados == "1")
            {
                btnAfecComp.Visible = true;
                btnDesafectar.Visible = false;
            }
            if(AfectarAfectados == "2")
            {
                btnAfecComp.Visible = false;
                btnDesafectar.Visible = true;
            }

        }
        private void CargarProductos()
        {
            if(lblCantAfectada.Text == lblCantAfectar.Text)
            {
                using (var hb = new DBdatos())
                {
                    //var ConsultaTT = (from TTEPT in hb.TT_Prodocuto_Afec_OrdenCarga
                    //                  //where TTEPT.Pedido_ID == 
                    //                  select TTEPT);

                    //var ResultadosTT = ConsultaTT.ToList();

                    //foreach (var item in ResultadosTT)
                    //{
                    //    //var ConsultaEPT = (from EPT in hb.Existencia_ProductoTerminado
                    //    //                   where EPT.ID == item.IDaModificar
                    //    //                   select EPT);

                    //    //var ResultadosEPT = ConsultaEPT.FirstOrDefault();

                    //    //if (ResultadosEPT != null)
                    //    //{
                    //    //    ResultadosEPT.Cantidad_Utiliz = item.Cantidad_Afec;
                    //    //}
                    //}

                    var Consulta = (from TTEPT in hb.TT_Existencia_ProductoTerminado
                                    where TTEPT.Producto_ID == ProductoID
                                        && TTEPT.Cantidad_Afec > 0
                                        && TTEPT.Pedido_ID == PedidoID
                                    select TTEPT);

                    var Resultados = Consulta.ToList();

                    foreach (var item in Resultados)
                    {
                        var i = new TT_Prodocuto_Afec_OrdenCarga();

                        i.ExitenciaProTer_ID = item.Existencia_ProductoTerminado.ID;
                        i.Pedido_ID = (long)item.Pedido_ID;
                        i.Cantidad = item.Cantidad_Afec;
                        i.Producto_ID = item.Producto_ID;

                        hb.TT_Prodocuto_Afec_OrdenCarga.Add(i);
                        hb.SaveChanges();
                    }
                    hb.SaveChanges();
                    MessageBox.Show("Datos cargados correctamente", "Atención");
                }
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Afectar();
        }
        private void FormatearCeldas()
        {
            if(dgvPedidoProductos.RowCount > 0)
            {
                string DepositoActual = dgvPedidoProductos.Rows[0].Cells["colDeposito"].Value.ToString();
                string DepositoSeleccionado = "";
                string ColorRow = "Khaki";

                for(int i = 0; i< dgvPedidoProductos.RowCount; i++)
                {
                    DepositoSeleccionado = dgvPedidoProductos.Rows[i].Cells["colDeposito"].Value.ToString();
                    if (DepositoActual == DepositoSeleccionado)
                    {
                        dgvPedidoProductos.Rows[i].DefaultCellStyle.BackColor = Color.FromName(ColorRow);
                        dgvPedidoProductos.Rows[i].DefaultCellStyle.BackColor = Color.FromName("PaleGoldenrod");
                    }
                    else
                    {
                        if (ColorRow == "Khaki")
                            ColorRow = "White";
                        else
                            ColorRow = "Khaki";

                        DepositoActual = dgvPedidoProductos.Rows[i].Cells["colDeposito"].Value.ToString();
                        dgvPedidoProductos.Rows[i].DefaultCellStyle.BackColor = Color.FromName(ColorRow);
                    }                   
                }
            }
        }
        private void btnAfectar_Click(object sender, EventArgs e)
        {
            //DeleteTablaTemporal();
            //InsertarDatosEnTablaTemporal();
            AfectarAfectados = "1";
            MostrarDatos("1");
            CambiarColorbtnSeleccionado(btnAfectar, btnAfectados);
            //btnEditar.Enabled = true;
            //btnEditar.Visible = true;
            MostrarOpciones();
            FormatearCeldas();
        }

        private void btnAfectados_Click(object sender, EventArgs e)
        {
            //DeleteTablaTemporal();
            //InsertarDatosEnTablaTemporal();
            AfectarAfectados = "2";
            MostrarDatos("2");
            CambiarColorbtnSeleccionado(btnAfectados, btnAfectar);
            btnEditar.Visible = false;
            MostrarOpciones();
        }

        private void frmSeleccionarProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
           // DeleteTablaTemporal();
        }
        private void CambiarColorbtnSeleccionado(/*string Pulso,*/ Button btnActivo, Button btnInactivo) //, ToolStripMenuItem btnAfeAfectados)
        {
            //string AfectarAfectados = Pulso;
            btnActivo.BackColor = Color.DarkOrange;
            btnInactivo.BackColor = Color.White;

            //if (Pulso == "1")
            //{
            //    btnAfectar.Visible = true;
            //    btnAfectados.Visible = false;
            //}
            //if (Pulso == "2")
            //{
            //    btnAfectar.Visible = false;
            //    btnAfectados.Visible = true;
            //}
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            //  CargarProductos();
            this.Close();
        }

        private void dgvPedidoProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarCantidades();
            if (dgvPedidoProductos.RowCount > 0)
            {
                if (AfectarAfectados == "1")
                    btnEditar.Visible = true;
                else
                    btnEditar.Visible = false;
            }
        }

        private void btnDesafectar_Click(object sender, EventArgs e)
        {
            Desafectar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //if(Convert.ToDecimal(txtCantAfectada.Text) == Convert.ToDecimal(txtCantAfectar.Text))
            //{
            //    FormOrdenCarga.dgvPedidoProductos.CurrentRow.Cells["colEstado"].Value = "Completo";
            //}
            this.Close();
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }

        private void txtCantidad_Click(object sender, EventArgs e)
        {
            txtCantidad.SelectAll();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //for (var i = 0; i < dgvPedidoProductos.RowCount; i++)
            //{
            //    if(chkFiltraProduccion.Checked)
            //    {
            //        if ((long)dgvPedidoProductos.Rows[i - 1].Cells[2].Value == Convert.ToInt64(txtFiltraProduccion.Text)) 
            //        {
            //            dgvPedidoProductos.Rows[i - 1].Selected = true;
            //        }
            //    }
            //}
        }
        private void MostrarEstadoDeFiltros()
        {
            if (chkFiltraProduccion.Checked ||
                chkFiltraMovimiento.Checked ||
                chkFiltraFicha.Checked ||
                chkFiltraRetencion.Checked ||
                chkFechaDesde.Checked ||
                chkFechaHasta.Checked)

            {
                picFiltroActivo.Visible = true;
                picFiltroInactivo.Visible = false;
            }
            else
            {
                picFiltroActivo.Visible = false;
                picFiltroInactivo.Visible = true;
            }

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //for (var i = 1; i <= dgvPedidoProductos.RowCount; i++)
            //{
            //    if (chkFiltraProduccion.Checked)
            //    {
            //        if ((long)dgvPedidoProductos.Rows[i - 1].Cells[2].Value == Convert.ToInt64(txtFiltraProduccion.Text))
            //        {
            //            dgvPedidoProductos.Rows[i - 1].Selected = true;
            //        }
            //    }
            //}
            if(AfectarAfectados == "1")
            {
                MostrarDatos("1");
            }
            if (AfectarAfectados == "2")
            {
                MostrarDatos("2");
            }

            MostrarEstadoDeFiltros();
        }

        private void chkFiltraProduccion_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraProduccion, chkFiltraProduccion);
        }

        private void chkFiltraMovimiento_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraMovimiento, cmbFiltraMovimiento);
            clsCargarCombos.MostrarCombomMovProduccion(cmbFiltraMovimiento,"PRO");
        }

        private void gbxFiltros_Enter(object sender, EventArgs e)
        {

        }

        private void chkFechaDesde_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDtpFecha(chkFechaDesde, dtpFechaDesde);
        }

        private void chkFechaHasta_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDtpFecha(chkFechaHasta, dtpFechaHasta);
        }

        private void chkFiltraRetencion_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraRetencion, cmbFiltraRetencion);
        }

        private void chkFiltraFicha_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraFicha, cmbFiltraFicha);
        }

        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCantidad);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Reutilizables.ExportarExcel(dgvPedidoProductos);
        }

        private void btnAfecComp_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCantidad);
        }

        private void dgvPedidoProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvPedidoProductos.Columns[e.ColumnIndex].Name == "colCantidad")
            {
                e.CellStyle.Font = new Font("Roboto Condensed", 10, FontStyle.Bold);
            }
        }
    }
}
